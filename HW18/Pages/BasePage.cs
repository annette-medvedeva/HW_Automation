using HW18.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; set; }


        protected BasePage(IWebDriver driver, bool openPageByUrl = false)
        {
            Driver = driver;
            
        }


    }
}
