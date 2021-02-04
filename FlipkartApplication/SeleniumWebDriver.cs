using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace FlipkartApplication
{
    class SeleniumWebDriver
    {
        private const int DEFAULT_PAGE_TIMEOUT = 10;
        public static ChromeDriver CreateChromeDriverInstance(string homePageUrl, int pageTimeout=DEFAULT_PAGE_TIMEOUT)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();

            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageTimeout);
            chromeDriver.Navigate().GoToUrl(homePageUrl);
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(pageTimeout);

            return chromeDriver;
        }
    }
}
