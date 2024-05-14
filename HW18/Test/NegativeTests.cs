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
    public class NegativeTests : BaseTest
    {
        [SetUp]
        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
        }

        [Test]
        [Category("Negative")]
        public void LoginWithoutPassword()
        {
            var userWithoutPass = new UserModel()
            {
                UserName = Configurator.ReadConfiguration().UserNameSauceDemo
            };

            Assert.That(
                UserStep.UnsuccesfulLoginWithoutPassword(userWithoutPass)
                    .ErrorTitle()
                    .Text, Is.EqualTo("Epic sadface: Password is required"));
        }

        [Test]
        [Category("Negative")]
        public void LoginWithoutUsernameAndPassword()
        {
            Assert.That(UserStep
                .UnsuccesfulLoginWithoutUserNameAndPassword()
                .ErrorTitle()
                .Text, Is.EqualTo("Epic sadface: Username is required"));
        }
    }
}
