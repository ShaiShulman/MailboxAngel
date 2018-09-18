namespace FilingHelper
{
    partial class FolderArchiverCtrl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderArchiverCtrl));
            this.lstFolders = new System.Windows.Forms.ListView();
            this.imgFoldersIcons = new System.Windows.Forms.ImageList(this.components);
            this.ctlProgress = new System.Windows.Forms.ProgressBar();
            this.lblFolderNum = new System.Windows.Forms.Label();
            this.lblMessageHeader = new System.Windows.Forms.Label();
            this.lblItemNum = new System.Windows.Forms.Label();
            this.chkAutoSelect = new System.Windows.Forms.CheckBox();
            this.chkOpenFolder = new System.Windows.Forms.CheckBox();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHistoricFolders = new HelperUtils.MenuButton();
            this.SuspendLayout();
            // 
            // lstFolders
            // 
            this.lstFolders.AutoArrange = false;
            this.lstFolders.FullRowSelect = true;
            this.lstFolders.HideSelection = false;
            this.lstFolders.HoverSelection = true;
            this.lstFolders.Location = new System.Drawing.Point(3, 37);
            this.lstFolders.MultiSelect = false;
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.ShowItemToolTips = true;
            this.lstFolders.Size = new System.Drawing.Size(434, 87);
            this.lstFolders.SmallImageList = this.imgFoldersIcons;
            this.lstFolders.TabIndex = 0;
            this.lstFolders.UseCompatibleStateImageBehavior = false;
            this.lstFolders.View = System.Windows.Forms.View.List;
            this.lstFolders.DoubleClick += new System.EventHandler(this.lstFolders_DoubleClick);
            // 
            // imgFoldersIcons
            // 
            this.imgFoldersIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFoldersIcons.ImageStream")));
            this.imgFoldersIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFoldersIcons.Images.SetKeyName(0, "Folders.png");
            // 
            // ctlProgress
            // 
            this.ctlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlProgress.Location = new System.Drawing.Point(0, 3);
            this.ctlProgress.Name = "ctlProgress";
            this.ctlProgress.Size = new System.Drawing.Size(671, 11);
            this.ctlProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ctlProgress.TabIndex = 3;
            this.ctlProgress.Visible = false;
            // 
            // lblFolderNum
            // 
            this.lblFolderNum.AutoSize = true;
            this.lblFolderNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderNum.Location = new System.Drawing.Point(595, 19);
            this.lblFolderNum.Name = "lblFolderNum";
            this.lblFolderNum.Size = new System.Drawing.Size(11, 13);
            this.lblFolderNum.TabIndex = 4;
            this.lblFolderNum.Text = " ";
            // 
            // lblMessageHeader
            // 
            this.lblMessageHeader.AutoSize = true;
            this.lblMessageHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageHeader.Location = new System.Drawing.Point(10, 19);
            this.lblMessageHeader.Name = "lblMessageHeader";
            this.lblMessageHeader.Size = new System.Drawing.Size(111, 13);
            this.lblMessageHeader.TabIndex = 5;
            this.lblMessageHeader.Text = "lblMessageHeader";
            // 
            // lblItemNum
            // 
            this.lblItemNum.AutoSize = true;
            this.lblItemNum.Location = new System.Drawing.Point(612, 19);
            this.lblItemNum.Name = "lblItemNum";
            this.lblItemNum.Size = new System.Drawing.Size(59, 13);
            this.lblItemNum.TabIndex = 6;
            this.lblItemNum.Text = "lblItemNum";
            // 
            // chkAutoSelect
            // 
            this.chkAutoSelect.AutoSize = true;
            this.chkAutoSelect.Location = new System.Drawing.Point(571, 43);
            this.chkAutoSelect.Name = "chkAutoSelect";
            this.chkAutoSelect.Size = new System.Drawing.Size(81, 17);
            this.chkAutoSelect.TabIndex = 4;
            this.chkAutoSelect.Text = "Auto Select";
            this.chkAutoSelect.UseVisualStyleBackColor = true;
            // 
            // chkOpenFolder
            // 
            this.chkOpenFolder.AutoSize = true;
            this.chkOpenFolder.Location = new System.Drawing.Point(571, 66);
            this.chkOpenFolder.Name = "chkOpenFolder";
            this.chkOpenFolder.Size = new System.Drawing.Size(85, 17);
            this.chkOpenFolder.TabIndex = 5;
            this.chkOpenFolder.Text = "Show Folder";
            this.chkOpenFolder.UseVisualStyleBackColor = true;
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Image = global::FilingHelper.Properties.Resources.Folders_Small;
            this.btnPickFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPickFolder.Location = new System.Drawing.Point(443, 67);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(100, 27);
            this.btnPickFolder.TabIndex = 2;
            this.btnPickFolder.Text = "Select Folder";
            this.btnPickFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TT.SetToolTip(this.btnPickFolder, "Select Folder");
            this.btnPickFolder.UseVisualStyleBackColor = true;
            this.btnPickFolder.Click += new System.EventHandler(this.btnPickFolder_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Image = global::FilingHelper.Properties.Resources.Move2Folder_Small;
            this.btnArchive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchive.Location = new System.Drawing.Point(443, 37);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(100, 27);
            this.btnArchive.TabIndex = 1;
            this.btnArchive.Text = "Move";
            this.btnArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TT.SetToolTip(this.btnArchive, "Move");
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.UseWaitCursor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::FilingHelper.Properties.Resources.Cancell_Small;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(571, 97);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHistoricFolders
            // 
            this.btnHistoricFolders.Image = global::FilingHelper.Properties.Resources.History_Small;
            this.btnHistoricFolders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoricFolders.Location = new System.Drawing.Point(443, 97);
            this.btnHistoricFolders.Name = "btnHistoricFolders";
            this.btnHistoricFolders.Size = new System.Drawing.Size(100, 27);
            this.btnHistoricFolders.TabIndex = 3;
            this.btnHistoricFolders.Text = "History";
            this.btnHistoricFolders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistoricFolders.UseVisualStyleBackColor = true;
            // 
            // FolderArchiverCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnHistoricFolders);
            this.Controls.Add(this.btnPickFolder);
            this.Controls.Add(this.chkOpenFolder);
            this.Controls.Add(this.chkAutoSelect);
            this.Controls.Add(this.lblItemNum);
            this.Controls.Add(this.lblMessageHeader);
            this.Controls.Add(this.lblFolderNum);
            this.Controls.Add(this.ctlProgress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.lstFolders);
            this.Name = "FolderArchiverCtrl";
            this.Size = new System.Drawing.Size(674, 127);
            this.TT.SetToolTip(this, "Cancel");
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderArchiverCtrl_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstFolders;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ProgressBar ctlProgress;
        private System.Windows.Forms.ImageList imgFoldersIcons;
        private System.Windows.Forms.Label lblFolderNum;
        private System.Windows.Forms.Label lblMessageHeader;
        private System.Windows.Forms.Label lblItemNum;
        public System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.CheckBox chkAutoSelect;
        private System.Windows.Forms.CheckBox chkOpenFolder;
        public System.Windows.Forms.Button btnPickFolder;
        private System.Windows.Forms.ToolTip TT;
        private HelperUtils.MenuButton btnHistoricFolders;
    }
}
