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

        public static void ClickButton(IWebElement element) {
            element.Click();
        }

        public static IWebElement ChooseByNameFromList(IList<IWebElement> list, string name)
        {
            foreach (IWebElement element in list) {
                if (element.Text.ToLower().Contains(name)) {
                    return element;
                }
            }
            return null;
        }
    }
}
