using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin.Overlays
{
    [Serializable]
    public class LabelOverlay : OverlayBase<LabelOverlayConfig>
    {
        public LabelOverlay(LabelOverlayConfig config)
            : base(config, config.Name)
        {
            timer.Stop();

            config.TextChanged += (o, e) =>
            {
                UpdateOverlayText();
            };
            config.HTMLModeChanged += (o, e) =>
            {
                UpdateOverlayText();
            };
            this.Overlay.Renderer.BrowserLoad += (o, e) =>
            {
                UpdateOverlayText();
            };
        }

        private void UpdateOverlayText()
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
                else
                {
                    Log(LogLevel.Error, "Update: Browser not ready");
                }

            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "Update: {1}", this.Name, ex);
            }
        }

        private string CreateEventDispatcherScript()
        {
            return string.Format(
                "document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', {{ detail: {0} }}));",
                CreateJson());
        }

        internal string CreateJson()
        {
            return string.Format(
                "{{ text: \"{0}\", isHTML: {1} }}",
                Util.CreateJsonSafeString(this.Config.Text),
                this.Config.HtmlModeEnabled ? "true" : "false");
        }

        protected override void Update()
        {
            
        }
    }
}
