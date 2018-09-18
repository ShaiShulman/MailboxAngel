using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using FilingHelper.Controls;
using HelperUtils;

namespace FilingHelper
{
    public partial class InspectorCustomRibbon
    {


        private SelectFolderFrm _selectionForm;
        public const string ITEM_MOVE_DIALOG_CAPTION = "Select Folder To Move To";

        private void InspectorCustomRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnArchive_Click(object sender, RibbonControlEventArgs e)
        {
            
        }

        private void btnAttachments_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.AttachmentManager(Globals.ThisAddIn.Application.ActiveInspector());
        }

        private void office_Click(object sender, RibbonControlEventArgs e)
        {

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
                (new RespondServices()).ReplyAttachments(original, true);
            }

        }

        private void btnItemReply_Click(object sender, RibbonControlEventArgs e)
        {
            Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector.CurrentItem is MailItem)
            {
                MailItem original = inspector.CurrentItem as MailItem;
                (new RespondServices()).ReplyAttachments(original, false);
            }

        }

        private void mnuConversation_ItemsLoading(object sender, RibbonControlEventArgs e)
        {
            Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector.CurrentItem is MailItem)
            {
                MailItem msg = (inspector.CurrentItem as MailItem);
                List<MAPIFolder> folders = (new ConversationUtils()).GetConversationFolders(msg, msg.Parent as MAPIFolder);
                if (folders.Count > 0)
                    mnuConversation.PopulateFoldersList(folders.Select(x => new FolderInfo(x)).Reverse(),
                    (s, ev) =>
                    {
                        MAPIFolder folder = Globals.ThisAddIn.Application.Session.GetFolderFromID((s as RibbonButton).Tag.ToString()) as MAPIFolder;
                        Globals.ThisAddIn.MoveMessages(Globals.ThisAddIn.Application.ActiveExplorer(), folder, msg);
                    }, this.Factory);
                else
                    mnuConversation.CreateEmptyList("(No Folders to Display)", this.Factory);
            }
        }
    }
}
