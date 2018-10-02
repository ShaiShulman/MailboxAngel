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
        public MailInfo()
        {

        }
        public override string UniqueID
        { get { return _mail.EntryID; } }

        private string _entryID;
        [Persistent]
        public string EntryID
        {
            get { if (_mail == null) return _entryID; else return _mail.EntryID; }
            set { _entryID = value; }
        }

        private string _storeID;
        [Persistent]
        public string StoreID
        {
            get { if (_mail!=null && _mail.Parent is Folder) return ((Folder)_mail.Parent).StoreID; else return _storeID; }
            set { _storeID = value; }
        }
        [Persistent]
        public new bool Persist
        {
            get { return _persist; }
            set { _persist = value; }
        }
        [Persistent]
        public new bool Avoid
        {
            get { return _avoid; }
            set { _avoid = value; }
        }
        public override bool Active
        { get { return _mail != null; } }

        public MailItem Item
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public override string ToString()
        {
            return String.Join(_mail.Subject, _mail.Body);
        }


    }
}
