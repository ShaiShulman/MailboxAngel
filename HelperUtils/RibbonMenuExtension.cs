using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    /// <summary>
    /// Utils for adding functionality to an Outlook Ribbon Menu button
    /// </summary>
    public static class RibbonMenuExtension
    {
        /// <summary>
        /// Clear all items in a menu
        /// </summary>
        /// <param name="control">Ribbon Menu to be cleared</param>
        public static void Clear(this RibbonMenu control)
        {
            control.Items.Clear();

        }

        /// <summary>
        /// Populate Outlook Ribbon Menu with a list of folders
        /// </summary>
        /// <param name="control">Ribbon Menu to be used</param>
        /// <param name="list">List of FolderInfo objects containing the folders to be edded</param>
        /// <param name="clickHandler">Function containing the action to perform where a menu item is sclisked</param>
        /// <param name="factory">RibbonFactory to be used</param>
        /// <param name="officeImageIdDelegate"></param>
        /// <param name="prefix">Prefix for menu item captions</param>
        public static void PopulateFoldersList(this RibbonMenu control, IEnumerable<FolderInfo> list, RibbonControlEventHandler clickHandler, RibbonFactory factory, Func<FolderInfo, string> officeImageIdDelegate, string prefix = "")
        {
            foreach (var item in list.Where(x=>x.Active))
            {
                RibbonButton button = factory.CreateRibbonButton();
                button.Label =  string.Concat(prefix,item.Name);
                button.Tag = item.EntryID;
                button.ScreenTip = item.Path;
                button.Click += clickHandler;
                //button.OfficeImageId = item.Persist?"CreateMailRule":"Folder";
                button.OfficeImageId = officeImageIdDelegate(item);
                button.ShowImage = true;
                control.Items.Add(button);
            }
        }
        /// <summary>
        /// Add an empty list of items to a n Outlook Ribbon Menu
        /// </summary>
        /// <param name="control">RibbonMenu to be used</param>
        /// <param name="text">Text to be used as caption</param>
        /// <param name="factory">RibbonFactory to be used</param>
        public static void CreateEmptyList(this RibbonMenu control, string text, RibbonFactory factory)
        {
            control.Items.Clear();
            RibbonButton button = factory.CreateRibbonButton();
            button.Label = text;
            button.Enabled = false;
            button.ShowImage = false;
            control.Items.Add(button);
        }
        /// <summary>
        /// Create a seperator on the menu
        /// </summary>
        /// <param name="control">RibbonMenu where the seperator will be created</param>
        /// <param name="factory">RibbonFactory to be used</param>
        public static void CreateSeperator(this RibbonMenu control, RibbonFactory factory)
        {
            RibbonSeparator seperator = factory.CreateRibbonSeparator();
            seperator.Enabled = false;
            control.Items.Add(seperator);
        }
        /// <summary>
        /// Create a search button on the menu
        /// </summary>
        /// <param name="control">RibbonMenu to be issued</param>
        /// <param name="clickHandler">Function to run when menu item is slicked</param>
        /// <param name="factory">RibbonFactory to be used</param>
        /// <param name="label">Menu item caption</param>
        public static void CreateSearchButton(this RibbonMenu control, RibbonControlEventHandler clickHandler, RibbonFactory factory, string label)
        {
            RibbonButton button = factory.CreateRibbonButton();
            button.Label = label;
            button.Click += clickHandler;
            button.OfficeImageId = "Search";
            button.ShowImage = true;
            control.Items.Add(button);
        }
    }
}
