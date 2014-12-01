using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    class SpellTimerOverlay : OverlayBase<OverlayConfig>
    {
        protected override OverlayConfig Config
        {
            get { throw new NotImplementedException(); }
        }

        public SpellTimerOverlay(PluginMain pluginMain)
            : base(pluginMain, "SpellTimerOverlay")
        {

        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
