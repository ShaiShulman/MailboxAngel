using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{

    /// <summary>
    /// Util class for handling file icons
    /// </summary>
    public static class IconUtil
    {

        const uint SHGFI_ICON = 0x100;
        const uint SHGFI_LARGEICON = 0x0;    // 32x32 pixels
        const uint SHGFI_SMALLICON = 0x1;    // 16x16 pixels

        public enum ShellIconSize : uint
        {
            SmallIcon = SHGFI_ICON | SHGFI_SMALLICON,
            LargeIcon = SHGFI_ICON | SHGFI_LARGEICON
        }

        [DllImport("Shell32.dll")]
        public extern static int ExtractIconEx(
            string libName,
            int iconIndex,
            IntPtr[] largeIcon,
            IntPtr[] smallIcon,
            uint nIcons
        );

        public static Icon GetIconForExtension(string extension, ShellIconSize size)
        {
            RegistryKey keyForExt = Registry.ClassesRoot.OpenSubKey(extension);
            if (keyForExt == null) return null;

            string className = Convert.ToString(keyForExt.GetValue(null));
            RegistryKey keyForClass = Registry.ClassesRoot.OpenSubKey(className);
            if (keyForClass == null) return null;

            RegistryKey keyForIcon = keyForClass.OpenSubKey("DefaultIcon");
            if (keyForIcon == null)
            {
                RegistryKey keyForCLSID = keyForClass.OpenSubKey("CLSID");
                if (keyForCLSID == null) return null;

                string clsid = "CLSID\\"
                    + Convert.ToString(keyForCLSID.GetValue(null))
                    + "\\DefaultIcon";
                keyForIcon = Registry.ClassesRoot.OpenSubKey(clsid);
                if (keyForIcon == null) return null;
            }

            string[] defaultIcon = Convert.ToString(keyForIcon.GetValue(null)).Split(',');
            int index = (defaultIcon.Length > 1) ? Int32.Parse(defaultIcon[1]) : 0;

            IntPtr[] handles = new IntPtr[1];
            if (ExtractIconEx(defaultIcon[0], index,
                (size == ShellIconSize.LargeIcon) ? handles : null,
                (size == ShellIconSize.SmallIcon) ? handles : null, 1) > 0)
                return Icon.FromHandle(handles[0]);
            else
                return null;
        }
    }
}
