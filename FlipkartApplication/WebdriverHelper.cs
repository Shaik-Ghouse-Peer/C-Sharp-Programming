using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace FlipkartApplication
{
    class WebdriverHelper
    {
        private readonly ChromeDriver chromeDriver;
        public WebdriverHelper(ChromeDriver chromeDriver)
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
        public  void SwitchToNewTab()
        {
            ReadOnlyCollection<string> windowTabs = this.chromeDriver.WindowHandles;
            this.chromeDriver.SwitchTo().Window(windowTabs[1]);
        }
        public void ClosePreviousTab()
        {
            ReadOnlyCollection<string> windowTabs = this.chromeDriver.WindowHandles;

            this.chromeDriver.SwitchTo().Window(windowTabs[0]).Close();

            this.chromeDriver.SwitchTo().Window(windowTabs[1]);
        }
    }
}
