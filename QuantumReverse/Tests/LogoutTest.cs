using NUnit.Framework;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    public class LogoutTest : BaseTest
    {
        [Test]
        [TestCase("alexandra", "123", TestName = "Valid logout test.")]
        public void LogoutPositiveTests(string name, string psw)
        {
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            var dashboard = new DashboardPage();
            dashboard.Logout();
            Assert.AreEqual("http://192.168.1.107:88/account/login", BrowserFactory.GetDriverUrl());
        }
    }
}