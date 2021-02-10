using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TestFlipkartApplication.Utils;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;

namespace TestFlipkartApplication.Pages
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

        public string GetTotalProductsInCart()
        {
            return totalProductsInCart.Text;
        }
        public int GetCostOfTotalProducts()
        {
            this.costOfTotalProducts = UnitConverters.ConvertPriceToInt32(TotalProductsPrice.Text);
            return costOfTotalProducts;
        }
    }
}
