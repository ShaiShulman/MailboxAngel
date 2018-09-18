using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using HelperUtils;

namespace FilingHelper.Controls
{
    public partial class ResearchItemSingleCtrl : UserControl,iDraggableChildControl
    {
        public event EventHandler<ChildDragEventArgs> ControlDragOver;
        public event EventHandler ControlDragLeave;
        public event EventHandler<ChildDragEventArgs> ControlDropOver;
        public event EventHandler ControlRemoved;
        public event EventHandler ToolStripShown;


        private MailInfo _mailInfo;
        public MailInfo MailInfo
        {
            get { return _mailInfo; }
            set { _mailInfo = value; }
        }
        private bool _commentMode
        {
            get { return txtComment.Visible; }
            set { txtComment.Visible = value; }
        }


        public ResearchItemSingleCtrl(MailInfo mailItem)
        {
            InitializeComponent();
            lblSubject.Text = mailItem.Item.Subject;
            lblContent.Text = mailItem.Item.Body;
            _mailInfo = mailItem;
        }

        public void HideToolStrip()
        {
            ctlToolStrip.Visible = false;
        }

        private void pnlContainer_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(this, DragDropEffects.Move);
        }

        #region EventArgs

        protected void onControlDragOver(ChildDragDirection direction)
        {
            if (ControlDragOver != null)
                ControlDragOver(this, new ChildDragEventArgs(direction));
        }

        protected void onControlRemoved()
        {
            if (ControlRemoved != null)
                ControlRemoved(this, EventArgs.Empty);
        }

        protected void onControlDragLeave()
        {
            if (ControlDragLeave != null)
                ControlDragLeave(this, EventArgs.Empty);
        }

        protected void onToolStripShown()
        {
            if (ToolStripShown != null)
                ToolStripShown(this, EventArgs.Empty);
        }

        #endregion

        private void btnOpenItem_Click(object sender, EventArgs e)
        {
            MailInfo.Item.Display();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            onControlRemoved();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            txtComment.Visible = btnNote.Checked;
            lblContent.Visible = !btnNote.Checked;

        }

        private void pnlContainer_Resize(object sender, EventArgs e)
        {
            txtComment.Width = this.Width - ctlToolStrip.Width;
            lblContent.Width = this.Width - ctlToolStrip.Width;
        }

        private void lblContent_DoubleClick(object sender, EventArgs e)
        {
            MailInfo.Item.Display();
        }

        private void txtComment_Enter(object sender, EventArgs e)
        {
            txtComment.BackColor = SystemColors.Window;
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            txtComment.BackColor = SystemColors.ButtonFace;
        }

        private void btnPintoBoard_Click(object sender, EventArgs e)
        {
            _mailInfo.Persist = btnPintoBoard.Checked;
        }

        private void pnlContainer_Enter(object sender, EventArgs e)
        {
        }

        private void pnlContainer_Leave(object sender, EventArgs e)
        {
        }

        private void pnlContainer_MouseEnter(object sender, EventArgs e)
        {
            ctlToolStrip.Visible = true;
            onToolStripShown();
        }

        private void pnlContainer_MouseLeave(object sender, EventArgs e)
        {
        }
    }
}
