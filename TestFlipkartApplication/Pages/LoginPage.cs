using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFlipkartApplication.Pages
{
    class LoginPage
    {
        private ChromeDriver driver;

        public LoginPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement closeButton => this.driver.FindElement(By.XPath("//button[contains(text(), '✕')]"));

        public void ClosePage()
        {
            closeButton.Click();
        }
    }
}
