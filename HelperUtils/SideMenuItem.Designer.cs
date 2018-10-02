namespace HelperUtils
{
    partial class SideMenuItem
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
            this.lblInner = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblInner
            // 
            this.lblInner.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInner.Location = new System.Drawing.Point(0, 0);
            this.lblInner.Name = "lblInner";
            this.lblInner.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.lblInner.Size = new System.Drawing.Size(117, 32);
            this.lblInner.TabIndex = 14;
            this.lblInner.Text = "label1";
            this.lblInner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInner.Click += new System.EventHandler(this.onClick);
            this.lblInner.MouseEnter += new System.EventHandler(this.onMouseEnter);
            this.lblInner.MouseLeave += new System.EventHandler(this.onMouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 32);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(112, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 32);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Location = new System.Drawing.Point(3, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 10);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel4.Location = new System.Drawing.Point(5, -6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(255, 10);
            this.panel4.TabIndex = 18;
            // 
            // SideMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInner);
            this.Name = "SideMenuItem";
            this.Size = new System.Drawing.Size(117, 32);
            this.MouseEnter += new System.EventHandler(this.onMouseEnter);
            this.MouseLeave += new System.EventHandler(this.onMouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}
