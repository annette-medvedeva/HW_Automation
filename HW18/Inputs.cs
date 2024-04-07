using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18
{
    internal class Inputs : Tests
    {
        [Test]
        public void CheckInputs()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");
            IWebElement input = driver.FindElement(By.TagName("input"));
            input.SendKeys("12345");
            Assert.AreEqual("12345", input.GetAttribute("value"), "Incorrect numeric value entered.");
            input.Clear();
            input.SendKeys("abcde");
            Assert.IsTrue(string.IsNullOrEmpty(input.GetAttribute("value")), "Input field should be empty.");
            input.SendKeys(Keys.ArrowUp);
            Assert.AreEqual("1", input.GetAttribute("value"), "Incorrect value after pressing ARROW_UP.");
            input.SendKeys(Keys.ArrowDown);
            Assert.AreEqual("0", input.GetAttribute("value"), "Incorrect value after pressing ARROW_DOWN.");
        }
        }
    }
