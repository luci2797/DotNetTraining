using DotNetTraining.models;
using DotNetTraining.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class ProductListPage : BasePage
    {
        //public List<ColorOption> colors;
        IList<IWebElement> ColorSortingOptions
        {
            get {
                return driver.FindElements(By.CssSelector("#ul_layered_id_attribute_group_3 li"));
            }
        }

        IList<IWebElement> ProductList {
            get {
                return driver.FindElements(By.CssSelector(".ajax_block_product "));
            }
        }

        IList<IWebElement> ProductColorsList {
            get {
                return driver.FindElements(By.CssSelector(".color_to_pick_list>li a"));
            }
        }

        IList<IWebElement> ColorLabels {
            get {
                return driver.FindElements(By.CssSelector(".layered_color"));
            }
        }

        public List<ColorOption> BuildColorOptionsObjects() {
            List<ColorOption> colors = new List<ColorOption>();
            foreach (IWebElement colorElement in ColorSortingOptions) {
                string colorCode = Conversions.StringToColorCode(colorElement.FindElement(By.CssSelector(".color-option")).GetAttribute("style"));
                colors.Add(new ColorOption(colorCode));
            }

            return colors;
        }

        public List<string> GetProductColorOptions() {
            List<string> colors = new List<string>();
            foreach (IWebElement productColor in ProductColorsList) {
                colors.Add(Conversions.StringToColorCode(productColor.GetAttribute("style")));
            }
            return colors;

        }

        public List<ColorOption> GetColorOptionsObjects()
        {
            List<ColorOption> colors = this.BuildColorOptionsObjects();
            foreach (string color in this.GetProductColorOptions()) {
                foreach (ColorOption colorOption in colors) {
                    if (colorOption.ColorCode.Equals(color))
                    {
                        colorOption.IncrementNumer();
                        break;
                    }
                }
            }
            return colors;
        }

        public void DisplayColorObjects() {
            foreach (ColorOption color in this.GetColorOptionsObjects()) {
                Console.WriteLine(color.ToString());
            }
        }

        public void DisplayColorOptionsShown() {
            foreach (IWebElement element in ColorSortingOptions) {
                Console.WriteLine(element.Text);
            }
        }

        public bool AreColorsDisplayedCorrect() {
            bool areColorsCorrect = true;
            for(int i = 0; i < ColorSortingOptions.Count;i++)
            {
                string actualNumber = this.GetColorOptionsObjects()[i].NumberOfProducts.ToString();
                if (!ColorSortingOptions[i].Text.Contains(actualNumber)) {
                    areColorsCorrect = false;
                    return areColorsCorrect;
                }
            }
            return areColorsCorrect;

        }
    }
}
