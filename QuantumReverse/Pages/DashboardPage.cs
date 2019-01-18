using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using QuantumReverse.Utils;

namespace QuantumReverse.Pages
{
    public class DashboardPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait WebDriverWait;

        public DashboardPage()
        {
            Driver = BrowserFactory.Driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
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
        protected By PropertyValueInput = By.XPath("//input[@class='field']");
        protected By PropertyZipInput = By.XPath("//div[@class='zip']//input[@class='field type-text']");
        protected By AddBorrowerButton = By.XPath("//a[contains(.,'Add Borrower')]");
        protected By FirstNameInput = By.XPath("(//div[@class = 'name']//input[(@class = 'field type-text')])[1]"); // xpath (if add borrower 1->3..)
        protected By LastNameInput = By.XPath("(//div[@class = 'name']//input[(@class = 'field type-text')])[2]"); // xpath (if add borrower 2->4..)
        protected By DateOfBirthInput = By.XPath("//div[@class = 'new-loan-block borrower-block']//input[(@type = 'text')]");
        protected By BorrowerTypeDropdownMenu = By.XPath("//div[@class='Select-value'][contains(.,'Borrower')]");
        protected By DeleteBorrowerButton = By.XPath("//div[@class='new-loan-block borrower-block']//button[@class='close']"); // xpath
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

        // Dashboard
        protected By DashboardItems = By.XPath("//div[@class='dashboard-item']");
        protected By LoanName = By.XPath("//div[@class='dashboard']//div[@class='dashboard-header']//a"); // collection
        protected By LoanId = By.XPath("//div[@class='dashboard-state']//div//div"); // collection
        protected By DeleteDashboardButton = By.XPath("//i[@class='material-icons'][contains(.,'clear')]"); // collection
        protected By DashboardSettingsButton = By.XPath("//div[@class='dashboard']//i[contains(.,'settings')]"); // collection
        protected By DashboardPageButton = By.XPath("//a[contains(.,'loan')]"); // collection
        protected By DashboardDocumentsButton = By.XPath("//a[contains(.,'documents')]"); // collection
        protected By DashboardNotificationsButton = By.XPath("//button[contains(.,'notifications')]"); // collection

        public void DeleteLastCreatedLoan(string createdLoanId)
        {
            var loanId = WebDriverWait.Until(driver => driver.FindElements(LoanId));
            foreach (var id in loanId)
            {
                if (loanId.IndexOf(id) % 4 == 0 && id.Text == createdLoanId)
                {
                    int dashboardIndex = loanId.IndexOf(id);
                    int loanIdIndex = 4 * dashboardIndex - 3;

                    var action = new Actions(Driver); // ???????
//                    BrowserFactory.ExecuteJs("arguments[0].hover", id);
                    action.MoveToElement(id);
                    WebDriverWait.Until(driver => driver.FindElements(DeleteDashboardButton))[dashboardIndex].Click();
                }
            }
        }

        public void Logout()
        {
            WebDriverWait.Until(driver => driver.FindElement(CurrentUserDropdownMenu)).Click();
            WebDriverWait.Until(driver => driver.FindElement(LogoutButton)).Click();
        }

        public void GoToNewLoanAndFillAllFields
            (string propertyValueInput, string propertyZipInput, string firstNameInput, string lastNameInput, string dateOfBirthInput)
        {
            WebDriverWait.Until(driver => driver.FindElement(NewLoanButton)).Click();
            WebDriverWait.Until(driver => driver.FindElement(NewLoanHeader));
            Driver.FindElement(PropertyValueInput).SendKeys(propertyValueInput);
            Driver.FindElement(PropertyZipInput).SendKeys(propertyZipInput);
            Driver.FindElement(FirstNameInput).SendKeys(firstNameInput);
            Driver.FindElement(LastNameInput).SendKeys(lastNameInput);
            Driver.FindElement(DateOfBirthInput).SendKeys(dateOfBirthInput);
            Driver.FindElement(NewLoanHeader).Click();
        }

        public void CreateNewLoan()
        {
            Driver.FindElement(CreateLoanButton).Click();
        }

        public bool GetStatusCreateLoanButton()
        {
            return WebDriverWait.Until(driver => driver.FindElement(CreateLoanButton).Enabled);
        }
    }
}
