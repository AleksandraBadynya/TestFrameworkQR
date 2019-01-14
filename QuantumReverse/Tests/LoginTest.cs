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
        [TestCase("alexandra", "123", TestName = "Valid login/password.")]
        public void LoginPositiveTests(string name, string psw)
        {
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            Assert.AreEqual("http://192.168.1.107:88/dashboard", BrowserFactory.GetDriverUrl());
        }

        [Test]
        [TestCase("alexandra", "000", TestName = "Invalid password.")]
        [TestCase("al", "123", TestName = "Invalid login.")]
        [TestCase("fdsgdreg", "rfeafefa", TestName = "Invalid login/password.")]
        [TestCase("", "", TestName = "Empty login/password.")]
        [TestCase("", "123", TestName = "Empty login.")]
        [TestCase("al", "", TestName = "Empty password.")]
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
