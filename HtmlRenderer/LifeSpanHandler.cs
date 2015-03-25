using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class LifeSpanHandler : CefLifeSpanHandler
    {
        private readonly Renderer renderer;

        public LifeSpanHandler(Renderer renderer)
        {
            this.renderer = renderer;
        }
        
        protected override void OnAfterCreated(CefBrowser browser)
        {
            base.OnAfterCreated(browser);

            this.renderer.OnCreated(browser);
        }
    }
}
