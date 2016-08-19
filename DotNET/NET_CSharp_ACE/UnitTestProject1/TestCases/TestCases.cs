using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;
using Selenium.WebDriver;
using Selenium.WebDriver.Extensions;
using KKamal_CaDevelopmentPlan.PageObjects;
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
using KKamal_CaDevelopmentPlan.Tools;
using System.Collections;
using Microsoft.VisualStudio.QualityTools;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
using System.Data.Odbc;


 

namespace KKamal_CaDevelopmentPlan
{
    [TestClass]
    public class UnitTest1
    {
        
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Test Initialize Procedure
        [TestInitialize]
        public void TestSetup() 
        {
            CommonActions.Setup(10);       
        }
        #endregion

        #region Practices from 1 - 3
        [TestMethod]
        public void Practice1_3()
        {

            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage =  new ACE_HomePage(Browser.Driver);
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]); 

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);
            Console.Out.WriteLine("Page Title: \n" + CommonActions.GetPageTitle());
            Console.Out.WriteLine("Page Source: \n" + CommonActions. GetPageSource());

            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());

            if (homepage._LoggingUserStatus_Txt.Displayed)
            {
                Assert.AreEqual("Administrator", homepage.GetLoggedInUser());
            }
            else
            {
                Console.Out.WriteLine("Error! Element Not Found");
            }

        }
        #endregion

        #region Practice4
        [TestMethod]
        public void Practice4() 
        {
            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage = new ACE_HomePage(Browser.Driver);
           
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]); 

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);

            //Login with valid user Name and password
            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());

            //Navigate to the dataset page
            homepage.OpenDatasetsLink();

            //Come back to Home page (Use ‘Back’ command)
            CommonActions.ExecuteBackCommand();

            //Again go back to Data set page (This time use ‘Forward’ command)
            CommonActions.ExecuteForwardCommand();

            //Again come back to Home page (This time use ‘Navigate’ command)
            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);

            //Refresh the Browser (Use ‘Refresh’ command)
            CommonActions.ExecuteRefreshCommand();
        }
        #endregion

        #region Practice5
        [TestMethod]
        public void Practice5()
        {
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]);

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);

            var loginpage = new ACE_LoginPage(Browser.Driver);

            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());
        }
        #endregion

        #region Practice6
        [TestMethod]
        public void Practice6()
        {
            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage = new ACE_HomePage(Browser.Driver);
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]); 

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);

            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());
            homepage.OpenDeploymentGroupsLink();

        }
        #endregion

        #region Practice7
        [TestMethod]
        public void Practice7()
        {
            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage = new ACE_HomePage(Browser.Driver);
            var usermgmtpage = new ACE_UsersMgmtPage(Browser.Driver);
            var createuserwindow = new ACE_CreateUserWindow(Browser.Driver);
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]);

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);

            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());
            homepage.OpenUsersLink();
            usermgmtpage.ClickCreateUserBtn();
            createuserwindow.SelectTitleByIndex();
            createuserwindow.SelectTitleByVisibleTxt();
            createuserwindow.PrintAllOptionsForTitle();
 
        }
#endregion

        #region Practice8
        [TestMethod]
        public void Practice8() 
        {
            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage = new ACE_HomePage(Browser.Driver);
            var dockpage = new ACE_DockStationPage(Browser.Driver);
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]);

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);
            
            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());

            homepage.OpenDockingStationsLink();
            CommonActions.GetTableData("//*[@id='ctl00_ctl00_MasterPageContent_cpv_listAGWs_itemPlaceholderContainer']");
            dockpage.GetTableData();
        }
        #endregion

        #region Practice9
        [TestMethod]
        public void Pratice9()
        {
            var QApage = new OpenQAPage(Browser.Driver);
            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["OpenQASwitchWindow"]);
            QApage.ClickTimingAlertButton();
            CommonActions.ExplicitWaitForAlerts(5);
            QApage.AcceptAlert();
        }
        #endregion

        #region Practice10
        [TestMethod]
        public void Practice10() 
        {
            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage = new ACE_HomePage(Browser.Driver);
            var pumpspage = new ACE_PumpsPage(Browser.Driver);
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]);

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);
            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());

            homepage.OpenPumpsLink();

            pumpspage.ClickFilter();
            Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            pumpspage.SelectConnectionStatusConnected();
            pumpspage._ApplyFilterButton_Btn.Click();

            Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            pumpspage.SelectConnectionStatusImported();
            pumpspage._ApplyFilterButton_Btn.Click();

        }
        #endregion

        #region Practice11
        [TestMethod]
        public void Practice11()
        {
       
            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["OpenQAPracticePage"]);
            var openQA = new OpenQAPage(Browser.Driver);
            //Select all elements and print all selection
            openQA.PlaywithSelection();
        }
        #endregion

        #region Practice12
        [TestMethod]
        public void Practice12()
        {
            // Navigate to URL
            Browser.Navigate(ConfigurationManager.AppSettings["OpenQAPracticeSwitchWindow"]);

            var openQApage = new OpenQAPage(Browser.Driver);

            //get the current window name and store it in a variable
            var FirstPageName = Browser.Driver.CurrentWindowHandle;

            //Click Switch to window button
            openQApage.ClickSwithToWindowButton();

            if (Browser.Driver.WindowHandles.Count > 0)
            {
                //get all the windows names in current browser instance
                System.Collections.ObjectModel.ReadOnlyCollection<string> CurrentWindowsHandle = Browser.Driver.WindowHandles;

                foreach (string WindowHandle in Browser.Driver.WindowHandles)
                {
                    Console.Out.WriteLine("Current Window Handle: " + WindowHandle);
                }
            }

            //Switch back to the 1st window
            CommonActions.SwitchTo(FirstPageName); 
        }
        #endregion

        #region Practice13
        [TestMethod]
        public void Practice13()
        {
            // Navigate to URL
            Browser.Navigate(ConfigurationManager.AppSettings["OpenQAPracticeSwitchWindow"]);

            var openQApage = new OpenQAPage(Browser.Driver);

            openQApage.ClickAlertButton();

            CommonActions.ExplicitWaitForAlerts(5);
            Browser.Driver.SwitchTo().Alert().Accept();
 
        }
        #endregion

        #region Upload Files
        [TestMethod]
        public void UploadFiles()
        {
            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage = new ACE_HomePage(Browser.Driver);
            var datasetadmin = new ACE_AdministrationDatasetPage(Browser.Driver);
            
            ExcelDataReader excelDataReader = new ExcelDataReader();
            var result = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["CredentialsWorkbook"]);

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);

            loginpage.login(result.Rows[0][0].ToString(), result.Rows[0][1].ToString());

            Browser.Navigate(ConfigurationManager.AppSettings["ACEDatasetADministrationPage"]);

            datasetadmin.Import();

            datasetadmin.FillUploaderPassword(result.Rows[0][1].ToString());

            datasetadmin.ClickSubmitButton();

            datasetadmin.ClickBrowseButton();

            ExcelDataReader excelDataReader2 = new ExcelDataReader();
            var result2 = excelDataReader.ReadDataWithOleDB(CommonActions.GetFileLocation(ConfigurationManager.AppSettings["FileLocation"]), ConfigurationManager.AppSettings["DatasetFilesLocation"]);

            datasetadmin.SubmitFileDialog(result2.Rows[0][0].ToString());

            CommonActions.implicitWait(5);

            datasetadmin.ClickContinueButton();

            datasetadmin.ProvideDScode(result2.Rows[0][1].ToString());

            datasetadmin.ClickImportDSbutton();

            CommonActions.implicitWait(5);

            var tableresults = CommonActions.GetTableData("//*[@id='ctl00_ctl00_MasterPageContent_cpv_lstDatasets_itemPlaceholderContainer']");

          // var tableresults =  datasetadmin.getTableData();

           Assert.IsTrue(tableresults.Contains(result2.Rows[0][1].ToString()));

 
        }
        #endregion

        #region Login using DDT
        [TestMethod]
        [DataSource(providerInvariantName:"System.Data.OleDb",
            connectionString:"Data Source= E:\\visual studio 2013\\Projects\\UnitTestProject1\\UnitTestProject1\\DataSource\\TestData.xlsx ; Provider='Microsoft.ACE.OLEDB.12.0'; Extended Properties='Excel 12.0 Xml;HDR=YES'",
            tableName: "Credentials$",
            dataAccessMethod: DataAccessMethod.Sequential)]
        public void LoginWithDDT() 
        {
            var loginpage = new ACE_LoginPage(Browser.Driver);
            var homepage = new ACE_HomePage(Browser.Driver);
            var datasetadmin = new ACE_AdministrationDatasetPage(Browser.Driver);

            Browser.Navigate(System.Configuration.ConfigurationManager.AppSettings["ACEHomePage"]);

            loginpage.login(testContextInstance.DataRow[0].ToString(), testContextInstance.DataRow[1].ToString());

        }
        #endregion

        #region Cleanup Procedure
        [TestCleanup]
        public void EndTest() 
        {
            CommonActions.CleanUp();
        }
        #endregion
    }
}
