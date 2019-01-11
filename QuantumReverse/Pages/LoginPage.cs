using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QuantumReverse.Utils;

namespace QuantumReverse.Pages
{
    public class LoginPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait WebDriverWait;

        public LoginPage()
        {
            Driver = BrowserFactory.Driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected By EmailInput = By.XPath("//input[@id = 'email']");
        protected By PasswordInput = By.XPath("//input[@id = 'password']");
        protected By SignInButton = By.Id("loginSubmit");
        protected By RememberMeCheckBox = By.XPath("//label[@class = 'checkbox material-icons']/input/i");
        protected By ExeptionIncorrectInput = By.XPath("//div[@class='text-danger']");

        public void LoginMethod(string email, string psw)
        {
            WebDriverWait.Until(driver => driver.FindElement(EmailInput)).SendKeys(email);
            WebDriverWait.Until(driver => driver.FindElement(PasswordInput)).SendKeys(psw);
            WebDriverWait.Until(driver => driver.FindElement(SignInButton)).Click();
        }

        public bool GetExeptionIncorrectInput()
        {
            return WebDriverWait.Until(driver => driver.FindElement(ExeptionIncorrectInput)).Displayed;
        }
    }
}
