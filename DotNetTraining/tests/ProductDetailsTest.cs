using DotNetTraining.steps;
using DotNetTraining.utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.tests
{
    class ProductDetailsTest:BaseTest
    {
        ProductListSteps productListSteps = new ProductListSteps();
        ProductDetailsSteps productDetailsSteps = new ProductDetailsSteps();
        BaseSteps baseSteps = new BaseSteps();

        [Test]
        public void ProductInfoTest() {
            baseSteps.NavigateToCategory("dresses");
            productListSteps.ChooseAndSaveRandomProduct();
            productDetailsSteps.CheckIfProductDetailsMatch();
            productDetailsSteps.CheckDiscountCalculation();
            /*productDetailsSteps.SelectRandomProductSize();
            productDetailsSteps.SelectRandomProductColor();
            productDetailsSteps.SetRandomQuantity();
            productDetailsSteps.ShareOnTwitter();*/
            //productDetailsSteps.AddProductToCart();
            //productDetailsSteps.ProceedToCheckout();
        }


    }
}
