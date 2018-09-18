using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper
{
    public class MailHistoryManager:HistoryManagerBase<MailInfo>
    {
        public event EventHandler<MailItemEventArgs> NewMailItem;
        public MailHistoryManager(int size):base(size) { }
        public void Insert(MailItem item)
        {
            MailInfo info = new MailInfo(item);
            _list.Enqueue(info);
            onNewMailItem(info);
        }

        #region EventHandlers
        protected void onNewMailItem(MailInfo info)
        {
            if (NewMailItem != null)
                NewMailItem(this, new MailItemEventArgs(info));
        }
        #endregion
    }


    #region EventArgs
    public class MailItemEventArgs:EventArgs
    {
        private MailInfo _itemInfo;
        public MailInfo ItemInfo
        {
            get { return _itemInfo; }
            set { _itemInfo = value; }
        }
        public MailItemEventArgs(MailInfo itemInfo)
        {
            _itemInfo = itemInfo;
        }
    }
    #endregion
}
