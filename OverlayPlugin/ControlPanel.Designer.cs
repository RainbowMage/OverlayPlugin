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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textMiniParseSortKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkMiniParseVisible = new System.Windows.Forms.CheckBox();
            this.checkMiniParseClickthru = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMiniParseReloadBrowser = new System.Windows.Forms.Button();
            this.buttonMiniParseCopyActXiv = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textMiniParseUrl = new System.Windows.Forms.TextBox();
            this.buttonMiniParseSelectFile = new System.Windows.Forms.Button();
            this.comboMiniParseSortType = new System.Windows.Forms.ComboBox();
            this.nudMiniParseMaxFrameRate = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkEnableGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.textGlobalHotkey = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSpellTimerMaxFrameRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkSpellTimerVisible = new System.Windows.Forms.CheckBox();
            this.checkSpellTimerClickThru = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSpellTimerReloadBrowser = new System.Windows.Forms.Button();
            this.buttonSpellTimerCopyActXiv = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textSpellTimerUrl = new System.Windows.Forms.TextBox();
            this.buttonSpellTimerSelectFile = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.checkSpellTimerEnableGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.textSpellTimerGlobalHotkey = new System.Windows.Forms.TextBox();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiniParseMaxFrameRate)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellTimerMaxFrameRate)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewLog);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label13, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textMiniParseSortKey, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkMiniParseVisible, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkMiniParseClickthru, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboMiniParseSortType, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudMiniParseMaxFrameRate, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkEnableGlobalHotkey, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textGlobalHotkey, 1, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textMiniParseSortKey
            // 
            resources.ApplyResources(this.textMiniParseSortKey, "textMiniParseSortKey");
            this.textMiniParseSortKey.Name = "textMiniParseSortKey";
            this.textMiniParseSortKey.TextChanged += new System.EventHandler(this.textSortKey_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkMiniParseVisible
            // 
            resources.ApplyResources(this.checkMiniParseVisible, "checkMiniParseVisible");
            this.checkMiniParseVisible.Name = "checkMiniParseVisible";
            this.checkMiniParseVisible.UseVisualStyleBackColor = true;
            this.checkMiniParseVisible.CheckedChanged += new System.EventHandler(this.checkWindowVisible_CheckedChanged);
            // 
            // checkMiniParseClickthru
            // 
            resources.ApplyResources(this.checkMiniParseClickthru, "checkMiniParseClickthru");
            this.checkMiniParseClickthru.Name = "checkMiniParseClickthru";
            this.checkMiniParseClickthru.UseVisualStyleBackColor = true;
            this.checkMiniParseClickthru.CheckedChanged += new System.EventHandler(this.checkMouseClickthru_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.buttonMiniParseReloadBrowser, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonMiniParseCopyActXiv, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // buttonMiniParseReloadBrowser
            // 
            resources.ApplyResources(this.buttonMiniParseReloadBrowser, "buttonMiniParseReloadBrowser");
            this.buttonMiniParseReloadBrowser.Name = "buttonMiniParseReloadBrowser";
            this.buttonMiniParseReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonMiniParseReloadBrowser.Click += new System.EventHandler(this.buttonReloadBrowser_Click);
            // 
            // buttonMiniParseCopyActXiv
            // 
            resources.ApplyResources(this.buttonMiniParseCopyActXiv, "buttonMiniParseCopyActXiv");
            this.buttonMiniParseCopyActXiv.Name = "buttonMiniParseCopyActXiv";
            this.buttonMiniParseCopyActXiv.UseVisualStyleBackColor = true;
            this.buttonMiniParseCopyActXiv.Click += new System.EventHandler(this.buttonCopyActXiv_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.textMiniParseUrl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonMiniParseSelectFile, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // textMiniParseUrl
            // 
            resources.ApplyResources(this.textMiniParseUrl, "textMiniParseUrl");
            this.textMiniParseUrl.Name = "textMiniParseUrl";
            this.textMiniParseUrl.TextChanged += new System.EventHandler(this.textUrl_TextChanged);
            // 
            // buttonMiniParseSelectFile
            // 
            resources.ApplyResources(this.buttonMiniParseSelectFile, "buttonMiniParseSelectFile");
            this.buttonMiniParseSelectFile.Name = "buttonMiniParseSelectFile";
            this.buttonMiniParseSelectFile.UseVisualStyleBackColor = true;
            this.buttonMiniParseSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // comboMiniParseSortType
            // 
            resources.ApplyResources(this.comboMiniParseSortType, "comboMiniParseSortType");
            this.comboMiniParseSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMiniParseSortType.FormattingEnabled = true;
            this.comboMiniParseSortType.Name = "comboMiniParseSortType";
            // 
            // nudMiniParseMaxFrameRate
            // 
            resources.ApplyResources(this.nudMiniParseMaxFrameRate, "nudMiniParseMaxFrameRate");
            this.nudMiniParseMaxFrameRate.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMiniParseMaxFrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMiniParseMaxFrameRate.Name = "nudMiniParseMaxFrameRate";
            this.nudMiniParseMaxFrameRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMiniParseMaxFrameRate.ValueChanged += new System.EventHandler(this.nudMiniParseMaxFrameRate_ValueChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // checkEnableGlobalHotkey
            // 
            resources.ApplyResources(this.checkEnableGlobalHotkey, "checkEnableGlobalHotkey");
            this.checkEnableGlobalHotkey.Name = "checkEnableGlobalHotkey";
            this.checkEnableGlobalHotkey.UseVisualStyleBackColor = true;
            this.checkEnableGlobalHotkey.CheckedChanged += new System.EventHandler(this.checkEnableGlobalHotkey_CheckedChanged);
            // 
            // textGlobalHotkey
            // 
            resources.ApplyResources(this.textGlobalHotkey, "textGlobalHotkey");
            this.textGlobalHotkey.Name = "textGlobalHotkey";
            this.textGlobalHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textGlobalHotkey_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.label12, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.nudSpellTimerMaxFrameRate, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.checkSpellTimerVisible, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkSpellTimerClickThru, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 9);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label16, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.checkSpellTimerEnableGlobalHotkey, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.textSpellTimerGlobalHotkey, 1, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // nudSpellTimerMaxFrameRate
            // 
            resources.ApplyResources(this.nudSpellTimerMaxFrameRate, "nudSpellTimerMaxFrameRate");
            this.nudSpellTimerMaxFrameRate.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudSpellTimerMaxFrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpellTimerMaxFrameRate.Name = "nudSpellTimerMaxFrameRate";
            this.nudSpellTimerMaxFrameRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpellTimerMaxFrameRate.ValueChanged += new System.EventHandler(this.nudSpellTimerMaxFrameRate_ValueChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // checkSpellTimerVisible
            // 
            resources.ApplyResources(this.checkSpellTimerVisible, "checkSpellTimerVisible");
            this.checkSpellTimerVisible.Name = "checkSpellTimerVisible";
            this.checkSpellTimerVisible.UseVisualStyleBackColor = true;
            this.checkSpellTimerVisible.CheckedChanged += new System.EventHandler(this.checkSpellTimerVisible_CheckedChanged);
            // 
            // checkSpellTimerClickThru
            // 
            resources.ApplyResources(this.checkSpellTimerClickThru, "checkSpellTimerClickThru");
            this.checkSpellTimerClickThru.Name = "checkSpellTimerClickThru";
            this.checkSpellTimerClickThru.UseVisualStyleBackColor = true;
            this.checkSpellTimerClickThru.CheckedChanged += new System.EventHandler(this.checkSpellTimerClickThru_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.buttonSpellTimerReloadBrowser, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonSpellTimerCopyActXiv, 0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // buttonSpellTimerReloadBrowser
            // 
            resources.ApplyResources(this.buttonSpellTimerReloadBrowser, "buttonSpellTimerReloadBrowser");
            this.buttonSpellTimerReloadBrowser.Name = "buttonSpellTimerReloadBrowser";
            this.buttonSpellTimerReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonSpellTimerReloadBrowser.Click += new System.EventHandler(this.buttonSpellTimerReloadBrowser_Click);
            // 
            // buttonSpellTimerCopyActXiv
            // 
            resources.ApplyResources(this.buttonSpellTimerCopyActXiv, "buttonSpellTimerCopyActXiv");
            this.buttonSpellTimerCopyActXiv.Name = "buttonSpellTimerCopyActXiv";
            this.buttonSpellTimerCopyActXiv.UseVisualStyleBackColor = true;
            this.buttonSpellTimerCopyActXiv.Click += new System.EventHandler(this.buttonSpellTimerCopyActXiv_Click);
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.textSpellTimerUrl, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonSpellTimerSelectFile, 1, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // textSpellTimerUrl
            // 
            resources.ApplyResources(this.textSpellTimerUrl, "textSpellTimerUrl");
            this.textSpellTimerUrl.Name = "textSpellTimerUrl";
            this.textSpellTimerUrl.TextChanged += new System.EventHandler(this.textSpellTimerUrl_TextChanged);
            // 
            // buttonSpellTimerSelectFile
            // 
            resources.ApplyResources(this.buttonSpellTimerSelectFile, "buttonSpellTimerSelectFile");
            this.buttonSpellTimerSelectFile.Name = "buttonSpellTimerSelectFile";
            this.buttonSpellTimerSelectFile.UseVisualStyleBackColor = true;
            this.buttonSpellTimerSelectFile.Click += new System.EventHandler(this.buttonSpellTimerSelectFile_Click);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // checkSpellTimerEnableGlobalHotkey
            // 
            resources.ApplyResources(this.checkSpellTimerEnableGlobalHotkey, "checkSpellTimerEnableGlobalHotkey");
            this.checkSpellTimerEnableGlobalHotkey.Name = "checkSpellTimerEnableGlobalHotkey";
            this.checkSpellTimerEnableGlobalHotkey.UseVisualStyleBackColor = true;
            this.checkSpellTimerEnableGlobalHotkey.CheckedChanged += new System.EventHandler(this.checkSpelltimerEnableGlobalHotkey_CheckedChanged);
            // 
            // textSpellTimerGlobalHotkey
            // 
            resources.ApplyResources(this.textSpellTimerGlobalHotkey, "textSpellTimerGlobalHotkey");
            this.textSpellTimerGlobalHotkey.Name = "textSpellTimerGlobalHotkey";
            this.textSpellTimerGlobalHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSpellTimerGlobalHotkey_KeyDown);
            // 
            // listViewLog
            // 
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewLog.ContextMenuStrip = this.contextMenuLogList;
            resources.ApplyResources(this.listViewLog, "listViewLog");
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
            this.contextMenuLogList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopyLogAll,
            this.menuLogCopy,
            this.toolStripMenuItem1,
            this.menuFollowLatestLog,
            this.toolStripMenuItem2,
            this.menuClearLog});
            this.contextMenuLogList.Name = "contextMenuLogList";
            resources.ApplyResources(this.contextMenuLogList, "contextMenuLogList");
            // 
            // menuCopyLogAll
            // 
            this.menuCopyLogAll.Name = "menuCopyLogAll";
            resources.ApplyResources(this.menuCopyLogAll, "menuCopyLogAll");
            this.menuCopyLogAll.Click += new System.EventHandler(this.menuCopyLogAll_Click);
            // 
            // menuLogCopy
            // 
            this.menuLogCopy.Name = "menuLogCopy";
            resources.ApplyResources(this.menuLogCopy, "menuLogCopy");
            this.menuLogCopy.Click += new System.EventHandler(this.menuLogCopy_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // menuFollowLatestLog
            // 
            this.menuFollowLatestLog.CheckOnClick = true;
            this.menuFollowLatestLog.Name = "menuFollowLatestLog";
            resources.ApplyResources(this.menuFollowLatestLog, "menuFollowLatestLog");
            this.menuFollowLatestLog.Click += new System.EventHandler(this.menuFollowLatestLog_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // menuClearLog
            // 
            this.menuClearLog.Name = "menuClearLog";
            resources.ApplyResources(this.menuClearLog, "menuClearLog");
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiniParseMaxFrameRate)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpellTimerMaxFrameRate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.contextMenuLogList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkMiniParseVisible;
        private System.Windows.Forms.CheckBox checkMiniParseClickthru;
        private System.Windows.Forms.TextBox textMiniParseUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonMiniParseReloadBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonMiniParseSelectFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuLogList;
        private System.Windows.Forms.ToolStripMenuItem menuLogCopy;
        private System.Windows.Forms.Button buttonMiniParseCopyActXiv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textMiniParseSortKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboMiniParseSortType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkSpellTimerVisible;
        private System.Windows.Forms.CheckBox checkSpellTimerClickThru;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonSpellTimerReloadBrowser;
        private System.Windows.Forms.Button buttonSpellTimerCopyActXiv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox textSpellTimerUrl;
        private System.Windows.Forms.Button buttonSpellTimerSelectFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudMiniParseMaxFrameRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSpellTimerMaxFrameRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuFollowLatestLog;
        private System.Windows.Forms.ToolStripMenuItem menuCopyLogAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuClearLog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkEnableGlobalHotkey;
        private System.Windows.Forms.TextBox textGlobalHotkey;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkSpellTimerEnableGlobalHotkey;
        private System.Windows.Forms.TextBox textSpellTimerGlobalHotkey;
    }
}
