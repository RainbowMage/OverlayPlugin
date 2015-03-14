using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    [DataContract]
    class SerializableTimerFrameEntry
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name = "color")]
        public int Color { get; set; }
        [DataMember(Name = "startCount")]
        public int StartCount { get; set; }
        [DataMember(Name = "warningCount")]
        public int WarningCount { get; set; }
        [DataMember(Name = "expireCount")]
        public int ExpireCount { get; set; }
        [DataMember(Name = "tooltip")]
        public string Tooltip { get; set; }
        [DataMember(Name = "absoluteTiming")]
        public bool AbsoluteTiming { get; set; }
        [DataMember(Name = "onlyMasterTicks")]
        public bool OnlyMasterTicks { get; set; }
        [DataMember(Name = "oneOnly")]
        public bool OneOnly { get; set; }
        //[DataMember(Name = "masterExists")]
        //public bool MasterExists { get; set; }
        //[DataMember(Name = "activeInList")]
        //public bool ActiveInList { get; set; }
        [DataMember(Name = "spellTimers")]
        public IList<SerializableSpellTimerEntry> SpellTimers { get; set; }

        public TimerFrame Original { get; private set; }

        public SerializableTimerFrameEntry(TimerFrame timerFrame)
        {
            this.Update(timerFrame);

            this.SpellTimers = new List<SerializableSpellTimerEntry>();

            this.Original = timerFrame;
        }

        public void Update(TimerFrame timerFrame)
        {
            this.Name = timerFrame.Name;
            this.Key = timerFrame.TimerData.Key;
            this.Color = timerFrame.TimerData.FillColor.ToArgb();
            this.StartCount = timerFrame.TimerData.TimerValue;
            this.WarningCount = timerFrame.TimerData.WarningValue;
            this.ExpireCount = timerFrame.TimerData.RemoveValue;
            this.Tooltip = timerFrame.TimerData.Tooltip;
            this.OnlyMasterTicks = timerFrame.TimerData.OnlyMasterTicks;
            this.AbsoluteTiming = timerFrame.TimerData.AbsoluteTiming;
            //this.OneOnly = timerFrame.OneOnly;
            //this.MasterExists = timerFrame.MasterExists;

        }
    }

    [DataContract]
    class SerializableSpellTimerEntry
    {
        public DateTime StartTime { get; set; }
        private static readonly DateTime EpochTime = new DateTime(1970, 1, 1);

        [DataMember(Name = "startTime")]
        public long StartTimeLong 
        { 
            get
            {
                return (this.StartTime.Ticks - EpochTime.Ticks) / 10000;
            }
            set
            {
                this.StartTime = new DateTime(EpochTime.Ticks + value * 10000);
            }
        }

        public SpellTimer Original { get; private set; }

        public SerializableSpellTimerEntry(SpellTimer spellTimer)
        {
            this.StartTime = DateTime.Now;

            this.Original = spellTimer;
        }
    }
}
