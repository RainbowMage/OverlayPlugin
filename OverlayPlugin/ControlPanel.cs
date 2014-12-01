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

        static readonly List<KeyValuePair<string, MiniParseSortType>> sortTypeDict = new List<KeyValuePair<string, MiniParseSortType>>()
        {
            new KeyValuePair<string, MiniParseSortType>("ソートしない", MiniParseSortType.None),
            new KeyValuePair<string, MiniParseSortType>("文字列 - 昇順", MiniParseSortType.StringAscending),
            new KeyValuePair<string, MiniParseSortType>("文字列 - 降順", MiniParseSortType.StringDescending),
            new KeyValuePair<string, MiniParseSortType>("数値 - 昇順", MiniParseSortType.NumericAscending),
            new KeyValuePair<string, MiniParseSortType>("数値 - 降順", MiniParseSortType.NumericDescending)
        };

        public ControlPanel(PluginMain pluginMain, PluginConfig config)
        {
            InitializeComponent();

            this.pluginMain = pluginMain;
            this.config = config;

            this.config.MiniParseOverlay.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkWindowVisible.Checked = e.IsVisible;
                });
            };
            this.config.MiniParseOverlay.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkMouseClickthru.Checked = e.IsClickThru;
                });
            };
            this.config.MiniParseOverlay.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textUrl.Text = e.NewUrl;
                });
            };
            this.config.MiniParseOverlay.SortKeyChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textSortKey.Text = e.NewSortKey;
                });
            };
            this.config.MiniParseOverlay.SortTypeChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.comboSortType.SelectedValue = e.NewSortType;
                });
            };

            this.checkWindowVisible.Checked = config.MiniParseOverlay.IsVisible;
            this.checkMouseClickthru.Checked = config.MiniParseOverlay.IsClickThru;
            this.textUrl.Text = config.MiniParseOverlay.Url;
            this.textSortKey.Text = config.MiniParseOverlay.SortKey;
            this.comboSortType.DisplayMember = "Key";
            this.comboSortType.ValueMember = "Value";
            this.comboSortType.DataSource = sortTypeDict;
            this.comboSortType.SelectedValue = config.MiniParseOverlay.SortType;

            this.listLog.DataSource = pluginMain.Logs;
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

        private void checkWindowVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.IsVisible = checkWindowVisible.Checked;
        }

        private void checkMouseClickthru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.IsClickThru = checkMouseClickthru.Checked;
        }

        private void textUrl_TextChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.Url = textUrl.Text;
        }

        private void buttonReloadBrowser_Click(object sender, EventArgs e)
        {
            if (pluginMain.MiniParseOverlay.Overlay.Url != config.MiniParseOverlay.Url)
            {
                pluginMain.MiniParseOverlay.Overlay.Url = config.MiniParseOverlay.Url;
            }
            else
            {
                pluginMain.MiniParseOverlay.Overlay.Reload();
            }
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.config.MiniParseOverlay.Url = new Uri(ofd.FileName).ToString();
            }
        }

        private void menuLogCopy_Click(object sender, EventArgs e)
        {
            if (listLog.SelectedItems != null)
            {
                var sb = new StringBuilder();
                foreach (var item in listLog.SelectedItems)
                {
                    sb.AppendLine(item.ToString());
                }
                Clipboard.SetText(sb.ToString());
            }
        }

        private void buttonCopyActXiv_Click(object sender, EventArgs e)
        {
            var updateScript = pluginMain.MiniParseOverlay.CreateUpdateScript();
            if (!string.IsNullOrWhiteSpace(updateScript))
            {
                Clipboard.SetText("var " + updateScript);
            }
        }

        private void textSortKey_TextChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.SortKey = this.textSortKey.Text;
        }

        private void comboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = (MiniParseSortType)this.comboSortType.SelectedValue;
            this.config.MiniParseOverlay.SortType = value;
        }
    }
}
