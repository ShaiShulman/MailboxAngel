using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingSuggester
{
    public class FolderKey: HelperUtils.ICounterListItem
    {
        private Folder _folder;
        public Folder OutlookFolder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        public string Key
        { get
            {
                return _folder.EntryID;
            }
        }

        public string Description
        {
            get
            {
                return _folder.FullFolderPath;
            }
        }

        public FolderKey(Folder folder)
        {
            _folder = folder;
        }

        public override string ToString()
        {
            return _folder.EntryID;
        }

        public class EqualityComparer : IEqualityComparer<FolderKey>
        {
            public bool Equals(FolderKey x, FolderKey y)
            {
                if (x == null || y == null)
                    return false;
                else
                    return x.Key == y.Key;
            }

            public int GetHashCode(FolderKey obj)
            {
                return obj.Key.GetHashCode();
            }
        }
    }
}
