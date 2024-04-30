using HW18.Models;
using HW18.Pages;
using HW18.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Steps
{
    public class UserStep : BaseStep
    {
        
        private LoginPage _loginPage;
        private TestRailPage _testRailPage;
        

        public UserStep(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            _loginPage = new LoginPage(driver);
            _testRailPage = new TestRailPage(driver);
        }

        public TestRailPage SuccessfulLogin(UserModel userModel)
        {
            Login(userModel);
            return new TestRailPage(Driver);
        }
        private void Login(UserModel userModel = null)
        {
            if (userModel.UserName == null)
                _loginPage.UserNameTestRailField().SendKeys("");
            else
                _loginPage.UserNameTestRailField().SendKeys(userModel.UserName);


            if (userModel.Password == null)
                _loginPage.PasswordTestRailField().SendKeys("");
            else
                _loginPage.PasswordTestRailField().SendKeys(userModel.Password);

            _loginPage.LoginTestRailButton().Click();
        }

        public TestRailPage SuccessfulCreateProject(ProjectModel projectModel)
        {
            CreateProject(projectModel);
            return new TestRailPage(Driver);
        }

        private void CreateProject (ProjectModel projectModel=null)
        {
            _testRailPage.AddProject().Click();
            _testRailPage.NameProject().SendKeys(projectModel.Name);
            _testRailPage.AnnouncementProject().SendKeys(projectModel.Announcement);
            _testRailPage.IsShowAnnouncement().Click();
            _testRailPage.ProjectTypeRadio().SendKeys(projectModel.ProjectType);
            _testRailPage.IsEnableTestCase().Click();
            _testRailPage.AddButton().Click();
        }

        public void RemoveProject(string projectName)
        {
            _testRailPage.DeleteButton(projectName).Click();
            _testRailPage.ConfirmDeleteProject();  
        }

        
    }
}
