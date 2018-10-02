using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperUtils
{
    public partial class SideMenuItem : UserControl
    {
        public string Label
        {
            get { return lblInner.Text; }
            set { lblInner.Text = value; }
        }

        private Control panel;
        public Control Panel
        {
            get { return panel; }
            set { panel = value; }
        }

        public SideMenuItem(string label, Control panel)
        {
            InitializeComponent();
            Label = label;
            Panel = panel;
        }

        private void onMouseEnter(object sender, EventArgs e)
        {
            lblInner.BackColor = SystemColors.ScrollBar;
            panel1.BackColor = SystemColors.ScrollBar;
            panel2.BackColor = SystemColors.ScrollBar;
            panel3.BackColor = SystemColors.ScrollBar;
            panel4.BackColor = SystemColors.ScrollBar;
        }

        private void onMouseLeave(object sender, EventArgs e)
        {
            lblInner.BackColor = SystemColors.Window;
            panel1.BackColor = SystemColors.Window;
            panel2.BackColor = SystemColors.Window;
            panel3.BackColor = SystemColors.Window;
            panel4.BackColor = SystemColors.Window;
        }

        private void onClick(object sender, EventArgs e)
        {
            lblInner.BackColor = SystemColors.ScrollBar;
            panel1.BackColor = SystemColors.ButtonShadow;
            panel2.BackColor = SystemColors.ButtonShadow;
            panel3.BackColor = SystemColors.ButtonShadow;
            panel4.BackColor = SystemColors.ButtonShadow;
        }

    }
}
