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

        static readonly List<KeyValuePair<string, SortType>> sortTypeDict = new List<KeyValuePair<string, SortType>>()
        {
            new KeyValuePair<string, SortType>("ソートしない", SortType.None),
            new KeyValuePair<string, SortType>("文字列 - 昇順", SortType.StringAscending),
            new KeyValuePair<string, SortType>("文字列 - 降順", SortType.StringDescending),
            new KeyValuePair<string, SortType>("数値 - 昇順", SortType.NumericAscending),
            new KeyValuePair<string, SortType>("数値 - 降順", SortType.NumericDescending)
        };

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
            this.config.SortKeyChanged += (o, e) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.textSortKey.Text = e.NewSortKey;
                }));
            };
            this.config.SortTypeChanged += (o, e) =>
            {
                this.Invoke(new Action(() =>
                {
                    this.comboSortType.SelectedValue = e.NewSortType;
                }));
            };
                 
            this.checkWindowVisible.Checked = config.IsVisible;
            this.checkMouseClickthru.Checked = config.IsClickThru;
            this.textUrl.Text = config.Url;
            this.textSortKey.Text = config.SortKey;
            this.comboSortType.DataSource = sortTypeDict;
            this.comboSortType.DisplayMember = "Key";
            this.comboSortType.ValueMember = "Value";
            this.comboSortType.SelectedValue = config.SortType;

            this.listLog.DataSource = pluginMain.Logs;
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
            var updateScript = pluginMain.GetUpdateScript();
            if (!string.IsNullOrWhiteSpace(updateScript))
            {
                Clipboard.SetText("var " + updateScript);
            }
        }

        private void textSortKey_TextChanged(object sender, EventArgs e)
        {
            this.config.SortKey = this.textSortKey.Text;
        }

        private void comboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.config.SortType = (SortType)this.comboSortType.SelectedValue;
        }
    }
}
