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
    public abstract class OverlayBase<TConfig> : IDisposable
        where TConfig: OverlayConfig
    {
        public event EventHandler<LogEventArgs> OnLog;

        //protected PluginMain pluginMain;
        protected System.Timers.Timer timer;

        public string Name { get; private set; }
        public OverlayForm Overlay { get; private set; }

        protected TConfig Config { get; private set; }

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
                Uri uri = null;
                try
                {
                    uri = new System.Uri(this.Config.Url);

                    // ローカルファイルの場合はファイルが存在するかチェックし、存在しなければ警告を出力
                    if (uri.Scheme == "file")
                    {
                        if (!File.Exists(uri.LocalPath))
                        {
                            Log("Warn: {0}: InitializeOverlay: Local file {1} is not exist!",
                                this.Name,
                                uri.LocalPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // URL パースエラー
                    Log("Error: {0}: InitializeOverlay: URI parse error! (Config.Url = {1}): {2}",
                        this.Name,
                        this.Config.Url,
                        ex);
                    Log("Error: {0}: InitializeOverlay: Please reconfigure URL.", this.Name);
                    uri = new System.Uri("about:blank"); // 空白ページを表示
                }

                this.Overlay = new OverlayForm(uri.AbsoluteUri, this.Config.MaxFrameRate);

                // 画面外にウィンドウがある場合は、初期表示位置をシステムに設定させる
                if (!Util.IsOnScreen(this.Overlay))
                {
                    this.Overlay.StartPosition = FormStartPosition.WindowsDefaultLocation;
                }
                else
                {
                    this.Overlay.Location = this.Config.Position;
                }
                this.Overlay.Size = this.Config.Size;
                this.Overlay.IsClickThru = this.Config.IsClickThru;
                this.Overlay.Renderer.BrowserError += (o, e) =>
                {
                    Log("Error: {0}: Overlay: {1}, {2}, {3}", this.Name, e.ErrorCode, e.ErrorText, e.Url);
                };
                this.Overlay.Renderer.BrowserLoad += (o, e) =>
                {
                    Log("Info: {0}: Overlay: {1}: {2}", this.Name, e.HttpStatusCode, e.Url);
                };

                this.Overlay.Show();

                this.Overlay.Visible = this.Config.IsVisible;
            }
            catch (Exception ex)
            {
                Log("Error: {0}: InitializeOverlay: {1}", this.Name, ex);
            }
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
                    Log("Error: {0}: Update: {0}", this.Name, ex.ToString());
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
            }
            catch (Exception ex)
            {
                Log("Error: {0}: Dispose: {1}", this.Name, ex);
            }
        }

        public class LogEventArgs : EventArgs
        {
            public string Message { get; private set; }
            public LogEventArgs(string message)
            {
                this.Message = message;
            }
        }

        protected void Log(string message)
        {
            if (OnLog != null)
            {
                OnLog(this, new LogEventArgs(message));
            }
        }

        protected void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }
    }
}
