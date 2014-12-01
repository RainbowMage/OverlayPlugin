using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        #region Config for version 0.1.2.0 or below
#pragma warning disable 612, 618
        [Obsolete] public event EventHandler<VisibleStateChangedEventArgs> VisibleChanged;
        [Obsolete] public event EventHandler<ThruStateChangedEventArgs> ClickThruChanged;
        [Obsolete] public event EventHandler<UrlChangedEventArgs> UrlChanged;
        [Obsolete] public event EventHandler<SortKeyChangedEventArgs> SortKeyChanged;
        [Obsolete] public event EventHandler<SortTypeChangedEventArgs> SortTypeChanged;

        private bool isVisible;
        [XmlElement("IsVisible")]
        public bool IsVisibleObsolete
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
        public bool IsClickThruObsolete
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

        private Point overlayPosition;
        [XmlElement("OverlayPosition")]
        public Point OverlayPositionObsolete
        { 
            get
            {
                return this.overlayPosition;
            }
            set
            {
                this.overlayPosition = value;
            }
        }

        private Size overlaySize;
        [XmlElement("OverlaySize")]
        public Size OverlaySizeObsolete
        {
            get
            {
                return this.overlaySize;
            }
            set
            {
                this.overlaySize = value;
            }
        }

        private string url;
        [XmlElement("Url")]
        public string UrlObsolete
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

        private string sortKey;
        [XmlElement("SortKey")]
        public string SortKeyObsolete
        {
            get
            {
                return this.sortKey;
            }
            set
            {
                if (this.sortKey != value)
                {
                    this.sortKey = value;
                    if (SortKeyChanged != null)
                    {
                        SortKeyChanged(this, new SortKeyChangedEventArgs(this.sortKey));
                    }
                }
            }
        }

        private MiniParseSortType sortType;
        [XmlElement("SortType")]
        public MiniParseSortType SortTypeObsolete
        {
            get
            {
                return this.sortType;
            }
            set
            {
                if (this.sortType != value)
                {
                    this.sortType = value;
                    if (SortTypeChanged != null)
                    {
                        SortTypeChanged(this, new SortTypeChangedEventArgs(this.sortType));
                    }
                }
            }
        }
#pragma warning restore 612, 618
        #endregion

        [XmlElement("MiniParseOverlay")]
        public MiniParseOverlayConfig MiniParseOverlay { get; set; }

        [XmlElement("SpellTimerOverlay")]
        public OverlayConfig SpellTimerOverlay { get; set; }

        [XmlElement("Version")]
        public Version Version { get; set; }

        [XmlIgnore]
        public bool IsFirstLaunch { get; set; }

        public PluginConfig()
        {
            #region Config for version 0.1.2.0 or below
#pragma warning disable 612, 618
            this.IsVisibleObsolete = true;
            this.IsClickThruObsolete = false;
            this.OverlayPositionObsolete = new Point(20, 20);
            this.OverlaySizeObsolete = new Size(300, 300);
            this.UrlObsolete = "";
            this.SortKeyObsolete = "encdps";
            this.SortTypeObsolete = OverlayPlugin.MiniParseSortType.NumericDescending;
#pragma warning restore 612, 618
            #endregion

            this.MiniParseOverlay = new MiniParseOverlayConfig();
            this.MiniParseOverlay.Position = new Point(20, 20);
            this.MiniParseOverlay.Size = new Size(500, 300);
            this.SpellTimerOverlay = new OverlayConfig();
            this.SpellTimerOverlay.Position = new Point(20, 520);
            this.SpellTimerOverlay.Size = new Size(200, 300);
            this.IsFirstLaunch = true;

        }

        public void SaveXml(string path)
        {
            this.Version = typeof(PluginMain).Assembly.GetName().Version;

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

                result.IsFirstLaunch = false;

                if (result.Version == null)
                {
                    result.UpdateFromVersion0_1_2_0OrBelow();
                }

                return result;
            }
        }

        private void UpdateFromVersion0_1_2_0OrBelow()
        {
#pragma warning disable 612, 618
            this.MiniParseOverlay.IsVisible = this.IsVisibleObsolete;
            this.MiniParseOverlay.IsClickThru = this.IsClickThruObsolete;
            this.MiniParseOverlay.Position = this.OverlayPositionObsolete;
            this.MiniParseOverlay.Size = this.OverlaySizeObsolete;
            this.MiniParseOverlay.Url = this.UrlObsolete;
#pragma warning restore 612, 618
        }
    }
}
