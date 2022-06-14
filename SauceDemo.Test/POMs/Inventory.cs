using OpenQA.Selenium;
using Xunit;

namespace SauceDemo.Test.POMs
{
    class Inventory
    {
        private IWebDriver driver { get; }
        public IWebElement About => driver.FindElement(By.LinkText("About"));
        public IWebElement LoggOff => driver.FindElement(By.LinkText("Log off"));
        public IWebElement Cart => driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement AddToCartBackpack => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement AddToCartBikeLight => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public IWebElement AddToCartTShirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement Filter => driver.FindElement(By.ClassName("select_container"));


        public Inventory(IWebDriver _driver)
        {
            driver = _driver;
        }

        public bool DisplayedCart() => Cart.Displayed;

        public bool DisplayedFilter() => Filter.Displayed;

        public void AddToCart()
        {
            AddToCartBackpack.Click();
            AddToCartBikeLight.Click();
            AddToCartTShirt.Click();
        }

        


    }
}
