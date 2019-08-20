using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.utils
{
    class WebElementInteractions
    {
        public static void InputText(IWebElement element, string text) {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }
    }
}
