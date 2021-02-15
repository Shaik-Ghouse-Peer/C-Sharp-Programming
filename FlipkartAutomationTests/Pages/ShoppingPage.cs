using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using FlipkartAutomationTests.Utils;
using System.Collections.ObjectModel;

namespace FlipkartAutomationTests.Pages
{
    class ShoppingPage
    {
        private ChromeDriver driver;
        private WebDriverHelper webDriverHelper;

        private string totalProductsInCart;
        private int costOfTotalProducts;
        private int productPrice;

        public ShoppingPage(ChromeDriver driver)
        {
            this.driver = driver;
            this.webDriverHelper = new WebDriverHelper(driver);

            this.costOfTotalProducts = 0;
            this.productPrice = 0;
        }

        private IWebElement searchBox => this.driver.FindElement(By.Name("q"));
        private ReadOnlyCollection<IWebElement> priceTags => this.driver.FindElements(By.CssSelector("._30jeq3._1_WHN1"));
        private IWebElement UserName => this.driver.FindElementByXPath("//div[@class='_2Xfa2_']/div[3]//div[@class='exehdJ']");
        private IWebElement GoToShoppingCart => this.driver.FindElementByClassName("_3SkBxJ");
        private IWebElement MoreOptions => this.driver.FindElementByCssSelector("._2Xfa2_>div:nth-of-type(4)>div");
        private IWebElement NotificationPreferences => this.driver.FindElementByXPath("//div[contains(text(), 'Notification Preferences')]/parent::a");

        public string GetUserName()
        {
            return UserName.Text;
        }
        public string GetTotalNumberOfProductsInCart()
        {
            return this.totalProductsInCart;
        }
        public int GetCostOfTotalProducts()
        {
            return this.costOfTotalProducts;
        }
        public int GetProductPrice()
        {
            return productPrice;
        }
        public ShoppingCartPage NavigateToShoppingCart()
        {
            GoToShoppingCart.Click();

            PageWaits.WaitUntilShoppingCartPageToLoad(driver, 10);

            return new ShoppingCartPage(driver);
        }
        public void SearchProduct(string product)
        {
            this.searchBox.SendKeys(product + Keys.Enter);
        }
        public bool AddProductToCart(IWebElement product)
        {
            ProductPage productPage;
            ShoppingCartPage shoppingCartPage;

            productPage = SelectProduct(product);

            shoppingCartPage = productPage.ClickOnAddToCart();

            if (IsProductAddedSuccessfully(shoppingCartPage))
            {
                return AddProductDetails(shoppingCartPage, productPage);
            }
            else
            {
                return ResetProductPrice();
            }
        }
        private bool IsProductAddedSuccessfully(ShoppingCartPage shoppingCartPage)
        {
            return shoppingCartPage != null;
        }
        private bool AddProductDetails(ShoppingCartPage shoppingCartPage, ProductPage productPage)
        {
            totalProductsInCart = shoppingCartPage.GetTotalProductsInCart();
            costOfTotalProducts = shoppingCartPage.GetCostOfTotalProducts();
            productPrice = productPage.GetProductPrice();

            return true;
        }
        private bool ResetProductPrice()
        {
            productPrice = 0;

            return false;
        }
        public ProductPage SelectProduct(IWebElement product)
        {
            product.Click();

            PageWaits.WaitUntilNavigateToProductPage(driver);

            return new ProductPage(this.driver);
        }      
        public NotificationsPreferencePage NavigateToNotifationsPreference()
        {
            MoveMouseOnToMoreOptions();
            NotificationPreferences.Click();

            return new NotificationsPreferencePage(driver);
        }
        private void MoveMouseOnToMoreOptions()
        {
            Thread.Sleep(5000);
            Actions mouse = new Actions(driver);
            mouse.MoveToElement(MoreOptions).Perform();
        }
    }
}
