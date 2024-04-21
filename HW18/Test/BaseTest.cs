using Allure.Net.Commons;
using Allure.NUnit;
using HW18.Core;
using HW18.Pages;
using HW18.Utils;
using HW18.Waits;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public ProductsPage ProductsPage { get; set; }
        public CartPage CartPage { get; set; }
        public WaitsHelper? WaitsHelper { get; set; }
        public  CheckoutPage CheckoutPage { get; set; }
        public Actions Actions { get; set; }
        public IJavaScriptExecutor Js { get; set; }



        private AllureLifecycle allure;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        { 
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            LoginPage = new LoginPage(Driver);
            ProductsPage = new ProductsPage(Driver);
            CartPage = new CartPage(Driver);
            CheckoutPage = new CheckoutPage(Driver);
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
            Actions = new Actions(Driver);
            Js = (IJavaScriptExecutor)Driver;
        }

        [TearDown]
        public void TearDown()
        {

            Driver.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] bytes = screenshot.AsByteArray;
                AllureApi.AddAttachment("Screenshot", "image/png", bytes);
            }
            
        }


    }
}
