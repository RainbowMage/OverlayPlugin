using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    /// <summary>
    /// OverlayPlugin のアドオンに必要な機能を定義します。
    /// このインターフェイスを実装したクラスを含むアセンブリを addon フォルダに配置すると、自動的にアドオンとして認識されます。
    /// </summary>
    public interface IOverlayAddon : IDisposable
    {
        /// <summary>
        /// アドオンで追加されるオーバーレイの名前を取得します。
        /// </summary>
        string Name { get; }
        /// <summary>
        /// アドオンで追加されるオーバーレイの説明文を取得します。
        /// </summary>
        string Description { get; }
        /// <summary>
        /// アドオンで追加されるオーバーレイの型を取得します。
        /// </summary>
        Type OverlayType { get; }
        /// <summary>
        /// アドオンで追加されるオーバーレイに対応する設定クラスの型を取得します。
        /// </summary>
        Type OverlayConfigType { get; }
        /// <summary>
        /// アドオンで追加されるオーバーレイに対応する設定 UI の型を取得します。
        /// </summary>
        Type OverlayConfigControlType { get; }
        /// <summary>
        /// オーバーレイのインスタンスを作成します。
        /// </summary>
        /// <param name="config">
        ///     CreateOverlayConfigInstance メソッドまたは XmlSerializer クラスにより生成された 
        ///     IOverlayConfig インスタンス。</param>
        /// <returns></returns>
        IOverlay CreateOverlayInstance(IOverlayConfig config);
        /// <summary>
        /// オーバーレイの設定クラスのインスタンスを作成します。
        /// </summary>
        /// <param name="name">ユーザーが設定したオーバーレイの名前。</param>
        /// <returns></returns>
        IOverlayConfig CreateOverlayConfigInstance(string name);
        /// <summary>
        /// オーバーレイの設定を行う UI のインスタンスを作成します。
        /// </summary>
        /// <param name="overlay">CreateOverlayInstance メソッドにより作成された IOverlay インスタンス。</param>
        /// <returns></returns>
        Control CreateOverlayConfigControlInstance(IOverlay overlay);
    }
}
