﻿using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using HW18.Utils;
using HW18.Waits;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{  
    [TestFixture]
    [AllureParentSuite("Checkout tests")]
    [AllureEpic("Web")]
    [AllureFeature("Checkout feature")]
    public class CheckoutTests : BaseTest
    {
        private Logger logger;
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
            logger = LogManager.GetCurrentClassLogger();
        }
             
        [AllureOwner("AMedvedeva")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("BUG-05")]
        [Test]
        public void PerformPositiveCheckout()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            CheckoutPage.AddProductToCart();
            CheckoutPage.ProceedToCheckout();
            CheckoutPage.FillCheckoutForm();
            CheckoutPage.AssertCheckoutDetails();
        }
        
        
        [AllureOwner("AMedvedeva")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStep("Negative Checkout")]
        [AllureIssue("BUG-06")]
        [Test]
        public void NegativeCheckoutInformation()
        {
            logger.Info("Log info");
            logger.Debug("Log debug");
            logger.Error("Log error");
            logger.Fatal("Log fatal");
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            CheckoutPage.AddProductToCart();
            CheckoutPage.ProceedToCheckout();
           // CheckoutPage.ProceedWithoutFillingCheckoutForm();
            CheckoutPage.AssertCheckoutErrors();
        }
    }  
}
