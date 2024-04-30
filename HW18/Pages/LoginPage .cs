using Allure.NUnit.Attributes;
using HW18.Element;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Pages
{
    public class LoginPage : BasePage
    {

        private static readonly By UserNameTestRailFieldBy = By.XPath("//input[@data-testid='loginIdName']");
        private static readonly By PasswordTestRailFieldBy = By.XPath("//input[@data-testid='loginPasswordFormDialog']");
        private static readonly By LoginTestRailButtonBy = By.XPath("//button[@id='button_primary']");
        private string _endPoint = "";


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        [AllureStep]
        public void Login(string userName = "", string password = "")
        {
            UserNameTestRailField().SendKeys(userName);
            PasswordTestRailField().SendKeys(password);
            LoginTestRailButton().Click();
        }
        protected override bool EvaluateLoadedStatus()
        {
            return LoginTestRailButton().Displayed;
        }

        //TestRail
        public IWebElement UserNameTestRailField()
        {
            return Driver.FindElement(UserNameTestRailFieldBy);
        }

        public IWebElement PasswordTestRailField()
        {
            return Driver.FindElement(PasswordTestRailFieldBy);
        }

        public IWebElement LoginTestRailButton()
        {
            return Driver.FindElement(LoginTestRailButtonBy);
        }

        protected override void ExecuteLoad()
        {
            throw new NotImplementedException();
        }
    }
}
