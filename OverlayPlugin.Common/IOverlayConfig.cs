using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    /// <summary>
    /// <see cref="RainbowMage.OverlayPlugin.IOverlay"/> の設定に必要なプロパティを定義します。
    /// </summary>
    /// <remarks>
    /// アドオンを作成する場合はこのインターフェイスを実装するのではなく、
    /// <see cref="RainbowMage.OverlayPlugin.OverlayConfigBase"/> 抽象クラスを継承してください。
    /// </remarks>
    public interface IOverlayConfig
    {
        string Name { get; set; }
        bool IsVisible { get; set; }
        bool IsClickThru { get; set; }
        Point Position { get; set; }
        Size Size { get; set; }
        string Url { get; set; }
        int MaxFrameRate { get; set; }
        bool GlobalHotkeyEnabled { get; set; }
        Keys GlobalHotkey { get; set; }
        Keys GlobalHotkeyModifiers { get; set; }

        // IOverlayConfig 実装型 → IOverlay 実装型の逆引き用
        Type OverlayType { get; }
    }
}
