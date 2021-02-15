using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FlipkartAutomationTests.Utils;

namespace FlipkartAutomationTests.Pages
{
    class ShoppingCartPage
    {
        private ChromeDriver driver;
        private int costOfTotalProducts;

        public ShoppingCartPage(ChromeDriver driver)
        {
            this.driver = driver;
            this.costOfTotalProducts = 0;
        }

        private IWebElement totalProductsInCart => driver.FindElementByClassName("_3g_HeN");
        private IWebElement TotalProductsPrice => driver.FindElementByCssSelector(".Ob17DV._3X7Jj1>span");
        IWebElement confirmRemove => driver.FindElementByCssSelector("._3dsJAO._24d-qY.FhkMJZ");

        public string GetTotalProductsInCart()
        {
            return totalProductsInCart.Text;
        }
        public int GetCostOfTotalProducts()
        {
            this.costOfTotalProducts = UnitConverters.ConvertPriceToInt32(TotalProductsPrice.Text);
            return costOfTotalProducts;
        }
        private IWebElement SearchProductInCart(string productLocator)
        {
            IWebElement product;
            try
            {
                product = driver.FindElementByPartialLinkText(productLocator);
            }
            catch(NoSuchElementException)
            {
                product = null;
            }

            return product;
        }
        public void RemoveProductFromCart(string productLocator)
        {
            IWebElement product = SearchProductInCart(productLocator);

            if (IsProductFound(product))
            {
                RemoveProduct(product);
            }
        }
        private bool IsProductFound(IWebElement product)
        {
            if (product is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void RemoveProduct(IWebElement product)
        {
            IWebElement parent = product.FindElement(By.XPath("./ancestor::div[@class='zab8Yh _10k93p']"));
            IWebElement RemoveButton = parent.FindElement(By.XPath(".//div[@class='_10vWcL td-FUv WDiNrH']/div[2]"));
            RemoveButton.Click();
            
            if (IsConfirmPopUpPresent())
            {
                confirmRemove.Click();
            }
        }
        private bool  IsConfirmPopUpPresent()
        {
            bool IsAlertPresent;

            try
            {
                IsAlertPresent = confirmRemove.Displayed;
            }
            catch(NoSuchElementException)
            {
                IsAlertPresent = false;
            }

            return IsAlertPresent;
        }
    }
}
