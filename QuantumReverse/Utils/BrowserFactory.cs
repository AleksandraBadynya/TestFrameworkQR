using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using QuantumReverse.Enums;

namespace QuantumReverse.Utils
{
    public static class BrowserFactory
    {
        [ThreadStatic]
        private static readonly IDictionary<BrowserEnum, IWebDriver> Drivers = new Dictionary<BrowserEnum, IWebDriver>();

        private static IWebDriver driver;
        
        private static string DefaultDirectory => AppDomain.CurrentDomain.BaseDirectory;
        private const string RelativePath = @"..\..\..\MyFramework";

        public static void GoTo(string url)
        {
            driver.Url = url;
        }

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    throw new NullReferenceException(
                        "The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                }

                return driver;
            }
            private set => driver = value;
        }

        public static void InitBrowser(BrowserEnum browserName)
        {
            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    driver = new ChromeDriver();
                    Drivers.Add(BrowserEnum.Chrome, Driver);
                    break;
                case BrowserEnum.FireFox:
                    driver = new FirefoxDriver();
                    Drivers.Add(BrowserEnum.FireFox, Driver);
                    break;
                case BrowserEnum.Grid:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserName), browserName, null);
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://192.168.1.107:88/");
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }

        public static void FocusOnElement(IWebElement element)
        {
            var action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public static void Close()
        {
            driver.Close();
            driver.Quit();
        }

        public static IWebDriver SwitchToFrame(IWebElement element) => driver.SwitchTo().Frame(element);

        public static void SetImplicitWait(double seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static string TakeScreenShot(string testName)
        {
            var screenShotFile = Path.Combine(DefaultDirectory, RelativePath, $@"bin\Debug\{testName}.jpg");
            driver.TakeScreenshot().SaveAsFile(screenShotFile, ScreenshotImageFormat.Png);
            return screenShotFile;
        }

        public static void ExecuteJs(string jsString, IWebElement element)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            var result = js?.ExecuteScript(jsString, element);
            Console.WriteLine(result);
        }

        public static void ExecuteJs(string jsString)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            var result = js?.ExecuteScript(jsString);
            Console.WriteLine(result);
        }
    }
}
