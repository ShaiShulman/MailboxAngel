using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FilingHelper
{
    public class MailHistoryManager : HistoryManagerBase<MailInfo>
    {
        const string FILE_NAME = "MailHistory.xml";
        public event EventHandler<MailItemEventArgs> NewMailItem;
        public MailHistoryManager(int size) : base(size)
        { }
        protected override string BaseNodeName { get { return "MailItems"; } }
        protected override string GetFileName()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FILE_NAME);
        }

        public void Insert(MailItem item)
        {
            MailInfo info = new MailInfo(item);
            if (_list.Enqueue(info))
                onNewMailItem(info);
        }

        public void Save()
        {
            SaveAll(_list.Where(x=>x.Persist));
        }

        public void Load()
        {
            List<MailInfo> list = loadAll();
            if (list != null && list.Count > 0)
            {
                _list.Fill(loadAll());
                foreach (var mail in _list)
                {
                    try
                    {
                        object newItem = Globals.ThisAddIn.Application.Session.GetItemFromID(mail.EntryID);
                        if (newItem != null && newItem is MailItem)
                        {
                            mail.Item = (MailItem)newItem;
                        }
                    }
                    catch (System.Exception)
                    {

                        mail.Item = null;
                    }
                }
            }
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
