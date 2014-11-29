using RainbowMage.HtmlRenderer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    public partial class OverlayForm : Form
    {
        public Renderer Renderer { get; private set; }

        private string url;
        public string Url
        {
            get { return this.url; }
            set
            {
                if (this.url != value)
                {
                    this.url = value;
                    UpdateRender();
                }
            }
        }

        private bool isClickThru;
        public bool IsClickThru
        { 
            get
            {
                return this.isClickThru;
            }
            set
            {
                if (this.isClickThru != value)
                {
                    this.isClickThru = value;
                    UpdateMouseClickThru();
                }
            }
        }

        public bool IsLoaded { get; private set; }

        public OverlayForm(string url)
        {
            InitializeComponent();
            Renderer.Initialize();

            this.Renderer = new Renderer();
            this.Renderer.Render += renderer_Render;

            this.url = url;
        }

        public void Reload()
        {
            this.Renderer.Reload();
        }

        #region Layered window related stuffs
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOPMOST = 0x00000008;
                const int WS_EX_LAYERED = 0x00080000;
                const int CP_NOCLOSE_BUTTON = 0x200;

                var cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TOPMOST | WS_EX_LAYERED;
                cp.ClassStyle = cp.ClassStyle | CP_NOCLOSE_BUTTON;

                return cp;
            }
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_NCHITTEST = 0x84;
            const int HTBOTTOMRIGHT = 17;

            const int gripSize = 16;

            if (m.Msg == WM_NCHITTEST)
            {
                var posisiton = new Point(m.LParam.ToInt32() & 0xFFFF, m.LParam.ToInt32() >> 16);
                posisiton = this.PointToClient(posisiton);
                if (posisiton.X >= this.ClientSize.Width - gripSize &&
                    posisiton.Y >= this.ClientSize.Height - gripSize)
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                    return;
                }
            }
            
        }

        private void UpdateLayeredWindowBitmap(Bitmap bitmap)
        {
            using (var gScreen = Graphics.FromHwnd(IntPtr.Zero))
            using (var gBitmap = Graphics.FromImage(bitmap))
            {
                var hScreen = gScreen.GetHdc();
                var hBitmap = gBitmap.GetHdc();

                var hOldBitmap = NativeMethods.SelectObject(hBitmap, bitmap.GetHbitmap(Color.FromArgb(0)));

                var blend = new NativeMethods.BlendFunction
                {
                    BlendOp = NativeMethods.AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = NativeMethods.AC_SRC_ALPHA
                };

                var windowPosition = new NativeMethods.Point { X = this.Left, Y = this.Top };
                var surfaceSize = new NativeMethods.Size { Width = this.Width, Height = this.Height };
                var surfacePosition = new NativeMethods.Point { X = 0, Y = 0 };

                IntPtr handle = IntPtr.Zero;
                try
                {
                    if (!this.IsDisposed)
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                handle = this.Handle;
                            }));
                        }
                        else
                        {
                            handle = this.Handle;
                        }

                        NativeMethods.UpdateLayeredWindow(
                            handle,
                            hScreen,
                            ref windowPosition,
                            ref surfaceSize,
                            hBitmap,
                            ref surfacePosition,
                            0,
                            ref blend,
                            NativeMethods.ULW_ALPHA);
                    }
                }
                catch (ObjectDisposedException)
                {

                }

                NativeMethods.DeleteObject(NativeMethods.SelectObject(hBitmap, hOldBitmap));
                gScreen.ReleaseHdc(hScreen);
                gBitmap.ReleaseHdc(hBitmap);
            }
        }
        #endregion

        #region Mouse click-thru related

        private void UpdateMouseClickThru()
        {
            if (this.IsLoaded)
            {
                if (this.isClickThru)
                {
                    EnableMouseClickThru();
                }
                else
                {
                    DisableMouseClickThru();
                }
            }
        }

        private void EnableMouseClickThru()
        {
            NativeMethods.SetWindowLong(
                this.Handle,
                NativeMethods.GWL_EXSTYLE,
                NativeMethods.GetWindowLong(this.Handle, NativeMethods.GWL_EXSTYLE) | NativeMethods.WS_EX_TRANSPARENT);
        }

        private void DisableMouseClickThru()
        {
            NativeMethods.SetWindowLong(
                this.Handle,
                NativeMethods.GWL_EXSTYLE,
                NativeMethods.GetWindowLong(this.Handle, NativeMethods.GWL_EXSTYLE) & ~NativeMethods.WS_EX_TRANSPARENT);
        }

        #endregion

        void renderer_Render(object sender, RenderEventArgs e)
        {
            var bitmap = new Bitmap(e.Width, e.Height, e.Width * 4, PixelFormat.Format32bppArgb, e.Buffer);
            UpdateLayeredWindowBitmap(bitmap);
        }

        private void UpdateRender()
        {
            if (this.Renderer != null)
            {
                this.Renderer.BeginRender(this.Width, this.Height, this.Url);
            }
        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            this.IsLoaded = true;

            UpdateMouseClickThru();
            UpdateRender();
        }

        private void OverlayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Renderer != null)
            {
                this.Renderer.Dispose();
                this.Renderer = null;
            }
        }

        private void OverlayForm_Resize(object sender, EventArgs e)
        {
            if (this.Renderer != null)
            {
                this.Renderer.Resize(this.Width, this.Height);
            }
        }

        bool isDragging;
        Point offset;

        private void OverlayForm_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            offset = e.Location;
        }

        private void OverlayForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var screenPosition = PointToScreen(e.Location);
                this.Location = new Point(
                    screenPosition.X - offset.X,
                    screenPosition.Y - offset.Y);
            }
        }

        private void OverlayForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
