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
        /// <summary>
        /// Fill MenuButton button with a list of folders (including caption and images)
        /// </summary>
        /// <param name="control">MenuButton control to which the items will be added</param>
        /// <param name="imageList">ImageList containing the images to use for the menu items</param>
        /// <param name="clickEvent">Click event handler to be triggerred when an item is clicked</param>
        /// <param name="list">Enumerable of FolderInfo object that include the folders names</param>
        /// <param name="excludeFolder">Folder to be excluded from menu</param>
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
