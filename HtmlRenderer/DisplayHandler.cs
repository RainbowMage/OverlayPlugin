using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class DisplayHandler : CefDisplayHandler
    {
        private Renderer renderer;

        public DisplayHandler(Renderer renderer)
        {
            this.renderer = renderer;
        }

        protected override bool OnConsoleMessage(CefBrowser browser, string message, string source, int line)
        {
            this.renderer.OnConsoleLog(browser, message, source, line);

            return base.OnConsoleMessage(browser, message, source, line);
        }
    }
}
