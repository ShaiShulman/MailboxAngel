namespace FilingHelper.Controls
{
    partial class ResearchItemSingleCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResearchItemSingleCtrl));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.ctlToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnOpenItem = new System.Windows.Forms.ToolStripButton();
            this.btnPintoBoard = new System.Windows.Forms.ToolStripButton();
            this.btnNote = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.ctlToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContainer.Controls.Add(this.txtComment);
            this.pnlContainer.Controls.Add(this.ctlToolStrip);
            this.pnlContainer.Controls.Add(this.pictureBox1);
            this.pnlContainer.Controls.Add(this.lblContent);
            this.pnlContainer.Controls.Add(this.lblSubject);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(309, 98);
            this.pnlContainer.TabIndex = 0;
            this.pnlContainer.Enter += new System.EventHandler(this.pnlContainer_Enter);
            this.pnlContainer.Leave += new System.EventHandler(this.pnlContainer_Leave);
            this.pnlContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlContainer_MouseDown);
            this.pnlContainer.MouseEnter += new System.EventHandler(this.pnlContainer_MouseEnter);
            this.pnlContainer.MouseLeave += new System.EventHandler(this.pnlContainer_MouseLeave);
            this.pnlContainer.Resize += new System.EventHandler(this.pnlContainer_Resize);
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtComment.Location = new System.Drawing.Point(0, 24);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(277, 71);
            this.txtComment.TabIndex = 5;
            this.txtComment.Visible = false;
            this.txtComment.Enter += new System.EventHandler(this.txtComment_Enter);
            this.txtComment.Leave += new System.EventHandler(this.txtComment_Leave);
            // 
            // ctlToolStrip
            // 
            this.ctlToolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.ctlToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ctlToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenItem,
            this.btnPintoBoard,
            this.btnNote,
            this.btnDeleteItem});
            this.ctlToolStrip.Location = new System.Drawing.Point(275, 0);
            this.ctlToolStrip.Name = "ctlToolStrip";
            this.ctlToolStrip.Size = new System.Drawing.Size(32, 96);
            this.ctlToolStrip.TabIndex = 4;
            this.ctlToolStrip.Text = "toolStrip1";
            this.ctlToolStrip.Visible = false;
            // 
            // btnOpenItem
            // 
            this.btnOpenItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenItem.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenItem.Image")));
            this.btnOpenItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenItem.Name = "btnOpenItem";
            this.btnOpenItem.Size = new System.Drawing.Size(21, 20);
            this.btnOpenItem.Text = "toolStripButton1";
            this.btnOpenItem.Click += new System.EventHandler(this.btnOpenItem_Click);
            // 
            // btnPintoBoard
            // 
            this.btnPintoBoard.CheckOnClick = true;
            this.btnPintoBoard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPintoBoard.Image = ((System.Drawing.Image)(resources.GetObject("btnPintoBoard.Image")));
            this.btnPintoBoard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPintoBoard.Name = "btnPintoBoard";
            this.btnPintoBoard.Size = new System.Drawing.Size(21, 20);
            this.btnPintoBoard.Text = "toolStripButton1";
            this.btnPintoBoard.Click += new System.EventHandler(this.btnPintoBoard_Click);
            // 
            // btnNote
            // 
            this.btnNote.CheckOnClick = true;
            this.btnNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNote.Image = ((System.Drawing.Image)(resources.GetObject("btnNote.Image")));
            this.btnNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(21, 20);
            this.btnNote.Text = "toolStripButton1";
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(21, 20);
            this.btnDeleteItem.Text = "toolStripButton2";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FilingHelper.Properties.Resources.icon_msg_unread;
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 19);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblContent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(3, 25);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(35, 13);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "label1";
            this.lblContent.DoubleClick += new System.EventHandler(this.lblContent_DoubleClick);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(17, 5);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(41, 13);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "label1";
            // 
            // ResearchItemSingleCtrl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Name = "ResearchItemSingleCtrl";
            this.Size = new System.Drawing.Size(309, 98);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ctlToolStrip.ResumeLayout(false);
            this.ctlToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip ctlToolStrip;
        private System.Windows.Forms.ToolStripButton btnOpenItem;
        private System.Windows.Forms.ToolStripButton btnDeleteItem;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.ToolStripButton btnPintoBoard;
        private System.Windows.Forms.ToolStripButton btnNote;
    }
}
