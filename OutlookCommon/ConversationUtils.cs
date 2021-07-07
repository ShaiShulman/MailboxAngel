using MailboxAngel.OutlookCommon;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MailboxAngel.OutlookCommon
{
    /// <summary>
    /// Util class for reading items from an email conversation in conversation view 
    /// </summary>
    public class ConversationUtils
    {
        /// <summary>
        /// Read mail items in selected conversation in a specific explorer pane
        /// </summary>
        /// <param name="explorer">Outlook Explorer pane</param>
        /// <returns>Array of MailItem objects representing all items in the conversation</returns>
        public MailItem[] GetConversationItems(Explorer explorer)
        {
            List<MailItem> items = new List<MailItem>();
            if (explorer.CurrentFolder.Store.IsConversationEnabled)
            {
                Selection convHeaders=explorer.Selection.GetSelection(OlSelectionContents.olConversationHeaders) as Selection;
                foreach (ConversationHeader header in convHeaders)
                {
                    SimpleItems convItems = header.GetItems();
                    foreach (var item in convItems)
                    {
                        try
                        {
                            if (item is MailItem
                                && (item as MailItem).Parent is Folder
                                && ((item as MailItem).Parent as Folder).EntryID == explorer.CurrentFolder.EntryID)
                            {
                                if (!items.Exists(x => x.EntryID == (item as MailItem).EntryID))
                                    items.Add(item as MailItem);
                            }
                        }
                        catch (COMException)
                        {
                        }
                    }
                }
            }
            foreach (var item in explorer.Selection)
            {
                if (item is MailItem
                    && !items.Exists(x => x.EntryID == (item as MailItem).EntryID))
                        items.Add(item as MailItem);
            }
            return items.ToArray();
        }
        /// <summary>
        /// Get list of folders where mail items in a conversation, use MailItem to find the conversation (called from GetConversationFolders for explorer)
        /// </summary>
        /// <param name="message">Mail item that is part of the conversation</param>
        /// <param name="excludedFolder">MAPIFolder to exclude from the search and list</param>
        /// <returns>Array of MAPIFolders that represent the list of folders</returns>
        public MAPIFolder[] GetConversationFolders(MailItem message, MAPIFolder excludedFolder = null)
        {
            FolderServices utils = new FolderServices(message.Session);
            List<FolderResult> folders = new List<FolderResult>();
            SimpleItems convItems = null;
            try
            {
                Conversation conv = message.GetConversation();
                convItems = conv.GetRootItems();
            }
            catch (COMException)
            {
            }


            if (convItems == null)
                return new MAPIFolder[0]; 
            if (convItems.Count<1)
                return new MAPIFolder[0];
            if ((convItems[1] as MailItem)==null)
                return new MAPIFolder[0];
            if ((convItems[1] as MailItem).GetConversation() == null)
                return new MAPIFolder[0];
            if ((convItems[1] as MailItem).GetConversation().GetTable() == null)
                return new MAPIFolder[0];

            Table tbl = (convItems[1] as MailItem).GetConversation().GetTable();
            while (!tbl.EndOfTable)
            {
                Row row = tbl.GetNextRow();
                var item = message.Session.GetItemFromID(row["EntryID"]);
                if (item is MailItem && (item as MailItem).Parent is MAPIFolder)
                {
                    try
                    {
                        MAPIFolder folder = (item as MailItem).Parent as MAPIFolder;
                        if (folder.EntryID != excludedFolder.EntryID
                            && !utils.isFolderSentMail(folder))
                        {
                            FolderResult match = folders.FirstOrDefault(x => x.Folder.EntryID == folder.EntryID);
                            if (match != null)
                                match.Frequency++;
                            else
                                folders.Add(new FolderResult(folder));
                        }
                    }
                    catch (COMException)
                    {
                    }
                }
            }
            return folders.OrderByDescending(x => x.Frequency).OrderBy(x => x.isInbox).Select(y => y.Folder).ToArray();
        }
        /// <summary>
        /// Get list of folders where mail items in a conversation, use selected items in Outlook Explorer to find the conversations
        /// </summary>
        /// <param name="explorer">Outlook Explorer to look for selected items</param>
        /// <param name="excludedFolder">Folder to be excluded from search and list</param>
        /// <returns>List of MAPIFolders</returns>
        public MAPIFolder[] GetConversationFolders(Explorer explorer, MAPIFolder excludedFolder=null)
        {
            if (!explorer.CurrentFolder.Store.IsConversationEnabled)
                return null;
            Selection convHeaders = explorer.Selection.GetSelection(OlSelectionContents.olConversationHeaders) as Selection;
            MailItem msg;
            if (convHeaders.Count > 0)
                msg = (convHeaders[1].GetItems()[1] as MailItem);
            else
            {
                if (explorer.Selection.Count > 0 && explorer.Selection[1] is MailItem)
                    msg = (explorer.Selection[1] as MailItem);
                else
                    return new MAPIFolder[0];
            }
            return GetConversationFolders(msg, excludedFolder);
        }
    }
    /// <summary>
    /// Util class to store results from the folders earch
    /// </summary>
    class FolderResult
    {
        private MAPIFolder _folder;
        public MAPIFolder Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        private int _frequency;
        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        private bool _inbox;
        public bool isInbox
        {
            get { return _inbox; }
            set { _inbox = value; }
        }

        public FolderResult(MAPIFolder folder)
        {
            _folder = folder;
            _frequency = 1;
            _inbox = (new FolderServices(folder.Session)).isFolderinDefaultInbox(folder);
        }
    }
}
