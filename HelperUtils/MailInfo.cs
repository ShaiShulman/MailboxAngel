using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class MailInfo : HistoryListItemBase
    {
        MailItem _mail;
        public MailInfo(MailItem mail)
        {
            _mail = mail;
        }

        public MailItem Item
        {
            get { return _mail; }
        }

        public override string ToString()
        {
            return String.Join(_mail.Subject, _mail.Body);
        }


    }
}
