using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FlipkartAutomationTests.Utils;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FlipkartAutomationTests.Pages
{
    class ProductPage
    {
        private int productPrice;
        private ChromeDriver driver;

        public ProductPage(ChromeDriver driver)
        {
            this.driver = driver;
            this.productPrice = 0;
        }

        private IWebElement addToCartButton => driver.FindElementByCssSelector("._2KpZ6l._2U9uOA._3v1-ww");
        private IWebElement priceTag => driver.FindElementByCssSelector("._30jeq3._16Jk6d");

        public int GetProductPrice()
        {
            return this.productPrice;
        }
        public ShoppingCartPage ClickOnAddToCart()
        {
            if (HasAddToCartButton())
            {
                this.productPrice = UnitConverters.ConvertPriceToInt32(priceTag.Text);
                addToCartButton.Click();

                if (IsProductOutOfStock())
                {
                    this.productPrice = 0;
                    return null;
                }
                else
                {
                    return new ShoppingCartPage(driver);
                }
            }
            else
            {
                return null;
            }
        }
        private bool HasAddToCartButton()
        {
            bool IsButtonPrensent;
            try
            {
                IsButtonPrensent = addToCartButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                IsButtonPrensent = false;
            }

            return IsButtonPrensent;
        }
        private bool IsProductOutOfStock()
        {
            bool isProductOutOfStock;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(ExpectedConditions.TitleContains(Constants.SHOPPING_CART_PAGE_TITLE));
                isProductOutOfStock = false;
            }
            catch (WebDriverTimeoutException)
            {
                isProductOutOfStock = true;
            }

            return isProductOutOfStock;
        }
    }
}
