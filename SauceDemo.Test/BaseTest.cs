using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SauceDemo.Test
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        protected IWebElement element;
        protected bool disposed;
        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        protected void Navigate()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                driver.Quit();
            }

            disposed = true;
        }

        ~BaseTest()
        {
            Dispose(false);
        }
    }
}
