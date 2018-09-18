namespace FilingHelper
{
    partial class InspectorCustomRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public InspectorCustomRibbon()
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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpMailReadArchive = this.Factory.CreateRibbonGroup();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.mnuConversation = this.Factory.CreateRibbonMenu();
            this.btnMoveSearch = this.Factory.CreateRibbonButton();
            this.archiveBtn = this.Factory.CreateRibbonButton();
            this.btnArchive = this.Factory.CreateRibbonButton();
            this.office = this.Factory.CreateRibbonButton();
            this.menu2 = this.Factory.CreateRibbonMenu();
            this.btnItemReplyAll = this.Factory.CreateRibbonButton();
            this.btnItemReply = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpMailReadArchive.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabReadMessage";
            this.tab1.Groups.Add(this.grpMailReadArchive);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "TabReadMessage";
            this.tab1.Name = "tab1";
            // 
            // grpMailReadArchive
            // 
            this.grpMailReadArchive.Items.Add(this.mnuConversation);
            this.grpMailReadArchive.Items.Add(this.btnMoveSearch);
            this.grpMailReadArchive.Items.Add(this.archiveBtn);
            this.grpMailReadArchive.Items.Add(this.btnArchive);
            this.grpMailReadArchive.Items.Add(this.office);
            this.grpMailReadArchive.Label = "Move Message";
            this.grpMailReadArchive.Name = "grpMailReadArchive";
            this.grpMailReadArchive.Position = this.Factory.RibbonPosition.BeforeOfficeId("MarkAsUnread");
            // 
            // group2
            // 
            this.group2.Items.Add(this.menu2);
            this.group2.Label = "Repond (Adv)";
            this.group2.Name = "group2";
            this.group2.Position = this.Factory.RibbonPosition.AfterOfficeId("GroupMailRespond");
            // 
            // mnuConversation
            // 
            this.mnuConversation.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.mnuConversation.Dynamic = true;
            this.mnuConversation.Label = "Conversation";
            this.mnuConversation.Name = "mnuConversation";
            this.mnuConversation.OfficeImageId = "ConversationsMenu";
            this.mnuConversation.ShowImage = true;
            this.mnuConversation.ItemsLoading += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.mnuConversation_ItemsLoading);
            // 
            // btnMoveSearch
            // 
            this.btnMoveSearch.Label = "Search to Move";
            this.btnMoveSearch.Name = "btnMoveSearch";
            this.btnMoveSearch.OfficeImageId = "ZoomToSelection";
            this.btnMoveSearch.ShowImage = true;
            this.btnMoveSearch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMoveSearch_Click);
            // 
            // archiveBtn
            // 
            this.archiveBtn.Label = "Archive";
            this.archiveBtn.Name = "archiveBtn";
            this.archiveBtn.OfficeImageId = "SaveSentItemsMenu";
            this.archiveBtn.ShowImage = true;
            this.archiveBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.archiveBtn_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Label = "";
            this.btnArchive.Name = "btnArchive";
            // 
            // office
            // 
            this.office.Label = "";
            this.office.Name = "office";
            // 
            // menu2
            // 
            this.menu2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.menu2.Image = global::FilingHelper.Properties.Resources.ReplyAttch;
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
            // InspectorCustomRibbon
            // 
            this.Name = "InspectorCustomRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.InspectorCustomRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpMailReadArchive.ResumeLayout(false);
            this.grpMailReadArchive.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpMailReadArchive;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnArchive;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton office;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton archiveBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMoveSearch;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnItemReplyAll;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnItemReply;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu mnuConversation;
    }

    partial class ThisRibbonCollection
    {
        internal InspectorCustomRibbon InspectorCustomRibbon
        {
            get { return this.GetRibbon<InspectorCustomRibbon>(); }
        }
    }
}
