using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QuantumReverse.Utils;

namespace QuantumReverse.Pages
{
    class LoanDetailsPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait WebDriverWait;

        public LoanDetailsPage()
        {
            Driver = BrowserFactory.Driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected By ReturnToDashboardButton = By.XPath("//div//img");
        protected By NewLoanButton = By.XPath("//div[@class='loan-name new-loan']");
        protected By LoanTableButton = By.XPath("//div[@class='loan-name loan-table-menu']");
        protected By DocumentsButton = By.XPath("//div[@class='header-label'][contains(.,'Documents')]");
        protected By HelpButton = By.XPath("//div[@class='header-label'][contains(.,'Help')]");
        protected By NotificationDropdownMenu = By.XPath("//i[contains(.,'inbox')]");

        // Dropdown menu
        protected By CurrentUserDropdownMenu = By.XPath("//div[@class='connected-user current-user']");
        protected By SettingsButton = By.XPath("//i[contains(.,'settings')]");
        protected By LogoutButton = By.XPath("//i[contains(.,'exit_to_app')]");

        // Left panel
        protected By LoanStatusName = By.XPath("//div[@class='loan-status-name']");


        // check
        public bool CheckingNameMatches(string firstName, string lastName)
        {
            var loanName = firstName + " " + lastName;
            var name = WebDriverWait.Until(driver => driver.FindElement(LoanStatusName).Text);
            return Equals(loanName, name);
        }
    }
}
