using Advanced_Combat_Tracker;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using RainbowMage.HtmlRenderer;
using System;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using RainbowMage.OverlayPlugin.Overlays;

namespace RainbowMage.OverlayPlugin
{
    public class PluginMain
    {
        TabPage tabPage;
        Label label;
        ControlPanel controlPanel;

        internal PluginConfig Config { get; private set; }
        internal List<IOverlay> Overlays { get; private set; }
        internal List<IOverlayAddon> Addons { get; set; }
        internal Logger Logger { get; set; }
        internal string PluginDirectory { get; private set; }

        public PluginMain(string pluginDirectory)
        {
            this.PluginDirectory = pluginDirectory;
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            try
            {
                this.Logger = new Logger();

                this.tabPage = pluginScreenSpace;
                this.label = pluginStatusText;

#if DEBUG
                Logger.Log(LogLevel.Warning, "##################################");
                Logger.Log(LogLevel.Warning, "    THIS IS THE DEBUG BUILD");
                Logger.Log(LogLevel.Warning, "##################################");
#endif

                Logger.Log(LogLevel.Info, "InitPlugin: PluginDirectory = {0}", this.PluginDirectory);


                // プラグイン読み込み
                LoadAddons();

                // コンフィグ系読み込み
                LoadConfig();

                // ACT 終了時に CEF をシャットダウン（ゾンビ化防止）
                Application.ApplicationExit += (o, e) =>
                {
                    try { Renderer.Shutdown(); }
                    catch { }
                };

                InitializeOverlays();

                // コンフィグUI系初期化
                this.controlPanel = new ControlPanel(this, this.Config);
                this.controlPanel.Dock = DockStyle.Fill;
                this.tabPage.Controls.Add(this.controlPanel);

                Logger.Log(LogLevel.Info, "InitPlugin: Initialized.");
                this.label.Text = "Initialized.";
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, "InitPlugin: {0}", e.ToString());
                MessageBox.Show(e.ToString());

                throw;
            }
        }

        private void InitializeOverlays()
        {
            // オーバーレイ初期化
            this.Overlays = new List<IOverlay>();
            foreach (var overlayConfig in this.Config.Overlays)
            {
                var addon = this.Addons.FirstOrDefault(x => x.OverlayType == overlayConfig.OverlayType);
                if (addon != null)
                {
                    var overlay = addon.CreateOverlayInstance(overlayConfig);
                    RegisterOverlay(overlay);
                }
                else
                {
                    Logger.Log(LogLevel.Error, "InitPlugin: Could not find addon for {0}.", overlayConfig.Name);
                }
            }
        }

        public void RegisterOverlay(IOverlay overlay)
        {
            overlay.OnLog += (o, e) => Logger.Log(e.Level, e.Message);
            overlay.Start();
            this.Overlays.Add(overlay);
        }

        public void RemoveOverlay(IOverlay overlay)
        {
            overlay.Dispose();
            this.Overlays.Remove(overlay);
        }

        public void DeInitPlugin()
        {
            SaveConfig();

            foreach (var overlay in this.Overlays)
            {
                overlay.Dispose();
            }

            foreach (var addon in this.Addons)
            {
                addon.Dispose();
            }

            Logger.Log(LogLevel.Info, "DeInitPlugin: Finalized.");
            this.label.Text = "Finalized.";
        }

        void LoadAddons()
        {
            try
            {
                // <プラグイン本体があるディレクトリ>\plugins\*.dll を検索する
                var directory = Path.Combine(PluginDirectory, "addons");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                this.Addons = new List<IOverlayAddon>();

                // 内蔵アドオンを追加
                this.Addons.Add(new MiniParseOverlayAddon());
                this.Addons.Add(new SpellTimerOverlayAddon());

                var version = typeof(PluginMain).Assembly.GetName().Version;

                foreach (var pluginFile in Directory.GetFiles(directory, "*.dll"))
                {
                    try
                    {
                        Logger.Log(LogLevel.Info, "LoadAddons: {0}", pluginFile);

                        // アセンブリが見つかったら読み込む
                        var asm = Assembly.LoadFrom(pluginFile);

                        // アセンブリから IOverlayAddon を実装した public クラスを列挙し...
                        var types = asm.GetExportedTypes().Where(t => 
                                t.GetInterface(typeof(IOverlayAddon).FullName) != null && t.IsClass);
                        foreach (var type in types)
                        {
                            try
                            {
                                // プラグインのインスタンスを生成し、アドオンリストに追加する
                                var addon = (IOverlayAddon)asm.CreateInstance(type.FullName);
                                this.Addons.Add(addon);

                                Logger.Log(LogLevel.Info, "LoadAddons: {0}: Initialized", type.FullName);
                            }
                            catch (Exception e)
                            {
                                Logger.Log(LogLevel.Error, "LoadAddons: {0}: {1}", type.FullName, e);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.Log(LogLevel.Error, "LoadAddons: {0}: {1}", pluginFile, e);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, "LoadAddons: {0}", e);
            }
        }

        private void LoadConfig()
        {
            try
            {
                Config = PluginConfig.LoadXml(this.PluginDirectory, GetConfigPath());
            }
            catch (Exception e)
            {
                // 設定ファイルが存在しない、もしくは破損している場合は作り直す
                Logger.Log(LogLevel.Warning, "LoadConfig: {0}", e);
                Logger.Log(LogLevel.Info, "LoadConfig: Creating new configuration.");
                Config = new PluginConfig();
                Config.SetDefaultOverlayConfigs(this.PluginDirectory);
            }
        }

        private void SaveConfig()
        {
            try
            {
                foreach (var overlay in this.Overlays)
                {
                    overlay.SavePositionAndSize();
                }

                Config.SaveXml(this.PluginDirectory, GetConfigPath());
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error, "SaveConfig: {0}", e);
            }
        }

        private static string GetConfigPath()
        {
            var path = System.IO.Path.Combine(
                ActGlobals.oFormActMain.AppDataFolder.FullName,
                "Config",
                "RainbowMage.OverlayPlugin.config.xml");

            return path;
        }
    }
}
