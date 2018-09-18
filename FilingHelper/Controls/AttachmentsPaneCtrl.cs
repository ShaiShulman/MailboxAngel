using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttachmentManager;
using System.Diagnostics;
using FilingHelper;
using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System.Threading;

namespace FilingHelper.Controls
{
    public partial class AttachmentsPaneCtrl : UserControl
    {
        const int TOP_PADDING = 90;
        public event EventHandler<AttachmentsUpdatedEventArgs> AttachmentsUpdated;
        private AttachmentService _manager;
        private string _lastLine = "";
        private int _bottonBarHeight;
        public int TotalHeight
        {
            get
            {
                return pnlContainer.Height + TOP_PADDING;
            }
            set
            {
                if (pnlContainer.AutoSize)
                    pnlContainer.AutoSize = false;
                pnlContainer.Height = Math.Min(value  - TOP_PADDING,pnlContainer.MaximumSize.Height);
            }
        }
        public int TotalWidth
        {
            get { return pnlMaster.Width; }
            set {
                this.Width = value;
                pnlContainer.Width = value;
                foreach (Control ctrl in pnlContainer.Controls)
                {
                    ctrl.Width = value;
                }
            }
        }
        public int MaxHeight { get { return pnlContainer.MaximumSize.Height + TOP_PADDING; } }
        public AttachmentsPaneCtrl(AttachmentService manager)
        {
            InitializeComponent();
            pnlContainer.AcceptableDragType = typeof(AttachmentSingleCtrl);
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            pnlContainer.Padding = new Padding(0, 0, vertScrollWidth, 0);
            _manager = manager;
        }
        public void Fill(IEnumerable<AttachmentCommand> attachments)
        {
            init(attachments);
        }
        public void Add(AttachmentCommand attachment)
        {
            AttachmentSingleCtrl control = new AttachmentSingleCtrl(attachment);
            initControl(control, pnlContainer.Controls.Count==0,true);
            if (attachment is ExistingAttachmentCommand)
            control.Tag = getAttachmentUID(((ExistingAttachmentCommand)attachment).Attachment);
            pnlContainer.AddControl(control);
            if (pnlContainer.Controls.Count>0)
            {
                ((AttachmentSingleCtrl)pnlContainer.Controls[pnlContainer.Controls.Count - 1]).Last = false;
            }
            onAttachmentsUpdated();
        }
        public void Remove(Microsoft.Office.Interop.Outlook.Attachment exattach)
        {
            bool found = false;
            string uid = getAttachmentUID(exattach);
            for (int i = 0; i < pnlContainer.Controls.Count && !found; i++)
            {
                if ((string)pnlContainer.Controls[i].Tag==uid)
                {
                    pnlContainer.RemoveControl(i);
                    found = false;
                }
            }
            onAttachmentsUpdated();
        }
        private void init(IEnumerable<AttachmentCommand> attachments)
        {
            List<AttachmentCommand>_attachments = attachments.ToList();
            pnlContainer.Controls.Clear();
            for (int i = 0; i < attachments.Count(); i++)
            {
                AttachmentSingleCtrl control = new AttachmentSingleCtrl(_attachments[i]);
                if (_attachments[i] is ExistingAttachmentCommand)
                    control.Tag = getAttachmentUID(((ExistingAttachmentCommand)_attachments[i]).Attachment);
                initControl(control,i==0,i==attachments.Count()-1);
                pnlContainer.AddControl(control);
            }
            _bottonBarHeight =  pnlMaster.Height- pnlContainer.Height;
            pnlContainer.finalizeLayout();
            onAttachmentsUpdated();
        }

        private void initControl(AttachmentSingleCtrl control, bool isFirst, bool isLast)
        {
            control.FileDropped += Control_FileDropped;
            control.AttachmentOpen += Control_AttachmentOpen;
            control.AttachmentMove += Control_AttachmentMove;
            control.First = isFirst;
            control.Last = isLast;
        }

        private void Control_AttachmentOpen(object sender, AttachmentEventArgs e)
        {
            _manager.OpenAttachmente(e.Attachment);
        }

        private void Control_FileDropped(object sender, FileDroppedEventArgs e)
        {
            int targetIndex = pnlContainer.Controls.IndexOf((Control)sender);
            if (e.Direction == ChildDragDirection.After)
                targetIndex++;
            for (int i = 0; i < e.Files.Length; i++)
            {
                Add(new NewAttachmentCommand(e.Files[i]));
                pnlContainer.Controls.SetChildIndex(pnlContainer.Controls[pnlContainer.Controls.Count - 1], targetIndex + i);
            }
        }


        private void Control_ControlDragOver(object sender, HelperUtils.ChildDragEventArgs e)
        {
            if (!(sender is AttachmentSingleCtrl))
                return;
            AttachmentSingleCtrl ctrl = (AttachmentSingleCtrl)sender;
            bool nextCtrl = false;
            //if (e.Direction==ChildDragDirection.After && !ctrl.Last)
            //{
            //    ctrl = (AttachmentSingleCtrl)pnlContainer.Controls[pnlContainer.Controls.IndexOf(ctrl) + 1];
            //    nextCtrl = true;
            //}
            //foreach (AttachmentSingleCtrl itrCtrl in pnlContainer.Controls)
            //{
            //    itrCtrl.ShowTopLine(itrCtrl == ctrl && (e.Direction == ChildDragDirection.Before || nextCtrl));
            //    itrCtrl.ShowBottomLine(itrCtrl == ctrl && e.Direction == ChildDragDirection.After && !nextCtrl);
            //}
            if (_lastLine != pnlContainer.Controls.IndexOf(ctrl).ToString() + e.Direction.ToString())
            {
                Pen pen = new Pen(Color.Black);
                int lineY = ctrl.Location.Y;
                if (e.Direction == ChildDragDirection.After)
                {
                    if (pnlContainer.Controls.IndexOf(ctrl) < pnlContainer.Controls.Count-1)
                        lineY = pnlContainer.Controls[pnlContainer.Controls.IndexOf(ctrl) + 1].Location.Y;
                    else
                        lineY = lineY + ctrl.Height;
                }

                //_ContainerGraphics.Clear(this.BackColor);
                //_ContainerGraphics.DrawLine(new Pen(Color.Black, 2), 0, lineY, pnlContainer.Width, lineY);
                //_lastLine = pnlContainer.Controls.IndexOf(ctrl).ToString() + e.Direction.ToString();
            }
        }

        private void Control_AttachmentMove(object sender, AttachmentMoveEventArgs e)
        {
            MoveItem(e.Attach, e.Direction, e.BeforeAfterAttach);
        }

        private string getAttachmentUID(Microsoft.Office.Interop.Outlook.Attachment exattach)
        {
            return string.Concat(exattach.DisplayName, exattach.Size.ToString());
        }

        private void MoveItem(AttachmentCommand attach, MoveDirection direction, AttachmentCommand beforeAfterAttach=null)
        {
            AttachmentSingleCtrl attachControl = CtrlByAttachment(attach);
            foreach (var item in pnlContainer.Controls)
            {
                Debug.WriteLine("{0} | {1}",pnlContainer.Controls.GetChildIndex((AttachmentSingleCtrl)item),
                    ((AttachmentSingleCtrl)item).Data.FullName);
            }
            int firstIndex = pnlContainer.Controls.IndexOf(attachControl);
            if ((direction == MoveDirection.Up && firstIndex == 0)
                || (direction == MoveDirection.Down && firstIndex == pnlContainer.Controls.Count-1))
                return;
            switch (direction)
            {
                case MoveDirection.Up:
                case MoveDirection.Down:
                    int secondIndex = 0;
                    if (direction == MoveDirection.Up)
                        secondIndex = firstIndex - 1;
                    else
                        secondIndex = firstIndex + 1;
                    AttachmentSingleCtrl secondCtrl = (AttachmentSingleCtrl)pnlContainer.Controls[secondIndex];
                    pnlContainer.Controls.SetChildIndex(attachControl, secondIndex);
                    pnlContainer.Controls.SetChildIndex(secondCtrl, firstIndex);
                    attachControl.First = secondIndex == 0;
                    attachControl.Last = secondIndex == (pnlContainer.Controls.Count - 1);
                    secondCtrl.First = firstIndex == 0;
                    secondCtrl.Last = firstIndex == (pnlContainer.Controls.Count - 1);
                    break;

                case MoveDirection.Before:
                case MoveDirection.After:
                    int targetIndex = pnlContainer.Controls.IndexOf(CtrlByAttachment(beforeAfterAttach));
                    pnlContainer.Controls.SetChildIndex(attachControl, (direction == MoveDirection.After && targetIndex<pnlContainer.Controls.Count-1 ? targetIndex + (firstIndex>targetIndex?1:0) : (direction==MoveDirection.Before?Math.Max(targetIndex-1,0):targetIndex)));
                    break;
                default:
                    break;
            }
            foreach (var item in pnlContainer.Controls)
            {
                Debug.WriteLine("{0} | {1}", pnlContainer.Controls.GetChildIndex((AttachmentSingleCtrl)item),
                    ((AttachmentSingleCtrl)item).Data.FullName);
            }


        }
        private AttachmentSingleCtrl CtrlByAttachment(AttachmentCommand attach)
        {
            foreach (var ctrl in pnlContainer.Controls)
            {
                if (ctrl is AttachmentSingleCtrl
                    && ((AttachmentSingleCtrl)ctrl).Data == attach)
                    return (AttachmentSingleCtrl)ctrl;
            }
            throw new KeyNotFoundException("Control not found");
        }

        public List<AttachmentCommand> Data
        {
            get
            {
                List<AttachmentCommand> attachments = new List<AttachmentCommand>();
                foreach (var control in pnlContainer.Controls)
                {
                    if (control is AttachmentSingleCtrl)
                    {
                        attachments.Add(((AttachmentSingleCtrl)control).Data);
                    }
                }
                return attachments;
            }
            set { init(value); }
        }

        public void Numberize()
        {
            int counter = 1;
            foreach (var control in pnlContainer.Controls)
            {
                if (control is AttachmentSingleCtrl)
                {
                    AttachmentSingleCtrl cc = ((AttachmentSingleCtrl)control);
                    cc.Rename(string.Concat(counter.ToString(), " ", cc.Data.NewName));
                }
                counter++;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            List<AttachmentCommand> attachments = Data;
            ctlProgress.Visible = true;
            //pnlContainer.ChildrenVisible = false;
            pnlContainer.Enabled=false;
            Globals.ThisAddIn.UpdateAttachmentsOnAddRemove = false;
            _manager.AttachmentsProgressInitiated += _manager_AttachmentsProgressInitiated;
            _manager.AttachmentProgressIncrement += _manager_AttachmentProgressIncrement;
            Thread processThread = new Thread(() =>
            {
                _manager.ProcessAttachments(attachments);
                this.BeginInvoke((System.Action)(() =>
                {
                    ctlProgress.Visible = false;
                    //pnlContainer.ChildrenVisible = true;
                    pnlContainer.Enabled = true;
                    ctlProgress.Visible = false;
                    Globals.ThisAddIn.UpdateAttachmentsOnAddRemove = true;
                }));
            });
            processThread.Start();
        }

        private void _manager_AttachmentsProgressInitiated(object sender, AttachmentsProgressInitiatedEventArgs e)
        {
            this.BeginInvoke((System.Action)(() =>
            {
                ctlProgress.Visible = true;
                ctlProgress.Maximum = e.ItemsCount;
                ctlProgress.Value = 0;
            }));
        }

        private void _manager_AttachmentProgressIncrement(object sender, EventArgs e)
        {
            this.BeginInvoke((System.Action)(() =>
            {
                ctlProgress.Value++;
            }));
        }

        private void btnNumberize_Click(object sender, EventArgs e)
        {
            Numberize();
        }

        private void pnlContainer_DragEnter(object sender, DragEventArgs e)
        {
            //if (pnlContainer.Controls.Count == 0)
            //    return;
            //int lastControl = pnlContainer.Controls.Count - 1;
            //if (e.Y > this.PointToScreen(this.Location).Y + (pnlContainer.Height/2))
            //    ((AttachmentSingleCtrl)pnlContainer.Controls[lastControl]).ShowBottomLine(true);

            //if (e.Y > this.PointToScreen(pnlContainer.Controls[lastControl].Location).Y+ pnlContainer.Controls[lastControl].Height)
            //    ((AttachmentSingleCtrl)pnlContainer.Controls[lastControl]).ShowBottomLine(true);
            //e.Effect = DragDropEffects.Move;
        }

        private void pnlContainer_DragLeave(object sender, EventArgs e)
        {
            //if (pnlContainer.Controls.Count == 0)
            //    return;
            //int lastControl = pnlContainer.Controls.Count - 1;
            //((AttachmentSingleCtrl)pnlContainer.Controls[lastControl]).ShowBottomLine(false);

        }

        private void AttachmentsPaneCtrl_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        #region event handlers

        protected void onAttachmentsUpdated()
        {
            if (AttachmentsUpdated != null)
                AttachmentsUpdated(this, new AttachmentsUpdatedEventArgs(_manager.UIElement));
        }

        #endregion

    }

    public class AttachmentsUpdatedEventArgs
    {
        private object _uiElement;

        public object UIElement
        {
            get { return _uiElement; }
            set { _uiElement = value; }
        }
        public AttachmentsUpdatedEventArgs(object element)
        {
            _uiElement=element;
        }
    }
}
