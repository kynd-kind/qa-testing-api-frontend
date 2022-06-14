using OpenQA.Selenium;
using Xunit;

namespace SauceDemo.Test.POMs
{
    public class HomePage
    {
        private IWebDriver driver { get; }
        
        public IWebElement UserName => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement LoginLink => driver.FindElement(By.Id("login-button"));
        


        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public bool DisplayedLoginLink() => LoginLink.Displayed;

        
        public void Login(string username_input, string password_input)
        {
            UserName.SendKeys(username_input);
            Password.SendKeys(password_input);
            LoginLink.Click();
        }

    }
}
