using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    /// <summary>
    /// Class for storing dictionaries of UI-related objects (of same time) for specific Outlook explorers and dictionaries
    /// </summary>
    /// <typeparam name="T">Type of objects to be stored</typeparam>
    public class OutlookWindowStore<T> where T : class
    {
        protected Dictionary<Explorer, T> explorerStorage;
        protected Dictionary<Inspector, T> inspectorStorage;
        public OutlookWindowStore()
        {
            explorerStorage = new Dictionary<Explorer, T>();
            inspectorStorage = new Dictionary<Inspector, T>();
        }

        /// <summary>
        /// get object for specific explorer
        /// </summary>
        /// <param name="explorer">Explorer for searching the dictionary</param>
        /// <returns>object to type T, default if explorer not found</returns>
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

        /// <summary>
        /// get object for specific inspector
        /// </summary>
        /// <param name="explorer">Inspector for searching the dictionary</param>
        /// <returns>object to type T, default if inspector not found</returns>
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
        /// <summary>
        /// Remove specific object from dictionary (whether it is in an inspctor or explorer)
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            Inspector inspectorKey = inspectorStorage.FirstOrDefault(x => x.Value == item).Key;
            if (inspectorKey != null)
                inspectorStorage.Remove(inspectorKey);
            Explorer explorerKey = explorerStorage.FirstOrDefault(x => x.Value == item).Key;
            if (explorerKey != null)
                explorerStorage.Remove(explorerKey);
        }
        /// <summary>
        /// Remove specific inspector
        /// </summary>
        /// <param name="inspector"></param>
        public void Remove(Inspector inspector)
        {
            if (inspector != null)
                inspectorStorage.Remove(inspector);
        }
        /// <summary>
        /// Remove specific explorer
        /// </summary>
        /// <param name="explorer"></param>
        public void Remove(Explorer explorer)
        {
            if (explorer != null)
                explorerStorage.Remove(explorer);
        }
    }
}
