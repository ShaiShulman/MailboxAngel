using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingSuggester
{
    public class Suggester
    {
        private Dictionary<string, CounterList<Folder>> _list;
        public Suggester()
        {
            _list = new Dictionary<string, CounterList<Folder>>();
        }

        public void Update(string recepient, Folder folder)
        {
            if (!_list.ContainsKey(recepient))
                _list.Add(recepient, new CounterList<Folder>());
            else
                _list[recepient].Add(folder);
        }

        public Folder[] GetSuggestions(string recepient,int topItems)
        {
            if (_list.ContainsKey(recepient))
                return _list[recepient].GetTop(topItems);
            else
                return null;
        }
    }
}
