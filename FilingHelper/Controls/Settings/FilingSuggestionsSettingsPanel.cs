using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilingSuggester;

namespace FilingHelper.Controls.Settings
{
    public partial class FilingSuggestionsSettingsPanel : UserControl, ISettingsDialogPanel
    {
        private List<SuggestNode> _deletedNodes = null;
        private bool _clearAllSuggestions = false;
        public FilingSuggestionsSettingsPanel()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            PopulateSuggestionsList();
            chkSuggestSender.Checked = Properties.AddinSettings.Default.SuggestionMenuSender;
            chkConversation.Checked = Properties.AddinSettings.Default.SuggestionMenuConversation;
            chkHistory.Checked= Properties.AddinSettings.Default.SuggestionMenuHistory;
        }

        public void PopulateSuggestionsList()
        {
            FilingSuggester.Suggester suggester = Globals.ThisAddIn.FilingSuggestor;
            ctlSuggestTree.Nodes.Clear();
            string[] receipients = suggester.GetRecepients();
            foreach (var rcp in receipients)
            {
                TreeNode node = ctlSuggestTree.Nodes.Add(rcp);
                Dictionary<FolderKey, int> folders = suggester.GetFolders(rcp);
                if (folders != null)
                    foreach (var folder in folders)
                    {
                        TreeNode subnode = node.Nodes.Add(folder.Key.ToString(), string.Format("{0} ({1})", folder.Key.Description, folder.Value));
                        subnode.Tag = folder.Key;
                    }
            }
            _deletedNodes = new List<SuggestNode>();
        }
        public void SaveSettings()
        {
            Properties.AddinSettings.Default.SuggestionMenuSender = chkSuggestSender.Checked;
            Properties.AddinSettings.Default.SuggestionMenuConversation = chkConversation.Checked;
            Properties.AddinSettings.Default.SuggestionMenuHistory = chkHistory.Checked;
            Properties.AddinSettings.Default.Save();
            foreach (var node in _deletedNodes)
            {
                if (node.Folder==null)
                    Globals.ThisAddIn.FilingSuggestor.RemoveRecepient(node.Recepient);
                else
                    Globals.ThisAddIn.FilingSuggestor.RemoveFolder(node.Recepient,node.Folder);
            }
            if (_clearAllSuggestions)
                Globals.ThisAddIn.FilingSuggestor.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ctlSuggestTree.SelectedNode == null)
                return;
            TreeNode prevNode = ctlSuggestTree.SelectedNode.PrevVisibleNode;
            switch (ctlSuggestTree.SelectedNode.Level)
            {
                case 0:
                    _deletedNodes.Add(new SuggestNode(ctlSuggestTree.SelectedNode.Text));
                    ctlSuggestTree.SelectedNode.Remove();
                    break;
                case 1:
                    TreeNode parentNode = ctlSuggestTree.SelectedNode.Parent;
                    _deletedNodes.Add(new SuggestNode(parentNode.Text,(FolderKey)ctlSuggestTree.Tag));
                    ctlSuggestTree.SelectedNode.Remove();
                    if (parentNode.Nodes.Count==0)
                    {
                        parentNode.Remove();
                    }
                    break;
            }
            if (prevNode == null)
                btnDelete.Enabled = false;
            else
                ctlSuggestTree.SelectedNode = prevNode;
        }

        private void ctlSuggestTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnDelete.Enabled = true;
        }

        private class SuggestNode
        {
            public string Recepient { get; set; }
            public FolderKey Folder { get; set; }

            public SuggestNode(string recepient)
            {
                Recepient = recepient;
                Folder = null;
            }

            public SuggestNode(string recepient, FolderKey folder)
            {
                Recepient = recepient;
                Folder = folder;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (Globals.ThisAddIn.CustomMessageBox("Are you sure you want to clear all suggestions?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)== DialogResult.Yes)
                _clearAllSuggestions = true;
        }
    }
}
