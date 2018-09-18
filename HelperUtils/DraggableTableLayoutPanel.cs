using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HelperUtils
{
    public partial class DraggableTableLayoutPanel : TableLayoutPanel
    {
        const int DRAG_MARKER_WIDTH= 2;
        private Graphics _containerGraphics;
        public event EventHandler<ExternalDropEventArgs> ExternalDrop;
        private string _lastLine;
        private Type _acceptableDragType;
        public Type AcceptableDragType
        {
            get { return _acceptableDragType; }
            set { _acceptableDragType = value; }
        }

        private bool _allowExternalDrop = false;
        public bool AllowExternalDrop
        {
            get { return _allowExternalDrop; }
            set { _allowExternalDrop = value; }
        }
        private bool _childrenVisible;
        public bool ChildrenVisible
        {
            set
            {
                foreach (Control ctrl in Controls)
                {
                    ctrl.Visible = value;
                }
                _childrenVisible = value;
            }
            get { return _childrenVisible; }
        }

        public DraggableTableLayoutPanel()
        {
            InitializeComponent();
            _lastLine = "";
        }

        public void AddControl(Control ctrl)
        {
            this.Controls.Add(ctrl);
            ctrl.DragDrop += Child_DragDrop;
            ctrl.DragOver += Child_DragOver;
            ctrl.DragEnter += Child_DragEnter;
            ctrl.DragLeave += Child_DragLeave;
            this.Height = Math.Min(this.MaximumSize.Height, this.Height + ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom);
        }

        public void AddControl(Control ctrl,MoveDirection direction, Control targetPosition)
        {
            AddControl(ctrl);
            MoveChildControl(ctrl, direction, targetPosition);
        }

        public void RemoveControl(int index)
        {
            int height = this.Controls[index].Height + this.Controls[index].Margin.Top + this.Controls[index].Margin.Bottom;
            this.Controls.RemoveAt(index);
            this.Height = Math.Max(this.MinimumSize.Height, this.Height - height);
        }

        public void finalizeLayout()
        {
            int height = 0;
            foreach (Control item in this.Controls)
            {
                height += item.Height;
                height += item.Margin.Top;
                height += item.Margin.Bottom;
            }
            this.Height = height + DRAG_MARKER_WIDTH;
            _containerGraphics = this.CreateGraphics();
        }

        private void Child_DragDrop(object sender, DragEventArgs e)
        {
           if (e.Data.GetDataPresent(_acceptableDragType) || _allowExternalDrop)
            {
                Control targetControl = (Control)e.Data.GetData(_acceptableDragType);
                Control dropPosition=(Control)sender;
                if (dropPosition.PointToClient(new Point(e.X, e.Y)).Y > (dropPosition.Height / 2))
                {
                    if (e.Data.GetDataPresent(_acceptableDragType))
                        MoveChildControl(targetControl, MoveDirection.After, dropPosition);
                    else
                        onExternalDrop(targetControl, MoveDirection.After, dropPosition);
                }
                else
                {
                    if (e.Data.GetDataPresent(_acceptableDragType))
                        MoveChildControl(targetControl, MoveDirection.Before, dropPosition);
                    else
                        onExternalDrop(targetControl, MoveDirection.Before, dropPosition);
                }
            }
        }

        private void Child_DragOver(object sender, DragEventArgs e)
        {
            Control ctrl = (Control)sender;
            MoveDirection direction = (ctrl.PointToClient(new Point(e.X,e.Y)).Y > (ctrl.Height / 2)) ? MoveDirection.After : MoveDirection.Before;
            if (_lastLine != this.Controls.IndexOf(ctrl).ToString() + direction.ToString())
            {
                Pen pen = new Pen(Color.Black);
                int lineY;
                if (direction == MoveDirection.After)
                {
                    if (this.Controls.IndexOf(ctrl) < this.Controls.Count - 1)
                        lineY = this.Controls[this.Controls.IndexOf(ctrl) + 1].Location.Y - DRAG_MARKER_WIDTH; 
                    else
                        lineY = ctrl.Location.Y + ctrl.Height + ctrl.Margin.Bottom + DRAG_MARKER_WIDTH;
                } else
                    lineY = ctrl.Location.Y - DRAG_MARKER_WIDTH;

                _containerGraphics.Clear(this.BackColor);
                _containerGraphics.DrawLine(new Pen(Color.Black, DRAG_MARKER_WIDTH), 0, lineY, ctrl.Width, lineY);
                _lastLine = this.Controls.IndexOf(ctrl).ToString() + direction.ToString();
            }
        }

        private void Child_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Child_DragLeave(object sender, EventArgs e)
        {
            _containerGraphics.Clear(this.BackColor);
        }

        private void MoveChildControl(Control targetControl, MoveDirection direction, Control beforeAfterControl = null)
        {
            int firstIndex = this.Controls.IndexOf(targetControl);
            if ((direction == MoveDirection.Up && firstIndex == 0)
                || (direction == MoveDirection.Down && firstIndex == this.Controls.Count - 1))
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
                    Control secondCtrl = (Control)this.Controls[secondIndex];
                    this.Controls.SetChildIndex(targetControl, secondIndex);
                    this.Controls.SetChildIndex(secondCtrl, firstIndex);
                    break;

                case MoveDirection.Before:
                case MoveDirection.After:
                    int targetIndex = this.Controls.IndexOf(beforeAfterControl);
                    if (targetIndex != firstIndex)
                        this.Controls.SetChildIndex(targetControl, (direction == MoveDirection.After && targetIndex < this.Controls.Count - 1 ?
                            targetIndex + (firstIndex > targetIndex ? 1 : 0) :
                            (direction == MoveDirection.Before ? targetIndex : targetIndex)));
                    else
                        this.Refresh();
                    break;
                default:
                    break;
            }
        }

        protected void onExternalDrop(object droppedObject,MoveDirection direction, Control dropPosition)
        {
            if (ExternalDrop != null)
                ExternalDrop(this,new ExternalDropEventArgs(droppedObject, direction, dropPosition));
        }

    }

    public class ExternalDropEventArgs:EventArgs
    {
        private object _droppedObject;

        public object DroppedObject
        {
            get { return _droppedObject; }
            set { _droppedObject = value; }
        }

        private Control _dropPosition;
        public Control DropPosition
        {
            get { return _dropPosition; }
            set { _dropPosition = value; }
        }
        private MoveDirection _direction;
        public MoveDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public ExternalDropEventArgs(object droppedObject, MoveDirection direction, Control dropPosition)
        {
            _droppedObject = droppedObject;
            _dropPosition = dropPosition;
            _direction = direction;
        }

    }
}
