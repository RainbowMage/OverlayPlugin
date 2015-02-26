using Advanced_Combat_Tracker;
using RainbowMage.OverlayPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalOverlayTest
{
    public class PluginMain : IActPluginV1
    {
        public void DeInitPlugin()
        {
            
        }

        public void InitPlugin(System.Windows.Forms.TabPage pluginScreenSpace, System.Windows.Forms.Label pluginStatusText)
        {
            OverlayTypeManager.RegisterOverlayType<ExternalOverlay, ExternalOverlayConfig, ExternalOverlayConfigPanel>(
                (config) => new ExternalOverlay(config as ExternalOverlayConfig),
                (name) => new ExternalOverlayConfig(name),
                (overlay) => new ExternalOverlayConfigPanel()
                );
        }
    }
}
