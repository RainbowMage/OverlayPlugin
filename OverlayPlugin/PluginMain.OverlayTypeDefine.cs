using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public partial class PluginMain
    {
        public delegate IOverlay OverlayFactoryDelegate(OverlayConfig config);
        public delegate OverlayConfig OverlayConfigFactoryDelegate(string name);
        public delegate System.Windows.Forms.Control OverlayConfigControlFactoryDelegate(IOverlay overlay);

        // コンフィグ型からオーバーレイ型への変換辞書（TConfig => TOverlay）
        public static Dictionary<Type, Type> OverlayConfigTypeTable = new Dictionary<Type, Type>();

		// オーバーレイのファクトリ辞書（TOverlay => OverlayFactory）
        public static Dictionary<Type, OverlayFactoryDelegate> OverlayFactories = new Dictionary<Type, OverlayFactoryDelegate>();

		// コンフィグのファクトリ辞書（TConfig => ConfigFactory）
        public static Dictionary<Type, OverlayConfigFactoryDelegate> OverlayConfigFactories = new Dictionary<Type, OverlayConfigFactoryDelegate>();

		// 設定パネルの型（TOverlay => TConfigControl）
        public static Dictionary<Type, Type> OverlayConfigControlDict = new Dictionary<Type, Type>();

		// 設定パネルのファクトリ辞書（TOverlay => ControlFactory）
		public static Dictionary<Type, OverlayConfigControlFactoryDelegate> OverlayConfigControlFactories = new Dictionary<Type,OverlayConfigControlFactoryDelegate>();

		private static void RegisterOurOverlayTypes()
        {
            RegisterOverlayType<MiniParseOverlay, MiniParseOverlayConfig, MiniParseConfigPanel>(
                (config) => new MiniParseOverlay(config as MiniParseOverlayConfig),
                (name) => new MiniParseOverlayConfig(name),
				(overlay) => new MiniParseConfigPanel(overlay as MiniParseOverlay)
                );

            RegisterOverlayType<SpellTimerOverlay, SpellTimerOverlayConfig, SpellTimerConfigPanel>(
                (config) => new SpellTimerOverlay(config as SpellTimerOverlayConfig),
                (name) => new SpellTimerOverlayConfig(name),
                (overlay) => new SpellTimerConfigPanel(overlay as SpellTimerOverlay)
                );
        }

		public static void RegisterOverlayType<TOverlay, TConfig, TConfigControl>(
            OverlayFactoryDelegate overlayFactory,
            OverlayConfigFactoryDelegate configFactory,
            OverlayConfigControlFactoryDelegate configControlFactory)
			where TOverlay: IOverlay
			where TConfig: OverlayConfig
			where TConfigControl: System.Windows.Forms.Control
        {
            OverlayConfigTypeTable.Add(typeof(TConfig), typeof(TOverlay));
            OverlayFactories.Add(typeof(TOverlay), overlayFactory);
            OverlayConfigFactories.Add(typeof(TConfig), configFactory);
            OverlayConfigControlDict.Add(typeof(TOverlay), typeof(TConfigControl));
            OverlayConfigControlFactories.Add(typeof(TOverlay), configControlFactory);
        }

        public static IOverlay CreateOverlayFromConfig(OverlayConfig config)
        {
            return OverlayFactories[OverlayConfigTypeTable[config.GetType()]](config);
        }

		public static OverlayConfig CreateOverlayConfig<T>(string name)
			where T: OverlayConfig
        {
            return PluginMain.OverlayConfigFactories[typeof(T)](name);
        }

		public static System.Windows.Forms.Control CreateOverlayConfigControl(IOverlay overlay)
        {
            return OverlayConfigControlFactories[overlay.GetType()](overlay);
        }
    }
}
