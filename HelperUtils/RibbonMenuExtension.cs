using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public static class RibbonMenuExtension
    {
        public static void Clear(this RibbonMenu control)
        {
            control.Items.Clear();

        }

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

        public static void CreateEmptyList(this RibbonMenu control, string text, RibbonFactory factory)
        {
            control.Items.Clear();
            RibbonButton button = factory.CreateRibbonButton();
            button.Label = text;
            button.Enabled = false;
            button.ShowImage = false;
            control.Items.Add(button);
        }

        public static void CreateSeperator(this RibbonMenu control, RibbonFactory factory)
        {
            RibbonSeparator seperator = factory.CreateRibbonSeparator();
            seperator.Enabled = false;
            control.Items.Add(seperator);
        }

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
