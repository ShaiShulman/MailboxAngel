using HelperUtils;

namespace FilingHelper.Controls
{
    partial class AttachmentSingleCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttachmentSingleCtrl));
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.ctrlToolStrip = new System.Windows.Forms.ToolStrip();
            this.picFileIcon = new System.Windows.Forms.ToolStripButton();
            this.txtFileName = new HelperUtils.FileNameToolStripTextBox();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.btnCompress = new System.Windows.Forms.ToolStripButton();
            this.btnUp = new System.Windows.Forms.ToolStripButton();
            this.btnDown = new System.Windows.Forms.ToolStripButton();
            this.btnFinalize = new System.Windows.Forms.ToolStripButton();
            this.srcBinding = new System.Windows.Forms.BindingSource(this.components);
            this.ctrlToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, ".zip");
            // 
            // ctrlToolStrip
            // 
            this.ctrlToolStrip.AutoSize = false;
            this.ctrlToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ctrlToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.picFileIcon,
            this.txtFileName,
            this.btnOpen,
            this.btnRemove,
            this.btnCompress,
            this.btnUp,
            this.btnDown,
            this.btnFinalize});
            this.ctrlToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ctrlToolStrip.Name = "ctrlToolStrip";
            this.ctrlToolStrip.Size = new System.Drawing.Size(586, 27);
            this.ctrlToolStrip.TabIndex = 8;
            this.ctrlToolStrip.Text = "toolStrip1";
            this.ctrlToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            this.ctrlToolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrlToolStrip_MouseDown);
            this.ctrlToolStrip.Resize += new System.EventHandler(this.ctrlToolStrip_Resize);
            // 
            // picFileIcon
            // 
            this.picFileIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.picFileIcon.Image = ((System.Drawing.Image)(resources.GetObject("picFileIcon.Image")));
            this.picFileIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.picFileIcon.Name = "picFileIcon";
            this.picFileIcon.Size = new System.Drawing.Size(23, 24);
            this.picFileIcon.Text = "toolStripButton1";
            this.picFileIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picFileIcon_MouseDown);
            // 
            // txtFileName
            // 
            this.txtFileName.AutoSize = false;
            this.txtFileName.Extension = "";
            this.txtFileName.FileName = "fileNameToolStripTextBox1";
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(380, 27);
            this.txtFileName.Text = "fileNameToolStripTextBox1";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 24);
            this.btnOpen.Text = "toolStripButton2";
            this.btnOpen.ToolTipText = "Open file";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.CheckOnClick = true;
            this.btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemove.Image = global::FilingHelper.Properties.Resources.if_Delete_132746;
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 24);
            this.btnRemove.Text = "toolStripButton1";
            this.btnRemove.ToolTipText = "Remove attachment";
            this.btnRemove.CheckedChanged += new System.EventHandler(this.btnRemove_CheckedChanged);
            // 
            // btnCompress
            // 
            this.btnCompress.CheckOnClick = true;
            this.btnCompress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCompress.Image = global::FilingHelper.Properties.Resources.if_compress_35891;
            this.btnCompress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(23, 24);
            this.btnCompress.Text = "Compress file";
            this.btnCompress.CheckedChanged += new System.EventHandler(this.btnCompress_CheckedChanged);
            // 
            // btnUp
            // 
            this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 24);
            this.btnUp.Text = "toolStripButton3";
            this.btnUp.ToolTipText = "Move up";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 24);
            this.btnDown.Text = "toolStripButton4";
            this.btnDown.ToolTipText = "Move down";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnFinalize
            // 
            this.btnFinalize.CheckOnClick = true;
            this.btnFinalize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFinalize.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalize.Image")));
            this.btnFinalize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(23, 24);
            this.btnFinalize.Text = "toolStripButton5";
            this.btnFinalize.ToolTipText = "Finalize tracked changes";
            // 
            // AttachmentSingleCtrl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.ctrlToolStrip);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.MaximumSize = new System.Drawing.Size(1200, 27);
            this.Name = "AttachmentSingleCtrl";
            this.Size = new System.Drawing.Size(553, 27);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AttachmentSingleCtrl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AttachmentSingleCtrl_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.AttachmentSingleCtrl_DragOver);
            this.DragLeave += new System.EventHandler(this.AttachmentSingleCtrl_DragLeave);
            this.Resize += new System.EventHandler(this.AttachmentSingleCtrl_Resize);
            this.ctrlToolStrip.ResumeLayout(false);
            this.ctrlToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcBinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource srcBinding;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.ToolStrip ctrlToolStrip;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnUp;
        private System.Windows.Forms.ToolStripButton btnDown;
        private System.Windows.Forms.ToolStripButton btnFinalize;
        private FileNameToolStripTextBox txtFileName;
        private System.Windows.Forms.ToolStripButton picFileIcon;
        private System.Windows.Forms.ToolStripButton btnCompress;
    }
}
