using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
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

    public class SortTypeChangedEventArgs : EventArgs
    {
        public MiniParseSortType NewSortType { get; private set; }
        public SortTypeChangedEventArgs(MiniParseSortType newSortType)
        {
            this.NewSortType = newSortType;
        }
    }

    public class SortKeyChangedEventArgs : EventArgs
    {
        public string NewSortKey { get; private set; }
        public SortKeyChangedEventArgs(string newSortKey)
        {
            this.NewSortKey = newSortKey;
        }
    }

    public class MaxFrameRateChangedEventArgs : EventArgs
    {
        public int NewFrameRate { get; private set; }
        public MaxFrameRateChangedEventArgs(int frameRate)
        {
            this.NewFrameRate = frameRate;
        }
    }
}
