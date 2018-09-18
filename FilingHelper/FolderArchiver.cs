using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper
{
    public class FolderArchiver
    {
        const string SUBSIDIARIES_PARENT_NAME= "Subsidiaries";
        const int MAX_ITEMS_SEARCH = 50;
        const int SEARCH_STRING_LEN = 10;
        private MAPIFolder baseFolder;
        public MAPIFolder BaseFolder
        {
            get { return baseFolder; }
        }
        private object uiElement;

        public object UIElement
        {
            get { return uiElement; }
            set { uiElement = value; }
        }

        private Queue<MailItem> searchItems;
        private int totalItems;
        private bool canceled;

        private string searchSubject;
        private string searchSubName;
        private MAPIFolder excludedFolder;
        public MAPIFolder ExcludeFolder
        {
            set { excludedFolder = value; }
        }
        public bool HasItems
        {
            get { return searchItems.Count > 0; }
        }

        public event EventHandler<SearchInitEventArgs> SearchInitiated;
        public event EventHandler<FolderFoundEventArgs> FolderFound;
        public event EventHandler<SearchTerminatedEventArgs> SearchTerminated;
        public event EventHandler<FolderArchiverEventArgs> SearchQueueEmpty;

        public FolderArchiver(MAPIFolder BaseFolder, IEnumerable<MailItem> SearchMailItems)
        {
            baseFolder = BaseFolder;
            searchItems = new Queue<MailItem>(SearchMailItems);
            totalItems = searchItems.Count;
            init();
        }

        public FolderArchiver(MAPIFolder BaseFolder, Inspector OutlookInspector, MailItem Message)
        {
            baseFolder = BaseFolder;
            searchItems = new Queue<MailItem>();
            searchItems.Enqueue(Message);
            init();
        }
        private void init()
        {
            searchSubName = null;
            excludedFolder = null;
            totalItems = searchItems.Count;
        }

        protected void onFolderFound(MAPIFolder folder)
        {
            if (FolderFound != null)
                FolderFound(this, new FolderFoundEventArgs(folder,uiElement));
        }

        protected void onSearchTerminated(bool hasResults)
        {
            if (SearchTerminated != null)
                SearchTerminated(this,new SearchTerminatedEventArgs(hasResults,uiElement));
        }

        protected void onSearchQueueEmpty()
        {
            if (SearchQueueEmpty != null)
                SearchQueueEmpty(this, new FolderArchiverEventArgs(uiElement));
        }

        protected void onSearchInitiated(MailItem message)
        {
            if (SearchInitiated != null)
                SearchInitiated(this, new SearchInitEventArgs(message, totalItems - searchItems.Count-1, totalItems,uiElement));
        }

        public void UISearchEnded(object sender, EventArgs e)
        {
            MatchNext();
        }

        public void MatchNext()
        {
            if (searchItems.Count > 0)
            {
                MailItem item = searchItems.Dequeue();
                match(item);
            } else
            {
                onSearchQueueEmpty();
            }
        }
        public void Stop()
        {
            canceled = true;
        }
        private void match(MailItem searchItem)
        {
            canceled = false;
            onSearchInitiated(searchItem);
            searchSubject = simplifySubject(searchItem.Subject);
            searchSubName = simplifySubsidiaryName(searchItem.Subject);
            bool hasResult=search(searchItem,baseFolder);
            onSearchTerminated(hasResult);
        }

        private Boolean search(MailItem item,MAPIFolder folder,bool fCheckName=false)
        {

            bool found = false;
            if (canceled)
                return false;
            if ((excludedFolder==null || folder.FullFolderPath != excludedFolder.FullFolderPath)
                && (searchFolderItems(folder)
                    || ((fCheckName || folder.Name == SUBSIDIARIES_PARENT_NAME) && compareFolderName(folder))))
            {
                found = true;
                onFolderFound(folder);
            }
            foreach (MAPIFolder subfolder in folder.Folders)
            {
                if (search(item, subfolder, fCheckName || folder.Name == SUBSIDIARIES_PARENT_NAME))
                    found = true;
            }
            return found;
        }

        private bool searchFolderItems(MAPIFolder folder)
        {
            bool found = false;
            string fname = folder.Name;
            for (int i = folder.Items.Count; i > Math.Max(folder.Items.Count-MAX_ITEMS_SEARCH,0); i--)
            {

                if (folder.Items[i] is MailItem)
                {
                    MailItem item = (MailItem)folder.Items[i];
                    if (item.Subject != null)
                    {
                        if (simplifySubject(item.Subject).ToUpper() == simplifySubject(searchSubject).ToUpper())
                        {
                            found = true;
                            break;
                        }
                    }
                }

            }
            return found;
        }

        private bool compareFolderName(MAPIFolder folder)
        {
            string name = simplifySubsidiaryName(folder.Name);
            string desc = simplifySubsidiaryName(folder.Description);
            return (name!= null && name.Substring(0, Math.Min(searchSubName.Length - 1, name.Length-1)) == searchSubName.ToUpper())
                || (desc != null && desc.Substring(0, Math.Min(searchSubName.Length - 1, desc.Length-1)) == searchSubName.ToUpper());
        }

        private string simplifySubject(string Source)
        {
            if (Source == null)
                return null;
            if (Source.Substring(0, Math.Min(Source.Length, SEARCH_STRING_LEN)).IndexOf(':') != -1)
                Source = Source.Substring(Source.IndexOf(':')+1);
            if (Source.IndexOf(':') != -1)
                Source = Source.Substring(0, Source.IndexOf(':') - 1);
            return Source.Trim();
        }
        private string simplifySubsidiaryName(string Name)
        {
            if (Name == null)
                return null;
            return Name.Replace(".", "").Replace("LLC", "").Replace("LLP", "").Replace("Ltd", "").Replace("Prv", "").Replace("Limited", "").Replace("(", "").Replace(")", "");
        }

    }
    #region eventargs
    public class FolderArchiverEventArgs:EventArgs
    {
        protected object uiElement;
        public object UIElement
        {
            get { return uiElement; }
            set { uiElement = value; }
        }
        public FolderArchiverEventArgs(object UIElement)
        {
            uiElement = UIElement;
        }
    }

    public class SearchInitEventArgs : FolderArchiverEventArgs
    {

        private MailItem message;
        public MailItem Message
        {
            get { return message; }
            set { message = value; }
        }

        private int itemNum;
        public int ItemNum
        {
            get { return itemNum; }
            set { itemNum = value; }
        }

        private int totalItems;

        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; }
        }

        public SearchInitEventArgs(MailItem Message,int ItemsNum,int TotalItems,object UIElement):base(UIElement)
        {
            message = Message;
            itemNum = ItemsNum;
            totalItems = TotalItems;
        }
    }

    public class FolderFoundEventArgs : FolderArchiverEventArgs
    {
        private MAPIFolder folder;
        public MAPIFolder Folder
        {
            get { return folder; }
            set { folder = value; }
        }

        public FolderFoundEventArgs(MAPIFolder foundFolder,object UIElement):base(UIElement)
        {
            folder = foundFolder;
        }
    }

    public class SearchTerminatedEventArgs: FolderArchiverEventArgs
    {
        private bool hasResults;
        public bool HasResults
        {
            get { return hasResults; }
            set { hasResults = value; }
        }

        public SearchTerminatedEventArgs(Boolean HasResults,object UIElement):base(UIElement)
        {
            hasResults = HasResults;
        }
    }
    #endregion
}

