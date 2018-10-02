namespace FilingHelper.Controls
{
    partial class ResearchPanelCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResearchPanelCtrl));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnShowPinned = new System.Windows.Forms.ToolStripButton();
            this.btnShowAll = new System.Windows.Forms.ToolStripButton();
            this.btnHideAll = new System.Windows.Forms.ToolStripButton();
            this.pnlItemsList = new HelperUtils.DraggableTableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.toolStrip1);
            this.flowLayoutPanel1.Controls.Add(this.pnlItemsList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(483, 342);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowPinned,
            this.btnShowAll,
            this.btnHideAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MaximumSize = new System.Drawing.Size(1000, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(280, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnShowPinned
            // 
            this.btnShowPinned.CheckOnClick = true;
            this.btnShowPinned.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPinned.Image")));
            this.btnShowPinned.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowPinned.Name = "btnShowPinned";
            this.btnShowPinned.Size = new System.Drawing.Size(90, 22);
            this.btnShowPinned.Text = "Pinned only";
            this.btnShowPinned.Click += new System.EventHandler(this.btnShowPinned_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(80, 22);
            this.btnShowAll.Text = "Display all";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnHideAll
            // 
            this.btnHideAll.Image = ((System.Drawing.Image)(resources.GetObject("btnHideAll.Image")));
            this.btnHideAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHideAll.Name = "btnHideAll";
            this.btnHideAll.Size = new System.Drawing.Size(67, 22);
            this.btnHideAll.Text = "Hide all";
            this.btnHideAll.Click += new System.EventHandler(this.btnHideAll_Click);
            // 
            // pnlItemsList
            // 
            this.pnlItemsList.AcceptableDragType = null;
            this.pnlItemsList.AllowDrop = true;
            this.pnlItemsList.AllowExternalDrop = false;
            this.pnlItemsList.AutoScroll = true;
            this.pnlItemsList.AutoSize = true;
            this.pnlItemsList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlItemsList.ChildrenVisible = false;
            this.pnlItemsList.ColumnCount = 1;
            this.pnlItemsList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemsList.Location = new System.Drawing.Point(3, 28);
            this.pnlItemsList.Name = "pnlItemsList";
            this.pnlItemsList.RowCount = 2;
            this.pnlItemsList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlItemsList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlItemsList.Size = new System.Drawing.Size(274, 0);
            this.pnlItemsList.TabIndex = 3;
            // 
            // ResearchPanelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ResearchPanelCtrl";
            this.Size = new System.Drawing.Size(483, 342);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnShowPinned;
        private HelperUtils.DraggableTableLayoutPanel pnlItemsList;
        private System.Windows.Forms.ToolStripButton btnShowAll;
        private System.Windows.Forms.ToolStripButton btnHideAll;
    }
}
