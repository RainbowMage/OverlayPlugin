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
        event EventHandler<LogEventArgs> OnLog;

        void Start();
        void Stop();
        void Navigate(string url);
        void SavePositionAndSize();
    }
}
