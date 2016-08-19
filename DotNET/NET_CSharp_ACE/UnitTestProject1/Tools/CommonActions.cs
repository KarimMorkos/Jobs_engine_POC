using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using KKamal_CaDevelopmentPlan.Tools;


namespace KKamal_CaDevelopmentPlan.Tools
{
    public class CommonActions
    {
        public static void Setup(int WaitTime)
        {
            Browser.StartWebDriver();
            Browser.MaximizeWindow();
            Browser.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.Parse(ConfigurationManager.AppSettings["PageLoadTimeout"])); 

        }

        public static void ExecuteBackCommand()
        {
            Browser.Driver.Navigate().Back();
        }

        public static void ExecuteForwardCommand() 
        {
            Browser.Driver.Navigate().Forward();
        }

        public static void ExecuteRefreshCommand()
        {
            Browser.Driver.Navigate().Refresh();
        }

        public static string GetPageTitle()
        {
            string PageTitle = Browser.Driver.Title;
            return PageTitle;
        }


        public static void SwitchTo(string WindowName) 
        {
            Browser.Driver.SwitchTo().Window(WindowName);
        }

        public static void ExplicitWaitForAlerts(int TimetoWait)
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(TimetoWait));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static void CleanUp() 
        {         
            Browser.Driver.Close();
            Browser.Driver.Quit();
        }

        public static string GetFileLocation(string fileName) 
        {
            var startDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string Location = startDirectory + fileName;
            return Location;
        }

        public static string GetPageSource()
        {
            try
            {
                string pageSource = Browser.Driver.PageSource;
                return pageSource;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                
            }
            return null;
            

        }

        public static string GetTableData(string XpathofTable) 
        {
            try
            {
                int RowCount = Browser.Driver.FindElements(By.XPath(XpathofTable +"/tbody/tr")).Count;
                int cellCount = Browser.Driver.FindElements(By.XPath(XpathofTable +"/tbody/tr/th")).Count;
                string TableResults = "";
                for (int i = 2; i <= RowCount; i++)
                {
                    for (int y = 1; y <= cellCount; y++)
                    {
                        TableResults +=
                            Browser.Driver.FindElement(By.XPath(XpathofTable + "/tbody/tr[" + i + "]/td[" + y + "]")).Text;
                           //Browser.Driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_MasterPageContent_cpv_listAGWs_itemPlaceholderContainer']/tbody/tr[" + i + "]/td[" + y + "]")).Text;
                    }

                }
                return TableResults;

            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            return null;

        }

        public static void implicitWait(int timeToWait)
        {
            Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeToWait));
        }




    }
}
