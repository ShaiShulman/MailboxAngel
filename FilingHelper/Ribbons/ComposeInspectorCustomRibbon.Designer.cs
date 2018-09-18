namespace FilingHelper
{
    partial class ComposeInspectorCustomRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ComposeInspectorCustomRibbon()
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
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnAttachments = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabNewMailMessage";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabNewMailMessage";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnAttachments);
            this.group1.Label = "Outlook Helper";
            this.group1.Name = "group1";
            // 
            // btnAttachments
            // 
            this.btnAttachments.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAttachments.Label = "Attachment Helper";
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.OfficeImageId = "MultiplePages";
            this.btnAttachments.ShowImage = true;
            this.btnAttachments.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAttachments_Click);
            // 
            // ComposeInspectorCustomRibbon
            // 
            this.Name = "ComposeInspectorCustomRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ComposeInspectorCustomRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAttachments;
    }

    partial class ThisRibbonCollection
    {
        internal ComposeInspectorCustomRibbon ComposeInspectorCustomRibbon
        {
            get { return this.GetRibbon<ComposeInspectorCustomRibbon>(); }
        }
    }
}
