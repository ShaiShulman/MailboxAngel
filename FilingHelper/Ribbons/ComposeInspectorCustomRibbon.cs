using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace FilingHelper
{
    public partial class ComposeInspectorCustomRibbon
    {
        private void ComposeInspectorCustomRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnAttachments_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.AttachmentManager(Globals.ThisAddIn.Application.ActiveInspector());
        }
    }
}
