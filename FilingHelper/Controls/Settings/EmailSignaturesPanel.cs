using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilingHelper.Controls.Settings
{
    public partial class AttachmentHelperPanel : UserControl, ISettingsDialogPanel
    {
        Control[] signatureComboBoxes;

        public AttachmentHelperPanel()
        {
            InitializeComponent();
            signatureComboBoxes = new ComboBox[]{ lstExternalNew, lstExternalReply, lstInternalNew, lstInternalReply };

        }

        private void loadSignatures()
        {
            
            SignaturesService service = new SignaturesService();
            string[] list = service.GetSignatures();
            foreach (ComboBox ctrl in signatureComboBoxes)
            {
                ctrl.Items.Clear();
                ctrl.Items.Add("<Nothing>");
                foreach (var item in list)
                    ctrl.Items.Add(item);
            }
        }

        private void addDomain()
        {
            if (!lstDomains.Items.Contains(txtNewDomain.Text))
                lstDomains.Items.Add(txtNewDomain.Text);
            lstDomains.SelectedIndex = lstDomains.Items.IndexOf(txtNewDomain.Text);
            txtNewDomain.Text = "";
        }
        private void removeDomain()
        {
            if (lstDomains.SelectedIndex >= 0)
            {
                int selected = lstDomains.SelectedIndex;
                lstDomains.Items.RemoveAt(lstDomains.SelectedIndex);
                if (lstDomains.Items.Count > 0)
                    lstDomains.SelectedIndex = (selected > 0 ? selected - 1 : selected);
                else
                    btnRemoveDomain.Enabled = false;
            }
        }
        public void LoadSettings()
        {
            loadSignatures();
            Properties.Settings.Default.Upgrade();
            Properties.AddinSettings prop = Properties.AddinSettings.Default;
            lstDomains.Items.Clear();
            lstDomains.Items.AddRange(prop.InternalDomainNames.Split(','));
            Dictionary<Control, string> values = new Dictionary<Control, string>()
            {
                { lstExternalNew, prop.EmailSignatureExternalNew }, 
                { lstExternalReply, prop.EmailSignatureExternalReply},
                { lstInternalNew, prop.EmailSignatureInternalNew},
                { lstInternalReply, prop.EmailSignatureInternalReply }
            };
            chkEnabled.Checked = prop.EmailSignatureEnabled;
            changeEnabled(prop.EmailSignatureEnabled);

            foreach (ComboBox control in signatureComboBoxes)
            {
                {
                    if (control.Items.IndexOf(values[control]) > 0)
                        control.SelectedIndex = control.Items.IndexOf(values[control]);
                    else
                        control.SelectedIndex = 0;
                    //control.Enabled = prop.EmailSignatureEnabled;
                }
            }
            //txtNewDomain.Enabled = prop.EmailSignatureEnabled;
            //btnAddDomain.Enabled = prop.EmailSignatureEnabled;
            //btnRemoveDomain.Enabled = prop.EmailSignatureEnabled;
            //lstDomains.Enabled = prop.EmailSignatureEnabled;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Upgrade();
            Properties.AddinSettings.Default.InternalDomainNames = String.Join(",", lstDomains.Items.Cast<string>());
            Properties.AddinSettings.Default.EmailSignatureInternalNew = lstInternalNew.SelectedIndex > 0 ? lstInternalNew.SelectedItem.ToString() : "";
            Properties.AddinSettings.Default.EmailSignatureInternalReply = lstInternalReply.SelectedIndex > 0 ? lstInternalReply.SelectedItem.ToString() : "";
            Properties.AddinSettings.Default.EmailSignatureExternalNew = lstExternalNew.SelectedIndex > 0 ? lstExternalNew.SelectedItem.ToString() : "";
            Properties.AddinSettings.Default.EmailSignatureExternalReply = lstExternalReply.SelectedIndex > 0 ? lstExternalReply.SelectedItem.ToString() : "";
            Properties.AddinSettings.Default.EmailSignatureEnabled = chkEnabled.Checked;
            Properties.AddinSettings.Default.Save();
            (new SignaturesService()).UpdateExistingSignature();
        }

        private void txtNewDomain_TextChanged(object sender, EventArgs e)
        {
            btnAddDomain.Enabled = (!string.IsNullOrWhiteSpace(txtNewDomain.Text));
        }

        private void btnAddDomain_Click(object sender, EventArgs e)
        {
            addDomain();
        }

        private void lstDomains_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveDomain.Enabled = (lstDomains.Items.Count > 0);
        }

        private void btnRemoveDomain_Click(object sender, EventArgs e)
        {
            removeDomain();
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            changeEnabled(chkEnabled.Checked);
        }
        
        private void changeEnabled(bool enabled)
        {
            foreach (ComboBox control in signatureComboBoxes)
            {
                {
                    control.Enabled = enabled;
                }
            }
            txtNewDomain.Enabled = enabled;
            btnAddDomain.Enabled = enabled;
            btnRemoveDomain.Enabled = enabled;
            lstDomains.Enabled = enabled;
        }
    }
}
