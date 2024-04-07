using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18
{
    internal class AddRemoveElement: Tests
    {
       
        [Test]
        public void AddElement()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            IWebElement addElementButton = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            addElementButton.Click();
            addElementButton.Click(); Thread.Sleep(3000);
            ReadOnlyCollection<IWebElement> deleteElementButtons = driver.FindElements(By.XPath("//button[text()='Delete']"));
            foreach (var button in deleteElementButtons)
                Assert.IsTrue(button.Displayed);
        }

        [Test]
        public void RemoveElement()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            IWebElement addElementButton = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            addElementButton.Click(); Thread.Sleep(2000);
            ReadOnlyCollection<IWebElement> deleteElementButtons = driver.FindElements(By.XPath("//button[text()='Delete']"));
            Assert.IsTrue(deleteElementButtons.Count > 0);
            IWebElement deleteElementButton = deleteElementButtons[0];
            deleteElementButton.Click(); Thread.Sleep(2000);
            deleteElementButtons = driver.FindElements(By.XPath("//button[text()='Delete']"));
            Assert.IsFalse(deleteElementButtons.Count > 0);

        }
    }
}
