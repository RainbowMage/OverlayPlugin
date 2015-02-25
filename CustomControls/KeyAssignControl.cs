using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainbowMage.Controls
{
    public partial class KeyAssignControl : UserControl
    {
        public KeyAssignControl()
        {
            InitializeComponent();

            this.TabStop = true;
        }

        private void KeyAssignControl_KeyDown(object sender, KeyEventArgs e)
        {
            List<string> keys = new List<string>();

            if (e.Control)
            {
                keys.Add("Ctrl");
            }
            if (e.Alt)
            {
                keys.Add("Alt");
            }
            if (e.Shift)
            {
                keys.Add("Shift");
            }
            if (e.KeyCode == Keys.ControlKey ||
                e.KeyCode == Keys.LControlKey ||
                e.KeyCode == Keys.RControlKey ||
                e.KeyCode == Keys.Menu ||
                e.KeyCode == Keys.RMenu ||
                e.KeyCode == Keys.LMenu ||
                e.KeyCode == Keys.ShiftKey ||
                e.KeyCode == Keys.RShiftKey ||
                e.KeyCode == Keys.LShiftKey)
            {
                keys.Add("");
            }
            else
            {
                keys.Add(e.KeyCode.ToString());
            }

            label1.Text = string.Join("+", keys);

            e.Handled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
