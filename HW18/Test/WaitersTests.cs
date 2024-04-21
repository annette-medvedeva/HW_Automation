using HW18.Utils;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    public class WaitersTests : BaseTest
    {
        private Logger logger;

        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "dynamic_loading/1");
            logger = LogManager.GetCurrentClassLogger();
        }

        [Test]
        public void WaitForHelloWorld()
        {

            var button = Driver.FindElement(By.XPath("//*[.='Start']"));
            button.Click();
            Assert.That(button.Displayed, Is.False);
            var loading = Driver.FindElement(By.Id("loading"));
            Assert.That(loading.Displayed, Is.True);
            Assert.That(loading.Displayed, Is.False);
            Assert.That(Driver.FindElement(By.Id("finish")).Displayed);
        }

        [Test]
        public void ExplicitWaitForHelloWorld()
        {
            logger.Info("Log info");
            logger.Debug("Log debug");
            logger.Error("Log error");
            logger.Fatal("Log fatal");
            var button = Driver.FindElement(By.XPath("//*[.='Start']"));
            button.Click();
            WaitsHelper.WaitForElementInvisible(button);
            Assert.That(button.Displayed, Is.False);
            var loading = WaitsHelper.WaitForVisibility(By.Id("loading"));
            Assert.That(loading.Displayed, Is.True);
            WaitsHelper.WaitForElementInvisible(loading);
            Assert.That(loading.Displayed, Is.False);
            Assert.That(Driver.FindElement(By.Id("finish")).Displayed);
        }
    }
}
