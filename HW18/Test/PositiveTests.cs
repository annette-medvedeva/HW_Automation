using HW18.Models;
using HW18.Steps;
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
        [Category("Positive")]
        public void PositiveLogin()
        {
            var admin = new UserModel()
            {
                UserName = Configurator.ReadConfiguration().UserNameSauceDemo,
                Password = Configurator.ReadConfiguration().PasswordSauceDemo
            };

            Assert.That(UserStep.SuccessfulLogin(admin)
                .ProductsTitle().Displayed, Is.True);
        }


        [Test]
        [Category("Positive")]
        public void NavigateToProductsTest()
        {
            var admin = new UserModel()
            {
                UserName = Configurator.ReadConfiguration().UserNameSauceDemo,
                Password = Configurator.ReadConfiguration().PasswordSauceDemo
            };

            UserStep.SuccessfulLogin(admin).CartIcon().Click();

            NavigationStep.NavigateToProductsPage();
        }
    }
}
