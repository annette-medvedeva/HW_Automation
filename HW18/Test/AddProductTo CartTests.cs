using HW18.Pages;
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
            var cartCount = CartPage.CartNumberSingle();
            Assert.AreEqual("1", cartCount);
        }

        [Test]
        public void AddSeveralProductsToCart_CartCount()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            var cartCount = CartPage.CartNumberMultiple();
            Assert.AreEqual("3", cartCount);
        }

        [Test]
        public void AddOneProduct_ToCart()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            var (inventoryTitleText, inventoryPriceText) = CartPage.AddProductToCart();

            Assert.Multiple(() =>
            {
                Assert.That(inventoryTitleText, Is.EqualTo("Sauce Labs Backpack"));
                Assert.That(inventoryPriceText, Is.EqualTo(Driver.FindElement(By.XPath("//div[text()='29.99']")).Text));
            });
        }

    }
}
