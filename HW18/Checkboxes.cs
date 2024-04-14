using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18
{
    internal class Checkboxes: Tests
    {

        [Test]
        public void CheckCheckbox()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
            IWebElement checkFirstCheckbox = driver.FindElement(By.XPath("//input[@type='checkbox'][1]"));
            IWebElement checkSecondCheckbox = driver.FindElement(By.XPath("//input[@type='checkbox'][2]"));
            checkFirstCheckbox.Click(); 
            checkSecondCheckbox.Click();
            Assert.IsTrue(checkFirstCheckbox.Selected);
            Assert.IsFalse(checkSecondCheckbox.Selected);
            checkFirstCheckbox.Click(); 
            checkSecondCheckbox.Click(); 
            Assert.IsFalse(checkFirstCheckbox.Selected);
            Assert.IsTrue(checkSecondCheckbox.Selected);
        }
    }
}
