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
        public void PositiveCheckout() 
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            IWebElement addToCartButton = Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();
            string inventoryTitleText = Driver.FindElement(By.XPath("//div[text()='Sauce Labs Backpack']")).Text;
            string inventoryPriceText = Driver.FindElement(By.XPath("//div[@class='pricebar']//div[text()='29.99']")).Text;
            Driver.FindElement(By.XPath("//span[@data-test='shopping-cart-badge']")).Click();
            var checkoutButton = Driver.FindElement(By.XPath("//button[@data-test='checkout']"));
            var chekoutLoading= WaitsHelper.WaitForVisibility(By.XPath("//button[@data-test='checkout']"));
            checkoutButton.Click();
            Driver.FindElement(By.XPath("//input[@data-test = 'firstName']")).SendKeys("test First Name");
            Driver.FindElement(By.XPath("//input[@data-test = 'lastName']")).SendKeys("test Last Name");
            Driver.FindElement(By.XPath("//input[@data-test = 'postalCode']")).SendKeys("456778");
            Driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();

            Assert.Multiple(() =>
            {
                Assert.That(inventoryTitleText, Is.EqualTo("Sauce Labs Backpack"));
                Assert.That(inventoryPriceText, Is.EqualTo(Driver.FindElement(By.XPath("//div[text()='29.99']")).Text));
            });
            Driver.FindElement(By.XPath("//button[@id= 'finish']")).Click();
            Assert.Multiple(() =>
            {
                Assert.That(Driver.FindElement(By.XPath("//img[@alt='Pony Express']/following-sibling::h2")).Text, Is.EqualTo("Thank you for your order!"));
                Assert.That(Driver.FindElement(By.XPath("//div[@data-test='secondary-header']")).Text, Is.EqualTo("Checkout: Complete!"));
            });
        }

        [Test]
        public void NegativeCheckoutInformation()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            IWebElement addToCartButton = Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();
            string inventoryTitleText = Driver.FindElement(By.XPath("//div[text()='Sauce Labs Backpack']")).Text;
            string inventoryPriceText = Driver.FindElement(By.XPath("//div[@class='pricebar']//div[text()='29.99']")).Text;
            Driver.FindElement(By.XPath("//span[@data-test='shopping-cart-badge']")).Click();
            var checkoutButton = Driver.FindElement(By.XPath("//button[@data-test='checkout']"));
            
            var chekoutLoading = WaitsHelper.WaitForVisibility(By.XPath("//button[@data-test='checkout']"));
            checkoutButton.Click();

            var continueButton = WaitsHelper.WaitForVisibility(By.XPath("//input[@type = 'submit']"));
            continueButton.Click();

            Assert.Multiple(() =>
            {
                Assert.That(Driver.FindElement(By.XPath("//button[contains(@class,'error-button')]/parent::h3")).Text, Is.EqualTo("Error: First Name is required"));
                Assert.That(Driver.FindElement(By.XPath("//input[contains(@data-test,'continue')]")).Displayed);
            });
        }
    }
}
