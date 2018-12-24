using System;
using System.Security.Policy;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using QuantumReverse.Enums;
using QuantumReverse.Utils;

namespace QuantumReverse.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public string Id { get; set; }

        public static string QuantumReverseUrl = "http://192.168.1.107:88/";

        [SetUp]
        public void SetUp()
        {
//            Id = DateTime.Now.ToString("MMddHHmmss");
            BrowserFactory.InitBrowser(BrowserEnum.Chrome);
//            BrowserFactory.GoTo(QuantumReverseUrl);
        }

        [TearDown]
        public void CleanUp()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
                {
//                    var name = $"{TestContext.CurrentContext.Test.Name} {Id}";
//                    var screenShotFile = BrowserFactory.TakeScreenShot(name);
//                    TestContext.AddTestAttachment(screenShotFile, name);
                }
            }
            finally
            {
                BrowserFactory.CloseAllDrivers();
            }
        }
    }
}
