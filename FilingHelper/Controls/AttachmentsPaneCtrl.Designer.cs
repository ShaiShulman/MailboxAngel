namespace FilingHelper.Controls
{
    partial class AttachmentsPaneCtrl
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
            this.pnlMaster = new System.Windows.Forms.FlowLayoutPanel();
            this.ctlProgress = new System.Windows.Forms.ProgressBar();
            this.pnlContainer = new HelperUtils.DraggableTableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnNumberize = new System.Windows.Forms.Button();
            this.btnCreateList = new System.Windows.Forms.Button();
            this.btnCompress = new HelperUtils.MenuButton();
            this.mnuCompress = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNoCompression = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompressSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompressAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtArchiveName = new HelperUtils.FileNameTextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.pnlMaster.SuspendLayout();
            this.mnuCompress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaster
            // 
            this.pnlMaster.AutoSize = true;
            this.pnlMaster.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlMaster.Controls.Add(this.ctlProgress);
            this.pnlMaster.Controls.Add(this.pnlContainer);
            this.pnlMaster.Controls.Add(this.btnApply);
            this.pnlMaster.Controls.Add(this.btnNumberize);
            this.pnlMaster.Controls.Add(this.btnCreateList);
            this.pnlMaster.Controls.Add(this.btnCompress);
            this.pnlMaster.Controls.Add(this.txtArchiveName);
            this.pnlMaster.Controls.Add(this.lblSize);
            this.pnlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMaster.Location = new System.Drawing.Point(0, 0);
            this.pnlMaster.MaximumSize = new System.Drawing.Size(1200, 250);
            this.pnlMaster.Name = "pnlMaster";
            this.pnlMaster.Size = new System.Drawing.Size(718, 247);
            this.pnlMaster.TabIndex = 0;
            // 
            // ctlProgress
            // 
            this.ctlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMaster.SetFlowBreak(this.ctlProgress, true);
            this.ctlProgress.Location = new System.Drawing.Point(3, 3);
            this.ctlProgress.Name = "ctlProgress";
            this.ctlProgress.Size = new System.Drawing.Size(598, 10);
            this.ctlProgress.Step = 1;
            this.ctlProgress.TabIndex = 1;
            this.ctlProgress.Visible = false;
            // 
            // pnlContainer
            // 
            this.pnlContainer.AcceptableDragType = null;
            this.pnlContainer.AllowExternalDrop = false;
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.ChildrenVisible = false;
            this.pnlContainer.ColumnCount = 1;
            this.pnlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContainer.Location = new System.Drawing.Point(3, 19);
            this.pnlContainer.MaximumSize = new System.Drawing.Size(8000, 170);
            this.pnlContainer.MinimumSize = new System.Drawing.Size(600, 50);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.RowCount = 2;
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlContainer.Size = new System.Drawing.Size(600, 50);
            this.pnlContainer.TabIndex = 15;
            // 
            // btnApply
            // 
            this.btnApply.Image = global::FilingHelper.Properties.Resources.if_Apply_132742;
            this.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApply.Location = new System.Drawing.Point(609, 19);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 25);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnNumberize
            // 
            this.btnNumberize.Image = global::FilingHelper.Properties.Resources.numbering__1_;
            this.btnNumberize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNumberize.Location = new System.Drawing.Point(3, 75);
            this.btnNumberize.Name = "btnNumberize";
            this.btnNumberize.Size = new System.Drawing.Size(87, 25);
            this.btnNumberize.TabIndex = 12;
            this.btnNumberize.Text = "Numberize";
            this.btnNumberize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNumberize.UseVisualStyleBackColor = true;
            this.btnNumberize.Click += new System.EventHandler(this.btnNumberize_Click);
            // 
            // btnCreateList
            // 
            this.btnCreateList.Image = global::FilingHelper.Properties.Resources.CreateList;
            this.btnCreateList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateList.Location = new System.Drawing.Point(96, 75);
            this.btnCreateList.Name = "btnCreateList";
            this.btnCreateList.Size = new System.Drawing.Size(87, 25);
            this.btnCreateList.TabIndex = 17;
            this.btnCreateList.Text = "Create List";
            this.btnCreateList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateList.UseVisualStyleBackColor = true;
            this.btnCreateList.Click += new System.EventHandler(this.btnCreateList_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Image = global::FilingHelper.Properties.Resources.if_compress_358911;
            this.btnCompress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompress.Location = new System.Drawing.Point(189, 75);
            this.btnCompress.Menu = this.mnuCompress;
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(80, 25);
            this.btnCompress.TabIndex = 21;
            this.btnCompress.Text = "Compress";
            this.btnCompress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompress.UseVisualStyleBackColor = true;
            // 
            // mnuCompress
            // 
            this.mnuCompress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNoCompression,
            this.mnuCompressSelected,
            this.mnuCompressAll});
            this.mnuCompress.Name = "mnuCompress";
            this.mnuCompress.Size = new System.Drawing.Size(174, 70);
            // 
            // mnuNoCompression
            // 
            this.mnuNoCompression.Checked = true;
            this.mnuNoCompression.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuNoCompression.Name = "mnuNoCompression";
            this.mnuNoCompression.Size = new System.Drawing.Size(173, 22);
            this.mnuNoCompression.Text = "Don\'t compress";
            this.mnuNoCompression.Click += new System.EventHandler(this.mnuNoCompression_Click);
            // 
            // mnuCompressSelected
            // 
            this.mnuCompressSelected.Name = "mnuCompressSelected";
            this.mnuCompressSelected.Size = new System.Drawing.Size(173, 22);
            this.mnuCompressSelected.Text = "Compress selected";
            this.mnuCompressSelected.Click += new System.EventHandler(this.mnuCompressSelected_Click);
            // 
            // mnuCompressAll
            // 
            this.mnuCompressAll.Name = "mnuCompressAll";
            this.mnuCompressAll.Size = new System.Drawing.Size(173, 22);
            this.mnuCompressAll.Text = "Compress all files";
            this.mnuCompressAll.Click += new System.EventHandler(this.mnuCompressAll_Click);
            // 
            // txtArchiveName
            // 
            this.txtArchiveName.Extension = "";
            this.txtArchiveName.FileName = "";
            this.txtArchiveName.Location = new System.Drawing.Point(275, 78);
            this.txtArchiveName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtArchiveName.Name = "txtArchiveName";
            this.txtArchiveName.Size = new System.Drawing.Size(197, 20);
            this.txtArchiveName.TabIndex = 20;
            this.txtArchiveName.Visible = false;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(478, 72);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(44, 31);
            this.lblSize.TabIndex = 16;
            this.lblSize.Text = "lblSize";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AttachmentsPaneCtrl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMaster);
            this.Name = "AttachmentsPaneCtrl";
            this.Size = new System.Drawing.Size(718, 247);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AttachmentsPaneCtrl_DragDrop);
            this.Resize += new System.EventHandler(this.AttachmentsPaneCtrl_Resize);
            this.pnlMaster.ResumeLayout(false);
            this.pnlMaster.PerformLayout();
            this.mnuCompress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnNumberize;
        public System.Windows.Forms.FlowLayoutPanel pnlMaster;
        private System.Windows.Forms.ProgressBar ctlProgress;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnCreateList;
        private HelperUtils.FileNameTextBox txtArchiveName;
        private HelperUtils.MenuButton btnCompress;
        private System.Windows.Forms.ContextMenuStrip mnuCompress;
        private System.Windows.Forms.ToolStripMenuItem mnuNoCompression;
        private System.Windows.Forms.ToolStripMenuItem mnuCompressAll;
        private System.Windows.Forms.ToolStripMenuItem mnuCompressSelected;
        private HelperUtils.DraggableTableLayoutPanel pnlContainer;
    }
}
