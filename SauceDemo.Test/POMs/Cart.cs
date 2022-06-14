using OpenQA.Selenium;
using Xunit;

    namespace SauceDemo.Test.POMs
    {
    public class Cart
    {
        private IWebDriver driver { get; }

        public IWebElement Item1 => driver.FindElement(By.XPath("//*[@id=\"item_4_title_link\"]/div"));
        public IWebElement Item2 => driver.FindElement(By.XPath("//*[@id=\"item_0_title_link\"]/div"));
        public IWebElement Item3 => driver.FindElement(By.XPath("//*[@id=\"item_1_title_link\"]/div"));
        public IWebElement RemoveItem1 => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        public IWebElement RemoveItem2 => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        public IWebElement RemoveItem3 => driver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt"));
        public IWebElement ContinueShopping => driver.FindElement(By.Id("continue-shopping"));
        public IWebElement CartLink => driver.FindElement(By.ClassName("shopping_cart_link"));

        public Cart(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void EmptyCart()
        {
            RemoveItem1.Click();
            RemoveItem2.Click();
            RemoveItem3.Click();
        }

        public void CheckCart()
        {
            var parent = driver.FindElements(By.XPath("//*[@id=\"shopping_cart_container\"]/a"));



            var i = -1;
            foreach (var item in parent)
            {
                i++;
                if (i == 1)
                {
                    var quantity = driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a/span"));
                    Assert.Equal("3", quantity.Text);
                }
                else
                {
                    Assert.True(i == 0);
                }
            }

        }

        public void BackToShopping()
        {
            ContinueShopping.Click();
        }

    }
    }
