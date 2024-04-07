using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18
{
    internal class DataTables : Tests
    {
        [Test]
        public void DataTableSort()
        {
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/tables");
            string[][] expectedValues = new string[][]
            {
        new string[] { "Smith", "John", "jsmith@gmail.com", "$50.00", "http://www.jsmith.com" },
        new string[] { "Bach", "Frank", "fbach@yahoo.com", "$51.00", "http://www.frank.com" }
            };

            for (int i = 0; i < expectedValues.Length; i++)
            {
                for (int j = 0; j < expectedValues[i].Length; j++)
                {
                    string xpath = $"//table//tr[{i+1}]//td[{j + 1}]";
                    IWebElement cell = driver.FindElement(By.XPath(xpath));
                    string cellText = cell.Text;
                    Assert.AreEqual(expectedValues[i][j], cellText, $"Содержимое ячейки ({i + 1}, {j + 1}) не соответствует ожидаемому.");
                }
            }
        }
    }
}
