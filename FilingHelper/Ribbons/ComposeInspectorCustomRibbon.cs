using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace FilingHelper
{
    public partial class ComposeInspectorCustomRibbon
    {
        Controls.Settings.SettingsFrm _settingsForm;
        private void btnAttachments_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.AttachmentManager(Globals.ThisAddIn.Application.ActiveInspector());
        }

        private void ComposeGroup_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            _settingsForm = new Controls.Settings.SettingsFrm(0);
            _settingsForm.ShowDialog();
        }
    }
}
