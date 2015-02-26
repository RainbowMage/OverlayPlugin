using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public static class OverlayTypeManager
    {
        public delegate IOverlay OverlayFactoryDelegate(OverlayConfig config);
        public delegate OverlayConfig OverlayConfigFactoryDelegate(string name);
        public delegate System.Windows.Forms.Control OverlayConfigControlFactoryDelegate(IOverlay overlay);


        // オーバーレイ型からコンフィグ型への変換辞書（TOverlay => TConfig）
        internal static Dictionary<Type, Type> OverlayToConfigDict = new Dictionary<Type, Type>();

        // コンフィグ型からオーバーレイ型への変換辞書（TConfig => TOverlay）
        internal static Dictionary<Type, Type> ConfigToOverlayDict = new Dictionary<Type, Type>();

        // オーバーレイのファクトリ辞書（TOverlay => OverlayFactory）
        internal static Dictionary<Type, OverlayFactoryDelegate> OverlayFactories = new Dictionary<Type, OverlayFactoryDelegate>();

        // コンフィグのファクトリ辞書（TConfig => ConfigFactory）
        internal static Dictionary<Type, OverlayConfigFactoryDelegate> OverlayConfigFactories = new Dictionary<Type, OverlayConfigFactoryDelegate>();

        // 設定パネルの型（TOverlay => TConfigControl）
        internal static Dictionary<Type, Type> OverlayToConfigControlDict = new Dictionary<Type, Type>();

        // 設定パネルのファクトリ辞書（TOverlay => ControlFactory）
        internal static Dictionary<Type, OverlayConfigControlFactoryDelegate> OverlayConfigControlFactories = new Dictionary<Type, OverlayConfigControlFactoryDelegate>();

        public static void RegisterOverlayType<TOverlay, TConfig, TConfigControl>(
            OverlayFactoryDelegate overlayFactory,
            OverlayConfigFactoryDelegate configFactory,
            OverlayConfigControlFactoryDelegate configControlFactory)
            where TOverlay : IOverlay
            where TConfig : OverlayConfig
            where TConfigControl : System.Windows.Forms.Control
        {
            OverlayToConfigDict.Add(typeof(TOverlay), typeof(TConfig));
            ConfigToOverlayDict.Add(typeof(TConfig), typeof(TOverlay));
            OverlayFactories.Add(typeof(TOverlay), overlayFactory);
            OverlayConfigFactories.Add(typeof(TConfig), configFactory);
            OverlayToConfigControlDict.Add(typeof(TOverlay), typeof(TConfigControl));
            OverlayConfigControlFactories.Add(typeof(TOverlay), configControlFactory);
        }

        public static Type GetConfigTypeFromOverlayType(Type overlayType)
        {
            return OverlayToConfigDict[overlayType];
        }

        public static Type GetOverlayTypeFromConfigType(Type configType)
        {
            return ConfigToOverlayDict[configType];
        }

        public static IOverlay CreateOverlayFromConfig(OverlayConfig config)
        {
            return OverlayFactories[ConfigToOverlayDict[config.GetType()]](config);
        }

        public static OverlayConfig CreateOverlayConfig<T>(string name)
            where T : OverlayConfig
        {
            return OverlayConfigFactories[typeof(T)](name);
        }

        public static OverlayConfig CreateOverlayConfigOf(Type overlayType, string name)
        {
            return OverlayConfigFactories[GetConfigTypeFromOverlayType(overlayType)](name);
        }

        public static System.Windows.Forms.Control CreateOverlayConfigControl(IOverlay overlay)
        {
            return OverlayConfigControlFactories[overlay.GetType()](overlay);
        }
    }
}
