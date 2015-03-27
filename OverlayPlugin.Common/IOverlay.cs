using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    /// <summary>
    /// オーバーレイに必要な機能を定義します。
    /// </summary>
    /// <remarks>
    /// アドオンを作成する場合はこのインターフェイスを実装するのではなく、
    /// <see cref="RainbowMage.OverlayPlugin.OverlayBase"/> 抽象クラスを継承してください。
    /// </remarks>
    public interface IOverlay : IDisposable
    {
        /// <summary>
        /// ユーザーが設定したオーバーレイの名前を取得します。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// プラグインの設定を取得します。
        /// </summary>
        IPluginConfig PluginConfig { get; set; }

        /// <summary>
        /// オーバーレイがログを出力したときに発生します。
        /// </summary>
        event EventHandler<LogEventArgs> OnLog;

        /// <summary>
        /// オーバーレイの更新を開始します。
        /// </summary>
        void Start();

        /// <summary>
        /// オーバーレイの更新を停止します。
        /// </summary>
        void Stop();

        /// <summary>
        /// 指定した URL を表示します。
        /// </summary>
        /// <param name="url">表示する URL。</param>
        void Navigate(string url);

        /// <summary>
        /// オーバーレイの位置と大きさを保存します。
        /// </summary>
        void SavePositionAndSize();

        /// <summary>
        /// オーバーレイにメッセージを送信します。
        /// </summary>
        /// <param name="message">メッセージの内容。</param>
        void SendMessage(string message);
    }
}
