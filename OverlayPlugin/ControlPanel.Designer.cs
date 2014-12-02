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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.textMiniParseSortKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkMiniParseVisible = new System.Windows.Forms.CheckBox();
            this.checkMiniParseClickthru = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonMiniParseCopyActXiv = new System.Windows.Forms.Button();
            this.buttonMiniParseReloadBrowser = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textMiniParseUrl = new System.Windows.Forms.TextBox();
            this.buttonMiniParseSelectFile = new System.Windows.Forms.Button();
            this.comboMiniParseSortType = new System.Windows.Forms.ComboBox();
            this.listLog = new System.Windows.Forms.ListBox();
            this.contextMenuLogList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuLogCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuLogList.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listLog);
            this.splitContainer1.Size = new System.Drawing.Size(602, 412);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textMiniParseSortKey, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkMiniParseVisible, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkMiniParseClickthru, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboMiniParseSortType, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 244);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "ソートタイプ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textMiniParseSortKey
            // 
            this.textMiniParseSortKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMiniParseSortKey.Location = new System.Drawing.Point(156, 67);
            this.textMiniParseSortKey.Margin = new System.Windows.Forms.Padding(1);
            this.textMiniParseSortKey.Name = "textMiniParseSortKey";
            this.textMiniParseSortKey.Size = new System.Drawing.Size(431, 19);
            this.textMiniParseSortKey.TabIndex = 9;
            this.textMiniParseSortKey.TextChanged += new System.EventHandler(this.textSortKey_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "ソートキー";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "クリックを透過させる";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "オーバーレイを表示する";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "表示するURL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkMiniParseVisible
            // 
            this.checkMiniParseVisible.AutoSize = true;
            this.checkMiniParseVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkMiniParseVisible.Location = new System.Drawing.Point(158, 3);
            this.checkMiniParseVisible.Name = "checkMiniParseVisible";
            this.checkMiniParseVisible.Size = new System.Drawing.Size(427, 16);
            this.checkMiniParseVisible.TabIndex = 1;
            this.checkMiniParseVisible.UseVisualStyleBackColor = true;
            this.checkMiniParseVisible.CheckedChanged += new System.EventHandler(this.checkWindowVisible_CheckedChanged);
            // 
            // checkMiniParseClickthru
            // 
            this.checkMiniParseClickthru.AutoSize = true;
            this.checkMiniParseClickthru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkMiniParseClickthru.Location = new System.Drawing.Point(158, 25);
            this.checkMiniParseClickthru.Name = "checkMiniParseClickthru";
            this.checkMiniParseClickthru.Size = new System.Drawing.Size(427, 16);
            this.checkMiniParseClickthru.TabIndex = 2;
            this.checkMiniParseClickthru.UseVisualStyleBackColor = true;
            this.checkMiniParseClickthru.CheckedChanged += new System.EventHandler(this.checkMouseClickthru_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(158, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 51);
            this.panel1.TabIndex = 4;
            // 
            // buttonMiniParseCopyActXiv
            // 
            this.buttonMiniParseCopyActXiv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMiniParseCopyActXiv.Location = new System.Drawing.Point(3, 3);
            this.buttonMiniParseCopyActXiv.Name = "buttonMiniParseCopyActXiv";
            this.buttonMiniParseCopyActXiv.Size = new System.Drawing.Size(207, 45);
            this.buttonMiniParseCopyActXiv.TabIndex = 1;
            this.buttonMiniParseCopyActXiv.Text = "ActXivをクリップボードにコピー";
            this.buttonMiniParseCopyActXiv.UseVisualStyleBackColor = true;
            this.buttonMiniParseCopyActXiv.Click += new System.EventHandler(this.buttonCopyActXiv_Click);
            // 
            // buttonMiniParseReloadBrowser
            // 
            this.buttonMiniParseReloadBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMiniParseReloadBrowser.Location = new System.Drawing.Point(216, 3);
            this.buttonMiniParseReloadBrowser.Name = "buttonMiniParseReloadBrowser";
            this.buttonMiniParseReloadBrowser.Size = new System.Drawing.Size(208, 45);
            this.buttonMiniParseReloadBrowser.TabIndex = 0;
            this.buttonMiniParseReloadBrowser.Text = "ブラウザの表示をリロード";
            this.buttonMiniParseReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonMiniParseReloadBrowser.Click += new System.EventHandler(this.buttonReloadBrowser_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.Controls.Add(this.textMiniParseUrl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonMiniParseSelectFile, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(156, 45);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(431, 20);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // textMiniParseUrl
            // 
            this.textMiniParseUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMiniParseUrl.Location = new System.Drawing.Point(0, 0);
            this.textMiniParseUrl.Margin = new System.Windows.Forms.Padding(0);
            this.textMiniParseUrl.Name = "textMiniParseUrl";
            this.textMiniParseUrl.Size = new System.Drawing.Size(394, 19);
            this.textMiniParseUrl.TabIndex = 3;
            this.textMiniParseUrl.TextChanged += new System.EventHandler(this.textUrl_TextChanged);
            // 
            // buttonMiniParseSelectFile
            // 
            this.buttonMiniParseSelectFile.Location = new System.Drawing.Point(394, 0);
            this.buttonMiniParseSelectFile.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.buttonMiniParseSelectFile.Name = "buttonMiniParseSelectFile";
            this.buttonMiniParseSelectFile.Size = new System.Drawing.Size(37, 19);
            this.buttonMiniParseSelectFile.TabIndex = 4;
            this.buttonMiniParseSelectFile.Text = "...";
            this.buttonMiniParseSelectFile.UseVisualStyleBackColor = true;
            this.buttonMiniParseSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // comboMiniParseSortType
            // 
            this.comboMiniParseSortType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboMiniParseSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMiniParseSortType.FormattingEnabled = true;
            this.comboMiniParseSortType.Location = new System.Drawing.Point(156, 89);
            this.comboMiniParseSortType.Margin = new System.Windows.Forms.Padding(1);
            this.comboMiniParseSortType.Name = "comboMiniParseSortType";
            this.comboMiniParseSortType.Size = new System.Drawing.Size(431, 20);
            this.comboMiniParseSortType.TabIndex = 11;
            // 
            // listLog
            // 
            this.listLog.ContextMenuStrip = this.contextMenuLogList;
            this.listLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 12;
            this.listLog.Location = new System.Drawing.Point(0, 0);
            this.listLog.Name = "listLog";
            this.listLog.ScrollAlwaysVisible = true;
            this.listLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listLog.Size = new System.Drawing.Size(602, 132);
            this.listLog.TabIndex = 0;
            // 
            // contextMenuLogList
            // 
            this.contextMenuLogList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogCopy});
            this.contextMenuLogList.Name = "contextMenuLogList";
            this.contextMenuLogList.Size = new System.Drawing.Size(177, 26);
            // 
            // menuLogCopy
            // 
            this.menuLogCopy.Name = "menuLogCopy";
            this.menuLogCopy.Size = new System.Drawing.Size(176, 22);
            this.menuLogCopy.Text = "選択した項目をコピー";
            this.menuLogCopy.Click += new System.EventHandler(this.menuLogCopy_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(602, 276);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(594, 250);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ミニパース";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(594, 250);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "スペルタイマー";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonMiniParseReloadBrowser, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonMiniParseCopyActXiv, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(427, 51);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.checkSpellTimerVisible, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkSpellTimerClickThru, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(588, 244);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "クリックを透過させる";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "オーバーレイを表示する";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "表示するURL";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkSpellTimerVisible
            // 
            this.checkSpellTimerVisible.AutoSize = true;
            this.checkSpellTimerVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkSpellTimerVisible.Location = new System.Drawing.Point(158, 3);
            this.checkSpellTimerVisible.Name = "checkSpellTimerVisible";
            this.checkSpellTimerVisible.Size = new System.Drawing.Size(427, 16);
            this.checkSpellTimerVisible.TabIndex = 1;
            this.checkSpellTimerVisible.UseVisualStyleBackColor = true;
            this.checkSpellTimerVisible.CheckedChanged += new System.EventHandler(this.checkSpellTimerVisible_CheckedChanged);
            // 
            // checkSpellTimerClickThru
            // 
            this.checkSpellTimerClickThru.AutoSize = true;
            this.checkSpellTimerClickThru.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkSpellTimerClickThru.Location = new System.Drawing.Point(158, 25);
            this.checkSpellTimerClickThru.Name = "checkSpellTimerClickThru";
            this.checkSpellTimerClickThru.Size = new System.Drawing.Size(427, 16);
            this.checkSpellTimerClickThru.TabIndex = 2;
            this.checkSpellTimerClickThru.UseVisualStyleBackColor = true;
            this.checkSpellTimerClickThru.CheckedChanged += new System.EventHandler(this.checkSpellTimerClickThru_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(158, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 51);
            this.panel2.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.buttonSpellTimerReloadBrowser, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonSpellTimerCopyActXiv, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(427, 51);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // buttonSpellTimerReloadBrowser
            // 
            this.buttonSpellTimerReloadBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSpellTimerReloadBrowser.Location = new System.Drawing.Point(216, 3);
            this.buttonSpellTimerReloadBrowser.Name = "buttonSpellTimerReloadBrowser";
            this.buttonSpellTimerReloadBrowser.Size = new System.Drawing.Size(208, 45);
            this.buttonSpellTimerReloadBrowser.TabIndex = 0;
            this.buttonSpellTimerReloadBrowser.Text = "ブラウザの表示をリロード";
            this.buttonSpellTimerReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonSpellTimerReloadBrowser.Click += new System.EventHandler(this.buttonSpellTimerReloadBrowser_Click);
            // 
            // buttonSpellTimerCopyActXiv
            // 
            this.buttonSpellTimerCopyActXiv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSpellTimerCopyActXiv.Location = new System.Drawing.Point(3, 3);
            this.buttonSpellTimerCopyActXiv.Name = "buttonSpellTimerCopyActXiv";
            this.buttonSpellTimerCopyActXiv.Size = new System.Drawing.Size(207, 45);
            this.buttonSpellTimerCopyActXiv.TabIndex = 1;
            this.buttonSpellTimerCopyActXiv.Text = "ActXivをクリップボードにコピー";
            this.buttonSpellTimerCopyActXiv.UseVisualStyleBackColor = true;
            this.buttonSpellTimerCopyActXiv.Click += new System.EventHandler(this.buttonSpellTimerCopyActXiv_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel6.Controls.Add(this.textSpellTimerUrl, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonSpellTimerSelectFile, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(156, 45);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(431, 20);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // textSpellTimerUrl
            // 
            this.textSpellTimerUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSpellTimerUrl.Location = new System.Drawing.Point(0, 0);
            this.textSpellTimerUrl.Margin = new System.Windows.Forms.Padding(0);
            this.textSpellTimerUrl.Name = "textSpellTimerUrl";
            this.textSpellTimerUrl.Size = new System.Drawing.Size(394, 19);
            this.textSpellTimerUrl.TabIndex = 3;
            this.textSpellTimerUrl.TextChanged += new System.EventHandler(this.textSpellTimerUrl_TextChanged);
            // 
            // buttonSpellTimerSelectFile
            // 
            this.buttonSpellTimerSelectFile.Location = new System.Drawing.Point(394, 0);
            this.buttonSpellTimerSelectFile.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.buttonSpellTimerSelectFile.Name = "buttonSpellTimerSelectFile";
            this.buttonSpellTimerSelectFile.Size = new System.Drawing.Size(37, 19);
            this.buttonSpellTimerSelectFile.TabIndex = 4;
            this.buttonSpellTimerSelectFile.Text = "...";
            this.buttonSpellTimerSelectFile.UseVisualStyleBackColor = true;
            this.buttonSpellTimerSelectFile.Click += new System.EventHandler(this.buttonSpellTimerSelectFile_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(602, 412);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.contextMenuLogList.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
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
        internal System.Windows.Forms.ListBox listLog;
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
    }
}
