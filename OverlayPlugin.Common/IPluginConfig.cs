using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public interface IPluginConfig
    {
        event EventHandler VisibleAllOverlaysChanged;
        OverlayConfigList Overlays { get; set; }
        bool FollowLatestLog { get; set; }
        bool HideOverlaysWhenNotActive { get; set; }
        bool VisibleAllOverlays { get; set; }
        Version Version { get; set; }
        bool IsFirstLaunch { get; set; }
    }
}
