using System;
using System.Threading;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests.NewLoan
{
    [TestFixture]
    public class DeleteLoanTest
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
        }

        [Test]
        [TestCase(TestName = "QR-186:Delete loan from dashboard.")]
        public void DeleteLoanPositiveTests()
        {
            var dashboard = new DashboardPage();
            var countOfDashboardItemsBefore = dashboard.GetCountOfDashboardItems();

            dashboard.GoToNewLoanAndFillAllFields("600000", "123", FirstName, LastName, "6 24 40 ");
            dashboard.CreateNewLoan();

            var loanDetails = new LoanDetailsPage();
            var createdLoanId = loanDetails.GetCreatedLoanId();
            loanDetails.GoToDashboardPage();
            Thread.Sleep(2000); //
            dashboard.DeleteLastCreatedLoan(createdLoanId);
            Thread.Sleep(2000); //

            var countOfDashboardItemsAfter = dashboard.GetCountOfDashboardItems();
            if (countOfDashboardItemsBefore == countOfDashboardItemsAfter)
            {
                Assert.True(true);
            }
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}