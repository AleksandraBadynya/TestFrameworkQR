using System;
using System.Threading;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    [TestFixture]
    public class DeleteLoanTest
    {
        private static readonly Random Rand = new Random();

        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser(BrowserEnum.Chrome);

            var name = "alexandra";
            var psw = "123";
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            var dashboard = new DashboardPage();

            var firstName = "Test" + Rand.Next(100, 999);
            var lastName = "TEST";

            dashboard.GoToNewLoanAndFillAllFields("600000", "123", firstName, lastName, "6 24 40 ");
            if (dashboard.GetStatusCreateLoanButton())
            {
                dashboard.CreateNewLoan();
            }
        }

        [Test]
        [TestCase(TestName = "Delete loan from dashboard.")]
        public void DeleteLoanPositiveTests()
        {
            var loanDetails = new LoanDetailsPage();
            var createdLoanId = loanDetails.GetCreatedLoanId();
            loanDetails.GoToDashboardPage();

            var dashboard = new DashboardPage();
            Thread.Sleep(3000); // test
            dashboard.DeleteLastCreatedLoan(createdLoanId);
            Thread.Sleep(3000); // test
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}