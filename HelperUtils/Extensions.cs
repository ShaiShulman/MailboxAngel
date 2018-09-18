using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public static class Extensions
    {
        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(value))
                return false;
            return text.IndexOf(value, stringComparison) >= 0;
        }

        //public static string ExtractFileName(this string text)
        //{
        //    if (text.LastIndexOf(".") > 0)
        //        return text.Substring(0, text.LastIndexOf("."));
        //    else
        //        return text;
        //}

        //public static string ExtractExtension(this string text)
        //{
        //    if (text.LastIndexOf(".") > 0)
        //        return text.Substring(text.LastIndexOf("."));
        //    else
        //        return "";

        //}



    }
}
