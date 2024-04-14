using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    public class WindowsTests : BaseTest
    {
        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
        }

        [Test]
        public void NewTabTest()
        {
            var generalWindowHandle = Driver.CurrentWindowHandle;

            var newTabButton = Driver.FindElement(By.Id("tabButton"));
            newTabButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            Assert.Multiple(() =>
            {
                Assert.That(Driver.WindowHandles.Count == 2);
                Assert.That(Driver.FindElement(By.Id("sampleHeading")).Text, Is.EqualTo("This is a sample page"));
            });

            Driver.SwitchTo().Window(generalWindowHandle);
            Assert.That(newTabButton.Displayed);
        }

        [Test]
        public void NewWindowTest()
        {
            var generalWindowHandle = Driver.CurrentWindowHandle;

            var newTabButton = Driver.FindElement(By.Id("windowButton"));
            newTabButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.Multiple(() =>
            {
                Assert.That(Driver.WindowHandles.Count == 2);
                Assert.That(Driver.FindElement(By.Id("sampleHeading")).Text, Is.EqualTo("This is a sample page"));
            });
            Driver.SwitchTo().Window(generalWindowHandle);
            Assert.That(newTabButton.Displayed);
        }

        [Test]
        public void MessageWindowTest()
        {
            var generalWindowHandle = Driver.CurrentWindowHandle;

            var newTabButton = Driver.FindElement(By.Id("messageWindowButton"));
            newTabButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.That(Driver.WindowHandles.Count == 2);
            Driver.Close();
            Driver.SwitchTo().Window(generalWindowHandle);
            Assert.That(newTabButton.Displayed);
        }
    }
}
