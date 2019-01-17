namespace FilingHelper.Controls.Settings
{
    partial class MailHistorySettingsPanel
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxMailItems = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnResetMailHistory = new HelperUtils.MenuButton();
            this.lstAddMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxMailItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(6, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(848, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Mail Items History Panel";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaxMailItems
            // 
            this.txtMaxMailItems.Location = new System.Drawing.Point(126, 26);
            this.txtMaxMailItems.Name = "txtMaxMailItems";
            this.txtMaxMailItems.Size = new System.Drawing.Size(51, 20);
            this.txtMaxMailItems.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Maximum items in list:";
            // 
            // btnResetMailHistory
            // 
            this.btnResetMailHistory.Location = new System.Drawing.Point(9, 82);
            this.btnResetMailHistory.Name = "btnResetMailHistory";
            this.btnResetMailHistory.Size = new System.Drawing.Size(133, 21);
            this.btnResetMailHistory.TabIndex = 34;
            this.btnResetMailHistory.Text = "Clear mail history";
            this.btnResetMailHistory.UseVisualStyleBackColor = true;
            this.btnResetMailHistory.Click += new System.EventHandler(this.btnResetMailHistory_Click);
            // 
            // lstAddMode
            // 
            this.lstAddMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstAddMode.FormattingEnabled = true;
            this.lstAddMode.Location = new System.Drawing.Point(126, 52);
            this.lstAddMode.Name = "lstAddMode";
            this.lstAddMode.Size = new System.Drawing.Size(151, 21);
            this.lstAddMode.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Add new items when:";
            // 
            // MailHistorySettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstAddMode);
            this.Controls.Add(this.txtMaxMailItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnResetMailHistory);
            this.Name = "MailHistorySettingsPanel";
            this.Size = new System.Drawing.Size(854, 413);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxMailItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtMaxMailItems;
        private System.Windows.Forms.Label label4;
        private HelperUtils.MenuButton btnResetMailHistory;
        private System.Windows.Forms.ComboBox lstAddMode;
        private System.Windows.Forms.Label label5;
    }
}
