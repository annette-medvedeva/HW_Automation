using HW18.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    [TestFixture]
    public class AlertTests : BaseTest
    {
        [SetUp]
        public void OpenHerokuApp()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "javascript_alerts");
        }

        [Test]
        public void ClickForJsAlert()
        {
            var clickForJsAlertButton = Driver.FindElement(By.XPath("//*[@onclick='jsAlert()']"));
            clickForJsAlertButton.Click();

            var alert = Driver.SwitchTo().Alert();

            Assert.That(alert.Text.Trim(), Is.EqualTo("I am a JS Alert"));
        }

        [Test]
        public void AcceptAlert()
        {
            var clickForJsConfirm = Driver.FindElement(By.XPath("//*[@onclick='jsConfirm()']"));
            clickForJsConfirm.Click();

            var alert = Driver.SwitchTo().Alert();
            alert.Accept();
            var resultText = Driver.FindElement(By.Id("result")).Text.Trim();
            Assert.That(resultText, Is.EqualTo("You clicked: Ok"));
        }

        [Test]
        public void DeclineAlert()
        {
            var clickForJsConfirm = Driver.FindElement(By.XPath("//*[@onclick='jsConfirm()']"));
            clickForJsConfirm.Click();

            var alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
            var resultText = Driver.FindElement(By.Id("result")).Text.Trim();
            Assert.That(resultText, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        public void EnterTextToAlert()
        {
            var clickForJsPrompt = Driver.FindElement(By.XPath("//*[@onclick='jsPrompt()']"));
            clickForJsPrompt.Click();

            var alert = Driver.SwitchTo().Alert();
            alert.SendKeys("test");
            alert.Accept();
            var resultText = Driver.FindElement(By.Id("result")).Text.Trim();
            Assert.That(resultText, Is.EqualTo("You entered: test"));
        }
    }
}
