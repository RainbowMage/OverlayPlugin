using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace RainbowMage.OverlayPlugin
{
    public abstract class OverlayBase<TConfig> : IOverlay
        where TConfig: OverlayConfigBase
    {
        private KeyboardHook hook = new KeyboardHook();
        protected System.Timers.Timer timer;
        protected System.Timers.Timer xivWindowTimer;

        /// <summary>
        /// オーバーレイがログを出力したときに発生します。
        /// </summary>
        public event EventHandler<LogEventArgs> OnLog;

        /// <summary>
        /// ユーザーが設定したオーバーレイの名前を取得します。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// オーバーレイフォームを取得します。
        /// </summary>
        public OverlayForm Overlay { get; private set; }

        /// <summary>
        /// オーバーレイの設定を取得します。
        /// </summary>
        public TConfig Config { get; private set; }

        /// <summary>
        /// プラグインの設定を取得します。
        /// </summary>
        public IPluginConfig PluginConfig { get; set; }

        protected OverlayBase(TConfig config, string name)
        {
            this.Config = config;
            this.Name = name;

            InitializeOverlay();
            InitializeTimer();
            InitializeConfigHandlers();
        }

        /// <summary>
        /// オーバーレイの更新を開始します。
        /// </summary>
        public void Start()
        {
            timer.Start();
            xivWindowTimer.Start();
        }

        /// <summary>
        /// オーバーレイの更新を停止します。
        /// </summary>
        public void Stop()
        {
            timer.Stop();
            xivWindowTimer.Stop();
        }

        /// <summary>
        /// オーバーレイを初期化します。
        /// </summary>
        protected virtual void InitializeOverlay()
        {
            try
            {
                this.Overlay = new OverlayForm("about:blank", this.Config.MaxFrameRate);

                // グローバルホットキーを設定
                if (this.Config.GlobalHotkeyEnabled)
                {
                    var modifierKeys = GetModifierKey(this.Config.GlobalHotkeyModifiers);
                    var key = this.Config.GlobalHotkey;
                    if (key != Keys.None)
                    {
                        hook.KeyPressed += (o, e) => this.Config.IsVisible = !this.Config.IsVisible;
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

                // イベントハンドラを設定
                this.Overlay.Renderer.BrowserError += (o, e) =>
                {
                    Log(LogLevel.Error, "BrowserError: {0}, {1}, {2}", e.ErrorCode, e.ErrorText, e.Url);
                };
                this.Overlay.Renderer.BrowserLoad += (o, e) =>
                {
                    Log(LogLevel.Debug, "BrowserLoad: {0}: {1}", e.HttpStatusCode, e.Url);
                    NotifyOverlayState();
                };
                this.Overlay.Renderer.BrowserConsoleLog += (o, e) =>
                {
                    Log(LogLevel.Info, "BrowserConsole: {0} (Source: {1}, Line: {2})", e.Message, e.Source, e.Line);
                };
                this.Config.UrlChanged += (o, e) =>
                {
                    Navigate(e.NewUrl);
                };

                if (CheckUrl(this.Config.Url))
                {
                    Navigate(this.Config.Url);
                }
                else
                {
                    Navigate("about:blank");
                }

                this.Overlay.Show();

                this.Overlay.Visible = this.Config.IsVisible;

                this.Overlay.Locked = this.Config.IsLocked;
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "InitializeOverlay: {0}", this.Name, ex);
            }
        }

        private ModifierKeys GetModifierKey(Keys modifier)
        {
            ModifierKeys modifiers = new ModifierKeys();
            if ((modifier & Keys.Shift) == Keys.Shift)
            {
                modifiers |= ModifierKeys.Shift;
            }
            if ((modifier & Keys.Control) == Keys.Control)
            {
                modifiers |= ModifierKeys.Control;
            }
            if ((modifier & Keys.Alt) == Keys.Alt)
            {
                modifiers |= ModifierKeys.Alt;
            }
            if ((modifier & Keys.LWin) == Keys.LWin || (modifier & Keys.RWin) == Keys.RWin)
            {
                modifiers |= ModifierKeys.Win;
            }
            return modifiers;
        }

        /// <summary>
        /// URL が妥当であり、さらにローカルファイルであれば存在するかどうかをチェックします。
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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

        /// <summary>
        /// タイマーを初期化します。
        /// </summary>
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

            xivWindowTimer = new System.Timers.Timer();
            xivWindowTimer.Interval = 1000;
            xivWindowTimer.Elapsed += (o, e) =>
            {
                try
                {
                    if (Config.IsVisible && PluginConfig.HideOverlaysWhenNotActive)
                    {
                        uint pid;
                        var hWndFg = NativeMethods.GetForegroundWindow();
                        if (hWndFg == IntPtr.Zero)
                        {
                            return;
                        }
                        NativeMethods.GetWindowThreadProcessId(hWndFg, out pid);
                        var exePath = Process.GetProcessById((int)pid).MainModule.FileName;

                        if (Path.GetFileName(exePath.ToString()) == "ffxiv.exe" ||
                            Path.GetFileName(exePath.ToString()) == "ffxiv_dx11.exe" ||
                            exePath.ToString() == Process.GetCurrentProcess().MainModule.FileName)
                        {
                            this.Overlay.Visible = true;
                        }
                        else
                        {
                            this.Overlay.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log(LogLevel.Error, "XivWindowWatcher: {0}", ex.ToString());
                }
            };
        }

        /// <summary>
        /// 設定クラスのイベントハンドラを設定します。
        /// </summary>
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
            this.Config.LockChanged += (o, e) =>
            {
                this.Overlay.Locked = e.IsLocked;
                NotifyOverlayState();
            };
        }

        /// <summary>
        /// オーバーレイを更新します。
        /// </summary>
        protected abstract void Update();

        /// <summary>
        /// オーバーレイのインスタンスを破棄します。
        /// </summary>
        public virtual void Dispose()
        {
            try
            {
                if (this.timer != null)
                {
                    this.timer.Stop();
                }
                if (this.xivWindowTimer != null)
                {
                    this.xivWindowTimer.Stop();
                }
                if (this.Overlay != null)
                {
                    this.Overlay.Close();
                    this.Overlay.Dispose();
                }
                if (this.hook != null)
                {
                    this.hook.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "Dispose: {0}", ex);
            }
        }

        public virtual void Navigate(string url)
        {
                this.Overlay.Url = url;
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

        private void NotifyOverlayState()
        {
            var updateScript = string.Format(
                "document.dispatchEvent(new CustomEvent('onOverlayStateUpdate', {{ detail: {{ isLocked: {0} }} }}));",
                this.Config.IsLocked ? "true" : "false");

            if (this.Overlay != null &&
                this.Overlay.Renderer != null &&
                this.Overlay.Renderer.Browser != null)
            {
                this.Overlay.Renderer.Browser.GetMainFrame().ExecuteJavaScript(updateScript, null, 0);
            }
        }

        public void SendMessage(string message)
        {
            var script = string.Format(
                "document.dispatchEvent(new CustomEvent('onBroadcastMessageReceive', {{ detail: {{ message: \"{0}\" }} }}));",
                Util.CreateJsonSafeString(message));

            if (this.Overlay != null &&
                this.Overlay.Renderer != null &&
                this.Overlay.Renderer.Browser != null)
            {
                foreach (var frameId in this.Overlay.Renderer.Browser.GetFrameIdentifiers())
                {
                    var frame = this.Overlay.Renderer.Browser.GetFrame(frameId);
                    frame.ExecuteJavaScript(script, null, 0);
                }
            }
        }
    }
}
