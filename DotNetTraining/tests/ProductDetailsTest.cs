using DotNetTraining.steps;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.tests
{
    class ProductDetailsTest:BaseTest
    {
        ProductListSteps productListSteps = new ProductListSteps();
        ProductDetailsSteps ProductDetailsSteps = new ProductDetailsSteps();
        BaseSteps baseSteps = new BaseSteps();

        [Test]
        public void ProductInfoTest() {
            baseSteps.NavigateToCategory("dresses");
            productListSteps.ChooseAndSaveRandomProduct();
            ProductDetailsSteps.CheckIfProductDetailsMatch();
        }
    }
}
