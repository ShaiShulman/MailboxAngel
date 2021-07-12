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
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using HelperUtils;

namespace FilingHelper.Controls
{
    public partial class AttachmentSingleCtrl : UserControl,iDraggableChildControl
    {
        const int VERTICAL_SPACE = 250;
        public event EventHandler<AttachmentMoveEventArgs> AttachmentMove;
        public event EventHandler<ChildDragEventArgs> ControlDragOver;
        public event EventHandler ControlDragLeave;
        public event EventHandler<ChildDragEventArgs> ControlDropOver;
        public event EventHandler<FileDroppedEventArgs> FileDropped;
        public event EventHandler<AttachmentEventArgs> AttachmentOpen;
        public event EventHandler CompressedChanged;

        private AttachmentCommand _attachment;
        public AttachmentSingleCtrl(AttachmentCommand attachment)
        {
            InitializeComponent();
            _attachment = attachment;
            init(attachment);
        }
        private void init(AttachmentCommand attachment)
        {
            txtFileName.FileName = _attachment.NameOnly;
            txtFileName.Extension = _attachment.Extension;
            txtFileName.InvalidFileNameDelegate = new Action(()=>Globals.ThisAddIn.CustomMessageBox("File Name is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation));
            if (!string.IsNullOrEmpty(attachment.Extension))
            {
                addIcon(attachment.FullName, attachment.Extension);
                picFileIcon.Image = imgIcons.Images[attachment.Extension];
            }
        }

        public AttachmentCommand Data
        {
            get {
                _attachment.NewName = txtFileName.Text;
                _attachment.Remove = btnRemove.Checked;
                _attachment.FinalizeChanges = btnFinalize.Checked;
                return _attachment;
            }
            set { init(value); }
        }
        public bool First
        {
            get { return !btnUp.Enabled; }
            set { btnUp.Enabled = !value; }
        }
        public bool Last
        {
            get { return !btnDown.Enabled; }
            set { btnDown.Enabled = !value; }
        }
        public void Rename(string name)
        {
            txtFileName.Text = name;
        }

        public bool Compressed
        {
            get { return btnCompress.Checked; }
            set { btnCompress.Checked = value; }
        }

        public object ShellIconSize { get; private set; }

        private void addIcon(string FileName, string Extension)
        {

            if (!imgIcons.Images.ContainsKey(Extension))
            {
                try
                {
                    Icon fileIcon = HelperUtils.IconUtil.GetIconForExtension(Extension, HelperUtils.IconUtil.ShellIconSize.SmallIcon);
                imgIcons.Images.Add(Extension, fileIcon);
                }
                    catch (Exception)
                {
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            onAttachmentMove(_attachment, MoveDirection.Up);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            onAttachmentMove(_attachment, MoveDirection.Down);
        }

        private void picIcon_MouseDown(object sender, MouseEventArgs e)
        {
            doDrag();
        }

        private void doDrag()
        {
            DoDragDrop(this, DragDropEffects.Move);
        }

        public void SetWidth(int width)
        {
            if (width > 0 && width != ctrlToolStrip.Width)
            {
                txtFileName.Width = width - VERTICAL_SPACE;
                ctrlToolStrip.Width = width;
            }
        }
        private void AttachmentSingleCtrl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void AttachmentSingleCtrl_DragLeave(object sender, EventArgs e)
        {
            onControlDragLeave();
        }

        private void AttachmentSingleCtrl_DragDrop(object sender, DragEventArgs e)
        {
             if (e.Data.GetDataPresent(typeof(ExistingAttachmentCommand))|| e.Data.GetDataPresent(typeof(NewAttachmentCommand))) 
            {
                AttachmentCommand targetAttach = e.Data.GetDataPresent(typeof(ExistingAttachmentCommand)) ?
                    (AttachmentCommand)e.Data.GetData(typeof(ExistingAttachmentCommand)) :
                    (AttachmentCommand)e.Data.GetData(typeof(NewAttachmentCommand));
                if (this.PointToClient(new Point(e.X, e.Y)).Y > (this.Height / 2))
                {
                    onAttachmentMove(targetAttach, MoveDirection.After, _attachment);
                }
                else
                {
                    onAttachmentMove(targetAttach, MoveDirection.Before, _attachment);
                }
            } else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string [] files= (string[])e.Data.GetData(DataFormats.FileDrop);
                onFileDropped(files, this.PointToClient(new Point(e.X, e.Y)).Y > (this.Height / 2)?ChildDragDirection.After:ChildDragDirection.Before);
            }

        }

        private void AttachmentSingleCtrl_DragOver(object sender, DragEventArgs e)
        {
            if (this.PointToClient(new Point(e.X, e.Y)).Y > (this.Height / 2))
            {
                onControlDragOver(ChildDragDirection.After);
            }
            else
            {
                onControlDragOver(ChildDragDirection.Before);
            }
        }

        #region EventHandlers

        protected void onAttachmentMove(AttachmentCommand attach, MoveDirection direction, AttachmentCommand beforeControl = null)
        {
            if (AttachmentMove != null)
                AttachmentMove(this, new AttachmentMoveEventArgs(attach, direction, beforeControl));
        }

        protected void onControlDragOver(ChildDragDirection direction)
        {
            if (ControlDragOver != null)
                ControlDragOver(this, new ChildDragEventArgs(direction));
        }

        protected void onControlDragLeave()
        {
            if (ControlDragLeave != null)
                ControlDragLeave(this, EventArgs.Empty);
        }

        protected void onFileDropped(string[] files,ChildDragDirection direction)
        {
            if (FileDropped != null)
                FileDropped(this, new FileDroppedEventArgs(files,direction));
        }

        protected void onAttachmentOpen()
        {
            if (AttachmentOpen != null)
                AttachmentOpen(this, new AttachmentEventArgs(_attachment));
        }

        protected void onCompressedChanged()
        {
            if (CompressedChanged != null)
                CompressedChanged(this, EventArgs.Empty);
        }
        #endregion

        private void chkRemove_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            onAttachmentOpen();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AttachmentSingleCtrl_Resize(object sender, EventArgs e)
        {
            //ctrlToolStrip.Width = this.Width - 200;
            //txtFileName.Width = ctrlToolStrip.Width - VERTICAL_SPACE;

        }

        private void ctrlToolStrip_Resize(object sender, EventArgs e)
        {
        }

        private void ctrlToolStrip_MouseDown(object sender, MouseEventArgs e)
        {
            doDrag();
        }

        private void picFileIcon_MouseDown(object sender, MouseEventArgs e)
        {
            doDrag();
        }

        private void btnRemove_CheckedChanged(object sender, EventArgs e)
        {
            txtFileName.Enabled = !btnRemove.Checked;
        }

        private void btnCompress_CheckedChanged(object sender, EventArgs e)
        {
            txtFileName.BackColor = btnCompress.Checked ? SystemColors.Info : SystemColors.Window;
            Data.Compress = btnCompress.Checked;
            onCompressedChanged();
        }
    }


    #region EventArgs
    //public class ChildDragEventArgs:EventArgs
    //{
    //    private ChildDragDirection _direction;

    //    public ChildDragDirection Direction
    //    {
    //        get { return _direction; }
    //        set { _direction = value; }
    //    }

    //    public ChildDragEventArgs(ChildDragDirection Direction)
    //    {
    //        _direction = Direction;
    //    }
    //}
    //public enum ChildDragDirection { Before, After }

    public class FileDroppedEventArgs : EventArgs
    {
        private string[] _files;
        public string[] Files
        {
            get { return _files; }
            set { _files = value; }
        }

        private ChildDragDirection _direction;
        public ChildDragDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public FileDroppedEventArgs(string[] Files, ChildDragDirection Direction)
        {
            _files = Files;
            _direction = Direction;
        }
    }

    public class AttachmentEventArgs : EventArgs
    {
        private AttachmentCommand _attachment;

        public AttachmentCommand Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }

        public AttachmentEventArgs(AttachmentCommand attach)
        {
            _attachment = attach;
        }
    }

    #endregion

}
