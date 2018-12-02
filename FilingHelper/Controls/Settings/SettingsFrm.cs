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
        private ISettingsDialogPanel[] _panels;
        private int _initialItem=0;
        public SettingsFrm()
        {
            InitializeComponent();
            _panels =new ISettingsDialogPanel[]{ctrlSignauresPanel,ctrlAttachmentsPanel,ctrlHistoryPanel};
            loadSettings();
        }
        public SettingsFrm(int selectedItem) 
            : this()
        {
            _initialItem = selectedItem;
        }

        private void loadSettings()
        {
            foreach (var panel in _panels)
            {
                panel.LoadSettings();
            }
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
  

            ctrlAttachmentsPanel.Visible = e.SelectedItem == 0;
            ctrlSignauresPanel.Visible = e.SelectedItem == 1;
            ctrlHistoryPanel.Visible = e.SelectedItem == 2;
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
        }
    }
}
