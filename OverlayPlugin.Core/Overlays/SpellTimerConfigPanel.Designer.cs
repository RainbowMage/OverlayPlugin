namespace RainbowMage.OverlayPlugin.Overlays
{
    partial class SpellTimerConfigPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellTimerConfigPanel));
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMaxFrameRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxVisible = new System.Windows.Forms.CheckBox();
            this.checkBoxClickThru = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReloadBrowser = new System.Windows.Forms.Button();
            this.buttonCopyVariable = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonSpellTimerSelectFile = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textGlobalHotkey = new System.Windows.Forms.TextBox();
            this.checkEnableGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkLock = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFrameRate)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.nudMaxFrameRate, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxVisible, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxClickThru, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label12, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.textGlobalHotkey, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.checkEnableGlobalHotkey, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.checkLock, 1, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // nudMaxFrameRate
            // 
            resources.ApplyResources(this.nudMaxFrameRate, "nudMaxFrameRate");
            this.nudMaxFrameRate.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMaxFrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxFrameRate.Name = "nudMaxFrameRate";
            this.nudMaxFrameRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxFrameRate.ValueChanged += new System.EventHandler(this.nudMaxFrameRate_ValueChanged);
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
            // checkBoxVisible
            // 
            resources.ApplyResources(this.checkBoxVisible, "checkBoxVisible");
            this.checkBoxVisible.Name = "checkBoxVisible";
            this.checkBoxVisible.UseVisualStyleBackColor = true;
            this.checkBoxVisible.CheckedChanged += new System.EventHandler(this.checkBoxVisible_CheckedChanged);
            // 
            // checkBoxClickThru
            // 
            resources.ApplyResources(this.checkBoxClickThru, "checkBoxClickThru");
            this.checkBoxClickThru.Name = "checkBoxClickThru";
            this.checkBoxClickThru.UseVisualStyleBackColor = true;
            this.checkBoxClickThru.CheckedChanged += new System.EventHandler(this.checkBoxClickThru_CheckedChanged);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Name = "panel2";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.buttonReloadBrowser, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonCopyVariable, 0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // buttonReloadBrowser
            // 
            resources.ApplyResources(this.buttonReloadBrowser, "buttonReloadBrowser");
            this.buttonReloadBrowser.Name = "buttonReloadBrowser";
            this.buttonReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonReloadBrowser.Click += new System.EventHandler(this.buttonSpellTimerReloadBrowser_Click);
            // 
            // buttonCopyVariable
            // 
            resources.ApplyResources(this.buttonCopyVariable, "buttonCopyVariable");
            this.buttonCopyVariable.Name = "buttonCopyVariable";
            this.buttonCopyVariable.UseVisualStyleBackColor = true;
            this.buttonCopyVariable.Click += new System.EventHandler(this.buttonCopyVariable_Click);
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.textBoxUrl, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.buttonSpellTimerSelectFile, 1, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // textBoxUrl
            // 
            resources.ApplyResources(this.textBoxUrl, "textBoxUrl");
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Leave += new System.EventHandler(this.textBoxUrl_Leave);
            // 
            // buttonSpellTimerSelectFile
            // 
            resources.ApplyResources(this.buttonSpellTimerSelectFile, "buttonSpellTimerSelectFile");
            this.buttonSpellTimerSelectFile.Name = "buttonSpellTimerSelectFile";
            this.buttonSpellTimerSelectFile.UseVisualStyleBackColor = true;
            this.buttonSpellTimerSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textGlobalHotkey
            // 
            resources.ApplyResources(this.textGlobalHotkey, "textGlobalHotkey");
            this.textGlobalHotkey.Name = "textGlobalHotkey";
            this.textGlobalHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textGlobalHotkey_KeyDown);
            // 
            // checkEnableGlobalHotkey
            // 
            resources.ApplyResources(this.checkEnableGlobalHotkey, "checkEnableGlobalHotkey");
            this.checkEnableGlobalHotkey.Name = "checkEnableGlobalHotkey";
            this.checkEnableGlobalHotkey.UseVisualStyleBackColor = true;
            this.checkEnableGlobalHotkey.CheckedChanged += new System.EventHandler(this.checkEnableGlobalHotkey_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // checkLock
            // 
            resources.ApplyResources(this.checkLock, "checkLock");
            this.checkLock.Name = "checkLock";
            this.checkLock.UseVisualStyleBackColor = true;
            this.checkLock.CheckedChanged += new System.EventHandler(this.checkLock_CheckedChanged);
            // 
            // SpellTimerConfigPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "SpellTimerConfigPanel";
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFrameRate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudMaxFrameRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxVisible;
        private System.Windows.Forms.CheckBox checkBoxClickThru;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonReloadBrowser;
        private System.Windows.Forms.Button buttonCopyVariable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonSpellTimerSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textGlobalHotkey;
        private System.Windows.Forms.CheckBox checkEnableGlobalHotkey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkLock;
    }
}
