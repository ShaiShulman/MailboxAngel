using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilingHelper.Controls
{
    public partial class SelectFolderFrm : Form
    {
        const int MAX_NODE_COUNT_STOP_SEARCH = 10;
        public event EventHandler<FolderSelectedEventArgs> FolderSelected;
        private List<HelperUtils.TreeNode<FolderSelectionNode>> _data;

        private bool isUpKeyPressed=false;
        public SelectFolderFrm(List<HelperUtils.TreeNode<FolderSelectionNode>> data, string searchTerm, string dialogTitle, bool ShowOpenFormCheckbox=false )
        {
            InitializeComponent();
            if (!String.IsNullOrWhiteSpace(dialogTitle))
                this.Text = dialogTitle;
            txtSearch.Text = searchTerm;
            _data = data;
            if (_data != null)
                populateList();
            else
            {
                btnGo.Enabled = false;
            }

            btnHistory.FillFoldersList(imgFoldersIcons, HistoryMenuItem_Click,
              Globals.ThisAddIn.FolderHistory.GetList());

            chkOpenFolder.Enabled = ShowOpenFormCheckbox;
        }
        private void populateList()
        {
            lstFolders.Nodes.Clear();
            foreach (var root in _data)
            {
                TreeNode newNode = new TreeNode(root.Value.Folder.Name);
                newNode.Tag = new TreeNodeTag(root.Value.Folder, root.Value.Enabled);
                if (!root.Value.Enabled)
                    newNode.ForeColor = Color.DimGray;
                newNode.ToolTipText = root.Value.Folder.FullFolderPath;
                lstFolders.Nodes.Add(newNode);
                addNodes(newNode, root, true);
            }
            lstFolders.ExpandAll();
            if (lstFolders.Nodes.Count > 0 && lstFolders.SelectedNode == null)
            {
                TreeNode firstEnabled = firstEnabledDescendant(lstFolders.Nodes[0]);
                if (firstEnabled!=null)
                {
                    lstFolders.SelectedNode = firstEnabled;
                    firstEnabled.EnsureVisible();
                }

            }
            lstFolders.Enabled = (_data.Count > 0);
            btnGo.Enabled = (_data.Count > 0);
            if (lstFolders.GetNodeCount(true)<=MAX_NODE_COUNT_STOP_SEARCH)
                lstFolders.Select();
        }
        private void addNodes(TreeNode ctrlNode, HelperUtils.TreeNode<FolderSelectionNode> dataNode,bool fTopLevel)
        {
            TreeNode newNode;
            if (!fTopLevel)
            {
                newNode = new TreeNode(dataNode.Value.Folder.Name);
                newNode.Tag = new TreeNodeTag(dataNode.Value.Folder, dataNode.Value.Enabled);
                if (!dataNode.Value.Enabled)
                    newNode.ForeColor = Color.DimGray;
                newNode.ToolTipText = dataNode.Value.Folder.FullFolderPath;
                ctrlNode.Nodes.Add(newNode);
            }
            else
                newNode = ctrlNode;
            foreach (var subNode in dataNode.Children)
            {
                addNodes(newNode, subNode,false);
            }
        }

 
        private void lstFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!(lstFolders.SelectedNode.Tag as dynamic).Enabled)
            {
                TreeNode firstEnabled;
                if (isUpKeyPressed)
                    firstEnabled = firstEnabledDescendantAbove(lstFolders.SelectedNode);
                else
                    firstEnabled = firstEnabledDescendant(lstFolders.SelectedNode);
                if (firstEnabled != null)
                {
                    lstFolders.SelectedNode = firstEnabled;
                    firstEnabled.EnsureVisible();
                }
            }
            isUpKeyPressed = false;
        }

        private TreeNode firstEnabledDescendant(TreeNode root)
        {
            foreach (TreeNode child in root.Nodes)
            {
                if ((child.Tag as dynamic).Enabled)
                    return child;
                else
                {
                    TreeNode result = firstEnabledDescendant(child);
                    if (result != null)
                        return child;
                }
            }
            return null;
            //foreach (TreeNode child in root.Nodes)
            //{
            //    if ((child.Tag as dynamic).Enabled)
            //        return child;
            //}
            //foreach (TreeNode child in root.Nodes)
            //{
            //    TreeNode result = firstEnabledDescendant(child);
            //    if (result!=null)
            //        return child;
            //}
            //return null;
        }

        private TreeNode firstEnabledDescendantAbove(TreeNode root)
        {
            TreeNode node = root;
            while ((node=node.PrevNode)!=null)
            {
                TreeNode result=firstEnabledDescendant(node);
                if (result != null)
                    return result;
            }
            if (root.Parent != null && root.Parent.PrevNode != null)
                return firstEnabledDescendant(root.Parent.PrevNode);
            return null;
        }

        private void lstFolders_DoubleClick(object sender, EventArgs e)
        {
            if (lstFolders.SelectedNode == null || !(lstFolders.SelectedNode.Tag is TreeNodeTag))
                return;
            onFolderSelected(((TreeNodeTag)lstFolders.SelectedNode.Tag).Folder);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            if (lstFolders.SelectedNode == null || !(lstFolders.SelectedNode.Tag is TreeNodeTag))
                return;
            onFolderSelected(((TreeNodeTag)lstFolders.SelectedNode.Tag).Folder);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
                return;
            var results = Globals.ThisAddIn.FolderSearch.SearchTree(txtSearch.Text, true);
            _data = results;
            populateList();
        }

        private void SelectFolderFrm_Shown(object sender, EventArgs e)
        {
            if (!btnGo.Enabled)
                txtSearch.Focus();

        }

        private void lstFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                isUpKeyPressed = true;
            else if (e.KeyCode != Keys.Down)
                e.SuppressKeyPress = true;
        }

        private void HistoryMenuItem_Click(object sender, EventArgs e)
        {
            MAPIFolder folder = Globals.ThisAddIn.FolderHistory.Find(x => x.Path == (sender as ToolStripMenuItem).Tag.ToString()).Folder;
            if (folder != null)
                onFolderSelected(folder);

        }

        #region Event Handlers
        protected void onFolderSelected(MAPIFolder folder)
        {
            if (FolderSelected != null)
                FolderSelected(this, new FolderSelectedEventArgs(folder, chkOpenFolder.Checked));
        }
        #endregion
    }

    #region eventargs

    public class FolderSelectedEventArgs:EventArgs
    {
        private MAPIFolder _folder;
        public MAPIFolder Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        private bool _openFolder;
        public bool OpenFolder
        {
            get { return _openFolder; }
            set { _openFolder = value; }
        }


        public FolderSelectedEventArgs(MAPIFolder folder, bool OpenFolder=false )
        {
            _folder = folder;
            _openFolder = OpenFolder;
        }
    }
    #endregion


}
