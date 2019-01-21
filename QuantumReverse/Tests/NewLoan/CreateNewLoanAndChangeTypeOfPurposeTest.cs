using System;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests.NewLoan
{
    [TestFixture]
    class CreateNewLoanAndChangeTypeOfPurposeTest
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
        [TestCase("Traditional", TestName = "QR-963:Change type of purpose - Traditional.(IN PROGRESS)")]
        [TestCase("HECM Refi", TestName = "QR-961:Change type of purpose - HECM Refi.(IN PROGRESS)")]
        [TestCase("Purchase", TestName = "QR-962:Change type of purpose - Purchase.(IN PROGRESS)")]
        public void CreateNewLoanAndChangeTypeOfPurposePositiveTests(string type)
        {
            var dashboard = new DashboardPage();

            var firstName = "Test" + Rand.Next(100, 999);
            var lastName = "TEST";

            dashboard.GoToNewLoanAndFillAllFields("600000", "123", firstName, lastName, "6 24 40 ");
            dashboard.ChangeTypeOfPurpose(type);

//            if (dashboard.GetStatusCreateLoanButton())
//            {
//                dashboard.CreateNewLoan();
//                var loanDetailsPage = new LoanDetailsPage();
//                Assert.IsTrue(loanDetailsPage.GetTypeOfPurpose(type));
//            }
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}