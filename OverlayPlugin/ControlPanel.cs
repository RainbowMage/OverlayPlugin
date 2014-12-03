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

            SetupMiniParseConfigHandlers();
            SetupSpellTimerConfigHandlers();

            SetupMiniParseTab();
            SetupSpellTimerTab();

            this.listLog.DataSource = pluginMain.Logs;
        }

        private void SetupMiniParseTab()
        {
            this.checkMiniParseVisible.Checked = config.MiniParseOverlay.IsVisible;
            this.checkMiniParseClickthru.Checked = config.MiniParseOverlay.IsClickThru;
            this.textMiniParseUrl.Text = config.MiniParseOverlay.Url;
            this.textMiniParseSortKey.Text = config.MiniParseOverlay.SortKey;
            this.comboMiniParseSortType.DisplayMember = "Key";
            this.comboMiniParseSortType.ValueMember = "Value";
            this.comboMiniParseSortType.DataSource = sortTypeDict;
            this.comboMiniParseSortType.SelectedValue = config.MiniParseOverlay.SortType;
            this.comboMiniParseSortType.SelectedIndexChanged += comboSortType_SelectedIndexChanged;
            this.nudMiniParseMaxFrameRate.Value = config.MiniParseOverlay.MaxFrameRate;
        }

        private void SetupSpellTimerTab()
        {
            this.checkSpellTimerVisible.Checked = config.SpellTimerOverlay.IsVisible;
            this.checkSpellTimerClickThru.Checked = config.SpellTimerOverlay.IsClickThru;
            this.textSpellTimerUrl.Text = config.SpellTimerOverlay.Url;
            this.nudSpellTimerMaxFrameRate.Value = config.SpellTimerOverlay.MaxFrameRate;
        }

        private void SetupMiniParseConfigHandlers()
        {
            this.config.MiniParseOverlay.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkMiniParseVisible.Checked = e.IsVisible;
                });
            };
            this.config.MiniParseOverlay.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkMiniParseClickthru.Checked = e.IsClickThru;
                });
            };
            this.config.MiniParseOverlay.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textMiniParseUrl.Text = e.NewUrl;
                });
            };
            this.config.MiniParseOverlay.SortKeyChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textMiniParseSortKey.Text = e.NewSortKey;
                });
            };
            this.config.MiniParseOverlay.SortTypeChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.comboMiniParseSortType.SelectedValue = e.NewSortType;
                });
            };
            this.config.MiniParseOverlay.MaxFrameRateChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudMiniParseMaxFrameRate.Value = e.NewFrameRate;
                });
            };
        }

        private void SetupSpellTimerConfigHandlers()
        {
            this.config.SpellTimerOverlay.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkSpellTimerVisible.Checked = e.IsVisible;
                });
            };
            this.config.SpellTimerOverlay.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkSpellTimerClickThru.Checked = e.IsClickThru;
                });
            };
            this.config.SpellTimerOverlay.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textSpellTimerUrl.Text = e.NewUrl;
                });
            };
            this.config.SpellTimerOverlay.MaxFrameRateChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudSpellTimerMaxFrameRate.Value = e.NewFrameRate;
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

        private void checkWindowVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.IsVisible = checkMiniParseVisible.Checked;
        }

        private void checkMouseClickthru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.IsClickThru = checkMiniParseClickthru.Checked;
        }

        private void textUrl_TextChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.Url = textMiniParseUrl.Text;
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
            this.config.MiniParseOverlay.SortKey = this.textMiniParseSortKey.Text;
        }

        private void comboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = (MiniParseSortType)this.comboMiniParseSortType.SelectedValue;
            this.config.MiniParseOverlay.SortType = value;
        }

        private void nudMiniParseMaxFrameRate_ValueChanged(object sender, EventArgs e)
        {
            this.config.MiniParseOverlay.MaxFrameRate = (int)nudMiniParseMaxFrameRate.Value;
        }

        private void checkSpellTimerVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.SpellTimerOverlay.IsVisible = this.checkSpellTimerVisible.Checked;
        }

        private void checkSpellTimerClickThru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.SpellTimerOverlay.IsClickThru = this.checkSpellTimerClickThru.Checked;
        }

        private void textSpellTimerUrl_TextChanged(object sender, EventArgs e)
        {
            this.config.SpellTimerOverlay.Url = this.textSpellTimerUrl.Text;
        }

        private void buttonSpellTimerSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.config.SpellTimerOverlay.Url = new Uri(ofd.FileName).ToString();
            }
        }

        private void buttonSpellTimerCopyActXiv_Click(object sender, EventArgs e)
        {
            var updateScript = pluginMain.SpellTimerOverlay.CreateUpdateString();
            if (!string.IsNullOrWhiteSpace(updateScript))
            {
                Clipboard.SetText("var " + updateScript);
            }
        }

        private void buttonSpellTimerReloadBrowser_Click(object sender, EventArgs e)
        {
            if (pluginMain.SpellTimerOverlay.Overlay.Url != config.SpellTimerOverlay.Url)
            {
                pluginMain.SpellTimerOverlay.Overlay.Url = config.SpellTimerOverlay.Url;
            }
            else
            {
                pluginMain.SpellTimerOverlay.Overlay.Reload();
            }
        }

        private void nudSpellTimerMaxFrameRate_ValueChanged(object sender, EventArgs e)
        {
            this.config.SpellTimerOverlay.MaxFrameRate = (int)nudSpellTimerMaxFrameRate.Value;
        }
    }
}
