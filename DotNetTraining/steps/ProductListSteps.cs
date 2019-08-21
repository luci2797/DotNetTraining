using DotNetTraining.models;
using DotNetTraining.pages;
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
    }
}
