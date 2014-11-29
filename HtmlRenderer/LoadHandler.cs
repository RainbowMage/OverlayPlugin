using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class LoadHandler : CefLoadHandler
    {
        private Renderer renderer;

        public LoadHandler(Renderer renderer)
        {
            this.renderer = renderer;
        }

        protected override void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
        {
            base.OnLoadError(browser, frame, errorCode, errorText, failedUrl);

            this.renderer.OnError(errorCode, errorText, failedUrl);
        }

        protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
        {
            base.OnLoadEnd(browser, frame, httpStatusCode);

            this.renderer.OnLoad(browser, frame, httpStatusCode);
        }
    }
}
