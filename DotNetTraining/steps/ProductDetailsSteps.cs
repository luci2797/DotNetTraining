using DotNetTraining.pages;
using DotNetTraining.utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraining.steps
{
    class ProductDetailsSteps
    {
        ProductDetailsPage productDetailsPage = new ProductDetailsPage();

        public void CheckIfProductDetailsMatch() {
            Assert.IsTrue(productDetailsPage.IsProductTheSame());
        }

        public void SelectRandomProductSize() {
            productDetailsPage.SelectRandomSize();
        }

        public void SelectRandomProductColor() {
            productDetailsPage.SelectRandomColor();
        }

        public void SetRandomQuantity() {
            productDetailsPage.SetRandomQuantity();
        }

        public void AddProductToCart() {
            WebElementInteractions.ClickButton(productDetailsPage.AddToCartButton);
        }

        public void ProceedToCheckout() {
            productDetailsPage.GoToCheckout();
        }

        public void ShareOnFacebook() {
            WebElementInteractions.ClickButton(productDetailsPage.FacebookButton);
        }
        public void ShareOnTwitter()
        {
            WebElementInteractions.ClickButton(productDetailsPage.TwitterButton);
        }
        public void ShareOnGooglePlus()
        {
            WebElementInteractions.ClickButton(productDetailsPage.GooglePlusButton);
        }
        public void ShareOnPinterest()
        {
            WebElementInteractions.ClickButton(productDetailsPage.PinterestButton);
        }

        public void CheckDiscountCalculation() {
            Assert.IsTrue(productDetailsPage.AreActualPriceAndDisplayedPriceTheSame());
        }

    }
}
