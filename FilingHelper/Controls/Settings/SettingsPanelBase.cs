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
    public partial class SettingsPanelBase : UserControl
    {
        private bool _isLoaded;

        public void LoadSettings()
        {
            if (!_isLoaded)
                loadSettings();
            _isLoaded = true;
        }
        public void SaveSettings()
        {
            if (_isLoaded)
            {
                saveSettings();
            }
        }
        protected virtual void loadSettings() { }
        protected virtual void saveSettings() { }

        public SettingsPanelBase()
        {
            InitializeComponent();
        }

    }
}
