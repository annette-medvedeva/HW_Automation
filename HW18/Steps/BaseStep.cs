
using OpenQA.Selenium;


namespace HW18.Steps
{
    public class BaseStep
    {
        protected IWebDriver _driver;

        public BaseStep(IWebDriver driver)
        {

            _driver = driver;
        }
    }
}
