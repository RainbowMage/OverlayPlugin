using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class Logger
    {
        public BindingList<LogEntry> Logs { get; private set; }

        public Logger()
        {
            this.Logs = new BindingList<LogEntry>();
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

        public void Log(LogLevel level, string format, params object[] args)
        {
            Log(level, string.Format(format, args));
        }
    }

    public class LogEntry
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

    public class LogEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public LogLevel Level { get; private set; }
        public LogEventArgs(LogLevel level, string message)
        {
            this.Message = message;
            this.Level = level;
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
