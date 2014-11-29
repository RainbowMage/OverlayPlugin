using Advanced_Combat_Tracker;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System;
using RainbowMage.HtmlRenderer;

namespace RainbowMage.OverlayPlugin
{
    public class PluginMain : IActPluginV1
    {
        TabPage tabPage;
        Label label;
        OverlayForm overlay;
        System.Timers.Timer timer;
        ListBox log;
        PluginConfig config;

        static readonly Dictionary<string, string> assemblyTable = new Dictionary<string,string>
        {
            { "HtmlRenderer", "HtmlRenderer.dll" },
            { "Xilium.CefGlue", "Xilium.CefGlue.dll" }
        };

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            try
            {
                this.tabPage = pluginScreenSpace;
                this.label = pluginStatusText;
                this.log = new ListBox();
                log.Dock = DockStyle.Fill;
                this.tabPage.Controls.Add(log);

                //ActGlobals.oFormActMain.KeyDown += (o, e) =>
                //{
                //    if (e.Control && e.KeyCode == Keys.O)
                //    {
                //        this.overlay.Visible = !this.overlay.Visible;
                //    }
                //};

                SetupAssemblyResolver();

                Application.ApplicationExit += (o, e) =>
                {
                    Renderer.Shutdown();
                };

                LoadConfig();

                var uri = new System.Uri(config.Url);
                this.overlay = new OverlayForm(uri.AbsoluteUri);
                this.overlay.Location = config.OverlayPosition;
                this.overlay.Size = config.OverlaySize;
                this.overlay.Show();

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

                Log("Initialized.");
                this.label.Text = "Initialized.";
            }
            catch (Exception e)
            {
                Log("Error: InitPlugin: {0}", e.ToString());
            }
        }

        public void DeInitPlugin()
        {
            SaveConfig();
            timer.Stop();
            this.overlay.Close();


            Log("Finalized.");
            this.label.Text = "Finalized.";
        }

        private void SetupAssemblyResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (o, e) =>
            {
                foreach (var pair in assemblyTable)
                {
                    if (e.Name.StartsWith(pair.Key))
                    {
                        var dir = GetPluginDirectory();
                        return Assembly.LoadFile(System.IO.Path.Combine(dir, pair.Value));
                    }
                }

                return null;
            };
        }

        private void Update()
        {
            if (!CheckIsActReady())
            {
                return;
            }

            var allies = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetAllies();

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
                combatantList.Add(new KeyValuePair<CombatantData,Dictionary<string,string>>(ally, valueDict));
            }

            combatantList.Sort((x, y) =>
                {
                    const string key = "ENCDPS";
                    double xValue, yValue;
                    double.TryParse(x.Value[key].Replace("%", ""), out xValue);
                    double.TryParse(y.Value[key].Replace("%", ""), out yValue);

                    return yValue.CompareTo(xValue);
                });

            var updateScript = GetUpdateScript(encounterDict, combatantList);

            if (this.overlay != null &&
                this.overlay.Renderer != null &&
                this.overlay.Renderer.Browser != null)
            {
                this.overlay.Renderer.Browser.GetMainFrame().ExecuteJavaScript(updateScript, null, 0);
            }
        }

        private string GetUpdateScript(
            Dictionary<string, string> encounter, 
            List<KeyValuePair<CombatantData, Dictionary<string, string>>> combatant)
        {
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
            builder.Append("}");
            builder.Append("};");

            return builder.ToString();
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
                config.Url = System.IO.Path.Combine(GetPluginDirectory(), "resources", "default.html");
            }
        }

        private void SaveConfig()
        {
            try
            {
                config.OverlayPosition = this.overlay.Location;
                config.OverlaySize = this.overlay.Size;

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
            log.Items.Add(DateTime.Now.ToString() + "|" + string.Format(format, args));
        }
    }
}
