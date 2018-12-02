using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperUtils;

namespace FilingHelper.Controls.Settings
{
    public partial class AttachmentHelperSettingsPanel : UserControl,ISettingsDialogPanel
    {
        public AttachmentHelperSettingsPanel()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            Properties.AddinSettings.Default.Upgrade();
            chkAutoShowHelper.Checked = Properties.AddinSettings.Default.AttachmentHelperAutoShow;
            chkAutoCloseHepler.Checked = Properties.AddinSettings.Default.AttachmentHelperAutoHide;
            txtMaxEmailSize.Text=Properties.AddinSettings.Default.AttachmentHelperMaxEmailSize.ToString();
        }

        public void SaveSettings()
        {
            Properties.AddinSettings.Default.AttachmentHelperAutoShow = chkAutoShowHelper.Checked;
            Properties.AddinSettings.Default.AttachmentHelperAutoHide = chkAutoCloseHepler.Checked;
            Properties.AddinSettings.Default.AttachmentHelperMaxEmailSize = txtMaxEmailSize.Text.TryParseInt(10);
            Properties.AddinSettings.Default.Save();
        }
    }
}
