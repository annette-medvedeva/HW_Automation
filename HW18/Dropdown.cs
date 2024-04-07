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
        public void CheckDropdown()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            IWebElement dropdownList = driver.FindElement(By.XPath("//select[@id='dropdown']"));
            IList<IWebElement> options = dropdownList.FindElements(By.TagName("option"));
            Assert.AreEqual(2, options.Count, "Unexpected number of options in the dropdown.");
            Assert.AreEqual("Please select an option", options[0].Text, "Incorrect text for the first option.");
            Assert.AreEqual("Option 1", options[1].Text, "Incorrect text for the second option.");
            options[1].Click();
            Assert.IsTrue(options[1].Selected, "Option 1 should be selected after clicking.");
            options[0].Click();
            Assert.IsTrue(options[0].Selected, "Please select an option should be selected after clicking.");


        }
    }
}
