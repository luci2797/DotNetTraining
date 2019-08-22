using DotNetTraining.models;
using DotNetTraining.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.pages
{
    class ProductDetailsPage : BasePage
    {
        IWebElement ProductName {
            get {
                return driver.FindElement(By.CssSelector(".pb-center-column h1"));
            }
        }

        IWebElement ProductPrice {
            get {
                return driver.FindElement(By.CssSelector(".our_price_display"));
            }
        }

        IList<IWebElement> ProductColors{
            get {
                return driver.FindElements(By.CssSelector("#color_to_pick_list li a"));
            }
        }

        List<string> GetConvertedColorsList() {
            List<string> colors = new List<string>();
            foreach (IWebElement element in ProductColors) {
                //Console.WriteLine(element.GetAttribute("style"));
                colors.Add(Conversions.StringToColorCode(element.GetAttribute("style")));
            }
            return colors;
        }

        Product GetProductObject() {
            string name = ProductName.Text;
            float price = Conversions.StringToPrice(ProductPrice.Text);
            Product product = new Product(name, price);
            product.Colors = this.GetConvertedColorsList();
            return product;
        }
        bool AreColorsTheSame() {
            bool areTheSame = true;
            List<string> colorsFromProductList = this.GetProductObject().Colors;
            List<string> colorsFromProductPage = this.GetConvertedColorsList();
            /*Console.WriteLine("product list colors");
            base.DisplayStringList(colorsFromProductList);
            Console.WriteLine("\nproduct details colors");*/
            base.DisplayStringList(colorsFromProductPage);
            if (colorsFromProductList.Count != colorsFromProductPage.Count) {
                Console.WriteLine("number of colors when selecting product is different from  the number of colors on product page");
                return false;
            }
            for (int i = 0; i < colorsFromProductPage.Count; i++) {
                if (!colorsFromProductPage[i].Equals(colorsFromProductList[i])) {
                    areTheSame = false;
                    break;
                }
            }

            return areTheSame;
        }

        public bool IsProductTheSame() {
            if (this.GetProductObject().Name.Equals(Constants.ChosenProduct.Name)
                && this.GetProductObject().Price == Constants.ChosenProduct.Price
                && this.AreColorsTheSame())
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
