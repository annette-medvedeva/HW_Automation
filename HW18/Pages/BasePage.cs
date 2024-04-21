﻿using HW18.Utils;
using OpenQA.Selenium;
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


        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public abstract string GetEndpoint();

        public void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl + GetEndpoint());
        }
    }
}