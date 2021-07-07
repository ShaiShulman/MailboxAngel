using HelperUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentManager
{
    /// <summary>
    /// Class representing a new attachment (one that did not already exist when the AttachmentManager was opened)
    /// Stores details of the file until the attachment is actually added to the mail item by the ProcessAttachments method
    /// </summary>
    public class NewAttachmentCommand : AttachmentCommand
    {
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        public override string Extension
        {
            get
            {
                return Path.GetExtension(_filePath);
            }
        }

        public override string NameOnly
        {
            get
            {
                return Path.GetFileNameWithoutExtension(_filePath);
            }
        }

        public override string FullName
        {
            get
            {
                return Path.GetFileName(_filePath);
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="FilePath">Path of the file on the local computer</param>
        public NewAttachmentCommand(string FilePath)
        {
            _filePath = FilePath;
        }
    }
}
