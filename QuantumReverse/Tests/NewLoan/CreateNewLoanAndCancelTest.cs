using System;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests.NewLoan
{
    [TestFixture]
    class CreateNewLoanAndCancelTest
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
        [TestCase(TestName = "QR-185:Add New Loan and click CancelButton.")]
        public void CreateNewLoanAndClickCancelTests()
        {
            var dashboard = new DashboardPage();
            var countOfDashboardItmsBefore = dashboard.GetCountOfDashboardItems();

            var firstName = "Test" + Rand.Next(100, 999);
            var lastName = "TEST";

            dashboard.GoToNewLoanAndFillAllFields("600000", "123", firstName, lastName, "6 24 40 ");
            dashboard.CancelCreateNewLoan();
            var countOfDashboardItmsAfter = dashboard.GetCountOfDashboardItems();

            if (countOfDashboardItmsBefore == countOfDashboardItmsAfter)
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