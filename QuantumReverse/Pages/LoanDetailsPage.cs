using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QuantumReverse.Utils;

namespace QuantumReverse.Pages
{
    class LoanDetailsPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Waiter;

        public LoanDetailsPage()
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
        protected By LoanName = By.XPath("//div[@class='loan-status-name']");
        protected By LoanId = By.XPath("//span[@class='loan-status-broker-id']");

        // Main dashboard
        protected By PurposeValue = By.XPath("//div[@class='loan-panel loan-middle']//span[@class='Select-value-label']");

        //
        public bool CheckingLoanNameMatches(string firstName, string lastName)
        {
            var loanName = firstName + " " + lastName;
            var name = FindElement(LoanName).Text;
            return Equals(loanName, name);
        }

        public string GetCreatedLoanId()
        {
            return FindElement(LoanId).Text;
        }

        public void GoToDashboardPage()
        {
            FindElement(ReturnToDashboardButton).Click();
        }

        public bool GetTypeOfPurpose(string type)
        {
            var purposeValue = FindElement(PurposeValue).Text;
            return purposeValue == type;
        }
    }
}
