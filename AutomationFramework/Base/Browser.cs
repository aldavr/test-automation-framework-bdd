using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace AutomationFramework.Base
{
    public class Browser
    {
        internal static IWebDriver webDriver { get; set; }
        internal static string baseUrl = ConfigurationManager.AppSettings["URL"];

        // Initializes Web Browser
        public static void Initialize()
        {
            switch(ConfigurationManager.AppSettings["Browser"].ToString())
            {
                case "IE":
                    webDriver = new InternetExplorerDriver(IEOptions);
                    webDriver.Manage().Window.Maximize();
                    webDriver.Navigate().GoToUrl(baseUrl);
                    break;
                case "Chrome":
                    webDriver = new ChromeDriver(GetChromeOptions());
                    webDriver.Navigate().GoToUrl(baseUrl);
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    webDriver.Manage().Window.Maximize();
                    webDriver.Navigate().GoToUrl(baseUrl);
                    break;
                default:
                    webDriver = new ChromeDriver(GetChromeOptions());
                    break;
            }

        }

        // Quits WebDriver, closes every associated window
        public static void Quit()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }

        // Closes the current window
        internal static void Close() => webDriver.Close();

        #region Browser Options

        // Custom options for IE
        protected static InternetExplorerOptions IEOptions
        {
            get
            {
                InternetExplorerOptions options = new InternetExplorerOptions
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    IgnoreZoomLevel = true,
                    EnablePersistentHover = false,
                    EnableNativeEvents = false
                };
                return options;
            }
        }

        // Custom options for Chrome
        protected static ChromeOptions GetChromeOptions()
        {
            string headless = ConfigurationManager.AppSettings["Headless"];
            ChromeOptions option = new ChromeOptions();

            option.AddArgument("start-maximized");

            //Opens headless
            if (headless[0] == 'Y' || headless[0] == 'y')
            {
                option.AddArgument("--headless");
                option.AddArgument("--window-size=1920,1080");
            }

            return option;
        }

        // Custom options for Firefox
        protected static FirefoxDriverService GetFirefoxOptions()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driverPath = Path.GetFullPath(Path.Combine(outPutDirectory));
            var service = FirefoxDriverService.CreateDefaultService(driverPath, "geckodriver.exe");
            service.HideCommandPromptWindow = true;
            return service;
        }

        #endregion

    }
}
