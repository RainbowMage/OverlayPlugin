using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    public partial class ControlPanel : UserControl
    {
        PluginMain pluginMain;
        PluginConfig config;

        public ControlPanel(PluginMain pluginMain, PluginConfig config)
        {
            InitializeComponent();

            this.pluginMain = pluginMain;
            this.config = config;

            this.config.VisibleChanged += (o, e) =>
            {
                this.Invoke(new Action(() =>
                    {
                        this.checkWindowVisible.Checked = e.IsVisible;
                    }));
            };
            this.config.ClickThruChanged += (o, e) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.checkMouseClickthru.Checked = e.IsClickThru;
                }));
            };
            this.config.UrlChanged += (o, e) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.textUrl.Text = e.NewUrl;
                }));
            };
                 
            this.checkWindowVisible.Checked = config.IsVisible;
            this.checkMouseClickthru.Checked = config.IsClickThru;
            this.textUrl.Text = config.Url;
        }

        private void checkWindowVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsVisible = checkWindowVisible.Checked;
        }

        private void checkMouseClickthru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsClickThru = checkMouseClickthru.Checked;
        }

        private void textUrl_TextChanged(object sender, EventArgs e)
        {
            this.config.Url = textUrl.Text;
        }

        private void buttonReloadBrowser_Click(object sender, EventArgs e)
        {
            if (pluginMain.Overlay.Url != config.Url)
            {
                pluginMain.Overlay.Url = config.Url;
            }
            else
            {
                pluginMain.Overlay.Reload();
            }
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.config.Url = new Uri(ofd.FileName).ToString();
            }
        }
    }
}
