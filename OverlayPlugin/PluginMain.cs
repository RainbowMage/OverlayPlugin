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
    public class PluginMain : IActPluginV1
    {
        TabPage tabPage;
        Label label;
        ControlPanel controlPanel;

        string pluginDirectory;

        internal PluginConfig Config { get; private set; }
        internal List<IOverlay> Overlays { get; private set; }
        internal BindingList<LogEntry> Logs { get; private set; }

        public PluginMain()
        {
            this.Logs = new BindingList<LogEntry>();
        }

        static PluginMain()
        {
            RegisterOurOverlayTypes();
        }

        private static void RegisterOurOverlayTypes()
        {
            OverlayTypeManager.RegisterOverlayType<MiniParseOverlay, MiniParseOverlayConfig, MiniParseConfigPanel>(
                "Mini Parse",
                (config) => new MiniParseOverlay(config as MiniParseOverlayConfig),
                (name) => new MiniParseOverlayConfig(name),
                (overlay) => new MiniParseConfigPanel(overlay as MiniParseOverlay)
                );

            OverlayTypeManager.RegisterOverlayType<SpellTimerOverlay, SpellTimerOverlayConfig, SpellTimerConfigPanel>(
                "Spell Timer",
                (config) => new SpellTimerOverlay(config as SpellTimerOverlayConfig),
                (name) => new SpellTimerOverlayConfig(name),
                (overlay) => new SpellTimerConfigPanel(overlay as SpellTimerOverlay)
                );
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            try
            {
                this.tabPage = pluginScreenSpace;
                this.label = pluginStatusText;

#if DEBUG
                Log(LogLevel.Warning, "##################################");
                Log(LogLevel.Warning, "    THIS IS THE DEBUG BUILD");
                Log(LogLevel.Warning, "##################################");
#endif

                this.pluginDirectory = GetPluginDirectory();
                Log(LogLevel.Info, "InitPlugin: PluginDirectory = {0}", this.pluginDirectory);

                // プラグインの配置してあるフォルダを検索するカスタムリゾルバーでアセンブリを解決する
                AppDomain.CurrentDomain.AssemblyResolve += CustomAssemblyResolve;

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

                // オーバーレイ初期化
                this.Overlays = new List<IOverlay>();
                foreach (var overlayConfig in this.Config.Overlays)
                {
                    var overlay = OverlayTypeManager.CreateOverlayFromConfig(overlayConfig);
                    RegisterOverlay(overlay);
                }

                // コンフィグUI系初期化
                this.controlPanel = new ControlPanel(this, this.Config);
                this.controlPanel.Dock = DockStyle.Fill;
                this.tabPage.Controls.Add(this.controlPanel);

                Log(LogLevel.Info, "InitPlugin: Initialized.");
                this.label.Text = "Initialized.";
            }
            catch (Exception e)
            {
                Log(LogLevel.Error, "InitPlugin: {0}", e.ToString());
                MessageBox.Show(e.ToString());

                throw;
            }
        }

        public void RegisterOverlay(IOverlay overlay)
        {
            overlay.OnLog += (o, e) => Log(e.Level, e.Message);
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

            AppDomain.CurrentDomain.AssemblyResolve -= CustomAssemblyResolve;

            Log(LogLevel.Info, "DeInitPlugin: Finalized.");
            this.label.Text = "Finalized.";
        }

        static readonly Regex assemblyNameParser = new Regex(
            @"(?<name>.+?), Version=(?<version>.+?), Culture=(?<culture>.+?), PublicKeyToken=(?<pubkey>.+)", 
            RegexOptions.Compiled);

        private Assembly CustomAssemblyResolve(object sender, ResolveEventArgs e)
        {
            Log(LogLevel.Debug, "AssemblyResolve: Resolving assembly for '{0}'...", e.Name);

            // 自分自身の解決が必要なときは、Assembly.GetExecutingAssembly() を返す
            if (e.Name == Assembly.GetExecutingAssembly().FullName)
            {
                Log(LogLevel.Debug, "AssemblyResolve: => Returns executing assembly.");
                return Assembly.GetExecutingAssembly();
            }

            // それ以外のときは、プラグインのディレクトリを基準にアセンブリを検索する
            var asmPath = "";
            var match = assemblyNameParser.Match(e.Name);
            if (match.Success)
            {
                var asmFileName = match.Groups["name"].Value + ".dll";
                if (match.Groups["culture"].Value == "neutral")
                {
                    asmPath = Path.Combine(pluginDirectory, asmFileName);
                }
                else
                {
                    asmPath = Path.Combine(pluginDirectory, match.Groups["culture"].Value, asmFileName);
                }
            }
            else
            {
                asmPath = Path.Combine(pluginDirectory, e.Name + ".dll");
            }

            if (File.Exists(asmPath))
            {
                return LoadAssembly(asmPath);
            }

            Log(LogLevel.Debug, "AssemblyResolve: => Not found in the plugin directory.");
            return null;
        }

        private Assembly LoadAssembly(string path)
        {
            try
            {
                var result = Assembly.LoadFile(path);
                Log(LogLevel.Debug, "LoadAssembly: => Loaded successfully: {0}.", path);
                return result;
            }
            catch (FileLoadException ex)
            {
                var message = string.Format(
                    Localization.GetText(TextItem.RequiredAssemblyFileCannotRead),
                    path
                    );
                Log(LogLevel.Error, "LoadAssembly: => {0}", message);
                Log(LogLevel.Error, "LoadAssembly: => {0}", ex);
                MessageBox.Show(message, Localization.GetText(TextItem.ErrorTitle), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException ex)
            {
                var message = string.Format(
                    Localization.GetText(TextItem.RequiredAssemblyFileBlocked),
                    path
                    );
                Log(LogLevel.Error, "LoadAssembly: => {0}", message);
                Log(LogLevel.Error, "LoadAssembly: => {0}", ex);
                MessageBox.Show(message, Localization.GetText(TextItem.ErrorTitle), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var message = string.Format(
                    Localization.GetText(TextItem.RequiredAssemblyFileException),
                    path
                    );
                Log(LogLevel.Error, "LoadAssembly: => {0}", ex);
                MessageBox.Show(message, Localization.GetText(TextItem.ErrorTitle), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        void LoadAddons()
        {
            try
            {
                // <プラグイン本体があるディレクトリ>\plugins\*.dll を検索する
                var directory = Path.Combine(pluginDirectory, "addons");
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                foreach (var pluginFile in Directory.GetFiles(directory, "*.dll"))
                {
                    try
                    {
                        Log(LogLevel.Info, "LoadAddons: {0}", pluginFile);

                        // アセンブリが見つかったら読み込む
                        var asm = LoadAssembly(pluginFile);

                        // IOverlayAddon を実装した public クラスを列挙し...
                        var types = asm.GetExportedTypes().Where(t =>
                                t.GetInterface(typeof(IOverlayAddon).FullName) != null && t.IsClass);
                        foreach (var type in types)
                        {
                            try
                            {
                                if (type.GetInterface(typeof(IOverlayAddon).FullName) != null)
                                {
                                    // 各クラスの静的コンストラクタを呼び出す
                                    System.Runtime.CompilerServices.
                                        RuntimeHelpers.RunClassConstructor(type.TypeHandle);
                                    Log(LogLevel.Info, "LoadAddons: {0}: Loaded", type.FullName);
                                }
                            }
                            catch (Exception e)
                            {
                                Log(LogLevel.Error, "LoadAddons: {0}: {1}", type.FullName, e);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log(LogLevel.Error, "LoadAddons: {0}: {1}", pluginFile, e);
                    }
                }
            }
            catch (Exception e)
            {
                Log(LogLevel.Error, "LoadAddons: {0}", e);
            }
        }

        private void LoadConfig()
        {
            try
            {
                Config = PluginConfig.LoadXml(GetConfigPath());
            }
            catch (Exception e)
            {
                // 設定ファイルが存在しない、もしくは破損している場合は作り直す
                Log(LogLevel.Warning, "LoadConfig: {0}", e);
                Log(LogLevel.Info, "LoadConfig: Creating new configuration.");
                Config = new PluginConfig();
                Config.SetDefaultOverlayConfigs();
            }
            finally
            {
                // デフォルトオーバーレイの URL が空の場合はデフォルトの URL を設定する
                var defaultMiniParse = Config.Overlays.FirstOrDefault(x => x.Name == PluginConfig.DefaultMiniParseOverlayName);
                var defaultSpellTimer = Config.Overlays.FirstOrDefault(x => x.Name == PluginConfig.DefaultSpellTimerOverlayName);

                if (defaultMiniParse != null && 
                    string.IsNullOrEmpty(defaultMiniParse.Url))
                {
                    defaultMiniParse.Url =
                        new Uri(Path.Combine(pluginDirectory, "resources", "miniparse.html")).ToString();
                }
                if (defaultSpellTimer != null && 
                    string.IsNullOrEmpty(defaultSpellTimer.Url))
                {
                    defaultSpellTimer.Url =
                        new Uri(Path.Combine(pluginDirectory, "resources", "spelltimer.html")).ToString();
                }
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

                Config.SaveXml(GetConfigPath());
            }
            catch (Exception e)
            {
                Log(LogLevel.Error, "SaveConfig: {0}", e);
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

        private string GetPluginDirectory()
        {
            // ACT のプラグインリストからパスを取得する
            // Assembly.LoadFrom(byte[]) で読み込まれているので、CodeBase からはパスを取得できない
            var plugin = ActGlobals.oFormActMain.ActPlugins.Where(x => x.pluginObj == this).FirstOrDefault();
            if (plugin != null)
            {
                return System.IO.Path.GetDirectoryName(plugin.pluginFile.FullName);
            }
            else
            {
                throw new Exception();
            }
        }

        internal void Log(LogLevel level, string message)
        {
#if !DEBUG
            if (level == LogLevel.Trace || level == LogLevel.Debug)
            {
                return;
            }
#endif
#if DEBUG
            System.Diagnostics.Trace.WriteLine(string.Format("{0}: {1}: {2}", level, DateTime.Now, message));
#endif

            this.Logs.Add(new LogEntry(level, DateTime.Now, message));
        }

        internal void Log(LogLevel level, string format, params object[] args)
        {
            Log(level, string.Format(format, args));
        }
    }

    internal class LogEntry
    {
        public string Message { get; set; }
        public LogLevel Level { get; set; }
        public DateTime Time { get; set; }

        public LogEntry(LogLevel level, DateTime time, string message)
        {
            this.Message = message;
            this.Level = level;
            this.Time = time;
        }
    }

    public enum LogLevel
    {
        Trace,
        Debug,
        Info,
        Warning,
        Error
    }
}
