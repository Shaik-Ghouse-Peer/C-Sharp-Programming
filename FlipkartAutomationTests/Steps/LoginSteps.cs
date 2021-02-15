using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using FlipkartAutomationTests.Pages;
using FlipkartAutomationTests.Hooks;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace FlipkartAutomationTests.Steps
{
    [Binding]
    class LoginSteps
    {
        private ChromeDriver chromeDriver;
        private LoginPage loginPage;
        private ShoppingPage shoppingPage;

        public LoginSteps()
        {
            this.chromeDriver = Hooks1.chromeDriver;
            loginPage = new LoginPage(chromeDriver);
        }

        [Given(@"User Is On Flipkart Apllication")]
        public void GivenUserIsOnFlipkartApllication()
        {
            chromeDriver.Navigate().GoToUrl("https://flipkart.com");
        }

        [When(@"The User Enter (.*) and (.*)")]
        public void WhenTheUserEnterAnd(string username, string password)
        {
            loginPage.EnterUserNameAndPassword(username, password);
        }

        [When(@"Click on Login")]
        public void WhenClickOnLogin()
        {
            shoppingPage = loginPage.ClickOnLogin();
        }

        [Then(@"The User Should Navigate To '(.*)' Account")]
        public void ThenTheUserShouldNavigateToAccount(string userName)
        {
            Assert.AreEqual(shoppingPage.GetUserName(), userName);
        }
    }
}
