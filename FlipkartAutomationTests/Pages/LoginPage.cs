using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FlipkartAutomationTests.Pages
{
    class LoginPage
    {
        private ChromeDriver driver;

        public LoginPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement CloseButton => this.driver.FindElement(By.XPath("//button[contains(text(), '✕')]"));
        private IWebElement UserName => this.driver.FindElementByCssSelector("._2IX_2-.VJZDxU");
        private IWebElement Password => this.driver.FindElementByCssSelector("._2IX_2-._3mctLh.VJZDxU");
        private IWebElement Login => this.driver.FindElementByCssSelector("._2KpZ6l._2HKlqd._3AWRsL");

        public void EnterUserNameAndPassword(string userName, string password)
        {
            this.UserName.SendKeys(userName);
            this.Password.SendKeys(password);
        }
        public ShoppingPage ClickOnLogin()
        {
            Login.Click();

            PageWaits.WaitUntilShoppingPageToLoad(driver, 10);
            return new ShoppingPage(driver);
        }
        public ShoppingPage ClosePage()
        {
            CloseButton.Click();

            PageWaits.WaitUntilShoppingPageToLoad(driver, 10);
            return new ShoppingPage(driver);
        }
    }
}
