using RainbowMage.OverlayPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalOverlayTest
{
    public class ExternalOverlayConfig : OverlayConfig
    {
        public ExternalOverlayConfig(string name)
            : base(name)
        {

        }

        private ExternalOverlayConfig() : base(null)
        {

        }
    }
}
