using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilingHelper.Controls
{
    public partial class SettingsFrm : Form
    {
        public SettingsFrm()
        {
            InitializeComponent();
            LoadSignatures();
            LoadSettings();
        }

        private void LoadSignatures()
        {
            SignaturesService service = new SignaturesService();
            lstSignatures.Items.Clear();
            lstSignatures.Items.Add("<Nothing>");
            string[] files = service.GetSignatures();
            foreach (var item in files)
                lstSignatures.Items.Add(item);
        }

        private void lstSignatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSignatureName.Text = lstSignatures.Text;
            if (lstSignatures.SelectedIndex == 0)
                txtSignatureContent.Clear();
            else
                DisplaySignature();
        }

        private void DisplaySignature()
        {
            SignaturesService service = new SignaturesService();
            string filename = service.GetSignaturePath(lstSignatures.Text, SignatureType.RTF);
            if (!string.IsNullOrEmpty(filename))
                txtSignatureContent.LoadFile(filename);
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
            if (lstDomains.SelectedIndex>=0)
            {
                int selected = lstDomains.SelectedIndex;
                lstDomains.Items.RemoveAt(lstDomains.SelectedIndex);
                if (lstDomains.Items.Count > 0)
                    lstDomains.SelectedIndex = (selected > 0 ? selected - 1 : selected);
                else
                    btnRemoveDomain.Enabled = false;
            }
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
            btnRemoveDomain.Enabled = (lstDomains.Items.Count>0);
        }

        private void btnRemoveDomain_Click(object sender, EventArgs e)
        {
            removeDomain();
        }

        private void btnSaveSettings(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.Upgrade();
            Properties.AddinSettings.Default.EmailSignatureInternalName = lstSignatures.SelectedIndex > 0?lstSignatures.SelectedItem.ToString():"";
            Properties.AddinSettings.Default.InternalDomainNames = String.Join(",", lstDomains.Items.Cast<string>());
            Properties.AddinSettings.Default.Save();
            (new SignaturesService()).UpdateExistingSignature();
            this.Close();
        }

        private void LoadSettings()
        {
            Properties.Settings.Default.Upgrade();
            string internalSignature = Properties.AddinSettings.Default.EmailSignatureInternalName;
            if (lstSignatures.Items.IndexOf(internalSignature) > 0)
                lstSignatures.SelectedIndex = lstSignatures.Items.IndexOf(internalSignature);
            lstDomains.Items.AddRange(Properties.AddinSettings.Default.InternalDomainNames.Split(','));
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {

        }

        private void txtTest_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
