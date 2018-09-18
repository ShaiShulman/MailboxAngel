using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper.Controls
{
    class TreeNodeTag
    {
        private MAPIFolder _folder;
        public MAPIFolder Folder
        {
            get { return _folder; }
        }

        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
        }

        public TreeNodeTag(MAPIFolder folder,bool enabled)
        {
            _folder = folder;
            _enabled = enabled;
        }
    }
}
