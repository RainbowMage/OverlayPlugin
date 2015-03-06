using RainbowMage.OverlayPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalOverlayTest
{
    public class ExternalOverlay : OverlayBase<ExternalOverlayConfig>
    {
        public ExternalOverlay(ExternalOverlayConfig config)
            : base(config, config.Name)
        {
            Navigate("http://www.yahoo.com/");
        }

        protected override void Update()
        {
            
        }
    }
}
