﻿using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    class MiniParseOverlay : OverlayBase<MiniParseOverlayConfig>
    {
        private string prevEncounterId { get; set; }
        private DateTime prevEndDateTime { get; set; }
        private bool prevEncounterActive { get; set; }
        public const string FormName = "MiniParseOverlay";
        public MiniParseOverlay(MiniParseOverlayConfig config)
            : base(config, FormName)
        {
        }

        public override void Navigate(string url)
        {
            base.Navigate(url);

            this.prevEncounterId = null;
            this.prevEndDateTime = DateTime.MinValue;
        }

        protected override void Update()
        {
            if (CheckIsActReady())
            {
                // 最終更新時刻に変化がないなら更新を行わない
                if (this.prevEncounterId == ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EncId &&
                    this.prevEndDateTime == ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EndTime &&
                    this.prevEncounterActive == ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active)
                {
                    return;
                }

                this.prevEncounterId = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EncId;
                this.prevEndDateTime = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.EndTime;
                this.prevEncounterActive = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active;

                var updateScript = CreateEventDispatcherScript();

                if (this.Overlay != null &&
                    this.Overlay.Renderer != null &&
                    this.Overlay.Renderer.Browser != null)
                {
                    this.Overlay.Renderer.Browser.GetMainFrame().ExecuteJavaScript(updateScript, null, 0);
                }
            }
        }

        private string CreateEventDispatcherScript()
        {
            return "var ActXiv = " + this.CreateJsonData() + ";\n" +
                   "document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', { detail: ActXiv }));";
        }

        internal string CreateJsonData()
        {
            if (!CheckIsActReady())
            {
                return "";
            }

#if DEBUG
            var stopwatch = new Stopwatch();
            stopwatch.Start();
#endif

            var allies = ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.GetAllies();

            var encounter = GetEncounterDictionary(allies);
            var combatant = GetCombatantList(allies);

            SortCombatantList(combatant);

            var builder = new StringBuilder();
            builder.Append("{");
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
                builder.AppendFormat("\"{0}\":\"{1}\"", Util.CleanUpString(pair.Key), Util.CleanUpString(pair.Value));
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
                builder.AppendFormat("\"{0}\": {{", Util.CleanUpString(pair.Key.Name));
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
                    builder.AppendFormat("\"{0}\":\"{1}\"", Util.CleanUpString(pair2.Key), Util.CleanUpString(pair2.Value));
                }
                builder.Append("}");
            }
            builder.Append("},");
            builder.AppendFormat("\"isActive\": {0}", ActGlobals.oFormActMain.ActiveZone.ActiveEncounter.Active ? "true" : "false");
            builder.Append("}");

#if DEBUG
            stopwatch.Stop();
            Log(LogLevel.Trace, "CreateUpdateScript: {0} msec", stopwatch.Elapsed.TotalMilliseconds);
#endif

            return builder.ToString();
        }

        private void SortCombatantList(List<KeyValuePair<CombatantData, Dictionary<string, string>>> combatant)
        {
            // 数値で並び替え
            if (this.Config.SortType == MiniParseSortType.NumericAscending ||
                this.Config.SortType == MiniParseSortType.NumericDescending)
            {
                combatant.Sort((x, y) =>
                {
                    int result = 0;
                    if (x.Value.ContainsKey(this.Config.SortKey) &&
                        y.Value.ContainsKey(this.Config.SortKey))
                    {
                        double xValue, yValue;
                        double.TryParse(x.Value[this.Config.SortKey].Replace("%", ""), out xValue);
                        double.TryParse(y.Value[this.Config.SortKey].Replace("%", ""), out yValue);

                        result = xValue.CompareTo(yValue);

                        if (this.Config.SortType == MiniParseSortType.NumericDescending)
                        {
                            result *= -1;
                        }
                    }

                    return result;
                });
            }
            // 文字列で並び替え
            else if (
                this.Config.SortType == MiniParseSortType.StringAscending ||
                this.Config.SortType == MiniParseSortType.StringDescending)
            {
                combatant.Sort((x, y) =>
                {
                    int result = 0;
                    if (x.Value.ContainsKey(this.Config.SortKey) &&
                        y.Value.ContainsKey(this.Config.SortKey))
                    {
                        result = x.Value[this.Config.SortKey].CompareTo(y.Value[this.Config.SortKey]);

                        if (this.Config.SortType == MiniParseSortType.StringDescending)
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

        private static bool CheckIsActReady()
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
    }
}
