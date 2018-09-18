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
        public static void PopulateFoldersList(this RibbonMenu control, IEnumerable<FolderInfo> list, RibbonControlEventHandler clickHandler, RibbonFactory factory)
        {
            control.Items.Clear();
            foreach (var item in list)
            {
                RibbonButton button = factory.CreateRibbonButton();
                button.Label = item.Name;
                button.Tag = item.EntryID;
                button.ScreenTip = item.Path;
                button.Click += clickHandler;
                button.OfficeImageId = item.Persist?"CreateMailRule":"Folder";
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
    }
}
