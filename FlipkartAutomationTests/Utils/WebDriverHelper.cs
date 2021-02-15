using System;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;

namespace FlipkartAutomationTests.Utils
{
    [Binding]
    class WebDriverHelper
    {
        private readonly ChromeDriver chromeDriver;

        public WebDriverHelper(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }
        public bool IsNewTabOpen()
        {
            if (this.chromeDriver.WindowHandles.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SwitchToNewTab()
        {
            ReadOnlyCollection<string> windowTabs = this.chromeDriver.WindowHandles;

            this.chromeDriver.SwitchTo().Window(windowTabs[1]);
        }
        public void CloseNewTab()
        {
            ReadOnlyCollection<string> windowTabs = this.chromeDriver.WindowHandles;

            this.chromeDriver.Close();

            this.chromeDriver.SwitchTo().Window(windowTabs[0]);
        }
    }
}
