using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public static class Extensions
    {
        /// <summary>
        /// Check if string contains a value with case insensitive match
        /// </summary>
        /// <param name="text">String to check</param>
        /// <param name="value">Value to search</param>
        /// <param name="stringComparison">String comparison type</param>
        /// <returns></returns>
        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(value))
                return false;
            return text.IndexOf(value, stringComparison) >= 0;
        }
        /// <summary>
        /// Try to parse string/decimal as int, return 0 if failed
        /// </summary>
        /// <param name="text">String to parse</param>
        /// <param name="defaultValue">value to be used in parsing failed (0 if ommited)</param>
        /// <returns></returns>
        public static int TryParseInt(this string text, int defaultValue)
        {
            int parsedValue = 0;
            if (int.TryParse(text, out parsedValue))
                return parsedValue;
            else
                return defaultValue;
        }
        public static int TryParseInt(this decimal val, int defaultValue)
        {
            int parsedValue = 0;
            if (int.TryParse(val.ToString(), out parsedValue))
                return parsedValue;
            else
                return defaultValue;
        }
        /// <summary>
        /// Get description from enum value
        /// </summary>
        /// <typeparam name="T">Enum yupe to be used</typeparam>
        /// <param name="e">enum value</param>
        /// <returns></returns>
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null; // could also return string.Empty
        }
    }
}


