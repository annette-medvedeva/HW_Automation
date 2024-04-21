using HW18.Utils;
using HW18.Waits;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Pages
{
    public class CheckoutPage : BasePage
    {

        private readonly By productToAddId = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By checkoutButtonXPath = By.XPath("//button[@data-test='checkout']");
        private readonly By checkoutIconXPath = By.XPath("//div[@id='shopping_cart_container']/a");
        private readonly By firstNameXPath = By.XPath("//input[@data-test='firstName']");
        private readonly By lastNameXPath = By.XPath("//input[@data-test='lastName']");
        private readonly By postalCodeXPath = By.XPath("//input[@data-test='postalCode']");
        private readonly By submitButtonXPath = By.XPath("//input[@type='submit']");
        private readonly By inventoryTitleXPath = By.XPath("//div[text()='Sauce Labs Backpack']");
        private readonly By inventoryPriceXPath = By.XPath("//div[@class='item_pricebar']//div[text()='29.99']");
        private readonly By thankYouMessageXPath = By.XPath("//img[@alt='Pony Express']/following-sibling::h2");
        private readonly By checkoutCompleteMessageXPath = By.XPath("//div[@data-test='secondary-header']");
        private readonly By continueButtonXPath = By.XPath("//input[@type = 'submit']");
        private readonly By errorHeadingXPath = By.XPath("//button[contains(@class,'error-button')]/parent::h3");
        private readonly By continueInputXPath = By.XPath("//input[contains(@data-test,'continue')]");

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }

        public override string GetEndpoint()
        {
            throw new NotImplementedException();
        }

        public void AddProductToCart()
        {
            IWebElement addToCartButton = Driver.FindElement(productToAddId);
            addToCartButton.Click();
            IWebElement checkoutIcon = Driver.FindElement(checkoutIconXPath);
            checkoutIcon.Click();
        }

        public void ProceedToCheckout()
        {
            var checkoutButton = Driver.FindElement(checkoutButtonXPath);
            checkoutButton.Click();
        }

        public void FillCheckoutForm()
        {
            Driver.FindElement(firstNameXPath).SendKeys("test First Name");
            Driver.FindElement(lastNameXPath).SendKeys("test Last Name");
            Driver.FindElement(postalCodeXPath).SendKeys("456778");
            Driver.FindElement(submitButtonXPath).Click();
        }

        public void AssertCheckoutDetails()
        {
            string inventoryTitleText = Driver.FindElement(inventoryTitleXPath).Text;
            string inventoryPriceText = Driver.FindElement(inventoryPriceXPath).Text;
            Assert.Multiple(() =>
            {
                Assert.That(inventoryTitleText, Is.EqualTo("Sauce Labs Backpack"));
                Assert.That(inventoryPriceText, Is.EqualTo(Driver.FindElement(inventoryPriceXPath).Text));
            });
            Driver.FindElement(By.Id("finish")).Click();
            Assert.Multiple(() =>
            {
                Assert.That(Driver.FindElement(thankYouMessageXPath).Text, Is.EqualTo("Thank you for your order!"));
                Assert.That(Driver.FindElement(checkoutCompleteMessageXPath).Text, Is.EqualTo("Checkout: Complete!"));
            });
        }

        public void ProceedWithoutFillingCheckoutForm()
        {
            var waitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(10));
            var continueButton = waitsHelper.WaitForVisibility(continueButtonXPath);
            continueButton.Click();
        }

        public void AssertCheckoutErrors()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Driver.FindElement(errorHeadingXPath).Text, Is.EqualTo("Error: First Name is required"));
                Assert.That(Driver.FindElement(continueInputXPath).Displayed);
            });
        }
    }
}
