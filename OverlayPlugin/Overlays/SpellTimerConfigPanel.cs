using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin.Overlays
{
    public partial class SpellTimerConfigPanel : UserControl
    {
        private SpellTimerOverlayConfig config;

        public SpellTimerConfigPanel(SpellTimerOverlay overlay)
        {
            InitializeComponent();

            this.config = overlay.Config as SpellTimerOverlayConfig;

            SetupConfigEventHandlers();
            SetupControlProperties();
        }

        private void SetupControlProperties()
        {
            this.checkBoxVisible.Checked = this.config.IsVisible;
            this.checkBoxClickThru.Checked = this.config.IsClickThru;
            this.textBoxUrl.Text = this.config.Url;
            this.nudMaxFrameRate.Value = this.config.MaxFrameRate;
        }

        private void SetupConfigEventHandlers()
        {
            this.config.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkBoxVisible.Checked = e.IsVisible;
                });
            };
            this.config.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkBoxClickThru.Checked = e.IsClickThru;
                });
            };
            this.config.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textBoxUrl.Text = e.NewUrl;
                });
            };
            this.config.MaxFrameRateChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudMaxFrameRate.Value = e.NewFrameRate;
                });
            };
        }

        private void InvokeIfRequired(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void checkBoxVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsVisible = this.checkBoxVisible.Checked;
        }

        private void checkBoxClickThru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsClickThru = this.checkBoxClickThru.Checked;
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            //this.config.Url = this.textBoxUrl.Text;
        }

        private void textBoxUrl_Leave(object sender, EventArgs e)
        {
            this.config.Url = this.textBoxUrl.Text;
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.config.Url = new Uri(ofd.FileName).ToString();
            }
        }

        private void buttonCopyVariable_Click(object sender, EventArgs e)
        {
            //var json = pluginMain.SpellTimerOverlay.CreateJsonData();
            //if (!string.IsNullOrWhiteSpace(json))
            //{
            //    Clipboard.SetText("var ActXiv = " + json + ";");
            //}
        }

        private void buttonSpellTimerReloadBrowser_Click(object sender, EventArgs e)
        {
            //pluginMain.SpellTimerOverlay.Navigate(config.SpellTimerOverlayObsolete.Url);
        }

        private void nudMaxFrameRate_ValueChanged(object sender, EventArgs e)
        {
            this.config.MaxFrameRate = (int)nudMaxFrameRate.Value;
        }
    }
}
