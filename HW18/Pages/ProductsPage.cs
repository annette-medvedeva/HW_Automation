using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Pages
{
    public class ProductsPage : BasePage
    {
        private static readonly By ProductsTitleBy = By.XPath("//*[.='Products']");
        private static readonly By CartIconBy = By.CssSelector("[data-test='shopping-cart-link']");
        private readonly string _endPoint = "inventory.html";

        public ProductsPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
        }

        public IWebElement ProductsTitle()
        {
            return Driver.FindElement(ProductsTitleBy);
        }

        public IWebElement CartIcon()
        {
            return Driver.FindElement(CartIconBy);
        }

        
    }
}
