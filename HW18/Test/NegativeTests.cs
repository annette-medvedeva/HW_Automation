using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW18.Utils;
using NLog;
using NLog.LayoutRenderers;

namespace HW18.Test
{
    [TestFixture]
    public class NegativeTests : BaseTest
    {
        private Logger logger;
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoUrl);
            logger = LogManager.GetCurrentClassLogger();
        }

        [Test]
        public void LoginWithoutPassword()
        {
            logger.Info("Log Info");
            logger.Debug("Log Debug");
            logger.Error("Log Error");
            LoginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo);

            Assert.That(LoginPage.ErrorTitle().Text, Is.EqualTo("Epic sadface: Password is required"));
        }

        [Test]
        public void LoginWithoutUsernameAndPassword()
        {
            LoginPage.Login();
            Assert.That(LoginPage.ErrorTitle().Text, Is.EqualTo("Epic sadface: Username is required"));
        }
    }
}
