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
        public WaitsHelper? WaitsHelper { get; set; }
        public Actions Actions { get; set; }
        public IJavaScriptExecutor Js { get; set; }

        private AllureLifecycle allure;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        { 
            allure = AllureLifecycle.Instance;  
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            LoginPage = new LoginPage(Driver);
            ProductsPage = new ProductsPage(Driver);
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
            Actions = new Actions(Driver);
            Js = (IJavaScriptExecutor)Driver;
        }

        [TearDown]
        public void TearDown()
        {

            Driver.Dispose();
        }

        //[OneTimeTearDown]
        //public void OneTimeTearDown()
        //{
        //    if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        //    {
        //    Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
        //        byte[] bytes = screenshot.AsByteArray;
        //        allure.AddAttachment("Screenshot", "image/png", bytes);
        //    }
        //    Browser.Instance.CloseBrowser();

            
        //}

        
    }
}
