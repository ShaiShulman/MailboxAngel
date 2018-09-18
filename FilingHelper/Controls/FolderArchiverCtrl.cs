using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using HelperUtils;

namespace FilingHelper
{
    public partial class FolderArchiverCtrl : UserControl
    {
        public event EventHandler SearchCanceledByUser;
        private MailItem mailItem;
        private FolderArchiver archiver;
        public FolderArchiver Archiver
        {
            get { return archiver; }
            set { archiver = value; }
        }

        public FolderArchiverCtrl()
        {
            InitializeComponent();
        }

        public void Initialize(MailItem selectedMailItem, int currentItem, int maxItems)
        {
            Initialize(selectedMailItem);
            lblItemNum.Text = maxItems > 1 ? string.Format("{0} / {1}", currentItem, maxItems) : "";
            lblMessageHeader.Text = selectedMailItem.Subject;
            chkOpenFolder.Checked = false;
        }

        public void Initialize(MailItem selectedMailItem)
        {
            mailItem = selectedMailItem;
            lstFolders.Clear();
            if (!ctlProgress.Visible)
                ctlProgress.Visible = true;
            btnArchive.Enabled = false;
            lstFolders.Enabled = false;
            lblItemNum.ResetText();
            btnHistoricFolders.FillFoldersList(imgFoldersIcons, HistoryMenuItem_Click,
                Globals.ThisAddIn.FolderHistory.GetList(), Globals.ThisAddIn.Application.ActiveExplorer().CurrentFolder.FolderPath);
        }
        public void AddFolder(MAPIFolder folder)
        {
            ListViewItem item = new ListViewItem(folder.Name);
            item.Tag = folder;
            item.Selected = (lstFolders.Items.Count==0);
            item.ImageIndex = 0;
            item.ToolTipText = folder.FullFolderPath;
            lstFolders.Items.Add(item);
            //if (lstFolders.SelectedItems.Count==0 && lstFolders.Items.Count != 0)
            //    lstFolders.Items[0].Selected = true;
            btnArchive.Enabled = lstFolders.Items.Count > 0;
            lstFolders.Enabled = lstFolders.Items.Count > 0;
            if (lstFolders.SelectedItems.Count == 1 && chkAutoSelect.Checked)
            {
                MoveTo(folder);
            }
        }
        public void Terminate()
        {
            ctlProgress.Visible = false;
        }

        public void MoveNext()
        {
            
        }

        protected void onSearchCanceledByUser()
        {
            if (SearchCanceledByUser != null)
                SearchCanceledByUser(this, new SearchCanceledByUserEventArgs(archiver));
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (lstFolders.SelectedItems.Count !=0)
            {
                MoveTo((MAPIFolder)lstFolders.SelectedItems[0].Tag);
            }
        }

        private void MoveTo(MAPIFolder folder)
        {
            ctlProgress.Visible = true;
            mailItem.Move(folder);
            if (chkOpenFolder.Checked)
                Globals.ThisAddIn.ShowFolder(folder);
            ctlProgress.Visible = false;
            onSearchCanceledByUser();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            onSearchCanceledByUser();
        }

        private void FolderArchiverCtrl_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            archiver.Stop();
            MAPIFolder folder = Globals.ThisAddIn.Application.GetNamespace("MAPI").PickFolder();
            if (folder != null)
            {
                MoveTo(folder);
            }
        }

        private void HistoryMenuItem_Click(object sender, EventArgs e)
        {
            MAPIFolder folder = Globals.ThisAddIn.FolderHistory.Find(x => x.Path == (sender as ToolStripMenuItem).Tag.ToString()).Folder;
            if (folder != null)
                MoveTo(folder);
        }


        private void lstFolders_DoubleClick(object sender, EventArgs e)
        {
            if (lstFolders.SelectedItems.Count != 0)
            {
                MoveTo((MAPIFolder)lstFolders.SelectedItems[0].Tag);
            }
        }
    }
    #region eventargs
    class SearchCanceledByUserEventArgs : EventArgs
    {
        private FolderArchiver archiver;

        public FolderArchiver Archiver
        {
            get { return archiver; }
            set { archiver = value; }
        }

        public SearchCanceledByUserEventArgs(FolderArchiver Archiver)
        {
            archiver = Archiver;
        }
    }

    #endregion

}
