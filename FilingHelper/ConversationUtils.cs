﻿using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper
{
    public class ConversationUtils
    {
        public List<MailItem> GetConversationItems(Explorer explorer)
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
            return items;
        }

        public List<MAPIFolder> GetConversationFolders(MailItem message, MAPIFolder excludedFolder = null)
        {
            FolderServices utils = new FolderServices();
            List<FolderResult> folders = new List<FolderResult>();
            Conversation conv = message.GetConversation();
            SimpleItems convItems = conv.GetRootItems();

            if (convItems == null)
                return new List<MAPIFolder>(); 
            if (convItems.Count<1)
                return new List<MAPIFolder>();
            if ((convItems[1] as MailItem)==null)
                return new List<MAPIFolder>();
            if ((convItems[1] as MailItem).GetConversation() == null)
                return new List<MAPIFolder>();
            if ((convItems[1] as MailItem).GetConversation().GetTable() == null)
                return new List<MAPIFolder>();

            Table tbl = (convItems[1] as MailItem).GetConversation().GetTable();
            while (!tbl.EndOfTable)
            {
                Row row = tbl.GetNextRow();
                var item = Globals.ThisAddIn.Application.Session.GetItemFromID(row["EntryID"]);
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
            //return folders.OrderBy(x=>x.isInbox).OrderByDescending(x=>x.Frequency).Select(y=>y.Folder).ToList();
            return folders.OrderByDescending(x => x.Frequency).OrderBy(x => x.isInbox).Select(y => y.Folder).ToList();
        }
        public List<MAPIFolder> GetConversationFolders(Explorer explorer, MAPIFolder excludedFolder=null)
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
                    return null;
            }
            return GetConversationFolders(msg, excludedFolder);
        }
    }

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
            _inbox = (new FolderServices()).isFolderinDefaultInbox(folder);
        }
    }
}
