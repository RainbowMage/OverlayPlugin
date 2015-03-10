using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    [Serializable]
    public class SpellTimerOverlayConfig : OverlayConfigBase
    {
        public SpellTimerOverlayConfig(string name) : base(name)
        {

        }

        // XmlSerializer用
        private SpellTimerOverlayConfig() : base(null)
        {

        }

        public override Type OverlayType
        {
            get { return typeof(SpellTimerOverlay); }
        }
    }
}
