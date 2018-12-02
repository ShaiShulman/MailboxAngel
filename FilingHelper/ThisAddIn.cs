using System;
using System.Linq;
using System.Collections.Generic;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading;
using Microsoft.Office.Tools;
using HelperUtils;
using AttachmentManager;
using FilingHelper.Controls;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Outlook;

namespace FilingHelper
{
    public partial class ThisAddIn
    {
        const int HISTORY_SIZE = 15;
        const string APPLICATION_CAPTION = "Outlook's Little Helper";
        const string FOLDER_CHANGED_MESSAGE = "Folder Changed to";
        const string ITEM_MOVED_MESSAGE = "Mail Item(s) Moved to";
        Outlook.Inspectors inspectors;
        Outlook.Explorers explorers;
        private Dictionary<Outlook.Explorer, ExplorerWrapper> folderPanelsWrapper = new Dictionary<Outlook.Explorer, ExplorerWrapper>();
        private OutlookWindowStore<FolderArchiver> folderArchivers = new OutlookWindowStore<FolderArchiver>();
        private OutlookWindowStore<AttachmentService> attachmentManagers = new OutlookWindowStore<AttachmentService>();
        private UserControlStore<FolderArchiverCtrl> folderArchiverCtrls = new UserControlStore<FolderArchiverCtrl>();
        private UserControlStore<Controls.AttachmentsPaneCtrl> attachmentPaneCtrls = new UserControlStore<Controls.AttachmentsPaneCtrl>();
        private UserControlStore<ResearchPanelCtrl> researchPaneCtril = new UserControlStore<ResearchPanelCtrl>();

        private FolderServices _folderSearch;
        public FolderServices FolderSearch
        {
            get { return _folderSearch; }
            set { _folderSearch = value; }
        }
        private FilingSuggester.Suggester _filingSuggester = new FilingSuggester.Suggester();
        public FilingSuggester.Suggester FilingSuggestor
        {
            get { return _filingSuggester; }
        }
        private FolderHistoryManager folderHistory;
        public FolderHistoryManager FolderHistory
        {
            get { return folderHistory; }
        }
        private MailHistoryManager mailHistory;
        public MailHistoryManager MailHistory
        {
            get { return mailHistory; }
        }
        private FolderNavigator _folderNavigatorService;

        public FolderNavigator FolderNavigatorService
        {
            get { return _folderNavigatorService; }
            set { _folderNavigatorService = value; }
        }

        public Dictionary<Outlook.Explorer, ExplorerWrapper> FolderPanelsWrapper
        {
            get
            {
                return folderPanelsWrapper;
            }
        }

        private bool _updateAttachmentsOnAddRemove = true;
        public bool UpdateAttachmentsOnAddRemove
        {
            get { return _updateAttachmentsOnAddRemove; }
            set { _updateAttachmentsOnAddRemove = value; }
        }

        public void NavigateFolder(Outlook.Explorer explorer, Outlook.MAPIFolder folder)
        {
            if (folder != null)
            {
                if (explorer == null)
                    explorer = Application.ActiveExplorer();
                Thread FolderChangeThread = new Thread(() =>
                {
                    Outlook.MAPIFolder previousFolder = explorer.CurrentFolder;
                    Microsoft.Office.Tools.CustomTaskPane taskPane = this.folderPanelsWrapper[explorer].TaskPane;
                    taskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionBottom;
                    explorer.Activate();
                    if (folder.Store.ExchangeStoreType== Outlook.OlExchangeStoreType.olExchangePublicFolder)
                        explorer.NavigationPane.CurrentModule = explorer.NavigationPane.Modules.GetNavigationModule(
                            Microsoft.Office.Interop.Outlook.OlNavigationModuleType.olModuleFolderList);

                    explorer.CurrentFolder = folder;
                    taskPane.Control.BeginInvoke((System.Action)(() => {
                        ((FolderPromptCtrl)taskPane.Control).SetText(FOLDER_CHANGED_MESSAGE,folder.FullFolderPath);
                    }));
                    ((FolderPromptCtrl)taskPane.Control).Undo += (s,e)=>
                    {
                        explorer.CurrentFolder = previousFolder;
                    };
                    
                    taskPane.Visible = true;
                    Thread.Sleep(4000);
                    taskPane.Visible = false;
                });
                FolderChangeThread.Start();
                FolderHistory.Insert(folder);
            }
        }

        public void MoveMessages(Outlook.Explorer explorer, Outlook.MAPIFolder target, params Outlook.MailItem[] items)
        {
            if (explorer == null)
                explorer = Application.ActiveExplorer();
            Thread FolderChangeThread = new Thread(() =>
            {
                Microsoft.Office.Tools.CustomTaskPane taskPane = this.folderPanelsWrapper[explorer].TaskPane;
                taskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionBottom;
                explorer.Activate();
                Queue<Outlook.MailItem> movedItems = new Queue<Microsoft.Office.Interop.Outlook.MailItem>();
                Queue<Outlook.MAPIFolder> prevFolders = new Queue<Microsoft.Office.Interop.Outlook.MAPIFolder>();
                string messageUID = Guid.NewGuid().ToString();
                foreach (var item in items)
                {
                    prevFolders.Enqueue((Outlook.MAPIFolder)item.Parent);
                    movedItems.Enqueue(item.Move(target));
                }

                taskPane.Control.BeginInvoke((System.Action)(() =>
                {
                    ((FolderPromptCtrl)taskPane.Control).SetText(items.Count().ToString() + " " + ITEM_MOVED_MESSAGE,target.FullFolderPath);
                }));
                EventHandler undoDelegate= (s, e) =>
                {
                    Thread.Sleep(500);
                    int counter = 0;
                    while (movedItems.Count > 0)
                    {
                        movedItems.Dequeue().Move(prevFolders.Dequeue());
                        counter++;
                    }
                    if (counter > 0)
                        CustomMessageBox(string.Format("{0} messages returned to original folder(s)", counter), MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                ((FolderPromptCtrl)taskPane.Control).Undo += undoDelegate;

                taskPane.Visible = true;
                Thread.Sleep(4000);
                ((FolderPromptCtrl)taskPane.Control).Undo -= undoDelegate;
                taskPane.Visible = false;
            });
            FolderChangeThread.Start();
            FolderHistory.Insert(target);
        }

        public void ArchiveMessage(Outlook.Explorer explorer)
        {
            if (explorer == null)
                explorer = Application.ActiveExplorer();
            if (folderArchivers[explorer] != null)
                return;
            Outlook.Selection selection = explorer.Selection;
            List<Outlook.MailItem> items = new List<Outlook.MailItem>();
            for (int i = 1; i <= selection.Count; i++)
            {
                if (selection[i] is Outlook.MailItem)
                    items.Add(selection[i]);
            }
            FolderArchiver archiver = initializeArchiver(Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox),
                items, explorer.CurrentFolder);
            folderArchivers[explorer] = archiver;
            CustomTaskPane customPane = initializeArchivePane(explorer, null, archiver);
            archiver.UIElement = customPane;
            System.Threading.Thread searchThread = new System.Threading.Thread(() =>
            {
                archiver.MatchNext();
            });
            searchThread.Start();
        }
        public void ArchiveMessage(Outlook.Inspector inspector)
        {
            if (!(inspector.CurrentItem is Outlook.MailItem))
                return;
            if (folderArchivers[inspector] != null)
                return;
            Outlook.MailItem message = (Outlook.MailItem)inspector.CurrentItem;
            List<Outlook.MailItem> items = new List<Outlook.MailItem>();
            items.Add(inspector.CurrentItem);
            FolderArchiver archiver = initializeArchiver(Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox),
                items, null);
            if (message.Parent is Outlook.MAPIFolder)
                archiver.ExcludeFolder = (Outlook.MAPIFolder)message.Parent;
            folderArchivers[inspector] = archiver;
            CustomTaskPane customPane = initializeArchivePane(null,inspector, archiver);
            archiver.UIElement = customPane;
            //customPane.Visible = true;
            System.Threading.Thread searchThread = new System.Threading.Thread(() =>
            {
                archiver.MatchNext();
            });
            searchThread.Start();
        }
        private FolderArchiver initializeArchiver(Outlook.MAPIFolder baseFolder, List<Outlook.MailItem> items, Outlook.MAPIFolder excludeFolder)
        {
            FolderArchiver archiver = new FolderArchiver(Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox), items);
            archiver.ExcludeFolder = excludeFolder;
            archiver.SearchInitiated += Archiver_SearchInitiated;
            archiver.FolderFound += Archiver_FolderFound;
            archiver.SearchTerminated += Archiver_SearchTerminated;
            archiver.SearchQueueEmpty += Archiver_SearchQueueEmpty;
            return archiver;
        }
        private CustomTaskPane initializeArchivePane(Outlook.Explorer explorer, Outlook.Inspector inspector,FolderArchiver archiver)
        {
            FolderArchiverCtrl panel = new FolderArchiverCtrl();
            CustomTaskPane customPane; 
            if (explorer != null)
                customPane = folderArchiverCtrls.Insert(panel, "Archive Message", explorer);
            else
            {
                if (inspector != null)
                    customPane=folderArchiverCtrls.Insert(panel, "Archive Message", inspector);
                else
                    throw new System.Exception("No Inspector or Explorer specified");
            }
            customPane.VisibleChanged += ArchiverCustomPane_VisibleChanged;
            panel.Archiver = archiver;
            panel.SearchCanceledByUser += archiver.UISearchEnded;
            customPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionTop;
            customPane.Height = 150;
            return customPane;
        }

        private void ArchiverCustomPane_VisibleChanged(object sender, EventArgs e)
        {
            CustomTaskPane customPane = (CustomTaskPane)sender;
            if (!customPane.Visible)
            {
                FolderArchiver archiver = ((FolderArchiverCtrl)(customPane.Control)).Archiver;
                archiver.Stop();
                folderArchiverCtrls.Remove(customPane);
                folderArchivers.Remove(archiver);
            }
        }

        public void ResearchPane(Outlook.Explorer explorer)
        {
            if (explorer == null)
                explorer = Application.ActiveExplorer();
            if (researchPaneCtril[explorer] != null)
            {
                HideResearchPane(explorer);
                return;
            }
            researchPaneCtril.Insert(new ResearchPanelCtrl(mailHistory), "Research Manager",explorer);
            CustomTaskPane pane = researchPaneCtril[explorer];
            pane.Visible = true;
            pane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            pane.Width = 400;
            pane.VisibleChanged += ((s, e) => {
                HideResearchPane(explorer);
            });
            ResearchPanelCtrl control = (ResearchPanelCtrl)pane.Control;
            control.MailItemDropped += ResearchPane_MailItemDropped;
            control.Resize += ((s, e) => {
                control.totalWidth = pane.Width;
            });
        }
        public void HideResearchPane(Outlook.Explorer explorer)
        {
            if (researchPaneCtril[explorer] != null && researchPaneCtril[explorer].Visible)
                researchPaneCtril[explorer].Visible = false;
            researchPaneCtril[explorer] = null;
            researchPaneCtril.Remove(explorer);
        }

        private void ResearchPane_MailItemDropped(object sender, DropMailEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void AttachmentManager(Outlook.Inspector inspector)
        {
            if (!(inspector.CurrentItem is Outlook.MailItem))
                return;
            if (attachmentPaneCtrls[inspector]!=null && attachmentPaneCtrls[inspector].Visible)
            {
                HideAttachmentManager(inspector,false);
                return;
            }
            AttachmentService manager = new AttachmentService(inspector.CurrentItem);
            manager.AttachmentsFinished += Manager_AttachmentsFinished;
            attachmentManagers[inspector] = manager;
            if (attachmentPaneCtrls[inspector] == null)
                attachmentPaneCtrls.Insert(new AttachmentsPaneCtrl(manager), "Attachment Manager", inspector);
            CustomTaskPane pane = attachmentPaneCtrls[inspector];
            ((AttachmentsPaneCtrl)pane.Control).TotalWidth = pane.Width;
            pane.Visible = true;
            pane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionTop;
            manager.UIElement = pane;
            List<AttachmentCommand> attachments = (manager.getAttachments());

            Outlook.MailItem message = (Outlook.MailItem)inspector.CurrentItem;
            message.AttachmentAdd += ThisAddIn_AttachmentAdd;
            message.AttachmentRemove += Message_AttachmentRemove;
            ((AttachmentsPaneCtrl)pane.Control).Fill(attachments);
            ((AttachmentsPaneCtrl)pane.Control).AttachmentsUpdated += AttachmentPaneCtrl_AttachmentsUpdated;
            ((AttachmentsPaneCtrl)pane.Control).Resize += ((s, e) => {
                ((AttachmentsPaneCtrl)pane.Control).TotalWidth = pane.Width;
                if (pane.Height > ((AttachmentsPaneCtrl)pane.Control).MaxHeight)
                    pane.Height = ((AttachmentsPaneCtrl)pane.Control).MaxHeight;
                else
                    ((AttachmentsPaneCtrl)pane.Control).TotalHeight = pane.Height;
            });
            pane.Height = ((AttachmentsPaneCtrl)pane.Control).TotalHeight;
        }

        private void AttachmentPaneCtrl_AttachmentsUpdated(object sender, AttachmentsUpdatedEventArgs e)
        {
            CustomTaskPane pane = (e.UIElement) as CustomTaskPane;
            pane.Height = ((AttachmentsPaneCtrl)pane.Control).TotalHeight;
        }

        private void HideAttachmentManager(Outlook.Inspector inspector, bool fRemove=false)
        {


            if (!(inspector.CurrentItem is Outlook.MailItem))
                return;
            if (fRemove)
            {
                attachmentPaneCtrls.Remove(inspector);
                attachmentManagers.Remove(inspector);
            } else
            {
                if (attachmentPaneCtrls[inspector] != null)
                    attachmentPaneCtrls[inspector].Visible=false;
            }
        }
        private void ThisAddIn_AttachmentAdd(Outlook.Attachment Attachment)
        {
            if (_updateAttachmentsOnAddRemove)
            {
                Outlook.Inspector inspector = ((Outlook.MailItem)Attachment.Parent).GetInspector;
                AttachmentService manager = attachmentManagers[inspector];
                ((AttachmentsPaneCtrl)((CustomTaskPane)manager.UIElement).Control).Add(new ExistingAttachmentCommand(Attachment));
            }
        }
        private void Message_AttachmentRemove(Outlook.Attachment Attachment)
        {
            if (_updateAttachmentsOnAddRemove)
            {
                Outlook.Inspector inspector = ((Outlook.MailItem)Attachment.Parent).GetInspector;
                AttachmentService manager = attachmentManagers[inspector];
                ((AttachmentsPaneCtrl)((CustomTaskPane)manager.UIElement).Control).Remove(Attachment);
            }
        }

        private void Manager_AttachmentsFinished(object sender, AttachmentsFinishedEventArgs e)
        {
            CustomTaskPane pane= (CustomTaskPane)e.UIElement;
            pane.Visible = false;
            pane.Height = ((AttachmentsPaneCtrl)pane.Control).TotalHeight;
        }


        private void Archiver_SearchQueueEmpty(object sender, FolderArchiverEventArgs e)
        {
            Microsoft.Office.Tools.CustomTaskPane taskPane = (Microsoft.Office.Tools.CustomTaskPane)e.UIElement;
            taskPane.Visible = false;
        }

    

        private void ThisAddIn_SearchCanceledByUser(object sender, SearchCanceledByUserEventArgs e)
        {
            Outlook.Explorer explorer = Application.ActiveExplorer();
            Microsoft.Office.Tools.CustomTaskPane taskPane = (Microsoft.Office.Tools.CustomTaskPane)this.folderArchivers[explorer].UIElement;
            e.Archiver.Stop();
            folderArchiverCtrls.Remove(taskPane);
            folderArchivers.Remove(e.Archiver);
        }

        private void Archiver_FolderFound(object sender, FolderFoundEventArgs e)
        {
            Microsoft.Office.Tools.CustomTaskPane taskPane = (Microsoft.Office.Tools.CustomTaskPane)e.UIElement;
            taskPane.Control.BeginInvoke((System.Action)(() =>
            {
                ((FolderArchiverCtrl)taskPane.Control).AddFolder(e.Folder);
                ((FolderArchiverCtrl)taskPane.Control).btnArchive.Focus();
            }));
        }

        private void Archiver_SearchTerminated(object sender, SearchTerminatedEventArgs e)
        {
            Microsoft.Office.Tools.CustomTaskPane taskPane = (Microsoft.Office.Tools.CustomTaskPane)e.UIElement;
            if (e.HasResults)
            {
                taskPane.Control.BeginInvoke((System.Action)(() =>
                {
                    ((FolderArchiverCtrl)taskPane.Control).Terminate();
                    //if (!e.HasResults && !((FolderArchiver)sender).HasItems)
                    //    taskPane.Visible = false;
                }));
            } else
                (sender as FolderArchiver).MatchNext();
        }

        private void Archiver_SearchInitiated(object sender, SearchInitEventArgs e)
        {
            Microsoft.Office.Tools.CustomTaskPane taskPane = (Microsoft.Office.Tools.CustomTaskPane)e.UIElement;
            if (!taskPane.Visible) taskPane.Visible = true;
            taskPane.Control.BeginInvoke((System.Action)(() =>
            {
                ((FolderArchiverCtrl)taskPane.Control).Initialize(e.Message,e.ItemNum+1,e.TotalItems);
            }));
        }

        public void CustomMessageBox(string message,MessageBoxButtons buttons,MessageBoxIcon icon)
        {
            MessageBox.Show(message, APPLICATION_CAPTION, buttons, icon);
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += Inspectors_NewInspector;
            explorers = this.Application.Explorers;
            explorers.NewExplorer += Explorers_NewExplorer;
            foreach (Outlook.Explorer explorer in explorers)
            {
                Explorers_NewExplorer(explorer);
            }

            this.Application.ItemSend += Application_ItemSend;

            folderHistory = new FolderHistoryManager(Properties.AddinSettings.Default.FolderHistoryMaxItems);
            folderHistory.Load();
            mailHistory = new MailHistoryManager(Properties.AddinSettings.Default.MailHistoryMaxItems);
            mailHistory.Load();
            ((Outlook.ApplicationEvents_11_Event)Application).Quit += ThisAddIn_Quit;
            _folderSearch = new FolderServices();
            _folderNavigatorService = new FolderNavigator();
        }

        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            MailItem mail = (MailItem)Item;
            if (mail.MessageClass == "IPM.Note")
                (new SignaturesService()).ApplyCustomSignature(mail);
        }

        private void Items_ItemAdd(object Item)
        {
            throw new NotImplementedException();
        }

        private void ThisAddIn_Quit()
        {
            folderHistory.Save();
            MailHistory.Save();
        }

        private void Explorers_NewExplorer(Outlook.Explorer Explorer)
        {
            folderPanelsWrapper.Add(Explorer, new ExplorerWrapper(Explorer, new FolderPromptCtrl(), "Folder Action"));
            Explorer.BeforeFolderSwitch += Explorer_BeforeFolderSwitch;
            Explorer.SelectionChange += (() =>
            {
                if (Properties.AddinSettings.Default.MailHistoryAddMode== MailHistoryAddMode.ExplorerSelectionChange
                    && Explorer.Selection.Count > 0 && Explorer.Selection[1] is Outlook.MailItem)
                {
                    Outlook.MailItem mailItem = Explorer.Selection[1] as Outlook.MailItem;
                    mailHistory.Insert(mailItem);
                }
                ((Folder)Explorer.CurrentFolder).BeforeItemMove += ThisAddIn_BeforeItemMove;
            });
        }

        private void ThisAddIn_BeforeItemMove(object Item, MAPIFolder MoveTo, ref bool Cancel)
        {
            if (Item is MailItem)
            {
                MailItem item = (MailItem)Item;
                _filingSuggester.Update(item.Sender.Address, (Folder)MoveTo);
            }
        }

        public void ShowFolder(Outlook.MAPIFolder folder, bool isNewWindow=false)
        {
            if (isNewWindow)
            {
                Outlook.Explorer newExplorer = Application.Explorers.Add(folder, Outlook.OlFolderDisplayMode.olFolderDisplayFolderOnly);
                newExplorer.Display();
            }
            else
                Application.ActiveExplorer().CurrentFolder = folder;
        }


        private void Explorer_BeforeFolderSwitch(object NewFolder, ref bool Cancel)
        {
            if (NewFolder != null)
            {
                Outlook.MAPIFolder folder = (Outlook.MAPIFolder)NewFolder;
                folderHistory.Insert(folder);

            }
        }

        private void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            if (Properties.AddinSettings.Default.MailHistoryAddMode== MailHistoryAddMode.InspectorOpened
                && Inspector.CurrentItem is Outlook.MailItem)
            {
                Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
                mailHistory.Insert(mailItem);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            explorers.NewExplorer -= Explorers_NewExplorer;
            explorers = null;
            folderPanelsWrapper = null;
            //archivePanelsWrapper = null;
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
