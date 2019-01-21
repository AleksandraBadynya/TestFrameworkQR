using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    [TestFixture]
    public class LogoutTest
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
        [TestCase(TestName = "QR-1202:Correctly logged out.")]
        public void LogoutPositiveTests()
        {
            var dashboard = new DashboardPage();
            dashboard.Logout();
            Assert.AreEqual("http://192.168.1.107:88/account/login", BrowserFactory.GetDriverUrl());
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}