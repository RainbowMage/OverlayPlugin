using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainbowMage.OverlayPlugin
{
    [Serializable]
    public class MiniParseOverlayConfig : OverlayConfig
    {
        public event EventHandler<SortKeyChangedEventArgs> SortKeyChanged;
        public event EventHandler<SortTypeChangedEventArgs> SortTypeChanged;

        private string sortKey;
        [XmlElement("SortKey")]
        public string SortKey
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
        public MiniParseSortType SortType
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

        public MiniParseOverlayConfig()
        {
            this.sortKey = "encdps";
            this.sortType = MiniParseSortType.NumericDescending;
        }
    }

    public enum MiniParseSortType
    {
        None,
        StringAscending,
        StringDescending,
        NumericAscending,
        NumericDescending
    }
}
