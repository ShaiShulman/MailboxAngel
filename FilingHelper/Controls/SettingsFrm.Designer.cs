namespace FilingHelper.Controls
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
            this.lstSignatures = new System.Windows.Forms.ListBox();
            this.txtSignatureContent = new System.Windows.Forms.RichTextBox();
            this.txtSignatureName = new System.Windows.Forms.Label();
            this.lstDomains = new System.Windows.Forms.ListBox();
            this.btnRemoveDomain = new System.Windows.Forms.Button();
            this.txtNewDomain = new System.Windows.Forms.TextBox();
            this.btnAddDomain = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.sideMenu1 = new HelperUtils.SideMenu();
            this.SuspendLayout();
            // 
            // lstSignatures
            // 
            this.lstSignatures.FormattingEnabled = true;
            this.lstSignatures.Location = new System.Drawing.Point(299, 22);
            this.lstSignatures.Name = "lstSignatures";
            this.lstSignatures.Size = new System.Drawing.Size(236, 173);
            this.lstSignatures.TabIndex = 0;
            this.lstSignatures.SelectedIndexChanged += new System.EventHandler(this.lstSignatures_SelectedIndexChanged);
            // 
            // txtSignatureContent
            // 
            this.txtSignatureContent.Location = new System.Drawing.Point(554, 71);
            this.txtSignatureContent.Name = "txtSignatureContent";
            this.txtSignatureContent.Size = new System.Drawing.Size(218, 124);
            this.txtSignatureContent.TabIndex = 1;
            this.txtSignatureContent.Text = "";
            // 
            // txtSignatureName
            // 
            this.txtSignatureName.AutoSize = true;
            this.txtSignatureName.Location = new System.Drawing.Point(551, 55);
            this.txtSignatureName.Name = "txtSignatureName";
            this.txtSignatureName.Size = new System.Drawing.Size(91, 13);
            this.txtSignatureName.TabIndex = 2;
            this.txtSignatureName.Text = "txtSignatureName";
            // 
            // lstDomains
            // 
            this.lstDomains.FormattingEnabled = true;
            this.lstDomains.Location = new System.Drawing.Point(299, 267);
            this.lstDomains.Name = "lstDomains";
            this.lstDomains.Size = new System.Drawing.Size(236, 134);
            this.lstDomains.TabIndex = 3;
            this.lstDomains.SelectedIndexChanged += new System.EventHandler(this.lstDomains_SelectedIndexChanged);
            // 
            // btnRemoveDomain
            // 
            this.btnRemoveDomain.Enabled = false;
            this.btnRemoveDomain.Location = new System.Drawing.Point(541, 267);
            this.btnRemoveDomain.Name = "btnRemoveDomain";
            this.btnRemoveDomain.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveDomain.TabIndex = 4;
            this.btnRemoveDomain.Text = "Remove";
            this.btnRemoveDomain.UseVisualStyleBackColor = true;
            this.btnRemoveDomain.Click += new System.EventHandler(this.btnRemoveDomain_Click);
            // 
            // txtNewDomain
            // 
            this.txtNewDomain.Location = new System.Drawing.Point(299, 241);
            this.txtNewDomain.Name = "txtNewDomain";
            this.txtNewDomain.Size = new System.Drawing.Size(200, 20);
            this.txtNewDomain.TabIndex = 5;
            this.txtNewDomain.TextChanged += new System.EventHandler(this.txtNewDomain_TextChanged);
            // 
            // btnAddDomain
            // 
            this.btnAddDomain.Enabled = false;
            this.btnAddDomain.Location = new System.Drawing.Point(505, 241);
            this.btnAddDomain.Name = "btnAddDomain";
            this.btnAddDomain.Size = new System.Drawing.Size(30, 23);
            this.btnAddDomain.TabIndex = 6;
            this.btnAddDomain.Text = "Add";
            this.btnAddDomain.UseVisualStyleBackColor = true;
            this.btnAddDomain.Click += new System.EventHandler(this.btnAddDomain_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(278, 425);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSetting.TabIndex = 7;
            this.btnSaveSetting.Text = "Save";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSettings);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(162, 185);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 8;
            // 
            // sideMenu1
            // 
            this.sideMenu1.BackColor = System.Drawing.SystemColors.Window;
            this.sideMenu1.Items = new string[] {
        "First",
        "Second ",
        "Third"};
            this.sideMenu1.Location = new System.Drawing.Point(1, 1);
            this.sideMenu1.Name = "sideMenu1";
            this.sideMenu1.Size = new System.Drawing.Size(165, 289);
            this.sideMenu1.TabIndex = 9;
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 479);
            this.Controls.Add(this.sideMenu1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnAddDomain);
            this.Controls.Add(this.txtNewDomain);
            this.Controls.Add(this.btnRemoveDomain);
            this.Controls.Add(this.lstDomains);
            this.Controls.Add(this.txtSignatureName);
            this.Controls.Add(this.txtSignatureContent);
            this.Controls.Add(this.lstSignatures);
            this.Name = "SettingsFrm";
            this.Text = "OutlookHelper Settings";
            this.Load += new System.EventHandler(this.SettingsFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSignatures;
        private System.Windows.Forms.RichTextBox txtSignatureContent;
        private System.Windows.Forms.Label txtSignatureName;
        private System.Windows.Forms.ListBox lstDomains;
        private System.Windows.Forms.Button btnRemoveDomain;
        private System.Windows.Forms.TextBox txtNewDomain;
        private System.Windows.Forms.Button btnAddDomain;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.ListBox listBox1;
        private HelperUtils.SideMenu sideMenu1;
    }
}