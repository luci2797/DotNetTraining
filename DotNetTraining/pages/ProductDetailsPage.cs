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

        IList<IWebElement> ProductColors {
            get {
                return driver.FindElements(By.CssSelector("#color_to_pick_list li a"));
            }
        }

        IWebElement QuantityField {
            get {
                return driver.FindElement(By.Id("quantity_wanted"));
            }
        }

        IWebElement SizeDropdownList {
            get {
                return driver.FindElement(By.Id("group_1"));
            }
        }

        public IWebElement AddToCartButton {
            get {
                return driver.FindElement(By.CssSelector("#add_to_cart button"));
            }
        }

        public IWebElement ProdeedToCheckoutButton
        {
            get {
                return driver.FindElement(By.CssSelector(".layer_cart_cart .button-medium"));
            }
        }

        public IWebElement TwitterButton {
            get
            {
                return driver.FindElement(By.CssSelector(".btn-twitter"));
            }
        }

        public IWebElement FacebookButton {
            get {
                return driver.FindElement(By.CssSelector(".btn-facebook"));
            }
        }

        public IWebElement GooglePlusButton {
            get {
                return driver.FindElement(By.CssSelector(".btn-google-plus"));
            }
        }

        public IWebElement PinterestButton {
            get {
                return driver.FindElement(By.CssSelector(".btn-pinterest"));
            }
        }

        IWebElement OldPriceLabel {
            get {
                return driver.FindElement(By.Id("old_price_display"));
            }
        }

        IWebElement DiscountPercentLabel {
            get {
                return driver.FindElement(By.Id("reduction_percent_display"));
            }
        }

        List<string> GetConvertedColorsList() {
            List<string> colors = new List<string>();
            foreach (IWebElement element in ProductColors) {
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
            Console.WriteLine("\nproduct details colors");
            base.DisplayStringList(colorsFromProductPage);*/
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

        public void SelectRandomSize()
        {
            base.SelectRandomOptionFromDropdown(SizeDropdownList);
        }

        public void SelectRandomColor() {
            base.SelectRandomElementInList(ProductColors);
        }

        public void SetRandomQuantity() {
            base.InputRandomAmount(QuantityField);
        }

        public void GoToCheckout() {
            int i = 0;
            while (i < 10) {
                try
                {
                    WebElementInteractions.ClickButton(ProdeedToCheckoutButton);
                    return;
                }
                catch (ElementNotInteractableException) {
                    System.Threading.Thread.Sleep(1000);
                    i++;
                }
            }
        }

        float GetProductPrice() {
            return Conversions.StringToPrice(ProductPrice.Text);
        }

        float GetOldPrice() {
            return Conversions.StringToPrice(OldPriceLabel.Text);
        }

        int GetDiscountPercent() {
            return Conversions.StringToDiscountPercent(DiscountPercentLabel.Text);
        }

        bool IsProductDiscounted() {
            try
            {
                this.GetOldPrice();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("price is not discounted");
                return false;
            }
            catch (ArgumentOutOfRangeException) {
                Console.WriteLine("price is not discounted");
                return false;
            }
            return true;
           
        }

        float CalculateDiscountedPrice() {
            if (this.IsProductDiscounted())
            {
                //Console.WriteLine("old price is:" + this.GetOldPrice() + "   and the discount is:" + this.GetDiscountPercent());
                float price = this.GetOldPrice();
                int discount = this.GetDiscountPercent();
                price = price - price * discount / 100;
                return price;
            }
            else {
                return 0f;
            }
        }

        public bool AreActualPriceAndDisplayedPriceTheSame() {
            Console.WriteLine("displayed price:" + this.GetProductPrice());
            Console.WriteLine("actual price:" + this.CalculateDiscountedPrice());
            if (this.CalculateDiscountedPrice() == 0f)
            {
                return true;
            }
            else {
                if (this.CalculateDiscountedPrice() == this.GetProductPrice()) {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    } 
}
