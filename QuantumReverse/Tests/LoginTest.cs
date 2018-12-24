using System.Threading;
using NUnit.Framework;
using QuantumReverse.Pages;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        [TestCase("alexandra", "123")]
        [TestCase("alexandra", "000")]
        [TestCase("al", "123")]
        public void Login(string name, string psw)
        {
            BrowserFactory.GoTo(QuantumReverseUrl);
            var quantumReversePage = new LoginPage();
            Thread.Sleep(2000);
            quantumReversePage.LoginMethod(name, psw);
            DashboardPage dashboard = new DashboardPage();
            dashboard.GoToNewLoan();

        }
    }
}
