using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace HW18.Core
{
    public class DriverFactory
    {
        public IWebDriver GetChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--incognito");

            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(chromeOptions);
        }

        public IWebDriver GetFireFoxDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--incognito");

            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver(firefoxOptions);
        }
    }
}
