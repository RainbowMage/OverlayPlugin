using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    class SpellTimerOverlayAddon : IOverlayAddon
    {
        public string Name
        {
            get { return "Spell Timer"; }
        }

        public string Description
        {
            get { return ""; }
        }

        public Type OverlayType
        {
            get { return typeof(SpellTimerOverlay); }
        }

        public Type OverlayConfigType
        {
            get { return typeof(SpellTimerOverlayConfig); }
        }

        public Type OverlayConfigControlType
        {
            get { return typeof(SpellTimerConfigPanel); }
        }

        public IOverlay CreateOverlayInstance(IOverlayConfig config)
        {
            return new SpellTimerOverlay((SpellTimerOverlayConfig)config);
        }

        public IOverlayConfig CreateOverlayConfigInstance(string name)
        {
            return new SpellTimerOverlayConfig(name);
        }

        public System.Windows.Forms.Control CreateOverlayConfigControlInstance(IOverlay overlay)
        {
            return new SpellTimerConfigPanel((SpellTimerOverlay)overlay);
        }

        public void Dispose()
        {

        }
    }
}
