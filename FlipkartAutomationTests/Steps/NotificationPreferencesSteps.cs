using System;
using TechTalk.SpecFlow;
using FlipkartAutomationTests.Pages;
using FlipkartAutomationTests.Utils;
using FlipkartAutomationTests.Hooks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace FlipkartAutomationTests.Steps
{
    [Binding]
    public class NotificationPreferencesSteps
    {
        private ChromeDriver chromeDriver;

        private LoginPage loginPage;
        private ShoppingPage shoppingPage;
        private NotificationsPreferencePage notificationsPreference;

        private bool expectedChecboxStatus;

        public NotificationPreferencesSteps()
        {
            this.chromeDriver = Hooks1.chromeDriver;
            loginPage = new LoginPage(chromeDriver);
        }

        [Given(@"User Is On Flipkart Application")]
        public void GivenUserIsOnFlipkartApplication()
        {
            chromeDriver.Navigate().GoToUrl("https://flipkart.com");
        }

        [Given(@"Logged In With Credentials '(.*)' and '(.*)'")]
        public void GivenLoggedInWithCredentialsAnd(string username, string password)
        {
            loginPage.EnterUserNameAndPassword(username, password);
            shoppingPage = loginPage.ClickOnLogin();
        }


        [When(@"User Selected Notification Preferences")]
        public void WhenUserSelectedNotificationPreferences()
        {
            notificationsPreference = shoppingPage.NavigateToNotifationsPreference();
        }
        
        [When(@"User Selected In-App Notifications Settings")]
        public void WhenUserSelectedIn_AppNotificationsSettings()
        {
            notificationsPreference.ClickOnInAppNotifications();   
        }
        
        [When(@"User Checked Remider Checkbox")]
        public void WhenUserCheckedRemiderCheckbox()
        {
            expectedChecboxStatus = notificationsPreference.GetCheckBoxStatus();

            notificationsPreference.SelectRemindersCheckbox();
        }
        
        [Then(@"the Reminder Checkbox State Should be Altered")]
        public void ThenTheReminderCheckboxStateShouldBeAltered()
        { 
            Assert.AreNotEqual(expectedChecboxStatus, notificationsPreference.GetCheckBoxStatus());
        }
    }
}