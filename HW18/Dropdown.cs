using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18
{
    internal class Dropdown: Tests
    {
        [Test]
        public void CheckDropdownOptionCount()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            IWebElement dropdownList = driver.FindElement(By.XPath("//select[@id='dropdown']"));
            IList<IWebElement> options = dropdownList.FindElements(By.TagName("option"));
            Assert.AreEqual(3, options.Count, "Unexpected number of options in the dropdown.");
        }

        [Test]
        public void CheckFirstOptionText()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            IWebElement dropdownList = driver.FindElement(By.XPath("//select[@id='dropdown']"));
            IWebElement firstOption = dropdownList.FindElement(By.XPath(".//option[1]"));
            Assert.AreEqual("Please select an option", firstOption.Text, "Incorrect text for the first option.");
        }

        [Test]
        public void CheckSecondOptionText()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            IWebElement dropdownList = driver.FindElement(By.XPath("//select[@id='dropdown']"));
            IWebElement secondOption = dropdownList.FindElement(By.XPath(".//option[2]"));
            Assert.AreEqual("Option 1", secondOption.Text, "Incorrect text for the second option.");
        }

        [Test]
        public void SelectSecondOption()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            IWebElement dropdownList = driver.FindElement(By.XPath("//select[@id='dropdown']"));
            IList<IWebElement> options = dropdownList.FindElements(By.TagName("option"));
            options[1].Click();
            Assert.IsTrue(options[1].Selected, "Option 1 should be selected after clicking.");
        }

        [Test]
        public void SelectFirstOption()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            IWebElement dropdownList = driver.FindElement(By.XPath("//select[@id='dropdown']"));
            IList<IWebElement> options = dropdownList.FindElements(By.TagName("option"));
            options[0].Click();
            Assert.IsTrue(options[0].Selected, "Please select an option should be selected after clicking.");
        }

    }
}
