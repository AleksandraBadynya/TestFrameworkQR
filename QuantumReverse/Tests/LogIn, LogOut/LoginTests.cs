using NUnit.Framework;
using QuantumReverse.Enums;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    [TestFixture]
    public class LoginTest
    {
        [SetUp]
        public void SetUp()
        {
            BrowserFactory.InitBrowser(BrowserEnum.Chrome);
        }

        [Test]
        [TestCase("alexandra", "123", TestName = "QR-27:Log in with correct credential.")]
        public void LoginPositiveTests(string name, string psw)
        {
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            Assert.AreEqual(BrowserFactory.QuantumReverseUrl + "dashboard", BrowserFactory.GetDriverUrl());
        }

        [Test]
        [TestCase("fdsgdreg", "rfeafefa", TestName = "QR-28:Log in with incorrect credential.")]
        [TestCase("", "", TestName = "QR-1199:Log in with empty login/password fields.(FAILED)")]
        [TestCase("", "123", TestName = "QR-1200:Log in with empty login field.(FAILED)")]
        [TestCase("al", "", TestName = "QR-1201:Log in with empty password field.")]
        [TestCase("alexandra", "000", TestName = "QR-1203:Log in with incorrect password.")]
        [TestCase("al", "123", TestName = "QR-1204:Log in with incorrect login.")]
        public void LoginNegativeTests(string name, string psw)
        {
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            Assert.IsTrue(loginPage.GetExeptionIncorrectInput());
        }

        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.CloseBrowser();
        }
    }
}
