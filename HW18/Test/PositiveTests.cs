using HW18.Pages;
using HW18.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Test
{
    [TestFixture]
    public class PositiveTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
        }

        [Test]
        public void PositiveLogin()
        {
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
                Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
            Assert.That(ProductsPage.ProductsTitle().Displayed, Is.True);
        }
    }
}
