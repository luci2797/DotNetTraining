using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DotNetTraining.utils
{
    class Conversions
    {
        public static string StringToColorCode(string text) {
            string colorcode;
            if (text.Length >= 12)
            {
                colorcode = text.Substring(11);
            }
            else {
                colorcode = text;
            }
            return colorcode;
            
        }

        public static float StringToPrice(string text) {
            string newPrice = text.Substring(1);
            return float.Parse(newPrice, CultureInfo.InvariantCulture.NumberFormat);
        }

        public static int StringToDiscountPercent(string text) {
            string trimmedPrice = text.Replace("-", string.Empty);
            trimmedPrice = trimmedPrice.Replace("%", string.Empty);
            return int.Parse(trimmedPrice);
        }
    }
}
