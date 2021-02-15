using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;
using FlipkartAutomationTests.Pages;
using FlipkartAutomationTests.Hooks;
using FlipkartAutomationTests.Utils;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FlipkartAutomationTests.Steps
{
    [Binding]
    public class AddProductToShoppingCartSteps
    {
        private ChromeDriver chromeDriver;
        private LoginPage loginPage;
        private ShoppingPage shoppingPage;
        private IWebElement productLink;

        public AddProductToShoppingCartSteps()
        {
            this.chromeDriver = Hooks1.chromeDriver;
            loginPage = new LoginPage(chromeDriver);
        }

        [Given(@"The User On Flipkart Application")]
        public void GivenTheUserOnFlipkartApplication()
        {
            chromeDriver.Navigate().GoToUrl("https://flipkart.com");
            try
            {
                shoppingPage = loginPage.ClosePage();
            }
            catch(NoSuchElementException)
            {
                shoppingPage = new ShoppingPage(chromeDriver);
            }
        }

        [When(@"the the User Search For '(.*)'")]
        public void WhenTheTheUserSearchFor(string productName)
        {
            shoppingPage.SearchProduct(productName);
        }

        [When(@"User Clicked On '(.*)'")]
        public void WhenUserClickedOn(string productDataId)
        {
            productLink = chromeDriver.FindElementByCssSelector($"div[data-id='{productDataId}']>div>a");
        }

        [When(@"Seleced Add to Cart")]
        public void WhenSelecedAddToCart()
        {
            shoppingPage.AddProductToCart(productLink);
        }

        [Then(@"the User Should See (.*) In His Cart")]
        public void ThenTheUserShouldSeeInHisCart(int expectedProductsCount)
        {
            Assert.AreEqual($"My Cart ({expectedProductsCount})", shoppingPage.GetTotalNumberOfProductsInCart());
        }
    }
}
