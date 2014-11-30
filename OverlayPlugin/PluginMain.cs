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

namespace RainbowMage.OverlayPlugin
{
    public class PluginMain : IActPluginV1
    {
        TabPage tabPage;
        Label label;
        ControlPanel controlPanel;

        PluginConfig config;
        System.Timers.Timer timer;
        bool isFirstLaunch;

        string pluginDirectory;

        internal OverlayForm Overlay { get; private set; }
        internal BindingList<string> Logs { get; private set; }

        public PluginMain()
        {
            this.Logs = new BindingList<string>();

            // プラグインの配置してあるフォルダを検索するカスタムリゾルバーでアセンブリを解決する
            SetupAssemblyResolver();
        }

        static readonly Dictionary<string, string> assemblyTable = new Dictionary<string,string>
        {
            { "HtmlRenderer,", "HtmlRenderer.dll" },
            { "Xilium.CefGlue,", "Xilium.CefGlue.dll" }
        };

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            this.tabPage = pluginScreenSpace;
            this.label = pluginStatusText;

            this.pluginDirectory = GetPluginDirectory();
            Log("Info: InitPlugin: PluginDirectory = {0}", this.pluginDirectory);

            // コンフィグ系読み込み
            LoadConfig();
            this.controlPanel = new ControlPanel(this, this.config);
            this.controlPanel.Dock = DockStyle.Fill;
            this.tabPage.Controls.Add(this.controlPanel);

            try
            {
                // ACT 終了時に CEF をシャットダウン（ゾンビ化防止）
                Application.ApplicationExit += (o, e) =>
                {
                    try { Renderer.Shutdown(); }
                    catch { }
                };

                InitializeOverlay();
                InitializeTimer();
                InitializeConfigHandlers();

                Log("Info: InitPlugin: Initialized.");
                this.label.Text = "Initialized.";
            }
            catch (Exception e)
            {
                Log("Error: InitPlugin: {0}", e.ToString());
            }
        }

        private void InitializeOverlay()
        {
            var uri = new System.Uri(config.Url);

            // ローカルファイルの場合はファイルが存在するかチェックし、存在しなければ警告を出力
            if (uri.Scheme == "file")
            {
                if (!File.Exists(uri.LocalPath))
                {
                    Log("Warn: InitializeOverlay: Local file {0} is not exist!", uri.LocalPath);
                }
            }

            this.Overlay = new OverlayForm(uri.AbsoluteUri);

            // 初回起動または画面外にウィンドウがある場合は、初期表示位置をシステムに設定させる
            if (!isFirstLaunch)
            {
                this.Overlay.Location = config.OverlayPosition;
                if (!IsOnScreen(this.Overlay))
                {
                    this.Overlay.StartPosition = FormStartPosition.WindowsDefaultLocation;
                }
            }
            else
            {
                this.Overlay.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }
            this.Overlay.Size = config.OverlaySize;
            this.Overlay.IsClickThru = config.IsClickThru;
            this.Overlay.Renderer.BrowserError += (o, e) =>
            {
                Log("Error: Browser: {0}, {1}, {2}", e.ErrorCode, e.ErrorText, e.Url);
            };
            this.Overlay.Renderer.BrowserLoad += (o, e) =>
            {
                Log("Info: Browser: {0}: {1}", e.HttpStatusCode, e.Url);
            };

            this.Overlay.Show();

            this.Overlay.Visible = this.config.IsVisible;
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (o, e) =>
            {
                try
                {
                    Update();
                }
                catch (Exception ex)
                {
                    Log("Error: Update: {0}", ex.ToString());
                }
            };
            timer.Start();
        }

        private void InitializeConfigHandlers()
        {
            this.config.VisibleChanged += (o, e) =>
            {
                this.Overlay.Visible = e.IsVisible;
            };

            this.config.ClickThruChanged += (o, e) =>
            {
                this.Overlay.IsClickThru = e.IsClickThru;
            };
        }

        public void DeInitPlugin()
        {
            SaveConfig();
            timer.Stop();
            this.Overlay.Close();

            Log("Info: DeInitPlugin: Finalized.");
            this.label.Text = "Finalized.";
        }

        private void SetupAssemblyResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (o, e) =>
            {
                Log("Info: AssemblyResolve: Resolving assembly for '{0}'...", e.Name);

                Assembly result = null;
                foreach (var pair in assemblyTable)
                {
                    if (e.Name.StartsWith(pair.Key))
                    {
                        try
                        {
                            var asmPath = System.IO.Path.Combine(pluginDirectory, pair.Value);
                            result = Assembly.LoadFile(asmPath);
                            Log("Info: AssemblyResolve: => Found assembly in {0}.", asmPath);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Log("Error: AssemblyResolve: => {0}", ex);
                            continue;
                        }
                    }
                }

                if (result == null)
                {
                    Log("Info: AssemblyResolve: => Not found in plugin directory.");
                }

                return result;
            };
        }

        private void Update()
        {
            var updateScript = GetUpdateScript();

            if (this.Overlay != null &&
                this.Overlay.Renderer != null &&
                this.Overlay.Renderer.Browser != null)
            {
                this.Overlay.Renderer.Browser.GetMainFrame().ExecuteJavaScript(updateScript, null, 0);
            }
        }

        internal string GetUpdateScript()
        {
            if (!CheckIsActReady())
            {
                return "";
            }

            var allies = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetAllies();

            var encounter = GetEncounterDictionary(allies);
            var combatant = GetCombatantList(allies);

            SortCombatantList(combatant);

            var builder = new StringBuilder();
            builder.Append("ActXiv = {");
            builder.Append("\"Encounter\": {");
            var isFirst1 = true;
            foreach (var pair in encounter)
            {
                if (isFirst1)
                {
                    isFirst1 = false;
                }
                else
                {
                    builder.Append(",");
                }
                builder.AppendFormat("\"{0}\":\"{1}\"", CleanUp(pair.Key), CleanUp(pair.Value));
            }
            builder.Append("},");
            builder.Append("\"Combatant\": {");
            var isFirst2 = true;
            foreach (var pair in combatant)
            {
                if (isFirst2)
                {
                    isFirst2 = false;
                }
                else
                {
                    builder.Append(",");
                }
                builder.AppendFormat("\"{0}\": {{", CleanUp(pair.Key.Name));
                var isFirst3 = true;
                foreach (var pair2 in pair.Value)
                {
                    if (isFirst3)
                    {
                        isFirst3 = false;
                    }
                    else
                    {
                        builder.Append(",");
                    }
                    builder.AppendFormat("\"{0}\":\"{1}\"", CleanUp(pair2.Key), CleanUp(pair2.Value));
                }
                builder.Append("}");
            }
            builder.Append("},");
            builder.AppendFormat("\"isActive\": {0}", ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active ? "true" : "false");
            builder.Append("};");

            return builder.ToString();
        }

        private void SortCombatantList(List<KeyValuePair<CombatantData, Dictionary<string, string>>> combatant)
        {
            if (config.SortType == SortType.NumericAscending ||
                config.SortType == SortType.NumericDescending)
            {
                combatant.Sort((x, y) =>
                {
                    int result = 0;
                    if (x.Value.ContainsKey(config.SortKey) &&
                        y.Value.ContainsKey(config.SortKey))
                    {
                        double xValue, yValue;
                        double.TryParse(x.Value[config.SortKey].Replace("%", ""), out xValue);
                        double.TryParse(y.Value[config.SortKey].Replace("%", ""), out yValue);

                        result = xValue.CompareTo(yValue);

                        if (config.SortType == SortType.NumericDescending)
                        {
                            result *= -1;
                        }
                    }

                    return result;
                });
            }
            else if (config.SortType == SortType.StringAscending ||
                config.SortType == SortType.StringDescending)
            {
                combatant.Sort((x, y) =>
                {
                    int result = 0;
                    if (x.Value.ContainsKey(config.SortKey) &&
                        y.Value.ContainsKey(config.SortKey))
                    {
                        result = x.Value[config.SortKey].CompareTo(y.Value[config.SortKey]);

                        if (config.SortType == SortType.StringDescending)
                        {
                            result *= -1;
                        }
                    }

                    return result;
                });
            }
        }

        private static List<KeyValuePair<CombatantData, Dictionary<string, string>>> GetCombatantList(List<CombatantData> allies)
        {
            var combatantList = new List<KeyValuePair<CombatantData, Dictionary<string, string>>>();
            foreach (var ally in allies)
            {
                var valueDict = new Dictionary<string, string>();
                foreach (var exportValuePair in CombatantData.ExportVariables)
                {
                    try
                    {
                        var value = exportValuePair.Value.GetExportString(ally, "");
                        valueDict.Add(exportValuePair.Key, value);
                    }
                    catch
                    {
                        continue;
                    }
                }
                combatantList.Add(new KeyValuePair<CombatantData, Dictionary<string, string>>(ally, valueDict));
            }
            return combatantList;
        }

        private static Dictionary<string, string> GetEncounterDictionary(List<CombatantData> allies)
        {
            var encounterDict = new Dictionary<string, string>();
            foreach (var exportValuePair in EncounterData.ExportVariables)
            {
                try
                {
                    var value = exportValuePair.Value.GetExportString(
                        ActGlobals.oFormActMain.ActiveZone.ActiveEncounter,
                        allies,
                        "");
                    encounterDict.Add(exportValuePair.Key, value);
                }
                catch
                {
                    continue;
                }
            }
            return encounterDict;
        }

        private string CleanUp(string str)
        {
            return str
                .Replace("\"", "\\\"")
                .Replace("'", "\\'")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace(double.NaN.ToString(), "---");
        }

        private bool CheckIsActReady()
        {
            if (ActGlobals.oFormActMain != null &&
                ActGlobals.oFormActMain.ActiveZone != null &&
                ActGlobals.oFormActMain.ActiveZone.ActiveEncounter != null &&
                EncounterData.ExportVariables != null &&
                CombatantData.ExportVariables != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoadConfig()
        {
            try
            {
                config = PluginConfig.LoadXml(GetConfigPath());
            }
            catch (Exception e)
            {
                Log("Error: LoadConfig: {0}", e);
                Log("Creating new config.");
                config = new PluginConfig();
                config.Url = new Uri(System.IO.Path.Combine(pluginDirectory, "resources", "default.html")).ToString();
                isFirstLaunch = true;
            }
        }

        private void SaveConfig()
        {
            try
            {
                config.OverlayPosition = this.Overlay.Location;
                config.OverlaySize = this.Overlay.Size;

                config.SaveXml(GetConfigPath());
            }
            catch (Exception e)
            {
                Log("Error: SaveConfig: {0}", e);
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

        private void Log(string format, params object[] args)
        {
            this.Logs.Add(DateTime.Now.ToString() + "|" + string.Format(format, args));
        }

        public bool IsOnScreen(Form form)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                Rectangle formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);

                if (screen.WorkingArea.IntersectsWith(formRectangle))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
