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
    public partial class FolderHistorySettingsPanel : SettingsPanelBase
    {
        private List<FolderInfoUI> _changes = null;
        private bool _clearAll = false;
        public FolderHistorySettingsPanel()
        {
            InitializeComponent();
        }


        protected override void loadSettings()
        {
            txtMaxFolders.Value = Properties.AddinSettings.Default.FolderHistoryMaxItems;
            chkShowNeverOption.Checked = Properties.AddinSettings.Default.FolderHistoryAvoidVisible;
            chkShowPersistentOption.Checked = Properties.AddinSettings.Default.FolderHistoryPersistVisible;
            populateFoldersList();
            _changes = new List<FolderInfoUI>();
        }

        private void populateFoldersList()
        {
            lstFolders.Items.Clear();
            foreach (var finfo in Globals.ThisAddIn.FolderHistory.GetList())
            {
                FolderInfoUI element = new FolderInfoUI(finfo);
                lstFolders.Items.Add(new ListViewItem
                {
                    Text = finfo.Name,
                    Tag = element,
                    SubItems = { element.PersistToString(), element.AvoidToString() }
                });
            }
        }

        protected override void saveSettings()
        {
            if (Properties.AddinSettings.Default.FolderHistoryMaxItems != txtMaxFolders.Value.TryParseInt(10))
            {
                Properties.AddinSettings.Default.FolderHistoryMaxItems = txtMaxFolders.Value.TryParseInt(10);
                Globals.ThisAddIn.FolderHistory.Resize(txtMaxFolders.Value.TryParseInt(10));
            }
            Properties.AddinSettings.Default.FolderHistoryMaxItems = txtMaxFolders.Value.TryParseInt(10);
            Properties.AddinSettings.Default.FolderHistoryAvoidVisible = chkShowNeverOption.Checked;
            Properties.AddinSettings.Default.FolderHistoryPersistVisible = chkShowPersistentOption.Checked;
            if (_clearAll)
                Globals.ThisAddIn.FolderHistory.ClearAll();
            else
            { 
                foreach (var change in _changes.Distinct())
                {
                    if (change.Remove)
                        Globals.ThisAddIn.FolderHistory.Remove(change.EntryID);
                    else
                    {
                        Globals.ThisAddIn.FolderHistory.ChangeFolderAvoidance(change.EntryID, change.Avoid);
                        Globals.ThisAddIn.FolderHistory.ChangeFolderPersistence(change.EntryID, change.Persist);
                    }
                }
            }
            Properties.AddinSettings.Default.Save();
        }

        private void btnResetFolderHistory_Click(object sender, EventArgs e)
        {
            if (Globals.ThisAddIn.CustomMessageBox("Are you sure you want to clear the entire filing history?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                _clearAll = true;
                lstFolders.Items.Clear();
            }
        }

        private void lstFolders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstFolders_Click(object sender, EventArgs e)
        {
            mnuFolderActions.Show();
        }

        private void lstFolders_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstFolders.FocusedItem!=null && lstFolders.FocusedItem.Bounds.Contains(e.Location))
            {
                FolderInfoUI element = (FolderInfoUI)lstFolders.FocusedItem.Tag;
                mnuAvoid.Checked = element.Avoid;
                mnuPersist.Checked = element.Persist;
                mnuFolderActions.Show(Cursor.Position);
            }
        }

        private void mnuRemove_Click(object sender, EventArgs e)
        {
            FolderInfoUI element = (FolderInfoUI)lstFolders.FocusedItem.Tag;
            if (element != null)
            {
                element.Remove = true;
                lstFolders.FocusedItem.Remove();
                _changes.Add(element);
            }
                    }

        private void mnuPersist_Click(object sender, EventArgs e)
        {
            FolderInfoUI element = (FolderInfoUI)lstFolders.FocusedItem.Tag;
            if (element != null)
            {
                element.Persist = !element.Persist;
                _changes.Add(element);
                lstFolders.FocusedItem.SubItems[1].Text = element.PersistToString();
            }
            _changes.Add(element);
        }
        private void mnuAvoid_Click(object sender, EventArgs e)
        {
            FolderInfoUI element = (FolderInfoUI)lstFolders.FocusedItem.Tag;
            if (element != null)
            {
                element.Avoid = !element.Avoid;
                _changes.Add(element);
                lstFolders.FocusedItem.SubItems[2].Text = element.AvoidToString();
            }
            _changes.Add(element);

        }
        public class FolderInfoUI
        {
            public string EntryID { get; set; }
            public bool Remove { get; set; }
            public bool Persist { get; set; }
            public bool Avoid { get; set; }
            public FolderInfoUI(FolderInfo finfo)
            {
                EntryID = finfo.EntryID;
                Persist = finfo.Persist;
                Avoid = finfo.Avoid;
            }
            public string PersistToString()
            {
                return Persist ? "Always" : "";
            }
            public string AvoidToString()
            {
                return Avoid ? "Never" : "";
            }
        }


    }
}
