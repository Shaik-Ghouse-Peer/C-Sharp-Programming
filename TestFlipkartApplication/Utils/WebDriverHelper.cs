using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Chrome;

namespace TestFlipkartApplication.Utils
{
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
