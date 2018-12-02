using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FilingHelper
{
    public class FolderHistoryManager : HistoryManagerBase<FolderInfo>
    {
        const string FILE_NAME = "FolderHistory.xml";
        protected override string BaseNodeName { get { return "MailItems"; } }
        protected override string GetFileName()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FILE_NAME);
        }

        public bool isFolderPersistent(string entryID)
        {
            FolderInfo item = _list.FirstOrDefault(x => x.EntryID == entryID);
            if (item == null)
                return false;
            else
                return item.Persist;
        }
        public bool isFolderAvoided(string entryID)
        {
            FolderInfo item = _list.FirstOrDefault(x => x.EntryID == entryID);
            if (item == null)
                return false;
            else
                return item.Avoid;
        }

        public void ChangeFolderPersistence(string entryID, bool value)
        {
            FolderInfo item = _list.FirstOrDefault(x => x.EntryID == entryID);
            if (item == null)
                throw new System.Exception("Folder not found in history");
            else
            {
                item.Persist = value;
                if (value)
                    item.Avoid = false;
            }
        }
        public void ChangeFolderAvoidance(string entryID, bool value)
        {
            FolderInfo item = _list.FirstOrDefault(x => x.EntryID == entryID);
            if (item == null)
                throw new System.Exception("Folder not found in history");
            else
            {
                item.Avoid = value;
                if (value)
                    item.Persist = false;
            }
        }

        private string getFileName()
        {
            return String.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"\", FILE_NAME);
        }
        public void Insert(MAPIFolder folder)
        {
            _list.Enqueue(new FolderInfo(folder));
        }
        public void Save()
        {
            XmlDocument document = new XmlDocument();
            XmlNode parent = document.AppendChild(document.CreateElement("History"));
            foreach (var item in _list)
            {
                XmlNode lineNode = document.CreateElement("Folder");
                XmlNode entryNode = document.CreateElement("EntryID");
                entryNode.InnerText = item.EntryID;
                lineNode.AppendChild(entryNode);
                XmlNode storeNode = document.CreateElement("StoreID");
                storeNode.InnerText = item.StoreID;
                lineNode.AppendChild(storeNode);
                XmlNode persistNode = document.CreateElement("Persist");
                persistNode.InnerText = item.Persist.ToString();
                lineNode.AppendChild(persistNode);
                XmlNode avoidNode = document.CreateElement("Avoid");
                avoidNode.InnerText = item.Avoid.ToString();
                lineNode.AppendChild(avoidNode);
                XmlNode pathNode = document.CreateElement("Path");
                pathNode.InnerText = item.Path.ToString();
                lineNode.AppendChild(pathNode);
                parent.AppendChild(lineNode);

            }
            document.Save(getFileName());
        }
        public void Load()
        {
            XmlDocument document = new XmlDocument();
            Microsoft.Office.Interop.Outlook.NameSpace session = Globals.ThisAddIn.Application.Session;
            string fname = getFileName();
            if (!File.Exists(fname))
                return;
            document.Load(getFileName()); ;
            _list = new LimitedUniqueQueue<FolderInfo>(_listSize);
            foreach (XmlNode node in document.SelectNodes("/History/Folder").Cast<XmlNode>().Reverse())
            {
                string entryId = node["EntryID"].InnerText;
                string storeId = node["StoreID"].InnerText;
                bool persist = node["Persist"].InnerText == "True";
                bool avoid = node["Avoid"].InnerText == "True";

                if (!string.IsNullOrWhiteSpace(entryId) && !(string.IsNullOrWhiteSpace(storeId)))
                {
                    MAPIFolder folder = null;
                    try
                    {
                        folder = session.GetFolderFromID(entryId, storeId);
                    }
                    catch (System.Exception)
                    {
                    }

                    if (folder != null)
                    {
                        FolderInfo folderInfo = new FolderInfo(folder);
                        folderInfo.Persist = persist;
                        folderInfo.Avoid = avoid;
                        _list.Enqueue(folderInfo);
                    }
                    else if (persist || avoid)
                    {
                        FolderInfo folderInfo = new FolderInfo(entryId, storeId);
                        folderInfo.Persist = persist;
                        folderInfo.Avoid = avoid;
                        _list.Enqueue(folderInfo);
                    }
                }
            }
        }

        public FolderHistoryManager(int size):base(size) { }
    }
}
