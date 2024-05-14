using HW18.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Steps
{
    public class NavigationStep : BaseStep
    {
        public NavigationStep(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void NavigateToCartPage()
        {
        }

        public ProductsPage NavigateToProductsPage()
        {
            return new ProductsPage(_driver, true);
        }
    }
}
