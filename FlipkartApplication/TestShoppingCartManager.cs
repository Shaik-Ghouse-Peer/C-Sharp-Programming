using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FlipkartApplication
{
    [TestFixture]
    class TestShoppingCartManager
    {
        ChromeDriver chromeDriver;
        LoginForm loginForm;
        ShopingCartManager shopingCartManager;

        [SetUp]
        public void Setup()
        {
            chromeDriver = SeleniumWebDriver.CreateChromeDriverInstance("https://www.flipkart.com");
            loginForm = new LoginForm();
            shopingCartManager = new ShopingCartManager(chromeDriver);
        }
        [Test]
        public void AddMultipleProductsToCart()
        {
            loginForm.Close(chromeDriver);

            shopingCartManager.AddProductToCart(Constants.ASUS_MOBILE_NAME, Constants.ASUS_MOBILE_LOCATOR);

            shopingCartManager.AddProductToCart(Constants.LENOVO_LAPTOP, Constants.LENOVO_LAPTOP_LOCATOR);

            shopingCartManager.AddProductToCart(Constants.LENOVO_LAPTOP_BAG, Constants.LENOVO_LAPTOP_BAG_LOCATOR);

            Assert.AreEqual(shopingCartManager.GetToatalProductsInCart(), Constants.EXPCTED_PRODUCTS_IN_CART);
        }
        [TearDown]
        public void CloseChromeBrowser()
        {
            chromeDriver.Quit();
        }
    }
}
