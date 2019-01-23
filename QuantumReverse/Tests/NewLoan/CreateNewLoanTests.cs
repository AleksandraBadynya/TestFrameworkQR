using System;
using System.Threading;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests.NewLoan
{
    [TestFixture]
    class CreateNewLoanTests
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
        [TestCase(TestName = "QR-1205:Go to new loan and fill in with correct data all fields.")]
        public void CreateNewLoanPositiveTests()
        {
            var dashboard = new DashboardPage();

            Assert.IsTrue(dashboard.GetStatusCreateLoanButton());
        }

        [Test]
        [TestCase(TestName = "QR-184:Create New Loan.")]
        public void CheckingNewLoanCreationPositiveTests()
        {
            var dashboard = new DashboardPage();

            if (dashboard.GetStatusCreateLoanButton())
            {
                dashboard.CreateNewLoan();
                var loanDetailsPage = new LoanDetailsPage();
                Assert.IsTrue(loanDetailsPage.CheckingLoanNameMatches(FirstName + " " + LastName));
            }
        }

        [Test]
        [TestCase(TestName = "QR-185:Create New Loan and click CancelButton.")]
        public void CreateNewLoanAndClickCancelTests()
        {
            var dashboard = new DashboardPage();
            var countOfDashboardItemsBefore = dashboard.GetCountOfDashboardItems();

            dashboard.GoToNewLoanAndFillAllFields("600000", "12345", FirstName, LastName, "2 20 40 ");
            dashboard.CancelCreateNewLoan();

            var countOfDashboardItemsAfter = dashboard.GetCountOfDashboardItems();
            if (countOfDashboardItemsBefore == countOfDashboardItemsAfter)
            {
                Assert.True(true);
            }
        }

        [Test]
        [TestCase("Traditional", TestName = "QR-963:Change type of purpose - Traditional.")]
        [TestCase("HECM Refi", TestName = "QR-961:Change type of purpose - HECM Refi.")]
        [TestCase("Purchase", TestName = "QR-962:Change type of purpose - Purchase.")]
        public void CreateNewLoanAndChangeTypeOfPurposePositiveTests(string type)
        {
            var dashboard = new DashboardPage();
            dashboard.ChangeTypeOfPurpose(type);

            if (dashboard.GetStatusCreateLoanButton())
            {
                dashboard.CreateNewLoan();
                var loanDetailsPage = new LoanDetailsPage();
                Assert.IsTrue(loanDetailsPage.GetTypeOfPurpose(type));
            }
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
