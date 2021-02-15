using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FlipkartAutomationTests.Utils;


namespace FlipkartAutomationTests.Utils
{
    class WebDriver
    {
        private ChromeDriver driver;

        public WebDriver()
        {
            this.driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);

            this.driver.Manage().Window.Maximize();
            this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.DEFAULT_PAGE_TIMEOUT);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants.DEFAULT_IMPLICIT_WAIT);
        }

        public ChromeDriver Driver()
        {
            return this.driver;
        }
    }
}
