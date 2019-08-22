using DotNetTraining.models;
using DotNetTraining.pages;
using DotNetTraining.utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class ProductListSteps
    {
        ProductListPage productListPage = new ProductListPage();

        public void DisplayColorOptions() {
            productListPage.DisplayColorOptionsShown();
        }

        public void DisplayProductColors() {
            foreach (string color in productListPage.GetProductColorOptions()) {
                Console.WriteLine(color);
            }
        }

        public void DisplayCountedColors() {
            productListPage.DisplayColorObjects();
        }

        public void CheckColors() {
            Assert.IsTrue(productListPage.AreColorsDisplayedCorrect());
        }

        public void DisplayProducts() {
            productListPage.DisplayProducts();
        }

        public void ChooseRandomProduct() {
            productListPage.SelectRandomElementInList(productListPage.ProductList);
        }

        public void LowerMaxPrice() {
            productListPage.MoveRightSlider(utils.SliderHandle.LEFT);
        }

        public void RaiseMinPrice() {
            productListPage.MoveLeftSlider(utils.SliderHandle.RIGHT);
        }

        public void DisplayMinPrice() {
            Console.WriteLine("the minimum price is:" + productListPage.GetLimitPrice(utils.MinOrMax.MIN));
        }

        public void DisplayMaxPrice() {
            Console.WriteLine("the maximum price is:" + productListPage.GetLimitPrice(utils.MinOrMax.MAX));
        }

        public void CheckIfPricesAreInRange() {
            Assert.IsTrue(productListPage.AreProductsInPriceRange());
        }

        public void ChooseAndSaveRandomProduct() {
            productListPage.ChooseAndSaveRandomProduct();
            Console.WriteLine(Constants.ChosenProduct.ToString());
        }
    }
}
