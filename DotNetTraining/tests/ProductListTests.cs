using DotNetTraining.steps;
using DotNetTraining.utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.tests
{
    class ProductListTests:BaseTest
    {
        ProductListSteps productListSteps = new ProductListSteps();
        BaseSteps baseSteps = new BaseSteps();

        [Test]
        public void ColorOptionsTest() {
            baseSteps.NavigateToCategory("dresses");
            productListSteps.DisplayColorOptions();
            productListSteps.DisplayCountedColors();
            productListSteps.CheckColors();
        }

        [Test]
        public void PriceSortTest() {
            baseSteps.NavigateToCategory("dresses");
            productListSteps.LowerMaxPrice();
            productListSteps.RaiseMinPrice();
            productListSteps.CheckIfPricesAreInRange();
            //productListSteps.DisplayMaxPrice();
            //System.Threading.Thread.Sleep(5000);
        }
    }
}
