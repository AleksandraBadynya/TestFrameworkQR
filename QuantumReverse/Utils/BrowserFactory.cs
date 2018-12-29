using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using QuantumReverse.Enums;

namespace QuantumReverse.Utils
{
    public static class BrowserFactory
    {
        private static IWebDriver _driver;
        public static string QuantumReverseUrl = "http://192.168.1.107:88/";

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException(
                        "The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                }

                return _driver;
            }
            private set => _driver = value;
        }

        public static void InitBrowser(BrowserEnum browserName)
        {
            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    _driver = new ChromeDriver();
                    break;
                case BrowserEnum.FireFox:
                    _driver = new FirefoxDriver();
                    break;
                case BrowserEnum.IE:
                    _driver = new InternetExplorerDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserName), browserName, null);
            }
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(QuantumReverseUrl);
        }

        public static void CloseBrowser()
        {
            _driver.Close();
            _driver.Quit();
        }

        public static void GoTo(string url)
        {
            _driver.Url = url;
        }

        public static string GetDriverUrl()
        {
            return _driver.Url;
        }
    }
}
