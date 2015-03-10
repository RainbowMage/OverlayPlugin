using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    public interface IOverlayAddon : IDisposable
    {
        string Name { get; }
        string Description { get; }
        Type OverlayType { get; }
        Type OverlayConfigType { get; }
        Type OverlayConfigControlType { get; }
        IOverlay CreateOverlayInstance(IOverlayConfig config);
        IOverlayConfig CreateOverlayConfigInstance(string name);
        Control CreateOverlayConfigControlInstance(IOverlay overlay);
    }
}
