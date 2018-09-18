using HelperUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentManager
{
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

        public NewAttachmentCommand(string FilePath)
        {
            _filePath = FilePath;
        }
    }
}
