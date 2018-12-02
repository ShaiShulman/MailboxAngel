namespace FilingHelper.Controls.Settings
{
    partial class HistoryManagersSettingsPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxFolders = new System.Windows.Forms.NumericUpDown();
            this.btnResetFolderHistory = new HelperUtils.MenuButton();
            this.chkShowPersistentOption = new System.Windows.Forms.CheckBox();
            this.chkShowNeverOption = new System.Windows.Forms.CheckBox();
            this.btnResetPersistAvoid = new HelperUtils.MenuButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxMailItems = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnResetMailHistory = new HelperUtils.MenuButton();
            this.lstAddMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxMailItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(715, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Folder History Menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Maximum folders in list:";
            // 
            // txtMaxFolders
            // 
            this.txtMaxFolders.Location = new System.Drawing.Point(123, 38);
            this.txtMaxFolders.Name = "txtMaxFolders";
            this.txtMaxFolders.Size = new System.Drawing.Size(51, 20);
            this.txtMaxFolders.TabIndex = 33;
            // 
            // btnResetFolderHistory
            // 
            this.btnResetFolderHistory.Location = new System.Drawing.Point(6, 110);
            this.btnResetFolderHistory.Name = "btnResetFolderHistory";
            this.btnResetFolderHistory.Size = new System.Drawing.Size(133, 29);
            this.btnResetFolderHistory.TabIndex = 34;
            this.btnResetFolderHistory.Text = "Clear folder history";
            this.btnResetFolderHistory.UseVisualStyleBackColor = true;
            this.btnResetFolderHistory.Click += new System.EventHandler(this.btnResetFolderHistory_Click);
            // 
            // chkShowPersistentOption
            // 
            this.chkShowPersistentOption.AutoSize = true;
            this.chkShowPersistentOption.Location = new System.Drawing.Point(6, 64);
            this.chkShowPersistentOption.Name = "chkShowPersistentOption";
            this.chkShowPersistentOption.Size = new System.Drawing.Size(153, 17);
            this.chkShowPersistentOption.TabIndex = 35;
            this.chkShowPersistentOption.Text = "Show PERSIST menu item";
            this.chkShowPersistentOption.UseVisualStyleBackColor = true;
            // 
            // chkShowNeverOption
            // 
            this.chkShowNeverOption.AutoSize = true;
            this.chkShowNeverOption.Location = new System.Drawing.Point(6, 87);
            this.chkShowNeverOption.Name = "chkShowNeverOption";
            this.chkShowNeverOption.Size = new System.Drawing.Size(144, 17);
            this.chkShowNeverOption.TabIndex = 36;
            this.chkShowNeverOption.Text = "Show NEVER menu item";
            this.chkShowNeverOption.UseVisualStyleBackColor = true;
            // 
            // btnResetPersistAvoid
            // 
            this.btnResetPersistAvoid.Location = new System.Drawing.Point(6, 145);
            this.btnResetPersistAvoid.Name = "btnResetPersistAvoid";
            this.btnResetPersistAvoid.Size = new System.Drawing.Size(133, 29);
            this.btnResetPersistAvoid.TabIndex = 37;
            this.btnResetPersistAvoid.Text = "Clear Persist and Never";
            this.btnResetPersistAvoid.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 195);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(715, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Mail Items History Panel";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaxMailItems
            // 
            this.txtMaxMailItems.Location = new System.Drawing.Point(123, 225);
            this.txtMaxMailItems.Name = "txtMaxMailItems";
            this.txtMaxMailItems.Size = new System.Drawing.Size(51, 20);
            this.txtMaxMailItems.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Maximum items in list:";
            // 
            // btnResetMailHistory
            // 
            this.btnResetMailHistory.Location = new System.Drawing.Point(6, 281);
            this.btnResetMailHistory.Name = "btnResetMailHistory";
            this.btnResetMailHistory.Size = new System.Drawing.Size(133, 29);
            this.btnResetMailHistory.TabIndex = 34;
            this.btnResetMailHistory.Text = "Clear mail history";
            this.btnResetMailHistory.UseVisualStyleBackColor = true;
            this.btnResetMailHistory.Click += new System.EventHandler(this.btnResetMailHistory_Click);
            // 
            // lstAddMode
            // 
            this.lstAddMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstAddMode.FormattingEnabled = true;
            this.lstAddMode.Location = new System.Drawing.Point(123, 251);
            this.lstAddMode.Name = "lstAddMode";
            this.lstAddMode.Size = new System.Drawing.Size(151, 21);
            this.lstAddMode.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Add new items when:";
            // 
            // HistoryManagersSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstAddMode);
            this.Controls.Add(this.txtMaxMailItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnResetPersistAvoid);
            this.Controls.Add(this.chkShowNeverOption);
            this.Controls.Add(this.chkShowPersistentOption);
            this.Controls.Add(this.btnResetMailHistory);
            this.Controls.Add(this.btnResetFolderHistory);
            this.Controls.Add(this.txtMaxFolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HistoryManagersSettingsPanel";
            this.Size = new System.Drawing.Size(732, 365);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxMailItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtMaxFolders;
        private HelperUtils.MenuButton btnResetFolderHistory;
        private System.Windows.Forms.CheckBox chkShowPersistentOption;
        private System.Windows.Forms.CheckBox chkShowNeverOption;
        private HelperUtils.MenuButton btnResetPersistAvoid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtMaxMailItems;
        private System.Windows.Forms.Label label4;
        private HelperUtils.MenuButton btnResetMailHistory;
        private System.Windows.Forms.ComboBox lstAddMode;
        private System.Windows.Forms.Label label5;
    }
}
