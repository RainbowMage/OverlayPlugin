using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainbowMage.OverlayPlugin
{
    [Serializable]
    public class OverlayConfig
    {
        public event EventHandler<VisibleStateChangedEventArgs> VisibleChanged;
        public event EventHandler<ThruStateChangedEventArgs> ClickThruChanged;
        public event EventHandler<UrlChangedEventArgs> UrlChanged;
        public event EventHandler<MaxFrameRateChangedEventArgs> MaxFrameRateChanged;

        private bool isVisible;
        [XmlElement("IsVisible")]
        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                if (this.isVisible != value)
                {
                    this.isVisible = value;
                    if (VisibleChanged != null)
                    {
                        VisibleChanged(this, new VisibleStateChangedEventArgs(this.isVisible));
                    }
                }
            }
        }

        private bool isClickThru;
        [XmlElement("IsClickThru")]
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
                    if (ClickThruChanged != null)
                    {
                        ClickThruChanged(this, new ThruStateChangedEventArgs(this.isClickThru));
                    }
                }
            }
        }

        [XmlElement("Position")]
        public Point Position { get; set; }

        [XmlElement("Size")]
        public Size Size { get; set; }

        private string url;
        [XmlElement("Url")]
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (this.url != value)
                {
                    this.url = value;
                    if (UrlChanged != null)
                    {
                        UrlChanged(this, new UrlChangedEventArgs(this.url));
                    }
                }
            }
        }

        private int maxFrameRate;
        [XmlElement("MaxFrameRate")]
        public int MaxFrameRate
        {
            get
            {
                return this.maxFrameRate;
            }
            set
            {
                if (this.maxFrameRate != value)
                {
                    this.maxFrameRate = value;
                    if (MaxFrameRateChanged != null)
                    {
                        MaxFrameRateChanged(this, new MaxFrameRateChangedEventArgs(this.maxFrameRate));
                    }
                }
            }
        }

        public OverlayConfig()
        {
            this.IsVisible = true;
            this.IsClickThru = false;
            this.Position = new Point(20, 20);
            this.Size = new Size(300, 300);
            this.Url = "";
            this.MaxFrameRate = 30;
        }
    }
}
