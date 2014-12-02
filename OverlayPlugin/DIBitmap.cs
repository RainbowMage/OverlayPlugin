using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    class DIBitmap : IDisposable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IntPtr Bits { get; private set; }
        public IntPtr Handle { get; private set; }
        public IntPtr DeviceContext { get; private set; }
        public bool IsDisposed { get; private set; }

        public DIBitmap(int width, int height)
        {
            this.IsDisposed = false;

            this.Width = width;
            this.Height = height;

            var hScreenDC = NativeMethods.CreateCompatibleDC(IntPtr.Zero);
            this.DeviceContext = NativeMethods.CreateCompatibleDC(hScreenDC);

            var bi = new NativeMethods.BitmapInfo();
            bi.bmiHeader.biSize = (uint)Marshal.SizeOf(bi);
            bi.bmiHeader.biBitCount = 32;
            bi.bmiHeader.biPlanes = 1;
            bi.bmiHeader.biWidth = width;
            bi.bmiHeader.biHeight = -height;

            IntPtr biBits;
            this.Handle = NativeMethods.CreateDIBSection(
                this.DeviceContext,
                ref bi,
                NativeMethods.DIB_RGB_COLORS,
                out biBits,
                IntPtr.Zero,
                0);
            this.Bits = biBits;
        }

        public void SetSurfaceData(IntPtr srcSurfaceData, uint count)
        {
            NativeMethods.CopyMemory(this.Bits, srcSurfaceData, count);
        }

        public void Dispose()
        {
            if (this.Handle != IntPtr.Zero)
            {
                NativeMethods.DeleteObject(this.Handle);
            }
            if (this.DeviceContext != IntPtr.Zero)
            {
                NativeMethods.DeleteDC(this.DeviceContext);
            }

            this.IsDisposed = true;
        }
    }
}
