using RainbowMage.OverlayPlugin.Overlays;
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
    public class PluginConfig : IPluginConfig
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

        #region Config for version 0.2.5.0 or below
        [XmlElement("MiniParseOverlay")]
        public MiniParseOverlayConfig MiniParseOverlayObsolete { get; set; }

        [XmlElement("SpellTimerOverlay")]
        public SpellTimerOverlayConfig SpellTimerOverlayObsolete { get; set; }
        #endregion

        public event EventHandler VisibleAllOverlaysChanged;
        public event EventHandler ShowOverlayPluginButtonOffsetChanged;

        /// <summary>
        /// オーバーレイ設定のリスト。
        /// </summary>
        [XmlElement("Overlays")]
        public OverlayConfigList Overlays { get; set; }

        /// <summary>
        /// 設定タブのログにおいて、常に最新のログ行を表示するかどうかを取得または設定します。
        /// </summary>
        [XmlElement("FollowLatestLog")]
        public bool FollowLatestLog { get; set; }

        [XmlElement("HideOverlaysWhenNotActive")]
        public bool HideOverlaysWhenNotActive { get; set; }

        private bool visibleAllOverlays;
        /// <summary>
        /// 全てのオーバーレイを表示するかのフラグを取得または設定します。
        /// </summary>
        [XmlElement("VisibleAllOverlays")]
        public bool VisibleAllOverlays
        {
            get
            {
                return this.visibleAllOverlays;
            }
            set
            {
                if (this.visibleAllOverlays != value)
                {
                    this.visibleAllOverlays = value;
                    if (VisibleAllOverlaysChanged != null)
                    {
                        VisibleAllOverlaysChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        // スペスペとTimeLineの固定位置より左になるオフセット値をデフォルトとしている
        private const int SHOW_OVERLAY_PLUGIN_BUTTON_OFFSET_DEFAULT = 623;
        private int showOverlayPluginButtonOffset = SHOW_OVERLAY_PLUGIN_BUTTON_OFFSET_DEFAULT;
        /// <summary>
        /// 全てのオーバーレイを表示するかを切り替えるボタンの配置を決めるオフセット値を指定します。
        /// </summary>
        [XmlElement("ShowOverlayPluginButtonOffset")]
        public int ShowOverlayPluginButtonOffset
        {
            get
            {
                if (this.showOverlayPluginButtonOffset > 0)
                {
                    return this.showOverlayPluginButtonOffset;
                }
                else
                {
                    return PluginConfig.SHOW_OVERLAY_PLUGIN_BUTTON_OFFSET_DEFAULT;
                }
            }
            set
            {
                if (this.showOverlayPluginButtonOffset != value)
                {
                    this.showOverlayPluginButtonOffset = value;
                    if (ShowOverlayPluginButtonOffsetChanged != null)
                    {
                        ShowOverlayPluginButtonOffsetChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// 設定ファイルを生成したプラグインのバージョンを取得または設定します。
        /// 設定が新規に作成された場合、またはバージョン0.3未満では null が設定されます。
        /// </summary>
        [XmlIgnore]
        public Version Version 
        {
            get
            {
                if (string.IsNullOrEmpty(this.VersionString))
                {
                    return null;
                }
                else
                {
                    return new Version(this.VersionString);
                }
            }
            set
            {
                if (value != null)
                {
                    this.VersionString = value.ToString();
                }
                else
                {
                    this.VersionString = null;
                }
            }
        }

        [XmlElement("Version")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public string VersionString { get; set; }

        /// <summary>
        /// 設定が新規に作成されたことを示すフラグを取得または設定します。
        /// </summary>
        [XmlIgnore]
        public bool IsFirstLaunch { get; set; }

        internal const string DefaultMiniParseOverlayName = "Mini Parse";
        internal const string DefaultSpellTimerOverlayName = "Spell Timer";

        public PluginConfig()
        {
            #region Config for version 0.1.2.0 or below
#pragma warning disable 612, 618
            this.IsVisibleObsolete = true;
            this.IsClickThruObsolete = false;
            this.OverlayPositionObsolete = new Point(20, 20);
            this.OverlaySizeObsolete = new Size(300, 300);
            this.UrlObsolete = null;
            this.SortKeyObsolete = "encdps";
            this.SortTypeObsolete = MiniParseSortType.NumericDescending;
#pragma warning restore 612, 618
            #endregion

            this.Overlays = new OverlayConfigList();

            this.FollowLatestLog = false;
            this.HideOverlaysWhenNotActive = false;
            this.VisibleAllOverlays = true;
            this.IsFirstLaunch = true;
        }

        /// <summary>
        /// 指定したファイルパスに設定を保存します。
        /// </summary>
        /// <param name="path"></param>
        public void SaveXml(string path)
        {
            this.Version = typeof(PluginMain).Assembly.GetName().Version;

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PluginConfig));
                serializer.Serialize(stream, this);
            }
        }

        /// <summary>
        /// 指定したファイルパスから設定を読み込みます。
        /// </summary>
        /// <param name="pluginDirectory"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PluginConfig LoadXml(string pluginDirectory, string path)
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
                    result.UpdateFromVersion0_1_2_0OrBelow(pluginDirectory);
                    result.UpdateFromVersion0_2_5_0OrBelow();
                }


                return result;
            }
        }

        /// <summary>
        /// デフォルトのオーバーレイを作成します。
        /// </summary>
        /// <param name="pluginDirectory"></param>
        public void SetDefaultOverlayConfigs(string pluginDirectory)
        {
            var miniparseOverlayConfig = new MiniParseOverlayConfig(DefaultMiniParseOverlayName);
            miniparseOverlayConfig.Position = new Point(20, 20);
            miniparseOverlayConfig.Size = new Size(500, 300);
            miniparseOverlayConfig.Url = new Uri(Path.Combine(pluginDirectory, "resources", "miniparse.html")).ToString(); 

            var spellTimerOverlayConfig = new SpellTimerOverlayConfig(DefaultSpellTimerOverlayName);
            spellTimerOverlayConfig.Position = new Point(20, 520);
            spellTimerOverlayConfig.Size = new Size(200, 300);
            spellTimerOverlayConfig.IsVisible = true;
            spellTimerOverlayConfig.MaxFrameRate = 5;
            spellTimerOverlayConfig.Url = new Uri(Path.Combine(pluginDirectory, "resources", "spelltimer.html")).ToString(); 

            this.Overlays = new OverlayConfigList();
            this.Overlays.Add(miniparseOverlayConfig);
            this.Overlays.Add(spellTimerOverlayConfig);
        }

        /// <summary>
        /// バージョン0.1.2.0以下からのアップデート用の処理を行います。
        /// </summary>
        /// <param name="pluginDirectory"></param>
        private void UpdateFromVersion0_1_2_0OrBelow(string pluginDirectory)
        {
#pragma warning disable 612, 618
            if (this.MiniParseOverlayObsolete == null)
            {
                this.MiniParseOverlayObsolete = new MiniParseOverlayConfig(DefaultMiniParseOverlayName);
                this.MiniParseOverlayObsolete.IsVisible = this.IsVisibleObsolete;
                this.MiniParseOverlayObsolete.IsClickThru = this.IsClickThruObsolete;
                this.MiniParseOverlayObsolete.Position = this.OverlayPositionObsolete;
                this.MiniParseOverlayObsolete.Size = this.OverlaySizeObsolete;
                this.MiniParseOverlayObsolete.Url = this.UrlObsolete;
            }
            if (this.SpellTimerOverlayObsolete == null)
            {
                this.SpellTimerOverlayObsolete = new SpellTimerOverlayConfig(DefaultSpellTimerOverlayName);
                this.SpellTimerOverlayObsolete.Position = new Point(20, 520);
                this.SpellTimerOverlayObsolete.Size = new Size(200, 300);
                this.SpellTimerOverlayObsolete.IsVisible = false;
                this.SpellTimerOverlayObsolete.MaxFrameRate = 5;
                this.SpellTimerOverlayObsolete.Url = new Uri(Path.Combine(pluginDirectory, "resources", "spelltimer.html")).ToString(); ;
            }
#pragma warning restore 612, 618
        }

        /// <summary>
        /// バージョン 0.2.5.0 以下からのアップデート処理を行います。
        /// </summary>
        private void UpdateFromVersion0_2_5_0OrBelow()
        {
#pragma warning disable 612, 618
            if (this.MiniParseOverlayObsolete != null)
            {
                var miniParseOverlayConfig = new MiniParseOverlayConfig(DefaultMiniParseOverlayName);
                miniParseOverlayConfig.IsVisible = this.MiniParseOverlayObsolete.IsVisible;
                miniParseOverlayConfig.IsClickThru = this.MiniParseOverlayObsolete.IsClickThru;
                miniParseOverlayConfig.Position = this.MiniParseOverlayObsolete.Position;
                miniParseOverlayConfig.Size = this.MiniParseOverlayObsolete.Size;
                miniParseOverlayConfig.Url = this.MiniParseOverlayObsolete.Url;
                miniParseOverlayConfig.SortKey = this.MiniParseOverlayObsolete.SortKey;
                miniParseOverlayConfig.SortType = this.MiniParseOverlayObsolete.SortType;
                miniParseOverlayConfig.MaxFrameRate = this.MiniParseOverlayObsolete.MaxFrameRate;
                miniParseOverlayConfig.GlobalHotkey = this.MiniParseOverlayObsolete.GlobalHotkey;
                miniParseOverlayConfig.GlobalHotkeyEnabled = this.MiniParseOverlayObsolete.GlobalHotkeyEnabled;
                miniParseOverlayConfig.GlobalHotkeyModifiers = this.MiniParseOverlayObsolete.GlobalHotkeyModifiers;

                this.Overlays.Add(miniParseOverlayConfig);

                this.MiniParseOverlayObsolete = null;
            }
            if (this.SpellTimerOverlayObsolete != null)
            {
                var spellTimerOverlayConfig = new SpellTimerOverlayConfig(DefaultSpellTimerOverlayName);
                spellTimerOverlayConfig.IsVisible = this.SpellTimerOverlayObsolete.IsVisible;
                spellTimerOverlayConfig.IsClickThru = this.SpellTimerOverlayObsolete.IsClickThru;
                spellTimerOverlayConfig.Position = this.SpellTimerOverlayObsolete.Position;
                spellTimerOverlayConfig.Size = this.SpellTimerOverlayObsolete.Size;
                spellTimerOverlayConfig.Url = this.SpellTimerOverlayObsolete.Url;
                spellTimerOverlayConfig.MaxFrameRate = this.SpellTimerOverlayObsolete.MaxFrameRate;
                spellTimerOverlayConfig.GlobalHotkey = this.SpellTimerOverlayObsolete.GlobalHotkey;
                spellTimerOverlayConfig.GlobalHotkeyEnabled = this.SpellTimerOverlayObsolete.GlobalHotkeyEnabled;
                spellTimerOverlayConfig.GlobalHotkeyModifiers = this.SpellTimerOverlayObsolete.GlobalHotkeyModifiers;

                this.Overlays.Add(spellTimerOverlayConfig);

                this.SpellTimerOverlayObsolete = null;
            }
#pragma warning restore 612, 618
        }
    }
}
