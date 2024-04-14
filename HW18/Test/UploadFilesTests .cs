using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    public class UploadFilesTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
        }

        [Test]
        public void UploadFile()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources",
                "ads.txt");
            Driver.FindElement(By.Id("file-upload")).SendKeys(filePath);
            Driver.FindElement(By.Id("file-submit")).Click();

            Assert.Multiple(() =>
            {
                Assert.That(Driver.FindElement(By.TagName("h3")).Text, Is.EqualTo("File Uploaded!"));
                Assert.That(Driver.FindElement(By.Id("uploaded-files")).Text, Is.EqualTo(Path.GetFileName(filePath)));
            });
        }
    }
}
