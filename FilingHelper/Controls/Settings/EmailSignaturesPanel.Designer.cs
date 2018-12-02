namespace FilingHelper.Controls.Settings
{
    partial class AttachmentHelperPanel
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
            this.txtNewDomain = new System.Windows.Forms.TextBox();
            this.btnRemoveDomain = new System.Windows.Forms.Button();
            this.lstDomains = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstExternalNew = new System.Windows.Forms.ComboBox();
            this.lstExternalReply = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddDomain = new System.Windows.Forms.Button();
            this.lstInternalReply = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstInternalNew = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtNewDomain
            // 
            this.txtNewDomain.Location = new System.Drawing.Point(103, 145);
            this.txtNewDomain.Name = "txtNewDomain";
            this.txtNewDomain.Size = new System.Drawing.Size(200, 20);
            this.txtNewDomain.TabIndex = 22;
            this.txtNewDomain.TextChanged += new System.EventHandler(this.txtNewDomain_TextChanged);
            // 
            // btnRemoveDomain
            // 
            this.btnRemoveDomain.Enabled = false;
            this.btnRemoveDomain.Location = new System.Drawing.Point(345, 171);
            this.btnRemoveDomain.Name = "btnRemoveDomain";
            this.btnRemoveDomain.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveDomain.TabIndex = 21;
            this.btnRemoveDomain.Text = "Remove";
            this.btnRemoveDomain.UseVisualStyleBackColor = true;
            this.btnRemoveDomain.Click += new System.EventHandler(this.btnRemoveDomain_Click);
            // 
            // lstDomains
            // 
            this.lstDomains.FormattingEnabled = true;
            this.lstDomains.Location = new System.Drawing.Point(103, 171);
            this.lstDomains.Name = "lstDomains";
            this.lstDomains.Size = new System.Drawing.Size(236, 95);
            this.lstDomains.TabIndex = 20;
            this.lstDomains.SelectedIndexChanged += new System.EventHandler(this.lstDomains_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(715, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "External emails signature";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "New messages:";
            // 
            // lstExternalNew
            // 
            this.lstExternalNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstExternalNew.FormattingEnabled = true;
            this.lstExternalNew.Location = new System.Drawing.Point(103, 57);
            this.lstExternalNew.Name = "lstExternalNew";
            this.lstExternalNew.Size = new System.Drawing.Size(236, 21);
            this.lstExternalNew.TabIndex = 28;
            // 
            // lstExternalReply
            // 
            this.lstExternalReply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstExternalReply.FormattingEnabled = true;
            this.lstExternalReply.Location = new System.Drawing.Point(103, 84);
            this.lstExternalReply.Name = "lstExternalReply";
            this.lstExternalReply.Size = new System.Drawing.Size(236, 21);
            this.lstExternalReply.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Replies/forwards:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(9, 117);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(715, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "Internal emails signature";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Internal domains:";
            // 
            // btnAddDomain
            // 
            this.btnAddDomain.Enabled = false;
            this.btnAddDomain.Image = global::FilingHelper.Properties.Resources.Add;
            this.btnAddDomain.Location = new System.Drawing.Point(309, 144);
            this.btnAddDomain.Name = "btnAddDomain";
            this.btnAddDomain.Size = new System.Drawing.Size(28, 23);
            this.btnAddDomain.TabIndex = 23;
            this.btnAddDomain.UseVisualStyleBackColor = true;
            this.btnAddDomain.Click += new System.EventHandler(this.btnAddDomain_Click);
            // 
            // lstInternalReply
            // 
            this.lstInternalReply.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInternalReply.FormattingEnabled = true;
            this.lstInternalReply.Location = new System.Drawing.Point(103, 308);
            this.lstInternalReply.Name = "lstInternalReply";
            this.lstInternalReply.Size = new System.Drawing.Size(236, 21);
            this.lstInternalReply.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Replies/forwards:";
            // 
            // lstInternalNew
            // 
            this.lstInternalNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstInternalNew.FormattingEnabled = true;
            this.lstInternalNew.Location = new System.Drawing.Point(103, 281);
            this.lstInternalNew.Name = "lstInternalNew";
            this.lstInternalNew.Size = new System.Drawing.Size(236, 21);
            this.lstInternalNew.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "New messages:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(9, 272);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(715, 2);
            this.label8.TabIndex = 37;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnabled.Location = new System.Drawing.Point(12, 9);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(316, 17);
            this.chkEnabled.TabIndex = 38;
            this.chkEnabled.Text = "Enable different signatures for internal and external recepients";
            this.chkEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // AttachmentHelperPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstInternalReply);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstInternalNew);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstExternalReply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstExternalNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddDomain);
            this.Controls.Add(this.txtNewDomain);
            this.Controls.Add(this.btnRemoveDomain);
            this.Controls.Add(this.lstDomains);
            this.Name = "AttachmentHelperPanel";
            this.Size = new System.Drawing.Size(732, 365);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddDomain;
        private System.Windows.Forms.TextBox txtNewDomain;
        private System.Windows.Forms.Button btnRemoveDomain;
        private System.Windows.Forms.ListBox lstDomains;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lstExternalNew;
        private System.Windows.Forms.ComboBox lstExternalReply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox lstInternalReply;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox lstInternalNew;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}
