using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QuantumReverse.Utils;

namespace QuantumReverse.Pages
{
    public class LoginPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Waiter;

        public LoginPage()
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

        protected By EmailInput = By.XPath("//input[@id = 'email']");
        protected By PasswordInput = By.XPath("//input[@id = 'password']");
        protected By SignInButton = By.Id("loginSubmit");
        protected By RememberMeCheckBox = By.XPath("//label[@class = 'checkbox material-icons']/input/i");
        protected By ExeptionIncorrectInput = By.XPath("//div[@class='text-danger']");

        public void LoginMethod(string email, string psw)
        {
            FindElement(EmailInput).SendKeys(email);
            FindElement(PasswordInput).SendKeys(psw);
            FindElement(SignInButton).Click();
        }

        public bool GetExeptionIncorrectInput()
        {
            return FindElement(ExeptionIncorrectInput).Displayed;
        }
    }
}
