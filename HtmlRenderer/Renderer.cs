using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    public class Renderer : IDisposable
    {
        public event EventHandler<RenderEventArgs> Render;
        public event EventHandler<BrowserErrorEventArgs> BrowserError;
        public event EventHandler<BrowserLoadEventArgs> BrowserLoad;

        public CefBrowser Browser { get; private set; }
        private Client Client { get; set; }

        public Renderer()
        {
            
        }

        public void BeginRender(int width, int height, string url, int maxFrameRate = 30)
        {
            EndRender();

            var cefWindowInfo = CefWindowInfo.Create();
            cefWindowInfo.SetAsWindowless(IntPtr.Zero, true);

            var cefBrowserSettings = new CefBrowserSettings();
            cefBrowserSettings.WindowlessFrameRate = maxFrameRate;

            this.Client = new Client(this, width, height);

            CefBrowserHost.CreateBrowser(
                cefWindowInfo,
                this.Client,
                cefBrowserSettings,
                url);
        }

        public void EndRender()
        {
            if (this.Browser != null)
            {
                var host = Browser.GetHost();
                if (host != null)
                {
                    host.CloseBrowser(true);
                    host.Dispose();
                }
                this.Browser.Dispose();
                this.Browser = null;
            }
        }

        public void Reload()
        {
            if (this.Browser != null)
            {
                this.Browser.Reload();
            }
        }

        public void Resize(int width, int height)
        {
            if (this.Client != null && this.Browser != null)
            {
                this.Client.ResizeView(width, height);
                this.Browser.GetHost().WasResized();
            }
        }

        internal void OnCreated(CefBrowser browser)
        {
            this.Browser = browser;
        }

        internal void OnPaint(CefBrowser browser, IntPtr buffer, int width, int height, CefRectangle[] dirtyRects)
        {
            if (Render != null)
            {
                Render(this, new RenderEventArgs(buffer, width, height, dirtyRects));
            }
        }

        internal void OnError(CefErrorCode errorCode, string errorText, string failedUrl)
        {
            if (BrowserError != null)
            {
                BrowserError(this, new BrowserErrorEventArgs(errorCode, errorText, failedUrl));
            }
        }

        internal void OnLoad(CefBrowser browser, CefFrame frame, int httpStatusCode)
        {
            if (BrowserLoad != null)
            {
                BrowserLoad(this, new BrowserLoadEventArgs(httpStatusCode, frame.Url));
            }
        }

        public void Dispose()
        {
            var host = Browser.GetHost();
            host.CloseBrowser(true);
            host.Dispose();
            host = null;
            Browser.Dispose();
            Browser = null;
        }

        static bool initialized = false;

        public static void Initialize()
        {
            if (!initialized)
            {
                CefRuntime.Load();

                var cefMainArgs = new CefMainArgs(new string[0]);
                var cefApp = new App();
                if (CefRuntime.ExecuteProcess(cefMainArgs, cefApp, IntPtr.Zero) != -1)
                {
                    Console.Error.WriteLine("Could not the secondary process.");
                }

                var cefSettings = new CefSettings
                {
                    SingleProcess = true,
                    MultiThreadedMessageLoop = true
                };

                CefRuntime.Initialize(cefMainArgs, cefSettings, cefApp, IntPtr.Zero);

                initialized = true;
            }
        }

        public static void Shutdown()
        {
            if (initialized)
            {
                CefRuntime.Shutdown();
            }
        }
    }

    public class BrowserErrorEventArgs : EventArgs
    {
        public CefErrorCode ErrorCode { get; private set; }
        public string ErrorText { get; private set; }
        public string Url { get; private set; }
        public BrowserErrorEventArgs(CefErrorCode errorCode, string errorText, string url)
        {
            this.ErrorCode = errorCode;
            this.ErrorText = errorText;
            this.Url = url;
        }
    }

    public class BrowserLoadEventArgs : EventArgs
    {
        public int HttpStatusCode { get; private set; }
        public string Url { get; private set; }
        public BrowserLoadEventArgs(int httpStatusCode, string url)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Url = url;
        }
    }
}
