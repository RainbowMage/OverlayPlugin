using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace RainbowMage.HtmlRenderer
{
    class RenderHandler : CefRenderHandler
    {
        private Renderer renderer;

        public int Height { get; set; }
        public int Width { get; set; }

        public RenderHandler(Renderer renderer, int windowWidth, int windowHeight)
        {
            this.renderer = renderer;
            this.Width = windowWidth;
            this.Height = windowHeight;
        }

        protected override bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
        {
            return GetViewRect(browser, ref rect);
        }

        protected override bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
        {
            screenX = viewX;
            screenY = viewY;
            return true;
        }

        protected override bool GetViewRect(CefBrowser browser, ref CefRectangle rect)
        {
            rect.X = 0;
            rect.Y = 0;
            rect.Width = Width;
            rect.Height = Height;
            return true;
        }

        protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
        {
            return false;
        }

        protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
        {
        }

        public event EventHandler<RenderEventArgs> Paint;

        protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
        {
            renderer.OnPaint(browser, buffer, width, height);
        }

        protected override void OnCursorChange(CefBrowser browser, IntPtr cursorHandle)
        {
        }

        protected override void OnScrollOffsetChanged(CefBrowser browser)
        {
        }
    }

    public class RenderEventArgs : EventArgs
    {
        public IntPtr Buffer { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public RenderEventArgs(IntPtr buffer, int width, int height)
        {
            this.Buffer = buffer;
            this.Width = width;
            this.Height = height;
        }
    }
}
