using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using HW18.Core;
using HW18.Pages;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;


namespace HW18.Steps
{
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [AllureNUnit]
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public UserStep UserStep { get; set; }

        public NavigationStep NavigationStep { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            UserStep = new UserStep(Driver);
            NavigationStep = new NavigationStep(Driver);
        }

        [TearDown]
        [AllureAfter("Driver quite")]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshotByte = ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray;
                AllureApi.AddAttachment("screenshot", "image/png", screenshotByte);
            }


            Driver.Dispose();
        }
    }
}