using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperUtils
{
    public static class MenuButtonExtension
    {
        public static void FillFoldersList(this MenuButton control, ImageList imageList,EventHandler clickEvent,
            IEnumerable<FolderInfo> list, string excludeFolder="")
        {
            control.Menu = new ContextMenuStrip();
            control.Menu.ImageList = imageList;
            foreach (var item in list)
            {
                try
                {
                    if (item.Folder.FolderPath != excludeFolder)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem();
                        menuItem.Text = item.Name;
                        menuItem.ToolTipText = item.Path;
                        menuItem.Tag = item.Path;
                        menuItem.ImageIndex = 0;
                        menuItem.Click += clickEvent;
                        control.Menu.Items.Add(menuItem);
                    }

                }
                catch (Exception)
                {
                }
             }

        }
    }
}
