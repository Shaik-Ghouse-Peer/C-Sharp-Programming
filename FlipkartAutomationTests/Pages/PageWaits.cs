using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;
using FlipkartAutomationTests.Utils;
using OpenQA.Selenium.Support.UI;

namespace FlipkartAutomationTests.Pages
{
    sealed class PageWaits
    {
        private static WebDriverHelper webDriverHelper;
        public static void WaitUntilShoppingCartPageToLoad(ChromeDriver driver, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            wait.Until(ExpectedConditions.TitleContains(Constants.SHOPPING_CART_PAGE_TITLE));
        }
        public static void WaitUntilNavigateToProductPage(ChromeDriver driver)
        {
            webDriverHelper  = new WebDriverHelper(driver);
            if (webDriverHelper.IsNewTabOpen())
            {
                webDriverHelper.SwitchToNewTab();
            }
        }
        public static void WaitUntilShoppingPageToLoad(ChromeDriver driver, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            wait.Until(ExpectedConditions.TitleContains("Shopping"));
        }
    }
}
