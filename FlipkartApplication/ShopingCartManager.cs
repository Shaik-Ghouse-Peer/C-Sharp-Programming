using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FlipkartApplication
{
    class ShopingCartManager
    {
        private ChromeDriver chromeDriver;
        private int totalProductsBeforeAddingNewProduct;

        public ShopingCartManager(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
            this.totalProductsBeforeAddingNewProduct = 0;
        }
        public bool AddProductToCart(string itemName, string itemLocator)
        {
            WebdriverHelper webdriverHelper = new WebdriverHelper(chromeDriver);

            SearchItem(chromeDriver, itemName);

            SelectItem(chromeDriver, itemLocator);

            if (webdriverHelper.IsNewTabOpen())
            {
                webdriverHelper.SwitchToNewTab();
                webdriverHelper.ClosePreviousTab();
            }
      
            ClickOnAddToCart(this.chromeDriver);
            WaitUntilShoppingCartPageLoad(this.chromeDriver);
            return IsProductAddedToCart();
        }
        private void WaitUntilShoppingCartPageLoad(ChromeDriver chromeDriver)
        {
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));

            Func<IWebDriver, bool> waitUntilProductAddedToCart = new Func<IWebDriver, bool>((IWebDriver driver) =>
            {
                if (driver.Title == "Shopping Cart | Flipkart.com")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            wait.Until(waitUntilProductAddedToCart);
        }
        private void SelectItem(ChromeDriver chromeDriver, string item_locator)
        {
            IWebElement item = chromeDriver.FindElementByCssSelector(item_locator);
            item.Click();
        }
        private void SearchItem(ChromeDriver chromeDriver, string itemName)
        {
            IWebElement searchBox = chromeDriver.FindElementByName("q");

            searchBox.SendKeys(itemName);
            searchBox.SendKeys(Keys.Enter);
        }
        private void ClickOnAddToCart(ChromeDriver chromeDriver)
        {
            IWebElement addToCart = chromeDriver.FindElementByCssSelector("button[class='_2KpZ6l _2U9uOA _3v1-ww']");
            addToCart.Click();
            
        }
        private bool IsProductAddedToCart()
        {
            if (GetToatalProductsInCart().Contains($"{this.totalProductsBeforeAddingNewProduct + 1}"))
            {
                this.totalProductsBeforeAddingNewProduct += 1;
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetToatalProductsInCart()
        {
            string totalProductsInCart;
            totalProductsInCart = this.chromeDriver.FindElementByClassName("_3g_HeN").Text;

            return totalProductsInCart;
        }
    }
}
