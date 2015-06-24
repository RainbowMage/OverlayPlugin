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
    public partial class MiniParseConfigPanel : UserControl
    {
        private MiniParseOverlayConfig config;
        private MiniParseOverlay overlay;

        static readonly List<KeyValuePair<string, MiniParseSortType>> sortTypeDict = new List<KeyValuePair<string, MiniParseSortType>>()
        {
            new KeyValuePair<string, MiniParseSortType>(Localization.GetText(TextItem.DoNotSort), MiniParseSortType.None),
            new KeyValuePair<string, MiniParseSortType>(Localization.GetText(TextItem.SortStringAscending), MiniParseSortType.StringAscending),
            new KeyValuePair<string, MiniParseSortType>(Localization.GetText(TextItem.SortStringDescending), MiniParseSortType.StringDescending),
            new KeyValuePair<string, MiniParseSortType>(Localization.GetText(TextItem.SortNumberAscending), MiniParseSortType.NumericAscending),
            new KeyValuePair<string, MiniParseSortType>(Localization.GetText(TextItem.SortNumberDescending), MiniParseSortType.NumericDescending)
        };

        public MiniParseConfigPanel(MiniParseOverlay overlay)
        {
            InitializeComponent();

            this.overlay = overlay;
            this.config = overlay.Config;

            SetupControlProperties();
            SetupConfigEventHandlers();
        }

        private void SetupControlProperties()
        {
            this.checkMiniParseVisible.Checked = config.IsVisible;
            this.checkMiniParseClickthru.Checked = config.IsClickThru;
            this.checkLock.Checked = config.IsLocked;
            this.textMiniParseUrl.Text = config.Url;
            this.textMiniParseSortKey.Text = config.SortKey;
            this.comboMiniParseSortType.DisplayMember = "Key";
            this.comboMiniParseSortType.ValueMember = "Value";
            this.comboMiniParseSortType.DataSource = sortTypeDict;
            this.comboMiniParseSortType.SelectedValue = config.SortType;
            this.comboMiniParseSortType.SelectedIndexChanged += comboSortType_SelectedIndexChanged;
            this.nudMaxFrameRate.Value = config.MaxFrameRate;
            this.checkEnableGlobalHotkey.Checked = config.GlobalHotkeyEnabled;
            this.textGlobalHotkey.Enabled = this.checkEnableGlobalHotkey.Checked;
            this.textGlobalHotkey.Text = Util.GetHotkeyString(config.GlobalHotkeyModifiers, config.GlobalHotkey);
        }

        private void SetupConfigEventHandlers()
        {
            this.config.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkMiniParseVisible.Checked = e.IsVisible;
                });
            };
            this.config.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkMiniParseClickthru.Checked = e.IsClickThru;
                });
            };
            this.config.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textMiniParseUrl.Text = e.NewUrl;
                });
            };
            this.config.SortKeyChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textMiniParseSortKey.Text = e.NewSortKey;
                });
            };
            this.config.SortTypeChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.comboMiniParseSortType.SelectedValue = e.NewSortType;
                });
            };
            this.config.MaxFrameRateChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudMaxFrameRate.Value = e.NewFrameRate;
                });
            };
            this.config.GlobalHotkeyEnabledChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkEnableGlobalHotkey.Checked = e.NewGlobalHotkeyEnabled;
                    this.textGlobalHotkey.Enabled = this.checkEnableGlobalHotkey.Checked;
                });
            };
            this.config.GlobalHotkeyChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textGlobalHotkey.Text = Util.GetHotkeyString(this.config.GlobalHotkeyModifiers, e.NewHotkey);
                });
            };
            this.config.GlobalHotkeyModifiersChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textGlobalHotkey.Text = Util.GetHotkeyString(e.NewHotkey, this.config.GlobalHotkey);
                });
            };
            this.config.LockChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkLock.Checked = e.IsLocked;
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
            this.config.IsVisible = checkMiniParseVisible.Checked;
        }

        private void checkMouseClickthru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsClickThru = checkMiniParseClickthru.Checked;
        }

        private void textUrl_TextChanged(object sender, EventArgs e)
        {
            //this.config.Url = textMiniParseUrl.Text;
        }

        private void textMiniParseUrl_Leave(object sender, EventArgs e)
        {
            this.config.Url = textMiniParseUrl.Text;
        }

        private void textSortKey_TextChanged(object sender, EventArgs e)
        {
            this.config.SortKey = this.textMiniParseSortKey.Text;
        }

        private void comboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = (MiniParseSortType)this.comboMiniParseSortType.SelectedValue;
            this.config.SortType = value;
        }

        private void nudMaxFrameRate_ValueChanged(object sender, EventArgs e)
        {
            this.config.MaxFrameRate = (int)nudMaxFrameRate.Value;
        }

        private void buttonReloadBrowser_Click(object sender, EventArgs e)
        {
            this.overlay.Navigate(this.config.Url);
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.config.Url = new Uri(ofd.FileName).ToString();
            }
        }

        private void buttonCopyActXiv_Click(object sender, EventArgs e)
        {
            var json = overlay.CreateJsonData();
            if (!string.IsNullOrWhiteSpace(json))
            {
                Clipboard.SetText("var ActXiv = " + json + ";");
            }
        }

        private void checkBoxEnableGlobalHotkey_CheckedChanged(object sender, EventArgs e)
        {
            this.config.GlobalHotkeyEnabled = this.checkEnableGlobalHotkey.Checked;
            this.textGlobalHotkey.Enabled = this.config.GlobalHotkeyEnabled;
        }

        private void textBoxGlobalHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            var key = Util.RemoveModifiers(e.KeyCode, e.Modifiers);
            this.config.GlobalHotkey = key;
            this.config.GlobalHotkeyModifiers = e.Modifiers;
        }

        private void checkLock_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsLocked = this.checkLock.Checked;
        }
    }
}
