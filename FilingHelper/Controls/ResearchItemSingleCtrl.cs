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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

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

        public bool CommentsMode
        {
            get { return txtComment.Visible; }
            set { txtComment.Visible = value; }
        }

        public ResearchItemSingleCtrl(MailInfo mailItem)
        {
            InitializeComponent();
            lblSubject.Text = mailItem.Item.Subject;
            btnPintoBoard.Checked = mailItem.Persist;
            txtComment.Text = mailItem.Comment;
            try
            {
                switch (mailItem.Item.BodyFormat)
                {
                    case OlBodyFormat.olFormatUnspecified:
                        txtBody.Text = mailItem.Item.Body;
                        break;
                    case OlBodyFormat.olFormatPlain:
                        txtBody.Text = mailItem.Item.Body;
                        break;
                    case OlBodyFormat.olFormatHTML:
                        txtBody.Text = mailItem.Item.Body;
                        break;
                    case OlBodyFormat.olFormatRichText:
                        txtBody.Rtf = System.Text.Encoding.UTF8.GetString(mailItem.Item.RTFBody);
                        break;
                }
                ctlToolTip.SetToolTip(txtBody, truncateBody(mailItem.Item.Body));
                ctlToolTip.ToolTipTitle = mailItem.Item.Subject;
            }
            finally
            { 
                _mailInfo = mailItem;
            }
        }

        private string truncateBody(string body)
        {
            const int MAX_LINE_LENGTH = 40;
            const int MAX_LINES = 8;
            string[] lines = Regex.Split(body, "\r\n|\r|\n");
            List<string> output = new List<string>();
            int sourceLine = 0;
            while (sourceLine<lines.Length && output.Count < MAX_LINES)
            {
                if (!string.IsNullOrWhiteSpace(lines[sourceLine]))
                {
                    int linePos = 0;
                    do
                    {
                        output.Add(lines[sourceLine].Substring(linePos, Math.Min(lines[sourceLine].Length-linePos,MAX_LINE_LENGTH))); 
                        linePos += MAX_LINE_LENGTH;
                    } while (linePos <lines[sourceLine].Length);
                }
                sourceLine++;
            }
            return String.Join("\n", output);
        }

        private void doDrag()
        {
            DoDragDrop(this, DragDropEffects.Move);
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
            txtBody.Visible = !btnNote.Checked;

        }
        private void pnlContainer_Resize(object sender, EventArgs e)
        {
            txtComment.Width = this.Width - ctlToolStrip.Width;
            txtBody.Width = this.Width - ctlToolStrip.Width;
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

        private void picMailIcon_Click(object sender, EventArgs e)
        {
            doDrag();
        }

        private void lblSubject_MouseDown(object sender, MouseEventArgs e)
        {
            doDrag();
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtComment_Validating(object sender, CancelEventArgs e)
        {
            _mailInfo.Comment = txtComment.Text;

        }
    }
}
