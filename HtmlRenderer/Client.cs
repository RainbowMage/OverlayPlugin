using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class Client : CefClient
    {
        private readonly Renderer renderer;
        private readonly RenderHandler renderHandler;
        private readonly LifeSpanHandler lifeSpanHandler;
        private readonly LoadHandler loadHandler;
        private readonly DisplayHandler displayHandler;
        private readonly MenuHandler menuHandler;

        public Client(Renderer renderer, int windowWidth, int windowHeight)
        {
            this.renderer = renderer;
            this.renderHandler = new RenderHandler(renderer, windowWidth, windowHeight);
            this.lifeSpanHandler = new LifeSpanHandler(renderer);
            this.loadHandler = new LoadHandler(renderer);
            this.displayHandler = new DisplayHandler(renderer);
            this.menuHandler = new MenuHandler();
        }

        protected override CefRenderHandler GetRenderHandler()
        {
            return renderHandler;
        }

        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return lifeSpanHandler;
        }

        protected override CefLoadHandler GetLoadHandler()
        {
            return loadHandler;
        }

        protected override CefDisplayHandler GetDisplayHandler()
        {
            return displayHandler;
        }

        protected override CefContextMenuHandler GetContextMenuHandler()
        {
            return menuHandler;
        }

        public void ResizeView(int width, int height)
        {
            renderHandler.Width = width;
            renderHandler.Height = height;
        }
    }
}
