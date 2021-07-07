using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilingHelper.Controls.Settings
{
    public partial class SettingsFrm : Form
    {
        private SettingsPanelBase[] _panels;
        private int _initialItem=0;
        public SettingsFrm()
        {
            InitializeComponent();
            _panels =new SettingsPanelBase[]{ctrlAttachments,ctrlFolders,ctrlMail,ctrlSuggestions,ctrlSignatures};
        }
        public SettingsFrm(int selectedItem) 
            : this()
        {
            _initialItem = selectedItem;
        }

        private void saveSettings()
        {
            foreach (var panel in _panels)
            {
                panel.SaveSettings();
            }
        }

        private void ctrlMenu_MenuItemSelected(object sender, HelperUtils.MenuItemSelectedEventArgs e)
        {


            ctrlAttachments.Visible = e.SelectedItem == 0;
            ctrlFolders.Visible = e.SelectedItem == 1;
            ctrlMail.Visible = e.SelectedItem == 2;
            ctrlSuggestions.Visible = e.SelectedItem == 3;
            ctrlSignatures.Visible = e.SelectedItem == 4;
            _panels[e.SelectedItem].LoadSettings();
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            ctrlMenu.SelectedItem = _initialItem;
            _panels[_initialItem].LoadSettings();
        }
    }
}
