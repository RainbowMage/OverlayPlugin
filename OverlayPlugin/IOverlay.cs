using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public interface IOverlay : IDisposable
    {
        string Name { get; }
        OverlayForm Overlay { get; }
        event EventHandler<LogEventArgs> OnLog;

        void Start();
        void Stop();
        void Navigate(string url);
        void SavePositionAndSize();
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
}
