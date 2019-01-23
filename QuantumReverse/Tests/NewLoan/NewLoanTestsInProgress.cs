using System;
using System.Threading;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests.NewLoan
{
    [TestFixture]
    public class NewLoanTestsInProgress
    {
        private static readonly Random Rand = new Random();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser(BrowserEnum.Chrome);

            var name = "alexandra";
            var psw = "123";
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            FirstName = "Test" + Rand.Next(100, 999);
            LastName = "TEST";

            var dashboard = new DashboardPage();
            dashboard.GoToNewLoanAndFillAllFields("600000", "12345", FirstName, LastName, "2 20 40 ");
        }

        [Test]
        [TestCase("BorrowerFN", " LN", "1 1 41", TestName = "QR-965:Create New Loan and add borrower.(IN PROGRESS)")]
        public void CreateNewLoanAndAddBorrowerTests(string secondBorrowerFirstName, string secondBorrowerLastName, string dateOfBirth)
        {
            var dashboard = new DashboardPage();

            dashboard.AddBorrower(secondBorrowerFirstName, secondBorrowerLastName, dateOfBirth);
            Thread.Sleep(3000);

            if (dashboard.GetStatusCreateLoanButton())
            {
                dashboard.CreateNewLoan();
                var loanDetailsPage = new LoanDetailsPage();
                var createdLoanUrl = BrowserFactory.GetDriverUrl();
//                createdLoanUrl = createdLoanUrl.Substring(31, createdLoanUrl.Length - 8);
                loanDetailsPage.GoToBorrowersPage();
                var borrowersPage = new BorrowersPage();
            }
        }

        [Test]
        [TestCase(TestName = "QR-964:Create New Loan and change product.(IN PROGRESS)")]
        public void CreateNewLoanAndChangeProductTest()
        {
            var dashboard = new DashboardPage();
        }

        [Test]
        [TestCase(TestName = "QR-1070:Check that Margin displays correctly.(IN PROGRESS)")]
        public void CreateNewLoanAndCheckMarginTest()
        {
            var dashboard = new DashboardPage();
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
