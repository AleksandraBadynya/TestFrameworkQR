using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QuantumReverse.Utils;

namespace QuantumReverse.Pages
{
    public class BorrowersPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Waiter;

        public BorrowersPage()
        {
            Driver = BrowserFactory.Driver;
            Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        }

        public IWebElement FindElement(By by)
        {
            return Waiter.Until(driver => driver.FindElement(by));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Waiter.Until(driver => driver.FindElements(by));
        }

        protected By Input = By.XPath("");

        public void Method(string email, string psw)
        {
            
        }
    }
}