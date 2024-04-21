using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Pages
{
    public class CartPage : BasePage
    {
        protected IWebDriver Driver { get; set; }
        public static readonly By firstProduct = By.Id("add-to-cart-sauce-labs-backpack");
        public static readonly By secondProduct = By.XPath("//button[@data-test='add-to-cart-sauce-labs-bike-light']");
        public static readonly By thirdProduct = By.XPath("(//div[@class='inventory_item_price']/following-sibling::button)[3]");
        public static readonly By addButton = By.Id("add-to-cart-sauce-labs-backpack");
        public static readonly By counter = By.XPath("//span[@data-test='shopping-cart-badge']");
        public static readonly By productTitle = By.XPath("//div[text()='Sauce Labs Backpack']");
        public static readonly By productPrice = By.XPath("//div[@class='pricebar']//div[text()='29.99']");

        public CartPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public string CartNumberMultiple()
        {
            IWebElement addFirstProductToCartButton = Driver.FindElement(firstProduct);
            addFirstProductToCartButton.Click();
            IWebElement addSecondProductToCartButton = Driver.FindElement(secondProduct);
            addSecondProductToCartButton.Click();
            IWebElement addThirdProductToCartButton = Driver.FindElement(thirdProduct);
            addThirdProductToCartButton.Click();
            IWebElement cartNumber = Driver.FindElement(counter);
            return cartNumber.Text;
        }

        public string CartNumberSingle()
        {
            IWebElement addToCartButton = Driver.FindElement(addButton);
            addToCartButton.Click();
            IWebElement cartNumber = Driver.FindElement(counter);
            string cartNumberText = cartNumber.Text;
            return cartNumberText;
        }

        public (string title, string price) AddProductToCart()
        {
            IWebElement addToCartButton = Driver.FindElement(firstProduct);
            addToCartButton.Click();
            string inventoryTitleText = Driver.FindElement(productTitle).Text;
            string inventoryPriceText = Driver.FindElement(productPrice).Text;
            IWebElement cartNumber = Driver.FindElement(counter);
            cartNumber.Click();
            return (inventoryTitleText, inventoryPriceText);
        }

        public override string GetEndpoint()
        {
            throw new NotImplementedException();
        }
    }
}
