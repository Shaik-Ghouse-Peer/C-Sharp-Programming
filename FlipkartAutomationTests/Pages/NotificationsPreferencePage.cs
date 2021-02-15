using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace FlipkartAutomationTests.Pages
{
    class NotificationsPreferencePage
    {
        private ChromeDriver driver;

        public NotificationsPreferencePage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        IWebElement InAppNotifications => driver.FindElementByXPath("//li[contains(text(), 'In-App Notifications')]/parent::a");
        IWebElement RemindersCheckBox => driver.FindElementByXPath("//ul[@class='IvfuoP']/li[3]//label");
        IWebElement RemindersCheckBoxStatus => driver.FindElementByXPath("//ul[@class='IvfuoP']/li[3]//input");

        public void ClickOnInAppNotifications()
        {
            InAppNotifications.Click();
        }
        public void SelectRemindersCheckbox()
        {   
            Actions mouse = new Actions(driver);
            mouse.MoveToElement(RemindersCheckBox).Perform();

            RemindersCheckBox.Click();
        }
        public bool GetCheckBoxStatus()
        {
            return RemindersCheckBoxStatus.Selected;
        }
    }
}
