using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using HW18.Utils;

namespace HW18.Waits
{
    public class WaitsHelper
    {
        private IWebDriver driver { get; set; }
        private WebDriverWait wait;
        private TimeSpan timeout { get; set; }

        public WaitsHelper(IWebDriver driver)
        {
            this.driver = driver;
            timeout = TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut);
            wait = new WebDriverWait(driver, timeout);
        }

        public IWebElement WaitForVisibility(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        
        public bool WaitForElementInvisible(By locator)
        {
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        public bool WaitForElementInvisible(IWebElement element)
        {
            try
            {
                wait.Until(d => !element.Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Element visible after {timeout} seconds");
            }

        }
        public IWebElement WaitForExist(By locator)
        {
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public IReadOnlyCollection<IWebElement> WaitForElementsPresence(By locator)
        {
            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }
    }
}
