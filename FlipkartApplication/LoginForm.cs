using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FlipkartApplication
{
    class LoginForm
    {
        public void Close(ChromeDriver chromeDriver)
        {
            IWebElement closeButton = chromeDriver.FindElementByXPath("//button[contains(text(), '✕')]");
            closeButton.Click();
        }
        
    }
}
