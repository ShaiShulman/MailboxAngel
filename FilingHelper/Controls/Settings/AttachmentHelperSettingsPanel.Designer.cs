namespace FilingHelper.Controls.Settings
{
    partial class AttachmentHelperSettingsPanel
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
            this.chkAutoShowHelper = new System.Windows.Forms.CheckBox();
            this.chkAutoCloseHepler = new System.Windows.Forms.CheckBox();
            this.txtMaxEmailSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(851, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Attachment Helper";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAutoShowHelper
            // 
            this.chkAutoShowHelper.AutoSize = true;
            this.chkAutoShowHelper.Location = new System.Drawing.Point(6, 35);
            this.chkAutoShowHelper.Name = "chkAutoShowHelper";
            this.chkAutoShowHelper.Size = new System.Drawing.Size(235, 17);
            this.chkAutoShowHelper.TabIndex = 27;
            this.chkAutoShowHelper.Text = "Auto show Helper when adding attachments";
            this.chkAutoShowHelper.UseVisualStyleBackColor = true;
            // 
            // chkAutoCloseHepler
            // 
            this.chkAutoCloseHepler.AutoSize = true;
            this.chkAutoCloseHepler.Location = new System.Drawing.Point(6, 58);
            this.chkAutoCloseHepler.Name = "chkAutoCloseHepler";
            this.chkAutoCloseHepler.Size = new System.Drawing.Size(244, 17);
            this.chkAutoCloseHepler.TabIndex = 28;
            this.chkAutoCloseHepler.Text = "Close Helper once attachments are processed";
            this.chkAutoCloseHepler.UseVisualStyleBackColor = true;
            // 
            // txtMaxEmailSize
            // 
            this.txtMaxEmailSize.Location = new System.Drawing.Point(120, 81);
            this.txtMaxEmailSize.Name = "txtMaxEmailSize";
            this.txtMaxEmailSize.Size = new System.Drawing.Size(102, 20);
            this.txtMaxEmailSize.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Maximum email size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "bytes";
            // 
            // AttachmentHelperSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaxEmailSize);
            this.Controls.Add(this.chkAutoCloseHepler);
            this.Controls.Add(this.chkAutoShowHelper);
            this.Controls.Add(this.label1);
            this.Name = "AttachmentHelperSettingsPanel";
            this.Size = new System.Drawing.Size(854, 413);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoShowHelper;
        private System.Windows.Forms.CheckBox chkAutoCloseHepler;
        private System.Windows.Forms.TextBox txtMaxEmailSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
