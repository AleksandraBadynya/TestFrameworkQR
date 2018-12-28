using NUnit.Framework;
using QuantumReverse.Pages;

namespace QuantumReverse.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        [TestCase("alexandra", "123", TestName = "Valid login/password test.")]
        [TestCase("alexandra", "000", TestName = "Invalid password test.")]
        [TestCase("al", "123", TestName = "Invalid login test.")]

        public void CheckLogin(string name, string psw)
        {
            var loginPage = new LoginPage();
            loginPage.LoginMethod(name, psw);

            var dashboard = new DashboardPage();
            dashboard.Logout();
        }
    }
}
