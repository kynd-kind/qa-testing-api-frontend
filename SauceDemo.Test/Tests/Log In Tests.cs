using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using SauceDemo.Test.POMs;
using Xunit;

namespace SauceDemo.Test.Tests
{
    public class LoginTest : BaseTest
    {
        private  HomePage homePage;
        private  Inventory inventory;

        public LoginTest()
        {
            homePage = new HomePage(driver);
            inventory = new Inventory(driver);
        }

        [Fact(DisplayName = "Log in user")]
        public void CorrectLogIn()
        {
            Navigate();

            homePage.Login("standard_user", "secret_sauce");

            Assert.True(inventory.DisplayedCart());
        }
        
        [Theory]
        [InlineData("potato", "totallyapassword")]
        [InlineData("cucumba", "")]
        [InlineData("avocadando", "1112")]
        [InlineData("", "yesnomaybeidk")]

        public void IncorrectLogins(string username_input, string password_input)
        {
            Navigate();
            
            homePage.Login(username_input, password_input);

            Assert.True(homePage.DisplayedLoginLink());
        }

    }
}