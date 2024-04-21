using HW18.Utils;
using HW18.Waits;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    public class CheckoutTests : BaseTest
    {

        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
        }

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

        [Test]
        public void NegativeCheckoutInformation()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
        Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            CheckoutPage.AddProductToCart();
            CheckoutPage.ProceedToCheckout();
            CheckoutPage.ProceedWithoutFillingCheckoutForm();
            CheckoutPage.AssertCheckoutErrors();
        }
    }  
}
