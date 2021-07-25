namespace FilingHelper
{
    partial class ExplorerCustomRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ExplorerCustomRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl2 = this.Factory.CreateRibbonDialogLauncher();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerCustomRibbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.tab2 = this.Factory.CreateRibbonTab();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.grpFoldersGroup = this.Factory.CreateRibbonGroup();
            this.txtSearchFolder = this.Factory.CreateRibbonEditBox();
            this.grpFilingGroup = this.Factory.CreateRibbonGroup();
            this.tab3 = this.Factory.CreateRibbonTab();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menu1 = this.Factory.CreateRibbonMenu();
            this.menu2 = this.Factory.CreateRibbonMenu();
            this.btnItemReplyAll = this.Factory.CreateRibbonButton();
            this.btnItemReply = this.Factory.CreateRibbonButton();
            this.btnPrevFolder = this.Factory.CreateRibbonButton();
            this.btnNextFolder = this.Factory.CreateRibbonButton();
            this.mnuHistory = this.Factory.CreateRibbonMenu();
            this.mnuSuggestions = this.Factory.CreateRibbonMenu();
            this.btnMoveSearch = this.Factory.CreateRibbonButton();
            this.btnResearchPane = this.Factory.CreateRibbonButton();
            this.btnCloseAll = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.group2.SuspendLayout();
            this.grpFoldersGroup.SuspendLayout();
            this.grpFilingGroup.SuspendLayout();
            this.tab3.SuspendLayout();
            this.group3.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabFolder";
            this.tab1.Label = "TabFolder";
            this.tab1.Name = "tab1";
            // 
            // tab2
            // 
            this.tab2.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab2.ControlId.OfficeId = "TabMail";
            this.tab2.Groups.Add(this.group2);
            this.tab2.Groups.Add(this.grpFoldersGroup);
            this.tab2.Groups.Add(this.grpFilingGroup);
            this.tab2.Label = "TabMail";
            this.tab2.Name = "tab2";
            // 
            // group2
            // 
            this.group2.Items.Add(this.menu2);
            this.group2.Label = "Repond (Adv)";
            this.group2.Name = "group2";
            this.group2.Position = this.Factory.RibbonPosition.AfterOfficeId("GroupMailRespond");
            // 
            // grpFoldersGroup
            // 
            this.grpFoldersGroup.DialogLauncher = ribbonDialogLauncherImpl1;
            this.grpFoldersGroup.Items.Add(this.txtSearchFolder);
            this.grpFoldersGroup.Items.Add(this.btnPrevFolder);
            this.grpFoldersGroup.Items.Add(this.btnNextFolder);
            this.grpFoldersGroup.Items.Add(this.mnuHistory);
            this.grpFoldersGroup.Label = "Folder Helper";
            this.grpFoldersGroup.Name = "grpFoldersGroup";
            this.grpFoldersGroup.Position = this.Factory.RibbonPosition.BeforeOfficeId("GroupCurrentView");
            this.grpFoldersGroup.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.grpFoldersGroup_DialogLauncherClick);
            // 
            // txtSearchFolder
            // 
            this.txtSearchFolder.KeyTip = "L";
            this.txtSearchFolder.Label = "Search:";
            this.txtSearchFolder.Name = "txtSearchFolder";
            this.txtSearchFolder.SizeString = "Search Folder";
            this.txtSearchFolder.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.txtSearchFolder_TextChanged);
            // 
            // grpFilingGroup
            // 
            this.grpFilingGroup.DialogLauncher = ribbonDialogLauncherImpl2;
            this.grpFilingGroup.Items.Add(this.mnuSuggestions);
            this.grpFilingGroup.Items.Add(this.btnMoveSearch);
            this.grpFilingGroup.Label = "Move Message";
            this.grpFilingGroup.Name = "grpFilingGroup";
            this.grpFilingGroup.Position = this.Factory.RibbonPosition.BeforeOfficeId("GroupCurrentView");
            this.grpFilingGroup.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.grpFilingGroup_DialogLauncherClick);
            // 
            // tab3
            // 
            this.tab3.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab3.ControlId.OfficeId = "TabView";
            this.tab3.Groups.Add(this.group3);
            this.tab3.Groups.Add(this.group1);
            this.tab3.Label = "TabView";
            this.tab3.Name = "tab3";
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnResearchPane);
            this.group3.Label = "Research";
            this.group3.Name = "group3";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnCloseAll);
            this.group1.Label = "Window Helper";
            this.group1.Name = "group1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menu1
            // 
            this.menu1.Label = "menu1";
            this.menu1.Name = "menu1";
            this.menu1.ShowImage = true;
            // 
            // menu2
            // 
            this.menu2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menu2.Image = ((System.Drawing.Image)(resources.GetObject("menu2.Image")));
            this.menu2.Items.Add(this.btnItemReplyAll);
            this.menu2.Items.Add(this.btnItemReply);
            this.menu2.Label = "Reply w/ Attachments";
            this.menu2.Name = "menu2";
            this.menu2.ShowImage = true;
            // 
            // btnItemReplyAll
            // 
            this.btnItemReplyAll.Label = "Reply All";
            this.btnItemReplyAll.Name = "btnItemReplyAll";
            this.btnItemReplyAll.OfficeImageId = "ReplyAll";
            this.btnItemReplyAll.ShowImage = true;
            this.btnItemReplyAll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnItemReplyAll_Click);
            // 
            // btnItemReply
            // 
            this.btnItemReply.Label = "Reply Sender";
            this.btnItemReply.Name = "btnItemReply";
            this.btnItemReply.OfficeImageId = "Reply";
            this.btnItemReply.ShowImage = true;
            this.btnItemReply.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnItemReply_Click);
            // 
            // btnPrevFolder
            // 
            this.btnPrevFolder.Label = "Previous";
            this.btnPrevFolder.Name = "btnPrevFolder";
            this.btnPrevFolder.OfficeImageId = "MessagePrevious";
            this.btnPrevFolder.ShowImage = true;
            this.btnPrevFolder.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrevFolder_Click);
            // 
            // btnNextFolder
            // 
            this.btnNextFolder.Label = "Next";
            this.btnNextFolder.Name = "btnNextFolder";
            this.btnNextFolder.OfficeImageId = "MessageNext";
            this.btnNextFolder.ShowImage = true;
            this.btnNextFolder.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnNextFolder_Click);
            // 
            // mnuHistory
            // 
            this.mnuHistory.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.mnuHistory.Dynamic = true;
            this.mnuHistory.Label = "History";
            this.mnuHistory.Name = "mnuHistory";
            this.mnuHistory.OfficeImageId = "StartTimer";
            this.mnuHistory.ShowImage = true;
            this.mnuHistory.ItemsLoading += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.MnuHistory_ItemsLoading);
            // 
            // mnuSuggestions
            // 
            this.mnuSuggestions.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.mnuSuggestions.Dynamic = true;
            this.mnuSuggestions.Label = "Suggestions";
            this.mnuSuggestions.Name = "mnuSuggestions";
            this.mnuSuggestions.OfficeImageId = "ConversationsMenu";
            this.mnuSuggestions.ShowImage = true;
            this.mnuSuggestions.ItemsLoading += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.mnuConversation_ItemsLoading);
            // 
            // btnMoveSearch
            // 
            this.btnMoveSearch.Label = "Search to Move";
            this.btnMoveSearch.Name = "btnMoveSearch";
            this.btnMoveSearch.OfficeImageId = "ZoomToSelection";
            this.btnMoveSearch.ShowImage = true;
            this.btnMoveSearch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMoveSearch_Click);
            // 
            // btnResearchPane
            // 
            this.btnResearchPane.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnResearchPane.Image = global::FilingHelper.Properties.Resources.if_ilustracoes_04_11_1519786__2_;
            this.btnResearchPane.Label = "Mail History";
            this.btnResearchPane.Name = "btnResearchPane";
            this.btnResearchPane.ShowImage = true;
            this.btnResearchPane.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnResearchPane_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnCloseAll.Label = "Close All";
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.OfficeImageId = "ViewDisplayInHighContrast";
            this.btnCloseAll.ShowImage = true;
            this.btnCloseAll.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCloseAll_Click);
            // 
            // ExplorerCustomRibbon
            // 
            this.Name = "ExplorerCustomRibbon";
            // 
            // ExplorerCustomRibbon.OfficeMenu
            // 
            this.OfficeMenu.Items.Add(this.menu1);
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.tab2);
            this.Tabs.Add(this.tab3);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ExplorerCustomRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.grpFoldersGroup.ResumeLayout(false);
            this.grpFoldersGroup.PerformLayout();
            this.grpFilingGroup.ResumeLayout(false);
            this.grpFilingGroup.PerformLayout();
            this.tab3.ResumeLayout(false);
            this.tab3.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnItemReplyAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnItemReply;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpFoldersGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPrevFolder;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnNextFolder;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mnuHistory;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox txtSearchFolder;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpFilingGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mnuSuggestions;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnResearchPane;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCloseAll;
        private System.Windows.Forms.ImageList imageList1;
        private Microsoft.Office.Tools.Ribbon.RibbonButton btnMoveSearch;
    }

    partial class ThisRibbonCollection
    {
        internal ExplorerCustomRibbon MainRibbon
        {
            get { return this.GetRibbon<ExplorerCustomRibbon>(); }
        }
    }
}
