using HW18.Test;
using HW18.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Pages
{
    public class JsExecutorTests : BaseTest
    {
        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "checkboxes");
        }


        [Test]
        public void ClickCheckboxWithJs()
        {
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;
            var checkboxes = Driver.FindElements(By.CssSelector("[type='checkbox']"));
            javaScriptExecutor.ExecuteScript("arguments[0].click();", checkboxes[0]);

            javaScriptExecutor.ExecuteScript("arguments[0].click();", checkboxes[0]);
        }

        [Test]
        public void ScrollToJs()
        {
            Driver.Navigate().GoToUrl("https://teachmeskills.by/");
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;
            var frontendLink =
                Driver.FindElements(By.XPath("(//a[@href='/kursy/frontend-html-css-javascript-online'])[1]"));
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", frontendLink);
        }
    }
}
