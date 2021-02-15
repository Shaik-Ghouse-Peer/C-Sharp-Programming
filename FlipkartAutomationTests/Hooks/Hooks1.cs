using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using FlipkartAutomationTests.Utils;
using OpenQA.Selenium.Chrome;

namespace FlipkartAutomationTests.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        public static ChromeDriver chromeDriver;
        private WebDriverHelper webDriverHelper;

        [BeforeFeature]
        public static void BeforeFeature()
        {
            chromeDriver = new WebDriver().Driver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            chromeDriver.Quit();
        }
        [AfterScenario("Add")]
        public void AfterAddingProduct()
        {
            webDriverHelper = new WebDriverHelper(chromeDriver);
            if (webDriverHelper.IsNewTabOpen())
            {
                webDriverHelper.CloseNewTab();
            }
        }
    }
}
