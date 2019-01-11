using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    class CreateNewLoanTest : BaseTest
    {
        [Test]
        [TestCase(TestName = "Go to new loan and fill all fields valid data.")]
        public void CreateNewLoanPositiveTests()
        {
            var name = "alexandra";
            var psw = "123";
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            var dashboard = new DashboardPage();
            dashboard.GoToNewLoanAndFillAllFields("600000", "123", "Aleksandra", "Aleksandra", "1 1 40 ");

            Assert.IsTrue(dashboard.GetStatusCreateLoanButton());
        }

        [Test]
        [TestCase(TestName = "Checking the creation of a new loan.")]
        public void CheckingNewLoanCreationPositiveTests()
        {
            var name = "alexandra";
            var psw = "123";
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            var dashboard = new DashboardPage();
            dashboard.GoToNewLoanAndFillAllFields("600000", "123", "Aleksandra", "Aleksandra", "6 24 40 ");

            if (dashboard.GetStatusCreateLoanButton())
            {
                dashboard.CreateNewLoan();
                var loanDetailsPage = new LoanDetailsPage();
                Assert.IsTrue(loanDetailsPage.CheckingNameMatches("Aleksandra", "Aleksandra"));
            }
        }
    }
}
