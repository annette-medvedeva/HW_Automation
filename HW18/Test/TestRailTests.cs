using HW18.Models;
using HW18.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW18.Test
{
    [TestFixture]
    public class TestRailTests : BaseTest
    {
        private static string projectName;
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl("https://qac0402.testrail.io/");
        }

        [Test]
        public void PositiveLogin()
        {
            var admin = new UserModel()
            {
                UserName = "workandreystep@gmail.com",
                Password = "tmsQAC0401?"

                //UserName = Configurator.ReadConfiguration().UsernameTestRail,
                //Password = Configurator.ReadConfiguration().PasswordTestRail
            };

            Assert.That(UserStep.SuccessfulLogin(admin)
                .TestRailTitle().Displayed, Is.True);
        }

        [Test]
        public void CreateProject()
        {
            projectName = "AMedvedeva" + Guid.NewGuid();
            PositiveLogin();
            var project = new ProjectModel()
            {
                Name = projectName,
                Announcement = "Test",
                IsShowAnnouncement = true,
                ProjectType = "Use a single repository for all cases (recommended)",
                IsEnableTestCase = false
            };
            Assert.That(UserStep.SuccessfulCreateProject(project)
                .SucceessfulyAddProjectTitle().Displayed, Is.True);
            
        }

        [Test]
        public void DeleteProject()
        {
            
            Driver.Navigate().GoToUrl("https://qac0402.testrail.io/index.php?/admin/projects/overview");
            PositiveLogin();
            UserStep.RemoveProject(projectName);
            Assert.AreEqual("Successfully deleted the project.", TestRailPage.MessageDelete().Text);

        }
    }
}
