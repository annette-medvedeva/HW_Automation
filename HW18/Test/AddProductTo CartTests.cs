using HW18.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    public class AddProductTo_CartTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
        }

        [Test]
        public void AddOneProductToCart_CartCount()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            IWebElement addToCartButton = Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();
            IWebElement cartNumber = Driver.FindElement(By.XPath("//span[@data-test='shopping-cart-badge']"));
            string cartNumberText = cartNumber.Text;
            Assert.AreEqual("1", cartNumberText);
        }

        [Test]
        public void AddSeveralProductsToCart_CartCount()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            IWebElement addFirstProductToCartButton = Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addFirstProductToCartButton.Click();
            IWebElement addSecondProductToCartButton = Driver.FindElement(By.XPath("//button[@data-test='add-to-cart-sauce-labs-bike-light']"));
            addSecondProductToCartButton.Click();
            IWebElement addThirdProductToCartButton = Driver.FindElement(By.XPath("(//div[@class='inventory_item_price']/following-sibling::button)[3]"));
            addThirdProductToCartButton.Click();
            IWebElement cartNumber = Driver.FindElement(By.XPath("//span[@data-test='shopping-cart-badge']"));
            string cartNumberText = cartNumber.Text;
            Assert.AreEqual("3", cartNumberText);
        }

        [Test]
        public void AddOneProduct_ToCart()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            IWebElement addToCartButton = Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();
            string inventoryTitleText= Driver.FindElement(By.XPath("//div[text()='Sauce Labs Backpack']")).Text;
            string inventoryPriceText = Driver.FindElement(By.XPath("//div[@class='pricebar']//div[text()='29.99']")).Text;
;            IWebElement cartNumber = Driver.FindElement(By.XPath("//span[@data-test='shopping-cart-badge']"));
            cartNumber.Click();

            Assert.Multiple(() =>
            {
                Assert.That(inventoryTitleText, Is.EqualTo("Sauce Labs Backpack"));
                Assert.That(inventoryPriceText, Is.EqualTo(Driver.FindElement(By.XPath("//div[text()='29.99']")).Text));
            });
            

        }
    }
}
