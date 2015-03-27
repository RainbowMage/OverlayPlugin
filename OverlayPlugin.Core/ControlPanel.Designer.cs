namespace RainbowMage.OverlayPlugin
{
    partial class ControlPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveOverlay = new System.Windows.Forms.Button();
            this.buttonNewOverlay = new System.Windows.Forms.Button();
            this.listViewOverlay = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxAutoHide = new System.Windows.Forms.CheckBox();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuLogList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCopyLogAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFollowLatestLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClearLog = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuLogList.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.tabControl);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.listViewLog);
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageMain
            // 
            resources.ApplyResources(this.tabPageMain, "tabPageMain");
            this.tabPageMain.Controls.Add(this.tableLayoutPanel1);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAutoHide, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.buttonRemoveOverlay);
            this.groupBox2.Controls.Add(this.buttonNewOverlay);
            this.groupBox2.Controls.Add(this.listViewOverlay);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // buttonRemoveOverlay
            // 
            resources.ApplyResources(this.buttonRemoveOverlay, "buttonRemoveOverlay");
            this.buttonRemoveOverlay.Name = "buttonRemoveOverlay";
            this.buttonRemoveOverlay.UseVisualStyleBackColor = true;
            this.buttonRemoveOverlay.Click += new System.EventHandler(this.buttonRemoveOverlay_Click);
            // 
            // buttonNewOverlay
            // 
            resources.ApplyResources(this.buttonNewOverlay, "buttonNewOverlay");
            this.buttonNewOverlay.Name = "buttonNewOverlay";
            this.buttonNewOverlay.UseVisualStyleBackColor = true;
            this.buttonNewOverlay.Click += new System.EventHandler(this.buttonNewOverlay_Click);
            // 
            // listViewOverlay
            // 
            resources.ApplyResources(this.listViewOverlay, "listViewOverlay");
            this.listViewOverlay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listViewOverlay.FullRowSelect = true;
            this.listViewOverlay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOverlay.HideSelection = false;
            this.listViewOverlay.Name = "listViewOverlay";
            this.listViewOverlay.UseCompatibleStateImageBehavior = false;
            this.listViewOverlay.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // checkBoxAutoHide
            // 
            resources.ApplyResources(this.checkBoxAutoHide, "checkBoxAutoHide");
            this.checkBoxAutoHide.Name = "checkBoxAutoHide";
            this.checkBoxAutoHide.UseVisualStyleBackColor = true;
            this.checkBoxAutoHide.CheckedChanged += new System.EventHandler(this.checkBoxAutoHide_CheckedChanged);
            // 
            // listViewLog
            // 
            resources.ApplyResources(this.listViewLog, "listViewLog");
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewLog.ContextMenuStrip = this.contextMenuLogList;
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewLog.HideSelection = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            this.listViewLog.VirtualMode = true;
            this.listViewLog.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listViewLog_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // contextMenuLogList
            // 
            resources.ApplyResources(this.contextMenuLogList, "contextMenuLogList");
            this.contextMenuLogList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopyLogAll,
            this.menuLogCopy,
            this.toolStripMenuItem1,
            this.menuFollowLatestLog,
            this.toolStripMenuItem2,
            this.menuClearLog});
            this.contextMenuLogList.Name = "contextMenuLogList";
            // 
            // menuCopyLogAll
            // 
            resources.ApplyResources(this.menuCopyLogAll, "menuCopyLogAll");
            this.menuCopyLogAll.Name = "menuCopyLogAll";
            this.menuCopyLogAll.Click += new System.EventHandler(this.menuCopyLogAll_Click);
            // 
            // menuLogCopy
            // 
            resources.ApplyResources(this.menuLogCopy, "menuLogCopy");
            this.menuLogCopy.Name = "menuLogCopy";
            this.menuLogCopy.Click += new System.EventHandler(this.menuLogCopy_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // menuFollowLatestLog
            // 
            resources.ApplyResources(this.menuFollowLatestLog, "menuFollowLatestLog");
            this.menuFollowLatestLog.CheckOnClick = true;
            this.menuFollowLatestLog.Name = "menuFollowLatestLog";
            this.menuFollowLatestLog.Click += new System.EventHandler(this.menuFollowLatestLog_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // menuClearLog
            // 
            resources.ApplyResources(this.menuClearLog, "menuClearLog");
            this.menuClearLog.Name = "menuClearLog";
            this.menuClearLog.Click += new System.EventHandler(this.menuClearLog_Click);
            // 
            // ControlPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControlPanel";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuLogList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuLogList;
        private System.Windows.Forms.ToolStripMenuItem menuLogCopy;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuFollowLatestLog;
        private System.Windows.Forms.ToolStripMenuItem menuCopyLogAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuClearLog;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRemoveOverlay;
        private System.Windows.Forms.Button buttonNewOverlay;
        private System.Windows.Forms.ListView listViewOverlay;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxAutoHide;
    }
}
