using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using FilingHelper.Controls;
using HelperUtils;
using MailboxAngel.OutlookCommon;

namespace FilingHelper
{
    public partial class InspectorCustomRibbon
    {


        private SelectFolderFrm _selectionForm;
        public const string ITEM_MOVE_DIALOG_CAPTION = "Select Folder To Move To";

        private void btnAttachments_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.AttachmentManager(Globals.ThisAddIn.Application.ActiveInspector());
        }

        private void archiveBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ArchiveMessage(Globals.ThisAddIn.Application.ActiveInspector());
        }

        private void btnMoveSearch_Click(object sender, RibbonControlEventArgs e)
        {
            Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector == null || !(inspector.CurrentItem is MailItem))
                return;
            MailItem item = (inspector.CurrentItem as MailItem);
            _selectionForm = new SelectFolderFrm(null, "", ITEM_MOVE_DIALOG_CAPTION,true);
            _selectionForm.FolderSelected += new EventHandler<FolderSelectedEventArgs>((s, ev) =>
                _selectionForm_MoveTargetSelected(s, ev, item));
            _selectionForm.ShowDialog();
        }

        private void _selectionForm_MoveTargetSelected(object sender, FolderSelectedEventArgs e, MailItem item)
        {
            item.Move(e.Folder);
            _selectionForm.Close();
            _selectionForm = null;
            if (e.OpenFolder)
                Globals.ThisAddIn.ShowFolder(e.Folder);
        }
        private void btnItemReplyAll_Click(object sender, RibbonControlEventArgs e)
        {
            Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector.CurrentItem is MailItem)
            {
                MailItem original = inspector.CurrentItem as MailItem;
                (new ResponseServices()).ReplyAttachments(original, true);
            }
        }

        private void btnItemReply_Click(object sender, RibbonControlEventArgs e)
        {
            Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector.CurrentItem is MailItem)
            {
                MailItem original = inspector.CurrentItem as MailItem;
                (new ResponseServices()).ReplyAttachments(original, false);
            }

        }

        private void mnuConversation_ItemsLoading(object sender, RibbonControlEventArgs e)
        {
            Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector.CurrentItem is MailItem)
            {

                FolderInfo[] history = Globals.ThisAddIn.FolderHistory.GetList().Where(x => x.EntryID != ((inspector.CurrentItem as MailItem).Parent as Folder).EntryID && !x.Avoid).ToArray();
                Globals.ThisAddIn.FilingSuggestor.CreateSuggestionMenu(null,inspector, mnuSuggestions, this.Factory,
                    Properties.AddinSettings.Default.SuggestionMenuSender,
                    Properties.AddinSettings.Default.SuggestionMenuConversation,
                    Properties.AddinSettings.Default.SuggestionMenuHistory?history:null);

                if (mnuSuggestions.Items.Count() == 0)
                    mnuSuggestions.CreateSeperator(this.Factory);
                mnuSuggestions.CreateSearchButton((s, ea) =>
                {
                    _selectionForm = new SelectFolderFrm(null, "", ITEM_MOVE_DIALOG_CAPTION, true);
                    _selectionForm.FolderSelected += new EventHandler<FolderSelectedEventArgs>((s2, ev2) =>
                        _selectionForm_MoveTargetSelected(s2, ev2, (MailItem) inspector.CurrentItem));
                    _selectionForm.ShowDialog();
                }, this.Factory, "Search others");

                //MailItem msg = (inspector.CurrentItem as MailItem);
                //MAPIFolder[] folders = (new ConversationUtils()).GetConversationFolders(msg, msg.Parent as MAPIFolder);
                //if (folders.Count() > 0)
                //    mnuConversation.PopulateFoldersList(folders.Select(x => new FolderInfo(x)).Reverse(),
                //    (s, ev) =>
                //    {
                //        MAPIFolder folder = Globals.ThisAddIn.Application.Session.GetFolderFromID((s as RibbonButton).Tag.ToString()) as MAPIFolder;
                //        Globals.ThisAddIn.MoveMessages(Globals.ThisAddIn.Application.ActiveExplorer(), folder, msg);
                //    }, this.Factory,fi=>"Folder");
                //else
                //    mnuConversation.CreateEmptyList("(No Folders to Display)", this.Factory);
            }
        }
    }
}
