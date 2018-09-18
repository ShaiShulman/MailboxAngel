namespace FilingHelper.Controls
{
    partial class SelectFolderFrm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectFolderFrm));
            this.lstFolders = new System.Windows.Forms.TreeView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.chkOpenFolder = new System.Windows.Forms.CheckBox();
            this.imgFoldersIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnHistory = new HelperUtils.MenuButton();
            this.SuspendLayout();
            // 
            // lstFolders
            // 
            this.lstFolders.FullRowSelect = true;
            this.lstFolders.HideSelection = false;
            this.lstFolders.Location = new System.Drawing.Point(12, 41);
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(364, 254);
            this.lstFolders.TabIndex = 1;
            this.lstFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.lstFolders_AfterSelect);
            this.lstFolders.DoubleClick += new System.EventHandler(this.lstFolders_DoubleClick);
            this.lstFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFolders_KeyDown);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(332, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(301, 322);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // chkOpenFolder
            // 
            this.chkOpenFolder.AutoSize = true;
            this.chkOpenFolder.Location = new System.Drawing.Point(12, 301);
            this.chkOpenFolder.Name = "chkOpenFolder";
            this.chkOpenFolder.Size = new System.Drawing.Size(139, 17);
            this.chkOpenFolder.TabIndex = 4;
            this.chkOpenFolder.TabStop = false;
            this.chkOpenFolder.Text = "Open Folder After Move";
            this.chkOpenFolder.UseVisualStyleBackColor = true;
            // 
            // imgFoldersIcons
            // 
            this.imgFoldersIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFoldersIcons.ImageStream")));
            this.imgFoldersIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFoldersIcons.Images.SetKeyName(0, "Folders.png");
            // 
            // btnHistory
            // 
            this.btnHistory.Image = global::FilingHelper.Properties.Resources.History_Small;
            this.btnHistory.Location = new System.Drawing.Point(350, 12);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(26, 20);
            this.btnHistory.TabIndex = 6;
            this.btnHistory.TabStop = false;
            this.btnHistory.UseVisualStyleBackColor = true;
            // 
            // SelectFolderFrm
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 354);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.chkOpenFolder);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lstFolders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectFolderFrm";
            this.Text = "Search Folder Name";
            this.Shown += new System.EventHandler(this.SelectFolderFrm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView lstFolders;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox chkOpenFolder;
        private HelperUtils.MenuButton btnHistory;
        private System.Windows.Forms.ImageList imgFoldersIcons;
    }
}