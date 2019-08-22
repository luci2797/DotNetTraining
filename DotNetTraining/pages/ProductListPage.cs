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

        public IList<IWebElement> ProductList {
            get {
                return driver.FindElements(By.CssSelector(".ajax_block_product"));
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

        IList<IWebElement> PriceSliderHeads {
            get {
                return driver.FindElements(By.CssSelector(".ui-slider-handle"));
            }
        }

        IWebElement PriceRangeLabel {
            get
            {
                return driver.FindElement(By.CssSelector("#layered_price_range"));
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
            for (int i = 0; i < ColorSortingOptions.Count; i++)
            {
                string actualNumber = this.GetColorOptionsObjects()[i].NumberOfProducts.ToString();
                if (!ColorSortingOptions[i].Text.Contains(actualNumber)) {
                    areColorsCorrect = false;
                    return areColorsCorrect;
                }
            }
            return areColorsCorrect;

        }

        public List<Product> GetProductObjects() {
            List<Product> products = new List<Product>();
            foreach (IWebElement element in ProductList) {
                string name = element.FindElement(By.CssSelector(".product-name")).Text;
                float price = Conversions.StringToPrice(element.FindElement(By.CssSelector(".right-block .price")).Text);
                products.Add(new Product(name, price));
            }
            return products;
        }

        public void DisplayProducts() {
            foreach (Product product in this.GetProductObjects()) {
                Console.WriteLine(product.ToString());
            }
        }

        public void MoveLeftSlider(SliderHandle direction) {
            base.MoveSliderHead(PriceSliderHeads[0], direction);
        }

        public void MoveRightSlider(SliderHandle direction) {
            base.MoveSliderHead(PriceSliderHeads[1], direction);
        }

        public float GetLimitPrice(MinOrMax minOrMax) {
            string priceRange = PriceRangeLabel.Text.Replace(" ", string.Empty);
            string[] values = priceRange.Split("-");
            if (minOrMax == MinOrMax.MIN)
            {
                return Conversions.StringToPrice(values[0]);
            }
            else {
                return Conversions.StringToPrice(values[1]);
            }

        }

        public bool AreProductsInPriceRange() {
            float minPrice = GetLimitPrice(MinOrMax.MIN);
            float maxPrice = GetLimitPrice(MinOrMax.MAX);
            bool areInRange = true;
            foreach (Product product in GetProductObjects()) {
                if (product.Price > maxPrice || product.Price < minPrice) {
                    areInRange = false;
                    break;
                }
            }
            return areInRange;
        }

    }
}
