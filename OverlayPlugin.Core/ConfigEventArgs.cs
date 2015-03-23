using RainbowMage.OverlayPlugin.Overlays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    public class StateChangedEventArgs<T> : EventArgs
    {
        public T NewState { get; private set; }
        public StateChangedEventArgs(T newState)
        {
            this.NewState = newState;
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

    public class GlobalHotkeyEnabledChangedEventArgs : EventArgs
    {
        public bool NewGlobalHotkeyEnabled { get; private set; }
        public GlobalHotkeyEnabledChangedEventArgs(bool globalHotkeyEnabled)
        {
            this.NewGlobalHotkeyEnabled = globalHotkeyEnabled;
        }
    }

    public class GlobalHotkeyChangedEventArgs : EventArgs
    {
        public Keys NewHotkey { get; private set; }
        public GlobalHotkeyChangedEventArgs(Keys hotkey)
        {
            this.NewHotkey = hotkey;
        }
    }

    public class LockStateChangedEventArgs : EventArgs
    {
        public bool IsLocked { get; private set; }
        public LockStateChangedEventArgs(bool isLocked)
        {
            this.IsLocked = isLocked;
        }
    }
}
