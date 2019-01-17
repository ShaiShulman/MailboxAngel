namespace FilingHelper.Controls.Settings
{
    partial class FolderHistorySettingsPanel
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
            this.chkShowNeverOption = new System.Windows.Forms.CheckBox();
            this.chkShowPersistentOption = new System.Windows.Forms.CheckBox();
            this.btnResetFolderHistory = new HelperUtils.MenuButton();
            this.txtMaxFolders = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstFolders = new System.Windows.Forms.ListView();
            this.Folder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Presist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Never = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuFolderActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPersist = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAvoid = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxFolders)).BeginInit();
            this.mnuFolderActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShowNeverOption
            // 
            this.chkShowNeverOption.AutoSize = true;
            this.chkShowNeverOption.Location = new System.Drawing.Point(6, 87);
            this.chkShowNeverOption.Name = "chkShowNeverOption";
            this.chkShowNeverOption.Size = new System.Drawing.Size(144, 17);
            this.chkShowNeverOption.TabIndex = 43;
            this.chkShowNeverOption.Text = "Show NEVER menu item";
            this.chkShowNeverOption.UseVisualStyleBackColor = true;
            // 
            // chkShowPersistentOption
            // 
            this.chkShowPersistentOption.AutoSize = true;
            this.chkShowPersistentOption.Location = new System.Drawing.Point(6, 64);
            this.chkShowPersistentOption.Name = "chkShowPersistentOption";
            this.chkShowPersistentOption.Size = new System.Drawing.Size(153, 17);
            this.chkShowPersistentOption.TabIndex = 42;
            this.chkShowPersistentOption.Text = "Show PERSIST menu item";
            this.chkShowPersistentOption.UseVisualStyleBackColor = true;
            // 
            // btnResetFolderHistory
            // 
            this.btnResetFolderHistory.Location = new System.Drawing.Point(764, 87);
            this.btnResetFolderHistory.Name = "btnResetFolderHistory";
            this.btnResetFolderHistory.Size = new System.Drawing.Size(87, 27);
            this.btnResetFolderHistory.TabIndex = 41;
            this.btnResetFolderHistory.Text = "Clear all";
            this.btnResetFolderHistory.UseVisualStyleBackColor = true;
            this.btnResetFolderHistory.Click += new System.EventHandler(this.btnResetFolderHistory_Click);
            // 
            // txtMaxFolders
            // 
            this.txtMaxFolders.Location = new System.Drawing.Point(123, 38);
            this.txtMaxFolders.Name = "txtMaxFolders";
            this.txtMaxFolders.Size = new System.Drawing.Size(51, 20);
            this.txtMaxFolders.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Maximum folders in list:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(848, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Folder History Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstFolders
            // 
            this.lstFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Folder,
            this.Presist,
            this.Never});
            this.lstFolders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstFolders.Location = new System.Drawing.Point(6, 120);
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(845, 290);
            this.lstFolders.TabIndex = 45;
            this.lstFolders.UseCompatibleStateImageBehavior = false;
            this.lstFolders.View = System.Windows.Forms.View.Details;
            this.lstFolders.SelectedIndexChanged += new System.EventHandler(this.lstFolders_SelectedIndexChanged);
            this.lstFolders.Click += new System.EventHandler(this.lstFolders_Click);
            this.lstFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstFolders_MouseClick);
            // 
            // Folder
            // 
            this.Folder.Text = "Folder";
            this.Folder.Width = 400;
            // 
            // Presist
            // 
            this.Presist.Text = "Always Show";
            this.Presist.Width = 100;
            // 
            // Never
            // 
            this.Never.Text = "Never Show";
            this.Never.Width = 100;
            // 
            // mnuFolderActions
            // 
            this.mnuFolderActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemove,
            this.toolStripSeparator1,
            this.mnuPersist,
            this.mnuAvoid});
            this.mnuFolderActions.Name = "mnuFolderActions";
            this.mnuFolderActions.Size = new System.Drawing.Size(143, 76);
            // 
            // mnuRemove
            // 
            this.mnuRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuRemove.Name = "mnuRemove";
            this.mnuRemove.Size = new System.Drawing.Size(142, 22);
            this.mnuRemove.Text = "Remove";
            this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // mnuPersist
            // 
            this.mnuPersist.CheckOnClick = true;
            this.mnuPersist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuPersist.Name = "mnuPersist";
            this.mnuPersist.Size = new System.Drawing.Size(142, 22);
            this.mnuPersist.Text = "Always show";
            this.mnuPersist.Click += new System.EventHandler(this.mnuPersist_Click);
            // 
            // mnuAvoid
            // 
            this.mnuAvoid.CheckOnClick = true;
            this.mnuAvoid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuAvoid.Name = "mnuAvoid";
            this.mnuAvoid.Size = new System.Drawing.Size(142, 22);
            this.mnuAvoid.Text = "Never show";
            this.mnuAvoid.Click += new System.EventHandler(this.mnuAvoid_Click);
            // 
            // FolderHistorySettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lstFolders);
            this.Controls.Add(this.chkShowNeverOption);
            this.Controls.Add(this.chkShowPersistentOption);
            this.Controls.Add(this.btnResetFolderHistory);
            this.Controls.Add(this.txtMaxFolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FolderHistorySettingsPanel";
            this.Size = new System.Drawing.Size(854, 413);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxFolders)).EndInit();
            this.mnuFolderActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkShowNeverOption;
        private System.Windows.Forms.CheckBox chkShowPersistentOption;
        private HelperUtils.MenuButton btnResetFolderHistory;
        private System.Windows.Forms.NumericUpDown txtMaxFolders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstFolders;
        private System.Windows.Forms.ColumnHeader Folder;
        private System.Windows.Forms.ColumnHeader Presist;
        private System.Windows.Forms.ColumnHeader Never;
        private System.Windows.Forms.ContextMenuStrip mnuFolderActions;
        private System.Windows.Forms.ToolStripMenuItem mnuRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuPersist;
        private System.Windows.Forms.ToolStripMenuItem mnuAvoid;
    }
}
