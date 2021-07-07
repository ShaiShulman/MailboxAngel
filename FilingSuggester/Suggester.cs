using HelperUtils;
using MailboxAngel.OutlookCommon;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilingSuggester
{
    /// <summary>
    /// 
    /// Class for keeping track of suggested folders per sender and generating list of suggestions for mail item
    /// The class loads the master list of suggestions from file when Outlook loads, update suggestions when a mail item is mvoed to a folder and save the suggestions back to file when Outlook exits
    /// 
    /// </summary>
    public class Suggester : JsonPersistent<Dictionary<string, CounterList<FolderKey>>>
    {
        const string FILE_NAME = "FilingSuggestion.json"; // Where suggestions (sender - folder pairs) are stored
        private readonly OlDefaultFolders[] _ExcludedDefaultFolders = { OlDefaultFolders.olFolderInbox, OlDefaultFolders.olFolderDrafts, OlDefaultFolders.olFolderDeletedItems };
        private Microsoft.Office.Interop.Outlook.NameSpace _session;
        private Dictionary<string, CounterList<FolderKey>> _list;

        private List<string> _excludedFoldersEntryId;
        private bool _supressSaving;
        public bool SupressSaving
        {
            get { return _supressSaving; }
            set { _supressSaving = value; }
        }

        public string[] GetRecepients()
        {
            return _list.Select(x => x.Key).ToArray();
        }
        public void RemoveRecepient(string recepient)
        {
            if (_list.ContainsKey(recepient))
                _list.Remove(recepient);
        }
        /// <summary>
        /// Remove folder-sender pair from list
        /// </summary>
        /// <param name="recepient">Email of recepient/sender</param>
        /// <param name="key">Folder key</param>
        public void RemoveFolder(string recepient, FolderKey key)
        {
            {
                if (_list.ContainsKey(recepient))
                {
                    _list[recepient].Remove(key);
                }
                if (_list[recepient].Empty)
                    _list.Remove(recepient);
            }
        }
        /// <summary>
        /// Clear the entire suggestion list
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }
        /// <summary>
        /// Get suggested folders for a recepient/sender
        /// </summary>
        /// <param name="recepient">Email of recepient/sender</param>
        /// <returns>Dicrionary containing folder keys and number of matches for the recepients</returns>
        public Dictionary<FolderKey,int> GetFolders(string recepient)
        {
            if (_list.ContainsKey(recepient))
                return _list[recepient].GetDictionary();
            else
                return null;
        }

        public event EventHandler<MessagesMoveEventArgs> MessagesMove;
        /// <summary>
        /// Builds full path of the file containing master list of suggestions
        /// </summary>
        protected override string GetFileName()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FILE_NAME);
        }
        /// <summary>
        /// Constrator for Suggester class
        /// </summary>
        /// <param name="session">Current Outlook session</param>
        /// <param name="excludedFoldersEntryId">EntryID for folders to be excluded from suggestions</param>
        public Suggester(Microsoft.Office.Interop.Outlook.NameSpace session,string[] excludedFoldersEntryId)
        {
            _list = new Dictionary<string, CounterList<FolderKey>>();
            _session = session;
            if (excludedFoldersEntryId == null)
                _excludedFoldersEntryId = new List<string>();
            else
                _excludedFoldersEntryId = excludedFoldersEntryId.ToList();

            populateDefaultExcludedFolders(_excludedFoldersEntryId);
        }
        /// <summary>
        /// Update master suggestion table after a mail items as moved to a folder
        /// </summary>
        /// <param name="recepient">recepient/sender of mail item</param>
        /// <param name="folder">Folder object of the folder the mail item was moved to</param>
        public void Update(string recepient, Folder folder)
        {
            if (!_list.ContainsKey(recepient))
                _list.Add(recepient, new CounterList<FolderKey>(new FolderKey.EqualityComparer()));
            else
                _list[recepient].Add(new FolderKey(folder));
        }
        /// <summary>
        /// Get suggested folders for based on mail item recepient
        /// </summary>
        /// <param name="recepient">Email address of mail item recepient/sender for look up</param>
        /// <param name="topItems">Number of items to return</param>
        /// <returns>List of folder objects</returns>
        public Folder[] GetSuggestions(string recepient,int topItems)
        {
            if (_list.ContainsKey(recepient))
                return _list[recepient].GetTop(topItems).Where(y => !_excludedFoldersEntryId.Contains(y.Key)).Select(x=> x.OutlookFolder).ToArray();
            else
                return new Folder[0];
        }
        /// <summary>
        /// Save suggestion master list in file (called on Outlook exit)
        /// </summary>
        public void Save()
        {
            if (!_supressSaving)
                Save(SerializeJson());
        }
        /// <summary>
        /// Load suggestion master list (callsed on Outlook load)
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            try
            {
                string txt = LoadText();
                return DeserializeJson(txt);
            }
            catch (IOException)
            {
                return false;
            }
        }
        /// <summary>
        /// return Folder objects for the default folders to be excluded from suggestions
        /// </summary>
        /// <param name="list">List of Folder objects</param>
        private void populateDefaultExcludedFolders(List<string> list)
        {
            foreach (var item in _ExcludedDefaultFolders)
            {
                Folder folder = (Folder)_session.GetDefaultFolder(item);
                if (folder != null)
                    list.Add(folder.EntryID);
            }
        }
        /// <summary>
        /// Serialize the master suggestion list
        /// </summary>
        /// <returns>Json string</returns>
        private string SerializeJson()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartArray();
                writer.Formatting = Formatting.Indented;
                foreach (var item in _list)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Sender");
                    writer.WriteValue(item.Key);
                    writer.WritePropertyName("Folders");
                    writer.WriteStartArray();
                    item.Value.WriteJson(writer);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            return sb.ToString();
        }
        /// <summary>
        /// Deserialize the master suggestion list load from file
        /// </summary>
        /// <param name="json">json string containing the master list</param>
        /// <returns>True if succesfull </returns>
        private bool DeserializeJson(string json)
        {
            _list = new Dictionary<string, CounterList<FolderKey>>();
            dynamic jsonList = null;
            try
            {
                jsonList = JsonConvert.DeserializeObject(json);
            }
            catch (JsonReaderException)
            {

                return false;
            }
            foreach (var item in jsonList)
            {
                CounterList<FolderKey> foldersList = new CounterList<FolderKey>(new FolderKey.EqualityComparer());
                try
                {
                    string senderName = item.Sender;
                    foreach (var folder in item.Folders)
                    {
                        try
                        {
                            Folder outlookFolder = (Folder)_session.GetFolderFromID(folder.Folder);
                            foldersList.Add(new FolderKey(outlookFolder), (int)folder.Counter);
                        }
                        catch (COMException)
                        {
                        }

                    }
                    if (!_list.ContainsKey(senderName))
                         _list.Add(senderName, foldersList);
                }
                catch (RuntimeBinderException) { }
            }
            return true;
        }
        /// <summary>
        /// Create a suggestion menu that include suggestions based on recepient, history and conversation
        /// </summary>
        /// <param name="explorer">Outlook Explorer pane from which the menu is called (null of called from Inspector)</param>
        /// <param name="inspector">Outlook Inspectgor pane from which the menu is called (null of called from Explorer)</param>
        /// <param name="menu">Ribbon menu to which the items will be added</param>
        /// <param name="factory">RibbonFactory object to use</param>
        /// <param name="showSuggestions">Show suggestion based on recepients</param>
        /// <param name="showConversation">Show suggestions based on conversation</param>
        /// <param name="history">Show history of last used folder</param>
        /// <returns>Array of MailItems currently selected for which the menu was created</returns>
        public MailItem[] CreateSuggestionMenu(Explorer explorer, Inspector inspector, Microsoft.Office.Tools.Ribbon.RibbonMenu menu, RibbonFactory factory, bool showSuggestions, bool showConversation, FolderInfo[] history)
        {
            NameSpace session = explorer != null ? explorer.Session : inspector.Session;
            MAPIFolder[] Convfolders=new MAPIFolder[0];
            Folder currentFolder = null;
            List<MailItem> mailItems = new List<MailItem>();
            if (explorer != null)
            {
                currentFolder = (Folder)explorer.CurrentFolder;
                if (showConversation)
                    Convfolders = (new ConversationUtils()).GetConversationFolders(explorer, currentFolder);
                else
                    Convfolders = new MAPIFolder[0];

                if (explorer.Selection.Count > 1)
                    foreach (var item in explorer.Selection)
                    {
                        if (item is MailItem)
                            mailItems.Add(item as MailItem);
                    }
                else
                    mailItems = (new ConversationUtils()).GetConversationItems(explorer).ToList();
            }
            else
                if (inspector != null && inspector.CurrentItem is MailItem)
                {
                    MailItem item = inspector.CurrentItem as MailItem;
                    mailItems.Add(item);
                    currentFolder = (Folder) item.Parent;
                    if (showConversation)
                        Convfolders =(new ConversationUtils()).GetConversationFolders(item, item.Parent as MAPIFolder);
                    else
                        Convfolders = new MAPIFolder[0];
            }

            Folder[] suggestFolders = new Folder[0];
            if (mailItems.Count>0 && showSuggestions)
            {
                MailItem msg = mailItems[0];
                string recepient = (new MailItemUtils()).GetSenderEmailAddress(msg);
                suggestFolders = GetSuggestions(recepient, 5)
                    .Where(x => (currentFolder == null || x.EntryID != currentFolder.EntryID) && !Convfolders.Select(y => y.EntryID).Contains(x.EntryID)).ToArray();
            }
            FolderInfo[] historyFiltered = new FolderInfo[0];
            if (history != null)
                historyFiltered = history.Where(x => !suggestFolders.Select(y => y.EntryID).Contains(x.EntryID))
                        .Where(x => !Convfolders.Select(y => y.EntryID).Contains(x.EntryID)).ToArray();
            if (Convfolders.Count()>0 || suggestFolders.Count()>0 || historyFiltered.Count()>0)
            {
                RibbonControlEventHandler clickHandler = ((s, ev) =>
                {
                    Folder folder = (Folder)(session.GetFolderFromID((s as RibbonButton).Tag.ToString()));
                    onMessagesMove(explorer, folder, mailItems.ToArray());
                });
                menu.Clear();
                menu.PopulateFoldersList(Convfolders.Select(x => new FolderInfo(x)).Reverse(),clickHandler, factory, 
                    fi => "ConversationsMenu", "Conversation: ");
                if (Convfolders.Count()>0 && (suggestFolders.Count() > 0 || historyFiltered.Count() > 0))
                    menu.CreateSeperator(factory);
                menu.PopulateFoldersList(suggestFolders.Select(x => new FolderInfo(x)),clickHandler, factory, 
                    fi => "Move", "Suggestion: ");
                if (suggestFolders.Count() > 0 && (Convfolders.Count() > 0 || historyFiltered.Count()>0))
                    menu.CreateSeperator(factory);
                menu.PopulateFoldersList(historyFiltered,clickHandler,factory, 
                    fi => fi.Persist ? "CreateMailRule" : "Folder", "History: ");
                menu.CreateSeperator(factory);
            }
            return mailItems.ToArray();
        }

        protected void onMessagesMove(Explorer explorer,Folder target, MailItem[] items)
        {
            if (MessagesMove!=null)
                MessagesMove(this, new MessagesMoveEventArgs() { Explorer = explorer, Target = target, Items = items });
        }
    }
    #region EventArgs
    public class MessagesMoveEventArgs : EventArgs
    {
        public Explorer Explorer { get; set; }
        public Folder Target { get; set; }
        public MailItem[] Items { get; set; }
    }
    #endregion
}
