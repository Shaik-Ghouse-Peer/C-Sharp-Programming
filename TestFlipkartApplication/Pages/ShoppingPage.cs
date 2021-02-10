using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;
using TestFlipkartApplication.Utils;

namespace TestFlipkartApplication.Pages
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

            this.totalProductsInCart = "./ ancestor::a";
            this.costOfTotalProducts = 0;
            this.productPrice = 0;
        }

        private IWebElement searchBox => this.driver.FindElement(By.Name("q"));
        private ReadOnlyCollection<IWebElement> priceTags => this.driver.FindElements(By.CssSelector("._30jeq3._1_WHN1"));
        private string productLink = "./ ancestor::a";

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
            IWebElement productLink = product.FindElement(By.XPath(this.productLink));

            this.driver.ExecuteScript("arguments[0].scrollIntoView();", productLink);

            productLink.Click();

            WaitUntilNavigateToProductPage();

            return new ProductPage(this.driver);
        }
        public void WaitUntilNavigateToProductPage()
        {
            if (webDriverHelper.IsNewTabOpen())
            {
                webDriverHelper.SwitchToNewTab();
            }
        }
        public List<IWebElement> GetProductsUnderPriceRange(int priceRange)
        {
            List<IWebElement> products = new List<IWebElement>();
            foreach (IWebElement priceTag in priceTags)
            {
                int productPrice = UnitConverters.ConvertPriceToInt32(priceTag.Text);
                if (IsProductUnderPriceRange(productPrice, priceRange))
                {
                    products.Add(priceTag);
                }
            }
            return products;
        }
        private bool IsProductUnderPriceRange(int productPrice, int priceRange)
        {
            if (productPrice <= priceRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
