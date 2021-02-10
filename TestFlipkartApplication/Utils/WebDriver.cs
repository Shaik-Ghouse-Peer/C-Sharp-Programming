using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFlipkartApplication.Utils
{
    class WebDriver
    {
        private ChromeDriver driver;

        public WebDriver(string homeUrl)
        {
            this.driver = new ChromeDriver();

            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.DEFAULT_PAGE_TIMEOUT);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.DEFAULT_IMPLICIT_WAIT);

            this.driver.Navigate().GoToUrl(homeUrl);
        }

        public ChromeDriver Driver()
        {
            return this.driver;
        }
    }
}
