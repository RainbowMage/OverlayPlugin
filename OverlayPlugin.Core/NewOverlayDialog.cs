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
        public IOverlayAddon SelectedOverlayType { get; set; }

        private PluginMain pluginMain;

        public NewOverlayDialog(PluginMain pluginMain)
        {
            InitializeComponent();

            this.pluginMain = pluginMain;

            // Default validator
            this.NameValidator = (name) => { return name != null; };

            foreach (var addon in pluginMain.Addons)
            {
                comboBox1.Items.Add(addon);
            }

            //comboBox1.ValueMember = "OverlayType";
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = 0;
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
                    this.SelectedOverlayType = (IOverlayAddon)comboBox1.SelectedItem;
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private class ComboItem
        {
            public Type OverlayType { get; set; }
            public string FriendlyName { get; set; }

            public ComboItem(Type overlayType, string friendlyName)
            {
                OverlayType = overlayType;
                FriendlyName = friendlyName;
            }
        }
    }
}
