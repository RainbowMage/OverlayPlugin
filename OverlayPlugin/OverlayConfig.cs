using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RainbowMage.OverlayPlugin
{
    [Serializable]
    public abstract class OverlayConfig
    {
        public event EventHandler<VisibleStateChangedEventArgs> VisibleChanged;
        public event EventHandler<ThruStateChangedEventArgs> ClickThruChanged;
        public event EventHandler<UrlChangedEventArgs> UrlChanged;
        public event EventHandler<MaxFrameRateChangedEventArgs> MaxFrameRateChanged;
        public event EventHandler<GlobalHotkeyEnabledChangedEventArgs> GlobalHotkeyEnabledChanged;
        public event EventHandler<GlobalHotkeyChangedEventArgs> GlobalHotkeyChanged;
        public event EventHandler<GlobalHotkeyChangedEventArgs> GlobalHotkeyModifiersChanged;

        [XmlElement("Name")]
        public string Name { get; set; }

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

        private bool globalHotkeyEnabled;
        [XmlElement("GlobalHotkeyEnabled")]
        public bool GlobalHotkeyEnabled
        {
            get
            {
                return this.globalHotkeyEnabled;
            }
            set
            {
                if (this.globalHotkeyEnabled != value)
                {
                    this.globalHotkeyEnabled = value;
                    if (GlobalHotkeyEnabledChanged != null)
                    {
                        GlobalHotkeyEnabledChanged(this, new GlobalHotkeyEnabledChangedEventArgs(this.globalHotkeyEnabled));
                    }
                }
            }
        }

        private Keys globalHotkey;
        [XmlElement("GlobalHotkey")]
        public Keys GlobalHotkey
        {
            get
            {
                return this.globalHotkey;
            }
            set
            {
                if (this.globalHotkey != value)
                {
                    this.globalHotkey = value;
                    if (GlobalHotkeyChanged != null)
                    {
                        GlobalHotkeyChanged(this, new GlobalHotkeyChangedEventArgs(this.globalHotkey));
                    }
                }
            }
        }

        private Keys globalHotkeyModifiers;
        [XmlElement("GlobalHotkeyModifiers")]
        public Keys GlobalHotkeyModifiers
        {
            get
            {
                return this.globalHotkeyModifiers;
            }
            set
            {
                if (this.globalHotkeyModifiers != value)
                {
                    this.globalHotkeyModifiers = value;
                    if (GlobalHotkeyModifiersChanged != null)
                    {
                        GlobalHotkeyModifiersChanged(this, new GlobalHotkeyChangedEventArgs(this.globalHotkeyModifiers));
                    }
                }
            }
        }

        public OverlayConfig(string name)
        {
            this.Name = name;
            this.IsVisible = true;
            this.IsClickThru = false;
            this.Position = new Point(20, 20);
            this.Size = new Size(300, 300);
            this.Url = "";
            this.MaxFrameRate = 30;
            this.globalHotkeyEnabled = false;
            this.GlobalHotkey = Keys.None;
            this.globalHotkeyModifiers = Keys.None;
        }
    }
}
