using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QuantumReverse.Utils;

namespace QuantumReverse.Pages
{
    public class DashboardPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Waiter;

        public DashboardPage()
        {
            Driver = BrowserFactory.Driver;
            Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(25));
        }

        public IWebElement FindElement(By by)
        {
            return Waiter.Until(driver => driver.FindElement(by));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Waiter.Until(driver => driver.FindElements(by));
        }

        // Main page
        protected By NewLoanButton = By.XPath("//div[@class='loan-name new-loan']");
        protected By LoanTableButton = By.XPath("//div[@class='loan-name loan-table-menu']");
        protected By UploadButton = By.XPath("//div[@class='loan-name'][contains(.,'Upload')]");
        protected By GoogleSheetsButton = By.XPath("//div[@class='loan-name'][contains(.,'Google Sheets')]");
        protected By HelpButton = By.XPath("//div[@class='header-label'][contains(.,'Help')]");

        // Dropdown menu
        protected By CurrentUserDropdownMenu = By.XPath("//div[@class='connected-user current-user']");
        protected By SettingsButton = By.XPath("//i[contains(.,'settings')]");
        protected By LogoutButton = By.XPath("//i[contains(.,'exit_to_app')]");

        // New Loan
        protected By NewLoanHeader = By.XPath("//h2[contains(.,'New Loan')]");
        protected By CloseNewLoanButton = By.XPath("//button[@class = 'close']");
        protected By PurposeValueDropdownMenu = By.XPath("//div[@class='Select-value']"); // ?
        protected By PurposeValueTraditional = By.XPath("//div[@class='Select-menu-outer']//div[@id='react-select-2--option-0']");
        protected By PurposeValueHecmRefi = By.XPath("//div[@class='Select-menu-outer']//div[@id='react-select-2--option-1']");
        protected By PurposeValuePurchase = By.XPath("//div[@class='Select-menu-outer']//div[@id='react-select-2--option-2']");
        protected By PropertyValueInput = By.XPath("//input[@class='field']");
        protected By PropertyZipInput = By.XPath("//div[@class='zip']//input[@class='field type-text']");
        protected By AddBorrowerButton = By.XPath("//a[contains(.,'Add Borrower')]");
        protected By NameInputs = By.XPath("//div[@class = 'name']//input[(@class = 'field type-text')]"); // firstName 0->2.. lastName 1->3..
        protected By DateOfBirthInputs = By.XPath("//div[@class = 'new-loan-block borrower-block']//input[(@type = 'text')]");
        protected By BorrowerTypeDropdownMenus = By.XPath("//div[@class='Select-value'][contains(.,'Borrower')]");
        protected By DeleteBorrowerButtons = By.XPath("//div[@class='new-loan-block borrower-block']//button[@class='close']"); // xpath
        protected By LoanOfficerChangeButton = By.XPath("//div[@class = 'new-loan-block loan-officer']//a[@class='button-header'][contains(.,'Change')]");

        // Select Loan Officer-----
        protected By CloseSelectLoanOfficerButton = By.XPath("//div[@class = 'modals-header']//button[@class='close']");
        protected By NameSorting = By.XPath("//span[contains(.,'Name')]");
        protected By CompanySorting = By.XPath("//span[contains(.,'Company')]");
        protected By BranchOfficeSorting = By.XPath("//span[contains(.,'Branch Office')]");
        protected By StateSorting = By.XPath("//span[contains(.,'State')]");
        protected By FilterButton = By.XPath("//i[contains(.,'filter_list')]");
        // (click FilterButton) add NameInput, CompanyInput,BranchOfficeInput, StateInput
        // -----Select Loan Officer

        protected By ProductChangeButton = By.XPath("//div[@class = 'new-loan-block product']//a[@class='button-header'][contains(.,'Change')]");
        // Select Product-----
        protected By CloseSelectProductButton = By.XPath("//div[@class = 'modals-header']//button[@class='close']");
        protected By ProductField = By.XPath("//tbody/tr[n]"); // n - product field number
        protected By SelectedProductField = By.XPath("//tbody/tr[@class = 'selected']");
        // -----Select Product

        protected By RateInput = By.XPath("");
        protected By ClosingDateIn1MonthModalButton = By.XPath("//a[@class='modal-button-add ml-10'][contains(.,'in 1 Month')]");
        protected By ClosingDateIn2MonthModalButton = By.XPath("//a[@class='modal-button-add'][contains(.,'in 2 Month')]");
        protected By ClosingDateIn3MonthModalButton = By.XPath("//a[@class='modal-button-add'][contains(.,'in 3 Month')]");
        protected By ClosingDateInput = By.XPath("//div[@class = 'new-loan-block product']//input[(@type = 'text')]");
        protected By CancelButton = By.XPath("//button[@class='modal-cancel-button']");
        protected By CreateLoanButton = By.XPath("//button[@class='modal-button-add']");

        // Dashboard (collections)
        protected By DashboardItems = By.XPath("//div[@class='dashboard-item']");
        protected By DashboardHeaders = By.XPath("//div[@class='dashboard-header']");
        protected By HeadersNames = By.XPath("//div[@class='dashboard']//div[@class='dashboard-header']//a");
        protected By HeadersId = By.XPath("//div[@class='dashboard-state']//div//div");
        protected By HeadersDeleteButton = By.XPath("//i[@class='material-icons'][contains(.,'clear')]");
        protected By DashboardSettingsButtons = By.XPath("//div[@class='dashboard']//i[contains(.,'settings')]");
        protected By DashboardPageButtons = By.XPath("//a[contains(.,'loan')]");
        protected By DashboardDocumentsButtons = By.XPath("//a[contains(.,'documents')]");
        protected By DashboardNotificationsButtons = By.XPath("//button[contains(.,'notifications')]");

        // ALL
        public int GetCountOfDashboardItems()
        {
            return FindElements(DashboardItems).Count;
        }

        // LOG OUT
        public void Logout()
        {
            FindElement(CurrentUserDropdownMenu).Click();
            FindElement(LogoutButton).Click();
        }

        // CREATE NEW LOAN
        public void GoToNewLoanAndFillAllFields
            (string propertyValue, string propertyZip, string firstName, string lastName, string dateOfBirth)
        {
            FindElement(NewLoanButton).Click();
            FindElement(NewLoanHeader);
            FindElement(PropertyValueInput).SendKeys(propertyValue);
            FindElement(PropertyZipInput).SendKeys(propertyZip);
            FindElements(NameInputs)[0].SendKeys(firstName);
            FindElements(NameInputs)[1].SendKeys(lastName);
            FindElements(DateOfBirthInputs)[0].SendKeys(dateOfBirth);
            FindElement(NewLoanHeader).Click();
        }

        public bool GetStatusCreateLoanButton()
        {
            return FindElement(CreateLoanButton).Enabled;
        }

        public void CreateNewLoan()
        {
            FindElement(CreateLoanButton).Click();
        }

        public void CancelCreateNewLoan()
        {
            FindElement(CancelButton).Click();
        }

        public void ChangeTypeOfPurpose(string type)
        {
            switch (type)
            {
                case "Traditional":
                    FindElement(PurposeValueDropdownMenu).Click();
                    FindElement(PurposeValueTraditional).Click();
                    break;
                case "HECM Refi":
                    FindElement(PurposeValueDropdownMenu).Click();
                    FindElement(PurposeValueHecmRefi).Click();
                    break;
                case "Purchase":
                    FindElement(PurposeValueDropdownMenu).Click();
                    FindElement(PurposeValuePurchase).Click();
                    break;
            }
        }

        public void AddBorrower(string firstName, string lastName, string dateOfBirth)
        {
            FindElement(AddBorrowerButton).Click();
            FindElements(NameInputs)[2].SendKeys(firstName);
            FindElements(NameInputs)[3].SendKeys(lastName);
            FindElements(DateOfBirthInputs)[1].SendKeys(dateOfBirth);
            FindElement(NewLoanHeader).Click();
        }

        // DELETE LOAN
        // (add void CheckLastCreatedLoanIsDeleted(string createdLoanId))
        // Write a check through ID (not the same as it was at the remote)
        public void DeleteLastCreatedLoan(string createdLoanId)
        {
            var loanIds = FindElements(HeadersId);
            var idIndex = 0;
            var dashboardIndex = 0;
            foreach (var id in loanIds)
            {
                idIndex++;
                if (id.Text == createdLoanId)
                {
                    dashboardIndex = idIndex / 4;
                }
            }
            FindElements(DashboardHeaders)[dashboardIndex].Click();
            FindElements(HeadersDeleteButton)[dashboardIndex].Click();
        }
    }
}
