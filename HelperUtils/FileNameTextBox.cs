        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperUtils
{
    public class FileNameTextBox:TextBox
    {
        private bool _firstSelection = true;
        private string _fileName;
        public string FileName
        {
            get { return Path.GetFileNameWithoutExtension(Text); }
            set { _fileName = value; Text = string.Concat(_fileName, _extension); }
        }

        private string _extension;
        public string Extension
        {
            get { return Path.GetExtension(Text); }
            set { _extension = value; Text = string.Concat(_fileName, _extension); }
        }

        private Action _invalidFileNameDelegate;
        public Action InvalidFileNameDelegate
        {
            set { _invalidFileNameDelegate = value; }
        }

        public override string Text
        {
            get { return base.Text; }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_firstSelection)
            {
                base.OnMouseDown(e);
                return;
            }
            this.Focus();
        }

        protected override void OnClick(EventArgs e)
        {
            if (!_firstSelection)
            {
                base.OnClick(e);
                return;
            }
            if (!String.IsNullOrEmpty(_fileName))
            {
                this.SelectionStart = 0;
                this.SelectionLength = _fileName.Length;
            }
            _firstSelection = false;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            //_fileName = Path.GetFileNameWithoutExtension(Text);
            //_extension = Path.GetExtension(Text);
            base.OnTextChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            bool isValid = !string.IsNullOrEmpty(this.Text) &&
                    this.Text.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
            if (!isValid)
            {
                if (_invalidFileNameDelegate!=null)
                    _invalidFileNameDelegate();
                e.Cancel = true;
            }
            base.OnValidating(e);
        }

    }

    public class FileNameToolStripTextBox : ToolStripTextBox
    {
        private bool _firstSelection = true;
        private string _fileName;
        public string FileName
        {
            get { return Path.GetFileNameWithoutExtension(Text); }
            set { _fileName = value; Text = string.Concat(_fileName, _extension); }
        }

        private string _extension;
        public string Extension
        {
            get { return Path.GetExtension(Text); }
            set { _extension = value; Text = string.Concat(_fileName, _extension); }
        }

        private Action _invalidFileNameDelegate;
        public Action InvalidFileNameDelegate
        {
            set { _invalidFileNameDelegate = value; }
        }

        public override string Text
        {
            get { return base.Text; }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_firstSelection)
            {
                base.OnMouseDown(e);
                return;
            }
            this.Focus();
        }

        protected override void OnClick(EventArgs e)
        {
            if (!_firstSelection)
            {
                base.OnClick(e);
                return;
            }
            if (!String.IsNullOrEmpty(_fileName))
            {
                this.SelectionStart = 0;
                this.SelectionLength = _fileName.Length;
            }
            _firstSelection = false;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            //_fileName = Path.GetFileNameWithoutExtension(Text);
            //_extension = Path.GetExtension(Text);
            base.OnTextChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            bool isValid = !string.IsNullOrEmpty(this.Text) &&
                    this.Text.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
            if (!isValid)
            {
                if (_invalidFileNameDelegate != null)
                    _invalidFileNameDelegate();
                e.Cancel = true;
            }
            base.OnValidating(e);
        }

    }

}
