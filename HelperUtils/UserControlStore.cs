using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using Microsoft.Office.Tools;

namespace FilingHelper
{
    public class UserControlStore<T>    where T : UserControl
    {
        private Dictionary<Explorer, CustomTaskPane> explorerStorage;
        private Dictionary<Inspector, CustomTaskPane> inspectorStorage;
        public UserControlStore()
        {
            explorerStorage = new Dictionary<Explorer, CustomTaskPane>();
            inspectorStorage = new Dictionary<Inspector, CustomTaskPane>();
        }
        
        public CustomTaskPane this[Explorer explorer]
        {
            get
            {
                if (explorerStorage.ContainsKey(explorer))
                    return explorerStorage[explorer];
                else
                    return null;
            }
            set
            {
                if (explorerStorage.ContainsKey(explorer))
                    explorerStorage[explorer] = value;
                else
                    explorerStorage.Add(explorer, value);
            }
        }
        public CustomTaskPane this[Inspector inspector]
        {
            get
            {
                if (inspectorStorage.ContainsKey(inspector))
                    return inspectorStorage[inspector];
                else
                    return null;
            }
            set
            {
                if (inspectorStorage.ContainsKey(inspector))
                    inspectorStorage[inspector] = value;
                else
                    inspectorStorage.Add(inspector, value);
            }
        }
        public CustomTaskPane Insert(T control, string title, Explorer explorer)
        {
            CustomTaskPane pane = getPanel(control, title);
            if (explorerStorage.ContainsKey(explorer))
                explorerStorage[explorer] = pane;
            else
                explorerStorage.Add(explorer, pane);
            return pane;
        }
        public CustomTaskPane Insert(T control, string title, Inspector inspector)
        {
            CustomTaskPane pane = getPanel(control, title);
            if (inspectorStorage.ContainsKey(inspector))
                inspectorStorage[inspector] = pane;
            else
                inspectorStorage.Add(inspector, pane);
            return pane;
        }
        private CustomTaskPane getPanel(T control, string title)
        {
            CustomTaskPane panel = Globals.ThisAddIn.CustomTaskPanes.Add(control, title);
            return panel;
        }
        public void Remove(CustomTaskPane pane)
        {
            Inspector inspectorKey = inspectorStorage.FirstOrDefault(x => x.Value == pane).Key;
            if (inspectorKey != null)
                inspectorStorage.Remove(inspectorKey);
            Explorer explorerKey = explorerStorage.FirstOrDefault(x => x.Value == pane).Key;
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

