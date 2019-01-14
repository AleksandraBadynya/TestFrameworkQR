using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    [TestFixture]
    public class DeleteLoanTest
    {
        public void SetUp()
        {
            BrowserFactory.InitBrowser(BrowserEnum.Chrome);

            var name = "alexandra";
            var psw = "123";
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);
        }

        // -
        [Test]
        [TestCase(TestName = "Delete loan from dashboard.")]
        public void DeleteLoanPositiveTests()
        {
            var dashboard = new DashboardPage();
            dashboard.GoToNewLoanAndFillAllFields("600000", "123", "Aleksandra", "Aleksandra", "6 24 40 ");

            var loanDetails = new LoanDetailsPage();
            var createdLoanId = loanDetails.GetCreatedLoanId();
            loanDetails.GoToDashboardPage();

            var dashboardLoanId = dashboard.GetCreatedLoanId();
            if (createdLoanId == dashboardLoanId)
            {
                dashboard.DeleteLastCreatedLoan();
            }
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}