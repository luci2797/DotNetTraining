using System;
using System.Collections.Generic;
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
    }
}
