using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    public class SpellTimerOverlay : OverlayBase<SpellTimerOverlayConfig>
    {
        static DataContractJsonSerializer jsonSerializer =
            new DataContractJsonSerializer(typeof(List<SerializableTimerFrameEntry>));

        IList<SerializableTimerFrameEntry> activatedTimers;

        public SpellTimerOverlay(SpellTimerOverlayConfig config)
            : base(config, config.Name)
        {
            this.activatedTimers = new List<SerializableTimerFrameEntry>();

            ActGlobals.oFormSpellTimers.OnSpellTimerNotify += (t) =>
            {
                lock (this.activatedTimers)
                {
                    var timerFrame = activatedTimers.Where(x => x.Original == t).FirstOrDefault();
                    if (timerFrame == null)
                    {
                        timerFrame = new SerializableTimerFrameEntry(t);
                        this.activatedTimers.Add(timerFrame);
                    }
                    else
                    {
                        timerFrame.Update(t);
                    }
                    foreach (var spellTimer in t.SpellTimers)
                    {
                        var timer = timerFrame.SpellTimers.Where(x => x.Original == spellTimer).FirstOrDefault();
                        if (timer == null)
                        {
                            timer = new SerializableSpellTimerEntry(spellTimer);
                            timerFrame.SpellTimers.Add(timer);
                        }
                    }
                }
            };
            ActGlobals.oFormSpellTimers.OnSpellTimerRemoved += (t) =>
            {
                //activatedTimers.Remove(t);
            };
        }

        protected override void Update()
        {
            try
            {
                var updateScript = CreateEventDispatcherScript();

                if (this.Overlay != null &&
                    this.Overlay.Renderer != null &&
                    this.Overlay.Renderer.Browser != null)
                {
                    this.Overlay.Renderer.Browser.GetMainFrame().ExecuteJavaScript(updateScript, null, 0);
                }

            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "Update: {1}", this.Name, ex);
            }
        }

        private void RemoveExpiredEntries()
        {
            var expiredTimerFrames = new List<SerializableTimerFrameEntry>();
            foreach (var timerFrame in activatedTimers)
            {
                var expiredSpellTimers = new List<SerializableSpellTimerEntry>();
                bool expired = true;
                foreach (var timer in timerFrame.SpellTimers)
                {
                    if (timerFrame.StartCount - timerFrame.ExpireCount > (DateTime.Now - timer.StartTime).TotalSeconds)
                    {
                        expired = false;
                        break;
                    }
                    else
                    {
                        expiredSpellTimers.Add(timer);
                    }
                }
                if (expired)
                {
                    expiredTimerFrames.Add(timerFrame);
                }
                else
                {
                    foreach (var expiredSpellTimer in expiredSpellTimers)
                    {
                        timerFrame.SpellTimers.Remove(expiredSpellTimer);
                    }
                }
            }
            foreach (var expiredTimerFrame in expiredTimerFrames)
            {
                activatedTimers.Remove(expiredTimerFrame);
            }
        }

        internal string CreateJsonData()
        {
            lock (this.activatedTimers)
            {
                RemoveExpiredEntries();
            }

            using (var ms = new MemoryStream())
            {
                lock (this.activatedTimers)
                {
                    RemoveExpiredEntries();
                    jsonSerializer.WriteObject(ms, activatedTimers);
                }

                var result = Encoding.UTF8.GetString(ms.ToArray());

                if (!string.IsNullOrWhiteSpace(result))
                {
                    return string.Format(
                        "{{ timerFrames: {0} }}",
                        result);
                }
                else
                {
                    return "";
                }
            }
        }

        private string CreateEventDispatcherScript()
        {
            return "var ActXiv = " + this.CreateJsonData() + ";\n" +
                   "document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', ActXiv));";
        }
    }
}
