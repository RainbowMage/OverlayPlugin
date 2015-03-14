using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    /// <summary>
    /// デバイス独立ビットマップを表現するクラス。
    /// </summary>
    class DIBitmap : IDisposable
    {
        /// <summary>
        /// ビットマップの幅を取得します。
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// ビットマップの高さを取得します。
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// ビットマップデータのアドレスを取得します。
        /// </summary>
        public IntPtr Bits { get; private set; }
        /// <summary>
        /// デバイス独立ビットマップのハンドルを取得します。
        /// </summary>
        public IntPtr Handle { get; private set; }
        /// <summary>
        /// デバイスコンテキストを取得します。
        /// </summary>
        public IntPtr DeviceContext { get; private set; }
        /// <summary>
        /// デバイス独立ビットマップが破棄されているかどうかを取得します。
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// 幅と高さを指定してデバイス独立ビットマップを作成します。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
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

        /// <summary>
        /// 指定されたサーフェイスデータをデバイス独立ビットマップにコピーします。
        /// </summary>
        /// <param name="srcSurfaceData"></param>
        /// <param name="count"></param>
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
