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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkWindowVisible = new System.Windows.Forms.CheckBox();
            this.checkMouseClickthru = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCopyActXiv = new System.Windows.Forms.Button();
            this.buttonReloadBrowser = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.contextMenuLogList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuLogCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.textSortKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboSortType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuLogList.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listLog);
            this.splitContainer1.Size = new System.Drawing.Size(481, 367);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textSortKey, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkWindowVisible, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkMouseClickthru, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboSortType, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 246);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // checkWindowVisible
            // 
            this.checkWindowVisible.AutoSize = true;
            this.checkWindowVisible.Location = new System.Drawing.Point(158, 3);
            this.checkWindowVisible.Name = "checkWindowVisible";
            this.checkWindowVisible.Size = new System.Drawing.Size(15, 14);
            this.checkWindowVisible.TabIndex = 1;
            this.checkWindowVisible.UseVisualStyleBackColor = true;
            this.checkWindowVisible.CheckedChanged += new System.EventHandler(this.checkWindowVisible_CheckedChanged);
            // 
            // checkMouseClickthru
            // 
            this.checkMouseClickthru.AutoSize = true;
            this.checkMouseClickthru.Location = new System.Drawing.Point(158, 25);
            this.checkMouseClickthru.Name = "checkMouseClickthru";
            this.checkMouseClickthru.Size = new System.Drawing.Size(15, 14);
            this.checkMouseClickthru.TabIndex = 2;
            this.checkMouseClickthru.UseVisualStyleBackColor = true;
            this.checkMouseClickthru.CheckedChanged += new System.EventHandler(this.checkMouseClickthru_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCopyActXiv);
            this.panel1.Controls.Add(this.buttonReloadBrowser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(158, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 51);
            this.panel1.TabIndex = 4;
            // 
            // buttonCopyActXiv
            // 
            this.buttonCopyActXiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyActXiv.Location = new System.Drawing.Point(36, 4);
            this.buttonCopyActXiv.Name = "buttonCopyActXiv";
            this.buttonCopyActXiv.Size = new System.Drawing.Size(137, 43);
            this.buttonCopyActXiv.TabIndex = 1;
            this.buttonCopyActXiv.Text = "ActXivをクリップボードにコピー";
            this.buttonCopyActXiv.UseVisualStyleBackColor = true;
            this.buttonCopyActXiv.Click += new System.EventHandler(this.buttonCopyActXiv_Click);
            // 
            // buttonReloadBrowser
            // 
            this.buttonReloadBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReloadBrowser.Location = new System.Drawing.Point(179, 4);
            this.buttonReloadBrowser.Name = "buttonReloadBrowser";
            this.buttonReloadBrowser.Size = new System.Drawing.Size(137, 43);
            this.buttonReloadBrowser.TabIndex = 0;
            this.buttonReloadBrowser.Text = "ブラウザの表示をリロード";
            this.buttonReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonReloadBrowser.Click += new System.EventHandler(this.buttonReloadBrowser_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.Controls.Add(this.textUrl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSelectFile, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(156, 45);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(324, 20);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // textUrl
            // 
            this.textUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textUrl.Location = new System.Drawing.Point(0, 0);
            this.textUrl.Margin = new System.Windows.Forms.Padding(0);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(287, 19);
            this.textUrl.TabIndex = 3;
            this.textUrl.TextChanged += new System.EventHandler(this.textUrl_TextChanged);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(287, 0);
            this.buttonSelectFile.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(37, 20);
            this.buttonSelectFile.TabIndex = 4;
            this.buttonSelectFile.Text = "...";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
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
            this.listLog.Size = new System.Drawing.Size(481, 117);
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
            // textSortKey
            // 
            this.textSortKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSortKey.Location = new System.Drawing.Point(156, 67);
            this.textSortKey.Margin = new System.Windows.Forms.Padding(1);
            this.textSortKey.Name = "textSortKey";
            this.textSortKey.Size = new System.Drawing.Size(324, 19);
            this.textSortKey.TabIndex = 9;
            this.textSortKey.TextChanged += new System.EventHandler(this.textSortKey_TextChanged);
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
            // comboSortType
            // 
            this.comboSortType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSortType.FormattingEnabled = true;
            this.comboSortType.Location = new System.Drawing.Point(156, 89);
            this.comboSortType.Margin = new System.Windows.Forms.Padding(1);
            this.comboSortType.Name = "comboSortType";
            this.comboSortType.Size = new System.Drawing.Size(324, 20);
            this.comboSortType.TabIndex = 11;
            this.comboSortType.SelectedIndexChanged += new System.EventHandler(this.comboSortType_SelectedIndexChanged);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(481, 367);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkWindowVisible;
        private System.Windows.Forms.CheckBox checkMouseClickthru;
        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReloadBrowser;
        internal System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuLogList;
        private System.Windows.Forms.ToolStripMenuItem menuLogCopy;
        private System.Windows.Forms.Button buttonCopyActXiv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textSortKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboSortType;
    }
}
