namespace FilingHelper.Controls.Settings
{
    partial class SettingsFrm
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
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.ctrlMenu = new HelperUtils.SideMenu();
            this.ctrlSignauresPanel = new FilingHelper.Controls.Settings.AttachmentHelperPanel();
            this.ctrlHistoryPanel = new FilingHelper.Controls.Settings.HistoryManagersSettingsPanel();
            this.ctrlAttachmentsPanel = new FilingHelper.Controls.Settings.AttachmentHelperSettingsPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSetting.Location = new System.Drawing.Point(678, 376);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSetting.TabIndex = 7;
            this.btnSaveSetting.Text = "OK";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // ctrlMenu
            // 
            this.ctrlMenu.BackColor = System.Drawing.SystemColors.Window;
            this.ctrlMenu.Items = new string[] {
        "Attachments Helper",
        "Email Signatures",
        "History"};
            this.ctrlMenu.Location = new System.Drawing.Point(3, 1);
            this.ctrlMenu.Name = "ctrlMenu";
            this.ctrlMenu.SelectedItem = 0;
            this.ctrlMenu.Size = new System.Drawing.Size(165, 398);
            this.ctrlMenu.TabIndex = 9;
            this.ctrlMenu.MenuItemSelected += new System.EventHandler<HelperUtils.MenuItemSelectedEventArgs>(this.ctrlMenu_MenuItemSelected);
            // 
            // ctrlSignauresPanel
            // 
            this.ctrlSignauresPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ctrlSignauresPanel.Location = new System.Drawing.Point(174, 1);
            this.ctrlSignauresPanel.Name = "ctrlSignauresPanel";
            this.ctrlSignauresPanel.Size = new System.Drawing.Size(732, 365);
            this.ctrlSignauresPanel.TabIndex = 10;
            this.ctrlSignauresPanel.Visible = false;
            // 
            // ctrlHistoryPanel
            // 
            this.ctrlHistoryPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ctrlHistoryPanel.Location = new System.Drawing.Point(174, 1);
            this.ctrlHistoryPanel.Name = "ctrlHistoryPanel";
            this.ctrlHistoryPanel.Size = new System.Drawing.Size(732, 365);
            this.ctrlHistoryPanel.TabIndex = 11;
            this.ctrlHistoryPanel.Visible = false;
            // 
            // ctrlAttachmentsPanel
            // 
            this.ctrlAttachmentsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ctrlAttachmentsPanel.Location = new System.Drawing.Point(174, 1);
            this.ctrlAttachmentsPanel.Name = "ctrlAttachmentsPanel";
            this.ctrlAttachmentsPanel.Size = new System.Drawing.Size(732, 365);
            this.ctrlAttachmentsPanel.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(759, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 405);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ctrlAttachmentsPanel);
            this.Controls.Add(this.ctrlHistoryPanel);
            this.Controls.Add(this.ctrlSignauresPanel);
            this.Controls.Add(this.ctrlMenu);
            this.Controls.Add(this.btnSaveSetting);
            this.Name = "SettingsFrm";
            this.Text = "OutlookHelper Settings";
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSaveSetting;
        private HelperUtils.SideMenu ctrlMenu;
        private AttachmentHelperPanel ctrlSignauresPanel;
        private HistoryManagersSettingsPanel ctrlHistoryPanel;
        private AttachmentHelperSettingsPanel ctrlAttachmentsPanel;
        private System.Windows.Forms.Button btnCancel;
    }
}