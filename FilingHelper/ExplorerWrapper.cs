using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;
using Microsoft.Office.Core;
using System.Windows.Forms;

namespace FilingHelper
{
    public class ExplorerWrapper
    {
        private Explorer explorer;
        private Microsoft.Office.Tools.CustomTaskPane panel;

        public ExplorerWrapper(Explorer explorer,UserControl control,string title)
        {
            this.explorer = explorer;
            panel = Globals.ThisAddIn.CustomTaskPanes.Add(control,title);
            panel.DockPosition = MsoCTPDockPosition.msoCTPDockPositionTop;
            panel.Height = 60;
            TaskPane.Visible = false;
        }

        public Microsoft.Office.Tools.CustomTaskPane TaskPane
        {
            get
            {
                return panel;
            }
        }
    }
}
