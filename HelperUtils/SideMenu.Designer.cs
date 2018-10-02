namespace HelperUtils
{
    partial class SideMenu
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
            this.ctlContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ctlContainer
            // 
            this.ctlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlContainer.Location = new System.Drawing.Point(0, 0);
            this.ctlContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ctlContainer.Name = "ctlContainer";
            this.ctlContainer.Size = new System.Drawing.Size(165, 236);
            this.ctlContainer.TabIndex = 0;
            // 
            // SideMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.ctlContainer);
            this.Name = "SideMenu";
            this.Size = new System.Drawing.Size(165, 236);
            this.Load += new System.EventHandler(this.SideMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ctlContainer;
    }
}
