using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

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

            this.menuFollowLatestLog.Checked = this.config.FollowLatestLog;
            this.listViewLog.VirtualListSize = pluginMain.Logs.Count;
            this.pluginMain.Logs.ListChanged += (o, e) =>
            {
                this.listViewLog.BeginUpdate();
                this.listViewLog.VirtualListSize = pluginMain.Logs.Count;
                if (this.config.FollowLatestLog && this.pluginMain.Logs.Count > 0)
                {
                    this.listViewLog.EnsureVisible(this.pluginMain.Logs.Count - 1);
                }
                this.listViewLog.EndUpdate();
            };

            InitializeOverlayConfigTabs();
            UpdateOverlayListView();
        }

        private void InitializeOverlayConfigTabs()
        {
            foreach (var overlay in this.pluginMain.Overlays)
            {
                AddConfigTab(overlay);
            }
        }

        private void AddConfigTab(IOverlay overlay)
        {
            var tabPage = new TabPage 
            { 
                Name = overlay.Name,
                Text = overlay.Name
            };

            var control = PluginMain.CreateOverlayConfigControl(overlay);
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);

            this.tabControl.TabPages.Add(tabPage);
        }

        private void UpdateOverlayListView()
        {
            this.listViewOverlay.Items.Clear();
            foreach (var overlay in this.pluginMain.Overlays)
            {
                var lvi = new ListViewItem();
                lvi.Text = overlay.Name;
                lvi.SubItems.Add(overlay.GetType().Name);
                this.listViewOverlay.Items.Add(lvi);
            }
        }

        private void menuLogCopy_Click(object sender, EventArgs e)
        {
            if (listViewLog.SelectedIndices.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (int index in listViewLog.SelectedIndices)
                {
                    sb.AppendFormat(
                        "{0}: {1}: {2}",
                        pluginMain.Logs[index].Time,
                        pluginMain.Logs[index].Level,
                        pluginMain.Logs[index].Message);
                    sb.AppendLine();
                }
                Clipboard.SetText(sb.ToString());
            }
        }

        private void listViewLog_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= pluginMain.Logs.Count) 
            {
                e.Item = new ListViewItem();
                return;
            };

            var log = this.pluginMain.Logs[e.ItemIndex];
            e.Item = new ListViewItem(log.Time.ToString());
            e.Item.UseItemStyleForSubItems = true;
            e.Item.SubItems.Add(log.Level.ToString());
            e.Item.SubItems.Add(log.Message);

            e.Item.ForeColor = Color.Black;
            if (log.Level == LogLevel.Warning)
            {
                e.Item.BackColor = Color.LightYellow;
            }
            else if (log.Level == LogLevel.Error)
            {
                e.Item.BackColor = Color.LightPink;
            }
            else
            {
                e.Item.BackColor = Color.White;
            }
        }

        private void menuFollowLatestLog_Click(object sender, EventArgs e)
        {
            this.config.FollowLatestLog = menuFollowLatestLog.Checked;
        }

        private void menuClearLog_Click(object sender, EventArgs e)
        {
            this.pluginMain.Logs.Clear();
        }

        private void menuCopyLogAll_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var log in this.pluginMain.Logs)
            {
                sb.AppendFormat(
                    "{0}: {1}: {2}",
                    log.Time,
                    log.Level,
                    log.Message);
                sb.AppendLine();
            }
            Clipboard.SetText(sb.ToString());
        }

        private void buttonNewOverlay_Click(object sender, EventArgs e)
        {
            var newOverlayDialog = new NewOverlayDialog();
            newOverlayDialog.NameValidator = (name) =>
                {
                    // 空もしくは空白文字のみの名前は許容しない
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        MessageBox.Show("Name must not be empty or white space only.");
                        return false;
                    }
                    // 名前の重複も許容しない
                    else if (config.Overlays.Where(x => x.Name == name).Any())
                    {
                        MessageBox.Show("Name should be unique.");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                };

            if (newOverlayDialog.ShowDialog(this.ParentForm) == DialogResult.OK)
            {
                if (newOverlayDialog.OverlayType == OverlayType.MiniParse)
                {
                    CreateAndRegisterOverlay<MiniParseOverlayConfig>(newOverlayDialog.OverlayName);
                }
                else if (newOverlayDialog.OverlayType == OverlayType.SpellTimer)
                {
                    CreateAndRegisterOverlay<SpellTimerOverlayConfig>(newOverlayDialog.OverlayName);
                }
            }
            newOverlayDialog.Dispose();
        }

        private IOverlay CreateAndRegisterOverlay<TConfig>(string name)
            where TConfig : OverlayConfig
        {
            var config = PluginMain.CreateOverlayConfig<TConfig>(name);
            this.config.Overlays.Add(config);

            var overlay = PluginMain.CreateOverlayFromConfig(config);
            pluginMain.RegisterOverlay(overlay);

            AddConfigTab(overlay);
            UpdateOverlayListView();

            return overlay;
        }

        private void buttonRemoveOverlay_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewOverlay.SelectedItems)
            {
                string selectedOverlayName = item.Text;

                // コンフィグ削除
                this.config.Overlays.RemoveAll(x => x.Name == selectedOverlayName);

                // 動作中のオーバーレイを停止して削除
                var overlays = this.pluginMain.Overlays.Where(x => x.Name == selectedOverlayName);
                foreach (var overlay in overlays)
                {
                    overlay.Dispose();
                }
                this.pluginMain.Overlays.RemoveAll(x => x.Name == selectedOverlayName);

                // タブページを削除
                this.tabControl.TabPages.RemoveByKey(selectedOverlayName);

                // リストビューを更新
                UpdateOverlayListView();
            }
        }
    }
}
