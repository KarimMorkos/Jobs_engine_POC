using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace PageObjects
{
    public static class Browser
    {
        static IWebDriver _webDriver;


        public static IWebDriver StartFFWebDriver()
        {

            _webDriver = new FirefoxDriver();

            return _webDriver;

        }

        public static IWebDriver StartChromeWebDriver()
        {

            _webDriver = new ChromeDriver();

            return _webDriver;

        }

        public static IWebDriver StartIEWebDriver()
        {

            _webDriver = new InternetExplorerDriver();

            return _webDriver;

        }

        public static string Title
        {

            get { return _webDriver.Title; }

        }

        public static IWebDriver Driver
        {

            get
            {
                return _webDriver;

            }

        }

        public static void Goto(string url)
        {

            _webDriver.Url = url;

        }

        public static void StopTests()
        {

            _webDriver.Close();

            _webDriver.Quit();

        }

        public static void ImplicitWait()
        {
            ITimeouts implicitlyWait = _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            if (implicitlyWait == null) throw new ArgumentNullException("imp" + "licitlyWait");
        }



    }
}
