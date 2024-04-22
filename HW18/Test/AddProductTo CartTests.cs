
using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using HW18.Pages;
using HW18.Utils;
using OpenQA.Selenium;


namespace HW18.Test
{
    [AllureParentSuite("Cart tests")]
    public class AddProductTo_CartTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
        }

        [AllureEpic("Web")]
        [AllureFeature("Cart")]
        [AllureStory("Frontend fix")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureDescription("Check Counter of the Cart")]
        [AllureOwner("AMedvedeva")]
        [Test]
        public void AddOneProductToCart_CartCount()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            var cartCount = CartPage.CartNumberSingle();
            Assert.AreEqual("1", cartCount);
        }

        [AllureStep("Login and Open Products Page")]
        [AllureFeature("Cart")]
        [AllureStory("Frontend fix")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AMedvedeva")]
        [AllureDescription("Check Miltiple Counter of the Cart")]
        [Test]
        public void AddSeveralProductsToCart_CartCount()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
            Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            var cartCount = CartPage.CartNumberMultiple();
            Assert.AreEqual("3", cartCount);
        }



        [AllureStep("Login and Add Products To Cart")]
        [AllureFeature("Cart")]
        [AllureStory("Frontend fix")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AMedvedeva")]
        [AllureDescription("Check Miltiple Counter of the Cart")]
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
