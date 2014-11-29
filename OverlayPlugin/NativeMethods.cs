using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    static class NativeMethods
    {
        public struct BlendFunction
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        public const byte AC_SRC_ALPHA = 1;
        public const byte AC_SRC_OVER = 0;

        public struct Point
        {
            public int X;
            public int Y;
        }

        public struct Size
        {
            public int Width;
            public int Height;
        }

        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32")]
        public static extern bool UpdateLayeredWindow(
            IntPtr hWnd,
            IntPtr hdcDst,
            [In] ref Point pptDst,
            [In]ref Size pSize,
            IntPtr hdcSrc,
            [In]ref Point pptSrc,
            int crKey,
            [In]ref BlendFunction pBlend,
            uint dwFlags);

        public const int ULW_ALPHA = 2;

        [DllImport("gdi32")]
        public static extern IntPtr SelectObject(
            IntPtr hdc,
            IntPtr hgdiobj);

        [DllImport("gdi32")]
        public static extern bool DeleteObject(
            IntPtr hObject);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x00000020;
    }
}
