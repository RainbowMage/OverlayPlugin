using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.OverlayPlugin
{
    public partial class NewOverlayDialog : Form
    {
        public delegate bool ValidateNameDelegate(string name);

        public ValidateNameDelegate NameValidator { get; set; }

        public string OverlayName { get; set; }
        public Type OverlayType { get; set; }

        public NewOverlayDialog()
        {
            InitializeComponent();

            // Default validator
            this.NameValidator = (name) => { return name != null; };

            foreach (Type type in OverlayTypeManager.ConfigToOverlayDict.Values)
            {
                comboBox1.Items.Add(type);
            }
            if (this.OverlayType != null)
            {
                comboBox1.SelectedItem = this.OverlayType;
            }
            else
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.NameValidator(this.textBox1.Text))
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please select overlay type.");
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }
                else
                {
                    this.OverlayName = textBox1.Text;
                    this.OverlayType = (Type)comboBox1.SelectedItem;
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
    }
}
