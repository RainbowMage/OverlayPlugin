using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class OverlayTypeManager
    {
        public delegate IOverlay OverlayFactoryDelegate(OverlayConfigBase config);
        public delegate OverlayConfigBase OverlayConfigFactoryDelegate(string name);
        public delegate System.Windows.Forms.Control OverlayConfigControlFactoryDelegate(IOverlay overlay);

        internal Dictionary<Type, string> OverlayNameDict = new Dictionary<Type, string>();

        // オーバーレイ型からコンフィグ型への変換辞書（TOverlay => TConfig）
        internal Dictionary<Type, Type> OverlayToConfigDict = new Dictionary<Type, Type>();

        // コンフィグ型からオーバーレイ型への変換辞書（TConfig => TOverlay）
        internal Dictionary<Type, Type> ConfigToOverlayDict = new Dictionary<Type, Type>();

        // オーバーレイのファクトリ辞書（TOverlay => OverlayFactory）
        internal Dictionary<Type, OverlayFactoryDelegate> OverlayFactories = new Dictionary<Type, OverlayFactoryDelegate>();

        // コンフィグのファクトリ辞書（TConfig => ConfigFactory）
        internal Dictionary<Type, OverlayConfigFactoryDelegate> OverlayConfigFactories = new Dictionary<Type, OverlayConfigFactoryDelegate>();

        // 設定パネルの型（TOverlay => TConfigControl）
        internal Dictionary<Type, Type> OverlayToConfigControlDict = new Dictionary<Type, Type>();

        // 設定パネルのファクトリ辞書（TOverlay => ControlFactory）
        internal Dictionary<Type, OverlayConfigControlFactoryDelegate> OverlayConfigControlFactories = new Dictionary<Type, OverlayConfigControlFactoryDelegate>();

        public void Register<TOverlay, TConfig, TConfigControl>(
            string friendlyName,
            OverlayFactoryDelegate overlayFactory,
            OverlayConfigFactoryDelegate configFactory,
            OverlayConfigControlFactoryDelegate configControlFactory)
            where TOverlay : IOverlay
            where TConfig : OverlayConfigBase
            where TConfigControl : System.Windows.Forms.Control
        {
            OverlayNameDict.Add(typeof(TOverlay), friendlyName);
            OverlayToConfigDict.Add(typeof(TOverlay), typeof(TConfig));
            ConfigToOverlayDict.Add(typeof(TConfig), typeof(TOverlay));
            OverlayFactories.Add(typeof(TOverlay), overlayFactory);
            OverlayConfigFactories.Add(typeof(TConfig), configFactory);
            OverlayToConfigControlDict.Add(typeof(TOverlay), typeof(TConfigControl));
            OverlayConfigControlFactories.Add(typeof(TOverlay), configControlFactory);
        }

        public void Unregister<TOverlay>()
            where TOverlay : IOverlay
        {
            var configType = OverlayToConfigDict[typeof(TOverlay)];
            var configControlType = OverlayToConfigControlDict[typeof(TOverlay)];

            OverlayNameDict.Remove(typeof(TOverlay));
            OverlayToConfigDict.Remove(typeof(TOverlay));
            ConfigToOverlayDict.Remove(configType);
            OverlayFactories.Remove(typeof(TOverlay));
            OverlayConfigFactories.Remove(typeof(TOverlay));
            OverlayToConfigControlDict.Remove(typeof(TOverlay));
            OverlayConfigControlFactories.Remove(typeof(TOverlay));
        }

        public string GetFriendlyName(Type overlayType)
        {
            return OverlayNameDict[overlayType];
        }

        public Type GetConfigTypeFromOverlayType(Type overlayType)
        {
            return OverlayToConfigDict[overlayType];
        }

        public Type GetOverlayTypeFromConfigType(Type configType)
        {
            return ConfigToOverlayDict[configType];
        }

        public IOverlay CreateOverlayFromConfig(OverlayConfigBase config)
        {
            return OverlayFactories[ConfigToOverlayDict[config.GetType()]](config);
        }

        public OverlayConfigBase CreateOverlayConfig<T>(string name)
            where T : OverlayConfigBase
        {
            return OverlayConfigFactories[typeof(T)](name);
        }

        public OverlayConfigBase CreateOverlayConfigOf(Type overlayType, string name)
        {
            return OverlayConfigFactories[GetConfigTypeFromOverlayType(overlayType)](name);
        }

        public System.Windows.Forms.Control CreateOverlayConfigControl(IOverlay overlay)
        {
            return OverlayConfigControlFactories[overlay.GetType()](overlay);
        }
    }
}
