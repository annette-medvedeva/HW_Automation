using HW18.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    public class IFrameTests : BaseTest
    {

        [SetUp]
        public void OpenHerokuApp()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "iframe");
        }


        [Test]
        public void GetTextFromFrameTest()
        {

            Driver.SwitchTo().Frame(Driver.FindElement(By.Id("mce_0_ifr")));
            var textField = Driver.FindElement(By.XPath("//body[@id='tinymce']//p"));
            Assert.That(textField.Text, Is.EqualTo("Your content goes here."));
        }

        [Test]
        public void ExitFromFrameTest()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(By.Id("mce_0_ifr")));
            Driver.FindElement(By.XPath("//body[@id='tinymce']//p"));
            Driver.SwitchTo().DefaultContent();
            Driver.FindElement(By.XPath("//*[.='Elemental Selenium']")).Click();

        }
    }

}