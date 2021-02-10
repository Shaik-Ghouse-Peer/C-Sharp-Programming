using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TestFlipkartApplication.Pages;
using TestFlipkartApplication.Utils;

namespace TestFlipkartApplication.Tests
{
    [TestFixture]
    class TestShoppingCart
    {
        private ChromeDriver chromeDriver;

        private LoginPage loginPage;
        private ShoppingPage shoppingPage;

        private WebDriverHelper webDriverHelper;

        private int expectedProductPrice;
        private int expectedTotalProctsCount;
        private int expectedTotalProductsCost;

        ExtentReports reportGenerator = new ExtentReports();
        ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Constants.REPORTING_DIRECTORY);
        ExtentTest logger;

        [OneTimeSetUp]
        public void TestEnvironmentSetup()
        {
            chromeDriver = new WebDriver(Constants.FLIPKART_URL).Driver();

            loginPage = new LoginPage(chromeDriver);
            shoppingPage = new ShoppingPage(chromeDriver);

            webDriverHelper = new WebDriverHelper(chromeDriver);

            expectedProductPrice = 0;
            expectedTotalProctsCount = 0;
            expectedTotalProductsCost = 0;

            reportGenerator.AddSystemInfo("OS", "Windows10");
            reportGenerator.AddSystemInfo("Browser", "Chrome");
            reportGenerator.AddSystemInfo("Test Case Runner", "Shaik Ghouse Peer");

            reportGenerator.AttachReporter(htmlReporter);
        }

        [Test]
        public void ValidateIndividualProductPrice()
        {
            this.logger = reportGenerator.CreateTest("ValidateIndividualProductPrice");

            loginPage.ClosePage();

            shoppingPage.SearchProduct(Constants.PRODUCT_CATEGORY);

            List<IWebElement> totalProducts = shoppingPage.GetProductsUnderPriceRange(Constants.PRICE_RANGE);

            int actualProductPrice;
            foreach (IWebElement product in totalProducts)
            {
                if (shoppingPage.AddProductToCart(product) == true)
                {
                    actualProductPrice = shoppingPage.GetCostOfTotalProducts() - shoppingPage.GetProductPrice();

                    Assert.AreEqual(expectedProductPrice, actualProductPrice);

                    expectedProductPrice = shoppingPage.GetCostOfTotalProducts();
                    expectedTotalProductsCost += shoppingPage.GetProductPrice();
                    expectedTotalProctsCount += 1;
                }
                webDriverHelper.CloseNewTab();
            }
        }

        [Test]
        public void ValidateProductsCount()
        {
            this.logger = reportGenerator.CreateTest("ValidateProductsCount");

            Assert.AreEqual(shoppingPage.GetTotalNumberOfProductsInCart(), $"My Cart ({expectedTotalProctsCount})");
        }

        [Test]
        public void ValidateTotalProductsPrice()
        {
            this.logger = reportGenerator.CreateTest("ValidateTotalProductsPrice");

            Assert.AreEqual(expectedTotalProductsCost, shoppingPage.GetCostOfTotalProducts());
        }

        [TearDown]
        public void LogTestResult()
        {
            string testName = TestContext.CurrentContext.Test.Name;

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = chromeDriver.GetScreenshot();
                screenshot.SaveAsFile($"{Constants.SCREENSHOTS_DIRECTORY}{testName}.png");

                logger.Fail(TestContext.CurrentContext.Result.Message);
            }
            else
            {
                if (File.Exists($"{Constants.SCREENSHOTS_DIRECTORY}{testName}.png"))
                {
                    File.Delete($"{Constants.SCREENSHOTS_DIRECTORY}{testName}.png");
                }
                logger.Pass($"Test {testName} Passed");
            }
        }

        [OneTimeTearDown]
        public void ReleaseResources()
        {
            reportGenerator.Flush();
            chromeDriver.Quit();
        }
    }
}
