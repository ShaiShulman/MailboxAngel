using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class WindowManager
    {
        /// <summary>
        /// Close all open windows in an Outlook application
        /// </summary>
        /// <param name="app">Appliction object for an open Outlook app</param>
        public void CloseAll(Application app)
        {
            while (app.Explorers.Count > 1)
            {
                int i=1;
                while (app.Explorers[i] != app.ActiveExplorer())
                    i++;
                app.Explorers[i].Close();
            }
            while (app.Inspectors.Count>0)
            {
                app.Inspectors[1].Close(OlInspectorClose.olPromptForSave);
            }
        }
    }
}
