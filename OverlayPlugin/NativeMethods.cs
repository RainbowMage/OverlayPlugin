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

        //public struct Rect
        //{
        //    public int Left;
        //    public int Top;
        //    public int Right;
        //    public int Bottom;
        //}

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

        [DllImport("gdi32")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct BitmapInfo
        {
            public BitmapInfoHeader bmiHeader;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
            public RgbQuad[] bmiColors;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct BitmapInfoHeader
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public BitmapCompressionMode biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;

            public void Init()
            {
                biSize = (uint)Marshal.SizeOf(this);
            }
        }

        public enum BitmapCompressionMode : uint
        {
            BI_RGB = 0,
            BI_RLE8 = 1,
            BI_RLE4 = 2,
            BI_BITFIELDS = 3,
            BI_JPEG = 4,
            BI_PNG = 5
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct RgbQuad
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved; 
        }

        [DllImport("gdi32")]
        public static extern IntPtr CreateDIBSection(
            IntPtr hdc,
            [In] ref BitmapInfo pbmi,
            uint iUsage,
            out IntPtr ppvBits,
            IntPtr hSection,
            uint dwOffset);

        public const int DIB_RGB_COLORS = 0x0000;

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x00000020;

        [DllImport("kernel32")]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    }
}
