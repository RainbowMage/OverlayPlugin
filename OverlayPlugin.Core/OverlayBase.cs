using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    public abstract class OverlayBase<TConfig> : IOverlay
        where TConfig: OverlayConfigBase
    {
        public event EventHandler<LogEventArgs> OnLog;
        private KeyboardHook hook = new KeyboardHook();

        protected System.Timers.Timer timer;

        public string Name { get; private set; }
        public OverlayForm Overlay { get; private set; }

        public TConfig Config { get; private set; }

        protected OverlayBase(TConfig config, string name)
        {
            this.Config = config;
            this.Name = name;

            InitializeOverlay();
            InitializeTimer();
            InitializeConfigHandlers();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        protected virtual void InitializeOverlay()
        {
            try
            {
                this.Overlay = new OverlayForm("about:blank", this.Config.MaxFrameRate);
                if (this.Config.GlobalHotkeyEnabled)
                {
                    var modifierKeys = GetModifierKey(this.Config.GlobalHotkeyModifiers);
                    var key = this.Config.GlobalHotkey;
                    if (key != Keys.None)
                    {
                        hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(Overlay_OnHotkeyPressed);
                        hook.RegisterHotKey(modifierKeys, key);
                    }
                }

                // 画面外にウィンドウがある場合は、初期表示位置をシステムに設定させる
                if (!Util.IsOnScreen(this.Overlay))
                {
                    this.Overlay.StartPosition = FormStartPosition.WindowsDefaultLocation;
                }
                else
                {
                    this.Overlay.Location = this.Config.Position;
                }
                this.Overlay.Text = this.Name;
                this.Overlay.Size = this.Config.Size;
                this.Overlay.IsClickThru = this.Config.IsClickThru;
                this.Overlay.Renderer.BrowserError += (o, e) =>
                {
                    Log(LogLevel.Error, "BrowserError: {0}, {1}, {2}", e.ErrorCode, e.ErrorText, e.Url);
                };
                this.Overlay.Renderer.BrowserLoad += (o, e) =>
                {
                    Log(LogLevel.Debug, "BrowserLoad: {0}: {1}", e.HttpStatusCode, e.Url);
                };
                this.Overlay.Renderer.BrowserConsoleLog += (o, e) =>
                {
                    Log(LogLevel.Info, "BrowserConsole: {0} (Source: {1}, Line: {2})", e.Message, e.Source, e.Line);
                };
                this.Config.UrlChanged += (o, e) =>
                {
                    Navigate(e.NewUrl);
                };

                Navigate(this.Config.Url);

                this.Overlay.Show();

                this.Overlay.Visible = this.Config.IsVisible;
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "InitializeOverlay: {0}", this.Name, ex);
            }
        }

        private ModifierKeys GetModifierKey(Keys Modifier)
        {
            ModifierKeys modifiers = new ModifierKeys();
            if ((Modifier & Keys.Shift) == Keys.Shift)
            {
                modifiers |= ModifierKeys.Shift;
            }
            if ((Modifier & Keys.Control) == Keys.Control)
            {
                modifiers |= ModifierKeys.Control;
            }
            if ((Modifier & Keys.Alt) == Keys.Alt)
            {
                modifiers |= ModifierKeys.Alt;
            }
            if ((Modifier & Keys.LWin) == Keys.LWin || (Modifier & Keys.RWin) == Keys.RWin)
            {
                modifiers |= ModifierKeys.Win;
            }
            return modifiers;
        }

        void Overlay_OnHotkeyPressed(object sender, KeyPressedEventArgs e)
        {
            this.Config.IsVisible = !this.Config.IsVisible;
        }

        private bool CheckUrl(string url)
        {
            try
            {
                var uri = new System.Uri(url);

                // ローカルファイルの場合はファイルが存在するかチェックし、存在しなければ警告を出力
                if (uri.Scheme == "file")
                {
                    if (!File.Exists(uri.LocalPath))
                    {
                        Log(LogLevel.Warning,
                            "InitializeOverlay: Local file {0} does not exist!",
                            uri.LocalPath);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // URL パースエラー
                Log(LogLevel.Error,
                    "InitializeOverlay: URI parse error! Please reconfigure the URL. (Config.Url = {0}): {1}",
                    this.Config.Url,
                    ex);
                return false;
            }

            return true;
        }

        protected virtual void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (o, e) =>
            {
                try
                {
                    Update();
                }
                catch (Exception ex)
                {
                    Log(LogLevel.Error, "Update: {0}", ex.ToString());
                }
            };
        }

        protected virtual void InitializeConfigHandlers()
        {
            this.Config.VisibleChanged += (o, e) =>
            {
                this.Overlay.Visible = e.IsVisible;
            };

            this.Config.ClickThruChanged += (o, e) =>
            {
                this.Overlay.IsClickThru = e.IsClickThru;
            };
        }

        protected abstract void Update();

        public void Dispose()
        {
            try
            {
                timer.Stop();
                this.Overlay.Close();
                this.Overlay.Dispose();
                hook.Dispose();
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "Dispose: {0}", ex);
            }
        }

        public virtual void Navigate(string url)
        {
            if (this.Overlay.Url != url)
            {
                this.Overlay.Url = url;
            }
            else
            {
                this.Overlay.Reload();
            }
        }

        protected void Log(LogLevel level, string message)
        {
            if (OnLog != null)
            {
                OnLog(this, new LogEventArgs(level, string.Format("{0}: {1}", this.Name, message)));
            }
        }

        protected void Log(LogLevel level, string format, params object[] args)
        {
            Log(level, string.Format(format, args));
        }


        public void SavePositionAndSize()
        {
            this.Config.Position = this.Overlay.Location;
            this.Config.Size = this.Overlay.Size;
        }
    }
}
