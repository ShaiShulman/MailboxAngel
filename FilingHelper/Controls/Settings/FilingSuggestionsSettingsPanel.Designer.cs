namespace FilingHelper.Controls.Settings
{
    partial class FilingSuggestionsSettingsPanel
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
            this.chkSuggestSender = new System.Windows.Forms.CheckBox();
            this.chkConversation = new System.Windows.Forms.CheckBox();
            this.chkHistory = new System.Windows.Forms.CheckBox();
            this.ctlSuggestTree = new System.Windows.Forms.TreeView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(848, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Items to appear in suggestion menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(848, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Suggestions based on sender";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSuggestSender
            // 
            this.chkSuggestSender.AutoSize = true;
            this.chkSuggestSender.Location = new System.Drawing.Point(11, 30);
            this.chkSuggestSender.Name = "chkSuggestSender";
            this.chkSuggestSender.Size = new System.Drawing.Size(166, 17);
            this.chkSuggestSender.TabIndex = 28;
            this.chkSuggestSender.Text = "Suggestions based on sender";
            this.chkSuggestSender.UseVisualStyleBackColor = true;
            // 
            // chkConversation
            // 
            this.chkConversation.AutoSize = true;
            this.chkConversation.Location = new System.Drawing.Point(11, 53);
            this.chkConversation.Name = "chkConversation";
            this.chkConversation.Size = new System.Drawing.Size(165, 17);
            this.chkConversation.TabIndex = 29;
            this.chkConversation.Text = "Folders with this conversation";
            this.chkConversation.UseVisualStyleBackColor = true;
            // 
            // chkHistory
            // 
            this.chkHistory.AutoSize = true;
            this.chkHistory.Location = new System.Drawing.Point(11, 76);
            this.chkHistory.Name = "chkHistory";
            this.chkHistory.Size = new System.Drawing.Size(95, 17);
            this.chkHistory.TabIndex = 30;
            this.chkHistory.Text = "Historic folders";
            this.chkHistory.UseVisualStyleBackColor = true;
            // 
            // ctlSuggestTree
            // 
            this.ctlSuggestTree.Location = new System.Drawing.Point(11, 125);
            this.ctlSuggestTree.Name = "ctlSuggestTree";
            this.ctlSuggestTree.Size = new System.Drawing.Size(759, 285);
            this.ctlSuggestTree.TabIndex = 31;
            this.ctlSuggestTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ctlSuggestTree_AfterSelect);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(776, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(776, 154);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 33;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // FilingSuggestionsSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.ctlSuggestTree);
            this.Controls.Add(this.chkHistory);
            this.Controls.Add(this.chkConversation);
            this.Controls.Add(this.chkSuggestSender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FilingSuggestionsSettingsPanel";
            this.Size = new System.Drawing.Size(854, 413);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSuggestSender;
        private System.Windows.Forms.CheckBox chkConversation;
        private System.Windows.Forms.CheckBox chkHistory;
        private System.Windows.Forms.TreeView ctlSuggestTree;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClearAll;
    }
}
