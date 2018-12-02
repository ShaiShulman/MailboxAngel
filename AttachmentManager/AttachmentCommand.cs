using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperUtils;


namespace AttachmentManager
{
    [Serializable]
    public abstract class AttachmentCommand
    {
        public abstract string Extension { get; }
        public abstract string NameOnly { get; }
        public abstract string FullName { get; }

        private string _newName;
        public string NewName
        {
            get { return _newName; }
            set { _newName = value; }
        }

        private int _sortOrder;
        public int SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        private bool _compress;
        public bool Compress
        {
            get { return _compress; }
            set { _compress = value; }
        }

        private bool _finalizeChanges;
        public bool FinalizeChanges
        {
            get { return _finalizeChanges; }
            set { _finalizeChanges = value; }
        }

        private bool _remove;
        public bool Remove
        {
            get { return _remove; }
            set { _remove = value; }
        }

    }
}
