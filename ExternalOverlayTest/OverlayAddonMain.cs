using RainbowMage.OverlayPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalOverlayTest
{
    public class OverlayAddonMain : IOverlayAddon
    {
        // IOverlayAddon を実装したクラスの静的コンストラクタの中で、オーバーレイの型を登録する
        static OverlayAddonMain()
        {
            OverlayTypeManager.RegisterOverlayType<
                ExternalOverlay,
                ExternalOverlayConfig,
                ExternalOverlayConfigPanel>(
                "External Overlay",
                (config) => new ExternalOverlay(config as ExternalOverlayConfig),
                (name) => new ExternalOverlayConfig(name),
                (overlay) => new ExternalOverlayConfigPanel()
                );
        }
    }
}
