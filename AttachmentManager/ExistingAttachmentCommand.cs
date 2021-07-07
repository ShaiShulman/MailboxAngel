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
    /// <summary>
    /// Class representing an existing attachment (attachment that was already in the mail item when the AttachmentManager was opened.
    /// Acts as a wrapper for the existing Outlook Attachment object and allow certain actions until the Attachment is updated by calling ProcessAttachments method
    /// </summary>
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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="attachment">Outlook Attachment object from the mail item</param>
        public ExistingAttachmentCommand(Attachment attachment)
        {
            _attachment = attachment;
        }
    }
}
