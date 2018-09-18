using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Tools.Ribbon;
using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using FilingHelper.Controls;

namespace FilingHelper
{
    public partial class ExplorerCustomRibbon
    {
        const string PERSIST_MENU_ITEM_TEXT = "ALWAYS show this folder in list";
        const string AVOID_MENU_ITEM_TEXT = "NEVER show this folder in list";
        const string FOLDER_SEARCH_DIALOG_CAPTION= "Search Folder By Name";
        const string ITEM_MOVE_DIALOG_CAPTION = "Select Folder To Move To";
        private List<MAPIFolder> _searchResults=null;
        private SelectFolderFrm _selectionForm;
        SettingsFrm _settingsForm;
        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            mnuHistory.ItemsLoading += MnuHistory_ItemsLoading;
        }

        private void BtnArchive_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ArchiveMessage(Globals.ThisAddIn.Application.ActiveExplorer());
        }

        private void MnuHistory_ItemsLoading(object sender, RibbonControlEventArgs e)
        {
            string currentFolder = Globals.ThisAddIn.Application.ActiveExplorer().CurrentFolder.EntryID;
            mnuHistory.PopulateFoldersList(Globals.ThisAddIn.FolderHistory.GetList().Where(x=>x.EntryID!= currentFolder && !x.Avoid),
                (s,ev)=>
                {
                    MAPIFolder folder = Globals.ThisAddIn.FolderHistory.Find(x => x.EntryID == (s as RibbonButton).Tag.ToString()).Folder;
                    Globals.ThisAddIn.NavigateFolder(null, folder);
                }, this.Factory 
                );
            bool isPersistent = Globals.ThisAddIn.FolderHistory.isFolderPersistent(currentFolder);
            RibbonButton buttonP = CreateRibbonButton();
            buttonP.Label = PERSIST_MENU_ITEM_TEXT;
            buttonP.Enabled = true;
            buttonP.ShowImage = isPersistent;
            if (isPersistent)
                buttonP.OfficeImageId = "AcceptInvitation";
            buttonP.Click +=
            (s, ev) =>
            {
                Globals.ThisAddIn.FolderHistory.ChangeFolderPersistence(currentFolder, !isPersistent);
            };
            mnuHistory.Items.Add(buttonP);

            bool isAvoided = Globals.ThisAddIn.FolderHistory.isFolderAvoided(currentFolder);
            RibbonButton buttonA = CreateRibbonButton();
            buttonA.Label = AVOID_MENU_ITEM_TEXT;
            buttonA.Enabled = true;
            buttonA.ShowImage = isAvoided;
            if (isAvoided)
                buttonA.OfficeImageId = "AcceptInvitation";
            buttonA.Click +=
            (s, ev) =>
            {
                Globals.ThisAddIn.FolderHistory.ChangeFolderAvoidance(currentFolder, !isAvoided);
            };
            mnuHistory.Items.Add(buttonA);
        }

        //private void PopulateFoldersList(IEnumerable<FolderInfo> list,RibbonMenu control,RibbonControlEventHandler clickHandler)
        //{
        //    control.Items.Clear();
        //    foreach (var item in list)
        //    {
        //        RibbonButton button = CreateRibbonButton();
        //        button.Label = item.Name;
        //        button.Tag = item.EntryID;
        //        button.ScreenTip = item.Path;
        //        button.Click += clickHandler;
        //        button.OfficeImageId = "Folder";
        //        button.ShowImage = true;
        //        control.Items.Add(button);
        //    }
        //}

        //public void CreateEmptyList(RibbonMenu control, string text)
        //{
        //    control.Items.Clear();
        //    RibbonButton button = CreateRibbonButton();
        //    button.Label = text;
        //    button.Enabled = false;
        //    button.ShowImage = false;
        //    control.Items.Add(button);
        //}

        private void Conversation_Button_Click(object sender, RibbonControlEventArgs e)
        {
            MAPIFolder folder = Globals.ThisAddIn.Application.Session.GetItemFromID((sender as RibbonButton).Tag.ToString());
            Globals.ThisAddIn.NavigateFolder(null, folder);
        }

        private RibbonDropDownItem CreateRibbonDropDownItem()
        {
            return this.Factory.CreateRibbonDropDownItem();
        }
        private RibbonMenu CreateRibbonMenu()
        {
            return this.Factory.CreateRibbonMenu();
        }
        private RibbonButton CreateRibbonButton()
        {
            RibbonButton button = this.Factory.CreateRibbonButton();
            return button;
        }

        private void btnCloseAll_Click(object sender, RibbonControlEventArgs e)
        {
            (new HelperUtils.WindowManager()).CloseAll(Globals.ThisAddIn.Application);
        }

        private void FolderSearchMenuButton_Click(object sender, RibbonControlEventArgs e)
        {
            MAPIFolder folder = _searchResults.Find(x => x.EntryID == (string)((RibbonButton)sender).Tag);
            Globals.ThisAddIn.NavigateFolder(null, folder);
        }

        private void txtSearchFolder_TextChanged(object sender, RibbonControlEventArgs e)
        {
            string target = ((RibbonEditBox)sender).Text;
            if (String.IsNullOrWhiteSpace(target))
            {
                _searchResults = null;
                return;
            }
            List<TreeNode<FolderSelectionNode>> results = Globals.ThisAddIn.FolderSearch.SearchTree(target,true);
            _selectionForm = new SelectFolderFrm(results,target, FOLDER_SEARCH_DIALOG_CAPTION);
            _selectionForm.FolderSelected += SelectFolderForm_Selected;
            _selectionForm.ShowDialog();
        }

        private void SelectFolderForm_Selected(object sender, FolderSelectedEventArgs e)
        {
            Globals.ThisAddIn.NavigateFolder(null, e.Folder);
            if (e.OpenFolder)
                Globals.ThisAddIn.ShowFolder(e.Folder);
            _selectionForm.Close();
            _selectionForm = null;

        }

        private void btnMoveSearch_Click(object sender, RibbonControlEventArgs e)
        {
            Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
            if (explorer == null)
                return;
            //List<MailItem> items = new List<MailItem>();
            List<MailItem> items = (new ConversationUtils()).GetConversationItems(explorer);
            //foreach (var item in explorer.Selection)
            //{
            //    if (item is MailItem)
            //        items.Add(item as MailItem);
            //}
            if (items.Count == 0)
                return;
            _selectionForm = new SelectFolderFrm(null, "",ITEM_MOVE_DIALOG_CAPTION,true);
            //_selectionForm.FolderSelected += new EventHandler<FolderSelectedEventArgs>((s, ev) => 
            //    _selectionForm_MoveTargetSelected(s, ev, items));
            _selectionForm.FolderSelected += (s, ev) =>
            {
                Globals.ThisAddIn.MoveMessages(null, ev.Folder, items.ToArray());
                //foreach (var item in items)
                //{
                //    item.Move(ev.Folder);
                //}
                _selectionForm.Close();
                _selectionForm = null;
                if (ev.OpenFolder)
                    Globals.ThisAddIn.ShowFolder(ev.Folder);
            };

            _selectionForm.ShowDialog();
        }


        private void ExplorerCustomRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnReplyAttch_Click(object sender, RibbonControlEventArgs e)
        {
            Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
            if (explorer.Selection.Count>0 && explorer.Selection[1] is MailItem)
            {
                MailItem original = explorer.Selection[1] as MailItem;
                (new RespondServices()).ReplyAttachments(original, true);
            }
        }

        private void btnItemReplyAll_Click(object sender, RibbonControlEventArgs e)
        {
            Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
            if (explorer.Selection.Count > 0 && explorer.Selection[1] is MailItem)
            {
                MailItem original = explorer.Selection[1] as MailItem;
                (new RespondServices()).ReplyAttachments(original, true);
            }

        }

        private void btnItemReply_Click(object sender, RibbonControlEventArgs e)
        {
            Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
            if (explorer.Selection.Count > 0 && explorer.Selection[1] is MailItem)
            {
                MailItem original = explorer.Selection[1] as MailItem;
                (new RespondServices()).ReplyAttachments(original, false);
            }

        }

        private void btnResearchPane_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ResearchPane(null);
        }

        private void btnNextFolder_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.FolderNavigatorService.NavigateSimilarFolder(Globals.ThisAddIn.Application.ActiveExplorer(), 1);
        }

        private void btnPrevFolder_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.FolderNavigatorService.NavigateSimilarFolder(Globals.ThisAddIn.Application.ActiveExplorer(), -1);
        }

        private void mnuConversation_ItemsLoading(object sender, RibbonControlEventArgs e)
        {
            Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
            List<MAPIFolder> folders = (new ConversationUtils()).GetConversationFolders(explorer,explorer.CurrentFolder);
            if (folders.Count > 0)
                mnuConversation.PopulateFoldersList(folders.Select(x => new FolderInfo(x)).Reverse(), 
                (s, ev) =>
                    {
                        MAPIFolder folder = Globals.ThisAddIn.Application.Session.GetFolderFromID((s as RibbonButton).Tag.ToString()) as MAPIFolder;
                        Globals.ThisAddIn.MoveMessages(explorer, folder,(new ConversationUtils()).GetConversationItems(explorer).ToArray());
                    }, this.Factory );
            else
                mnuConversation.CreateEmptyList("(No Folders to Display)",this.Factory);

        }

        private void btnSettings_Click(object sender, RibbonControlEventArgs e)
        {
            _settingsForm = new SettingsFrm();
            _settingsForm.ShowDialog();
        }
    }
}

