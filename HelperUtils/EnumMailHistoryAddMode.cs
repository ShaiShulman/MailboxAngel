using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{ 
    /// <summary>
    /// User-selected display modes for history item (whether to never display, display when it is opened or also when previewed
    /// </summary>
    public enum MailHistoryAddMode
    {
        [Description("Never")]
        Never=0,
        [Description("When item is opened")]
        InspectorOpened=1,
        [Description("When item is opened or previewed")]
        ExplorerSelectionChange=2
    } 
}
