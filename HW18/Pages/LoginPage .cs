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
        private static readonly By UserNameFieldBy = By.XPath("//input[@data-test='username']");
        private static readonly By PasswordFieldBy = By.CssSelector("[placeholder='Password']");
        private static readonly By LoginButtonBy = By.CssSelector(".submit-button.btn_action");
        private static readonly By ErrorTitleBy = By.TagName("h3");

        public IWebElement UserNameField()
        {
            return Driver.FindElement(UserNameFieldBy);
        }

        public IWebElement PasswordField()
        {
            return Driver.FindElement(PasswordFieldBy);
        }

        public IWebElement LoginButton()
        {
            return Driver.FindElement(LoginButtonBy);
        }

        public IWebElement ErrorTitle()
        {
            return Driver.FindElement(ErrorTitleBy);
        }


        [AllureStep]
        public void Login(string userName = "", string password = "")
        {
            UserNameTestRailField().SendKeys(userName);
            PasswordTestRailField().SendKeys(password);
            LoginTestRailButton().Click();
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

        
    }
}
