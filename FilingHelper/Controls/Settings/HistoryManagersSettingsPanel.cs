using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperUtils;

namespace FilingHelper.Controls.Settings
{
    public partial class HistoryManagersSettingsPanel : UserControl,ISettingsDialogPanel
    {
        public HistoryManagersSettingsPanel()
        {
            InitializeComponent();
        }

        private void populateAddModeList()
        {
            var values = Enum.GetValues(typeof(MailHistoryAddMode));
            for (int i = 0; i < values.Length; i++)
            {
                lstAddMode.Items.Add(((MailHistoryAddMode)values.GetValue(i)).GetDescription());
            }
        }
        public void LoadSettings()
        {
            Properties.AddinSettings.Default.Upgrade();
            txtMaxFolders.Value = Properties.AddinSettings.Default.FolderHistoryMaxItems;
            chkShowNeverOption.Checked = Properties.AddinSettings.Default.FolderHistoryAvoidVisible;
            chkShowPersistentOption.Checked = Properties.AddinSettings.Default.FolderHistoryPersistVisible;
            txtMaxMailItems.Value = Properties.AddinSettings.Default.MailHistoryMaxItems;
            populateAddModeList();
            lstAddMode.SelectedIndex = (int)Properties.AddinSettings.Default.MailHistoryAddMode;
        }

        public void SaveSettings()
        {
            if (Properties.AddinSettings.Default.FolderHistoryMaxItems != txtMaxFolders.Value.TryParseInt(10))
            {
                Properties.AddinSettings.Default.FolderHistoryMaxItems = txtMaxFolders.Value.TryParseInt(10);
                Globals.ThisAddIn.FolderHistory.Resize(txtMaxMailItems.Value.TryParseInt(10));
            }

            Properties.AddinSettings.Default.FolderHistoryMaxItems = txtMaxFolders.Value.TryParseInt(10);
            Properties.AddinSettings.Default.FolderHistoryAvoidVisible = chkShowNeverOption.Checked;
            Properties.AddinSettings.Default.FolderHistoryPersistVisible = chkShowPersistentOption.Checked;
            if (Properties.AddinSettings.Default.MailHistoryMaxItems != txtMaxMailItems.Value.TryParseInt(10))
            {
                Properties.AddinSettings.Default.MailHistoryMaxItems = txtMaxMailItems.Value.TryParseInt(10);
                Globals.ThisAddIn.MailHistory.Resize(txtMaxMailItems.Value.TryParseInt(10));
            }
            Properties.AddinSettings.Default.MailHistoryAddMode = (MailHistoryAddMode)lstAddMode.SelectedIndex;

            Properties.AddinSettings.Default.Save();
        }

        private void btnResetFolderHistory_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.FolderHistory.ClearAll();
            btnResetFolderHistory.Enabled = false;
        }

        private void btnResetMailHistory_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.MailHistory.ClearAll();
            btnResetMailHistory.Enabled = false;
        }
    }
}
