using NUnit.Framework;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        [TestCase("alexandra", "123", TestName = "Valid login/password test.")]
        public void LoginPositiveTests(string name, string psw)
        {
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            Assert.AreEqual("http://192.168.1.107:88/dashboard", BrowserFactory.GetDriverUrl());

//            var dashboard = new DashboardPage();
//            dashboard.Logout();
        }

        [Test]
        [TestCase("alexandra", "000", TestName = "Invalid password test.")]
        [TestCase("al", "123", TestName = "Invalid login test.")]
        [TestCase("fdsgdreg", "rfeafefa", TestName = "Invalid login/password test.")]
        [TestCase("", "", TestName = "Empty login/password test.")]
        [TestCase("", "123", TestName = "Empty login test.")]
        [TestCase("al", "", TestName = "Empty password test.")]
        public void LoginNegativeTests(string name, string psw)
        {
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            Assert.IsTrue(loginPage.GetExeptionIncorrectInput());
        }
    }
}
