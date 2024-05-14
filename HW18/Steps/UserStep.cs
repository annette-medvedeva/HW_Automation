using HW18.Models;
using HW18.Pages;
using OpenQA.Selenium;


namespace HW18.Steps
{
    public class UserStep : BaseStep
    {
        private LoginPage _loginPage;

        public UserStep(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(driver);
        }

        public ProductsPage SuccessfulLogin(UserModel userModel)
        {
            Login(userModel);
            return new ProductsPage(_driver);
        }

        public LoginPage UnsuccesfulLoginWithoutPassword(UserModel userModel)
        {
            Login(userModel);
            return _loginPage;
        }

        public LoginPage UnsuccesfulLoginWithoutUserNameAndPassword()
        {
            Login();
            return _loginPage;
        }

        private void Login(UserModel userModel = null)
        {
            if (userModel.UserName == null)
                _loginPage.UserNameField().SendKeys("");
            else
                _loginPage.UserNameField().SendKeys(userModel.UserName);


            if (userModel.Password == null)
                _loginPage.PasswordField().SendKeys("");
            else
                _loginPage.PasswordField().SendKeys(userModel.Password);

            _loginPage.LoginButton().Click();
        }
    }
}
