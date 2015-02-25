using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    [Serializable]
    public class SpellTimerOverlayConfig : OverlayConfig
    {
        public SpellTimerOverlayConfig(string name) : base(name)
        {

        }

        // XmlSerializer用
        private SpellTimerOverlayConfig() : base(null)
        {

        }
    }
}
