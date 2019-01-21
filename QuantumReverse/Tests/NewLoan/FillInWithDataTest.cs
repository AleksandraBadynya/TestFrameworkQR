using System;
using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests.NewLoan
{
    [TestFixture]
    class FillInWithDataTest
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
        [TestCase(TestName = "QR-1205:Go to new loan and fill in with correct data all fields.")]
        public void CreateNewLoanPositiveTests()
        {
            var dashboard = new DashboardPage();

            var firstName = "Test" + Rand.Next(100, 999);
            var lastName = "TEST";

            dashboard.GoToNewLoanAndFillAllFields("600000", "123", firstName, lastName, "6 24 40 ");

            Assert.IsTrue(dashboard.GetStatusCreateLoanButton());
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
