using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace HW18.Waits
{
    public class WaitsHelper
    {
        private IWebDriver driver { get; set; }
        private WebDriverWait wait;
        private TimeSpan timeout { get; set; }

        public WaitsHelper(IWebDriver driver, TimeSpan timeout)
        {
            this.driver = driver;
            this.timeout = timeout;
            wait = new WebDriverWait(driver, this.timeout);
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
    }
}
