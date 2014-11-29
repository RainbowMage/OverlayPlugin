using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainbowMage.OverlayPlugin
{
    [Serializable]
    public class PluginConfig
    {
        public event EventHandler<VisibleStateChangedEventArgs> VisibleChanged;
        public event EventHandler<ThruStateChangedEventArgs> ClickThruChanged;
        public event EventHandler<UrlChangedEventArgs> UrlChanged;

        [XmlElement("IsVisible")]
        private bool isVisible;
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

        [XmlElement("IsClickThru")]
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
                    if (ClickThruChanged != null)
                    {
                        ClickThruChanged(this, new ThruStateChangedEventArgs(this.isClickThru));
                    }
                }
            }
        }

        [XmlElement("OverlayPosition")]
        public Point OverlayPosition { get; set; }

        [XmlElement("OverlaySize")]
        public Size OverlaySize { get; set; }

        [XmlElement("Url")]
        private string url;
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

        public PluginConfig()
        {
            this.IsVisible = true;
            this.IsClickThru = false;
            this.OverlayPosition = new Point(20, 20);
            this.OverlaySize = new Size(300, 300);
            this.Url = "";
        }

        public void SaveXml(string path)
        {
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PluginConfig));
                serializer.Serialize(stream, this);
            }
        }

        public static PluginConfig LoadXml(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Specified file is not exists.", path);
            }

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PluginConfig));
                var result = (PluginConfig)serializer.Deserialize(stream);
                return result;
            }
        }
    }

    public class VisibleStateChangedEventArgs : EventArgs
    {
        public bool IsVisible { get; private set; }
        public VisibleStateChangedEventArgs(bool isVisible)
        {
            this.IsVisible = isVisible;
        }
    }

    public class ThruStateChangedEventArgs : EventArgs
    {
        public bool IsClickThru { get; private set; }
        public ThruStateChangedEventArgs(bool isClickThru)
        {
            this.IsClickThru = isClickThru;
        }
    }

    public class UrlChangedEventArgs : EventArgs
    {
        public string NewUrl { get; private set; }
        public UrlChangedEventArgs(string url)
        {
            this.NewUrl = url;
        }
    }
}
