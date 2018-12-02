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

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set {
                _selected = value;
                lblInner.BackColor = _selected ? SystemColors.ScrollBar : SystemColors.Window;
                panel1.BackColor = _selected ? SystemColors.ButtonShadow : SystemColors.Window;
                panel2.BackColor = _selected ? SystemColors.ButtonShadow : SystemColors.Window;
                panel3.BackColor = _selected ? SystemColors.ButtonShadow : SystemColors.Window;
                panel4.BackColor = _selected ? SystemColors.ButtonShadow : SystemColors.Window;
            }
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
            if (_selected)
                return;
            lblInner.BackColor = SystemColors.ScrollBar;
            panel1.BackColor = SystemColors.ScrollBar;
            panel2.BackColor = SystemColors.ScrollBar;
            panel3.BackColor = SystemColors.ScrollBar;
            panel4.BackColor = SystemColors.ScrollBar;
        }

        private void onMouseLeave(object sender, EventArgs e)
        {
            if (_selected)
                return;
            lblInner.BackColor = SystemColors.Window;
            panel1.BackColor = SystemColors.Window;
            panel2.BackColor = SystemColors.Window;
            panel3.BackColor = SystemColors.Window;
            panel4.BackColor = SystemColors.Window;
        }

        private void onItemClick(object sender, EventArgs e)
        {
            _selected = true;
            this.OnClick(EventArgs.Empty);
        }

    }
}
