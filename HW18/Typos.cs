using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18
{
    internal class Typos : Tests
    {
        [Test]
        public void TestTypos() 
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/typos");
            IReadOnlyCollection<IWebElement> paragraphs = driver.FindElements(By.TagName("p"));
            string expectedText = "Sometimes you'll see a typo, other times you won't.";
            foreach (IWebElement paragraph in paragraphs)
            {
                if (paragraph.Text.Equals(expectedText))
                {
                    Console.WriteLine("The paragraph text matches the expected text: " + expectedText);
                    Assert.Pass();
                }
            }
            Console.WriteLine("The expected text was not found in any paragraph.");
            Assert.Fail();
        }
    }
}
