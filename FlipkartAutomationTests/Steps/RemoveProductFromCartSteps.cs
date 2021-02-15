using System;
using TechTalk.SpecFlow;
using FlipkartAutomationTests.Pages;
using FlipkartAutomationTests.Utils;
using FlipkartAutomationTests.Hooks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace FlipkartAutomationTests.Steps
{
    [Binding]
    class RemoveProductFromCartSteps
    {
        private ChromeDriver chromeDriver;
        private ShoppingPage shoppingPage;
        private ShoppingCartPage shoppingCartPage;
        private string expectedProductsCount;

        public RemoveProductFromCartSteps()
        {
            this.chromeDriver = Hooks1.chromeDriver;
            shoppingPage = new ShoppingPage(chromeDriver);
        }

        [Given(@"User Has Products In His Cart")]
        public void GivenUserHasProductsInHisCart()
        {
            shoppingCartPage = shoppingPage.NavigateToShoppingCart();
            Assert.AreNotEqual(Constants.EMPTY_SHOPPING_CART, shoppingCartPage.GetTotalProductsInCart());
        }

        [When(@"He Removed '(.*)' from Cart")]
        public void WhenHeRemovedFromCart(string productName)
        {
            expectedProductsCount = shoppingCartPage.GetTotalProductsInCart();
            shoppingCartPage.RemoveProductFromCart(productName);
        }

        [Then(@"Product Should Be Removed Successfully")]
        public void ThenProductShouldBeRemovedSuccessfully()
        {
            Assert.AreNotEqual(expectedProductsCount, shoppingCartPage.GetTotalProductsInCart());
        }

    }
}
