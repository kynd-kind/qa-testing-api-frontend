using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using SauceDemo.Test.POMs;
using Xunit;

namespace SauceDemo.Test.Tests
{
    public class ShopCartTest : BaseTest
    {
        private HomePage homePage;
        private Inventory inventory;
        private Cart cart;

        public ShopCartTest()
        {
            homePage = new HomePage(driver);
            inventory = new Inventory(driver);
            cart = new Cart(driver);
        }

        [Fact(DisplayName = "Log in, Shop, Check if Cart is filled, Empty Cart, Check if Cart empty, Back to Shopping")]
        public void ShoppingTest()
        {
            Navigate();

            homePage.Login("standard_user", "secret_sauce");
                        
            inventory.AddToCart();

            inventory.Cart.Click();
                     
            cart.CheckCart();

            cart.EmptyCart();

            cart.CheckCart();

            cart.BackToShopping();

            Assert.True(inventory.DisplayedFilter());                      
        }


    }
}