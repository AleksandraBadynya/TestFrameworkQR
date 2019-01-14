using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    [TestFixture]
    class CreateNewLoanTest
    {
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
        [TestCase(TestName = "Go to new loan and fill all fields valid data.")]
        public void CreateNewLoanPositiveTests()
        {
            var dashboard = new DashboardPage();
            dashboard.GoToNewLoanAndFillAllFields("600000", "123", "Aleksandra", "Aleksandra", "6 24 40 ");

            Assert.IsTrue(dashboard.GetStatusCreateLoanButton());
        }

        [Test]
        [TestCase(TestName = "Checking the creation of a new loan.")]
        public void CheckingNewLoanCreationPositiveTests()
        {
            var dashboard = new DashboardPage();
            dashboard.GoToNewLoanAndFillAllFields("600000", "123", "Aleksandra", "Aleksandra", "6 24 40 ");

            if (dashboard.GetStatusCreateLoanButton())
            {
                dashboard.CreateNewLoan();
                var loanDetailsPage = new LoanDetailsPage();
                Assert.IsTrue(loanDetailsPage.CheckingLoanNameMatches("Aleksandra", "Aleksandra"));
            }
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
