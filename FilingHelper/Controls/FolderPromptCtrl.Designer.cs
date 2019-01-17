namespace FilingHelper
{
    partial class FolderPromptCtrl
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNormalText = new System.Windows.Forms.Label();
            this.lblBoldText = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lblNormalText);
            this.flowLayoutPanel1.Controls.Add(this.lblBoldText);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 3);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(0, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(33, 26);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // lblNormalText
            // 
            this.lblNormalText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNormalText.AutoSize = true;
            this.lblNormalText.Location = new System.Drawing.Point(3, 0);
            this.lblNormalText.Name = "lblNormalText";
            this.lblNormalText.Size = new System.Drawing.Size(10, 13);
            this.lblNormalText.TabIndex = 7;
            this.lblNormalText.Text = " ";
            // 
            // lblBoldText
            // 
            this.lblBoldText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBoldText.AutoSize = true;
            this.lblBoldText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoldText.Location = new System.Drawing.Point(19, 0);
            this.lblBoldText.Name = "lblBoldText";
            this.lblBoldText.Size = new System.Drawing.Size(11, 13);
            this.lblBoldText.TabIndex = 8;
            this.lblBoldText.Text = " ";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOpenFolder.Image = global::FilingHelper.Properties.Resources.iconfinder_folder_horizontal_open_26356;
            this.btnOpenFolder.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnOpenFolder.Location = new System.Drawing.Point(367, 4);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(89, 23);
            this.btnOpenFolder.TabIndex = 8;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUndo.Image = global::FilingHelper.Properties.Resources.Up_small3;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnUndo.Location = new System.Drawing.Point(462, 4);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(89, 23);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.Text = "Undo";
            this.btnUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FilingHelper.Properties.Resources.Folder1;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 29);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FolderPromptCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FolderPromptCtrl";
            this.Size = new System.Drawing.Size(554, 33);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblNormalText;
        private System.Windows.Forms.Label lblBoldText;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}
