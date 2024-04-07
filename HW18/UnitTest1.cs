using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;

namespace HW18
{
    public class Tests
    {
        public static IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Cookies.DeleteAllCookies();
        }

        

        [TearDown]
        public void TearDown() 
        { 
            driver.Dispose();
            driver.Quit();
        }
    }
}