using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;


namespace KKamal_CaDevelopmentPlan.Tools
{
    public static class Browser
    {
        static IWebDriver _WebDriver;

        public static IWebDriver StartWebDriver()
        {
            //Start New Firefox 
            _WebDriver = new FirefoxDriver();

            //// Start New IE Driver
            //_WebDriver = new InternetExplorerDriver();
           
            ////Start New Chrome Driver
            //_WebDriver = new ChromeDriver();
           
            return _WebDriver;
        }


        public static void Navigate(string url) 
        {
            _WebDriver.Url = url;
        }

        public static void MaximizeWindow() 
        {
            _WebDriver.Manage().Window.Maximize();
        }

        public static IWebDriver Driver 
        {
            get
            {
                return _WebDriver;
            }
        }

    }
}
