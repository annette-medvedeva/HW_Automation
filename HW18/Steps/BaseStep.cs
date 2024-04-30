using HW18.Waits;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Steps
{
    public class BaseStep
    {
        protected IWebDriver Driver;
        private WaitsHelper waitsHelper;

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
            waitsHelper = new WaitsHelper(driver);
        }
    }
}
