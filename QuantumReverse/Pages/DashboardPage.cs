﻿using System;
using OpenQA.Selenium;
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
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        //Main page
        protected By NewLoanButton = By.XPath("//div[@class='loan-name new-loan']");
        protected By LoanTableButton = By.XPath("//div[@class='loan-name loan-table-menu']");
        protected By UploadButton = By.XPath("//div[@class='loan-name'][contains(.,'Upload')]");
        protected By GoogleSheetsButton = By.XPath("//div[@class='loan-name'][contains(.,'Google Sheets')]");
        protected By HelpButton = By.XPath("//div[@class='header-label'][contains(.,'Help')]");

        //Dropdown menu
        protected By CurrentUserDropdownMenu = By.XPath("//div[@class='connected-user current-user']");
        protected By SettingsButton = By.XPath("//i[contains(.,'settings')]");
        protected By LogoutButton = By.XPath("//i[contains(.,'exit_to_app')]");

        //New Loan
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

        public void GoToNewLoan()
        {
            WebDriverWait.Until(driver => driver.FindElement(NewLoanButton)).Click();
        }

        public void Logout()
        {
            WebDriverWait.Until(driver => driver.FindElement(CurrentUserDropdownMenu)).Click();
            WebDriverWait.Until(driver => driver.FindElement(LogoutButton)).Click();
        }
    }
}
