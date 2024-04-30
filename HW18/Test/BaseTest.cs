
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using HW18.Core;
using HW18.Pages;
using HW18.Steps;
using HW18.Utils;
using HW18.Waits;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Reflection;

namespace HW18.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public WaitsHelper? WaitsHelper { get; set; }
        public Actions Actions { get; set; }
        public IJavaScriptExecutor Js { get; set; }
        public UserStep UserStep { get; set; }
        public TestRailPage TestRailPage { get; set; }


        [AllureBefore("Clean up allure-results directory")]
        [OneTimeSetUp]
        public void OneTimeSetUp() 
        { 
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [AllureBefore("Set up driver")]
        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            LoginPage = new LoginPage(Driver);
            TestRailPage = new TestRailPage(Driver);
            Actions = new Actions(Driver);
            Js = (IJavaScriptExecutor)Driver;
            UserStep = new UserStep(Driver);
            WaitsHelper = new WaitsHelper(Driver);
        }
        

        [AllureAfter("Driver quite")]
        [TearDown]
        public void TearDown()
        {
            var allure = AllureLifecycle.Instance;
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var screenshotByte = screenshot.AsByteArray;
                AllureApi.AddAttachment("Screenshot", "image/png", screenshotByte);
            }

            try
            {
                var loggerPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "fileLogger.txt");
                AllureApi.AddAttachment("logger", "text/html", loggerPath);
            }
            catch
            {
                Console.WriteLine("couldnt load file");
            }
            Driver.Dispose();
            Driver.Quit();

        }


    }
}
