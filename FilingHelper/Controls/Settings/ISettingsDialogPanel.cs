using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper.Controls.Settings
{
    interface ISettingsDialogPanel
    {
        bool Validate();
        void SaveSettings();
        void LoadSettings();
    }
}
