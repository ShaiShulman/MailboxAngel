using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{ 
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
