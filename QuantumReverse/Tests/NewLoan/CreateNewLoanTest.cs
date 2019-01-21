using System;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests.NewLoan
{
    [TestFixture]
    class CreateNewLoanTest
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
        }

        [Test]
        [TestCase(TestName = "QR-184:Add New Loan.")]
        public void CheckingNewLoanCreationPositiveTests()
        {
            var dashboard = new DashboardPage();

            var firstName = "Test" + Rand.Next(100, 999);
            var lastName = "TEST";

            dashboard.GoToNewLoanAndFillAllFields("600000", "123", firstName, lastName, "6 24 40 ");

            if (dashboard.GetStatusCreateLoanButton())
            {
                dashboard.CreateNewLoan();
                var loanDetailsPage = new LoanDetailsPage();
                Assert.IsTrue(loanDetailsPage.CheckingLoanNameMatches(firstName, lastName));
            }
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
