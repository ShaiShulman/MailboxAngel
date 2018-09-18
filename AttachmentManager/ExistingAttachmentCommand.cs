using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentManager
{
    public class ExistingAttachmentCommand:AttachmentCommand
    {
        private Attachment _attachment;
        public Attachment Attachment
        {
            get { return _attachment; }
        }

        public override string Extension
        {
            get
            { return Path.GetExtension(_attachment.FileName); }
        }
        public override string NameOnly
        {
            get
            { return Path.GetFileNameWithoutExtension( _attachment.FileName); }
        }

        public override string FullName
        {
            get
            { return _attachment.FileName; }
        }

        public ExistingAttachmentCommand(Attachment attachment)
        {
            _attachment = attachment;
        }
    }
}
