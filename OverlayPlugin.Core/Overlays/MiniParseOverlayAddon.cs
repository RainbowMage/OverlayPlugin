using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    class MiniParseOverlayAddon : IOverlayAddon
    {
        public string Name
        {
            get { return "Mini Parse"; }
        }

        public string Description
        {
            get { return ""; }
        }

        public Type OverlayType
        {
            get { return typeof(MiniParseOverlay); }
        }

        public Type OverlayConfigType
        {
            get { return typeof(MiniParseOverlayConfig); }
        }

        public Type OverlayConfigControlType
        {
            get { return typeof(MiniParseConfigPanel); }
        }

        public IOverlay CreateOverlayInstance(IOverlayConfig config)
        {
            return new MiniParseOverlay((MiniParseOverlayConfig)config);
        }

        public IOverlayConfig CreateOverlayConfigInstance(string name)
        {
            return new MiniParseOverlayConfig(name);
        }

        public System.Windows.Forms.Control CreateOverlayConfigControlInstance(IOverlay overlay)
        {
            return new MiniParseConfigPanel((MiniParseOverlay)overlay);
        }

        public void Dispose()
        {
            
        }
    }
}
