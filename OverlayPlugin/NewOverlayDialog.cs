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
        public OverlayType OverlayType { get; set; }

        public NewOverlayDialog()
        {
            InitializeComponent();

            // Default validator
            this.NameValidator = (name) => { return name != null; };

            foreach (OverlayType type in Enum.GetValues(typeof(OverlayType)))
            {
                comboBox1.Items.Add(type);
            }
            comboBox1.SelectedItem = this.OverlayType;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.NameValidator(this.textBox1.Text))
            {
                this.OverlayName = textBox1.Text;
                this.OverlayType = (OverlayType)comboBox1.SelectedItem;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
    }
}
