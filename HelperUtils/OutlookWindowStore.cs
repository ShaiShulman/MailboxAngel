using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class OutlookWindowStore<T> where T : class
    {
        protected Dictionary<Explorer, T> explorerStorage;
        protected Dictionary<Inspector, T> inspectorStorage;
        public OutlookWindowStore()
        {
            explorerStorage = new Dictionary<Explorer, T>();
            inspectorStorage = new Dictionary<Inspector, T>();
        }

        public T this[Explorer explorer]
        {
            get
            {
                if (explorerStorage.ContainsKey(explorer))
                    return explorerStorage[explorer];
                else
                    return default(T);
            }
            set
            {
                if (explorerStorage.ContainsKey(explorer))
                    explorerStorage[explorer] = value;
                else
                    explorerStorage.Add(explorer, value);
            }
        }
        public T this[Inspector inspector]
        {
            get
            {
                if (inspectorStorage.ContainsKey(inspector))
                    return inspectorStorage[inspector];
                else
                    return default(T);
            }
            set
            {
                if (inspectorStorage.ContainsKey(inspector))
                    inspectorStorage[inspector] = value;
                else
                    inspectorStorage.Add(inspector, value);
            }
        }
        public void Remove(T item)
        {
            Inspector inspectorKey = inspectorStorage.FirstOrDefault(x => x.Value == item).Key;
            if (inspectorKey != null)
                inspectorStorage.Remove(inspectorKey);
            Explorer explorerKey = explorerStorage.FirstOrDefault(x => x.Value == item).Key;
            if (explorerKey != null)
                explorerStorage.Remove(explorerKey);
        }
        public void Remove(Inspector inspector)
        {
            if (inspector != null)
                inspectorStorage.Remove(inspector);
        }
        public void Remove(Explorer explorer)
        {
            if (explorer != null)
                explorerStorage.Remove(explorer);
        }
    }
}
