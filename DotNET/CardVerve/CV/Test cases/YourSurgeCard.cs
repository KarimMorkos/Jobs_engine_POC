using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using CV.DataSource;
using Excel.Log;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Constraints;
using OfficeOpenXml;
using PageObjects;
using NUnit;
using OfficeOpenXml.ConditionalFormatting;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Drawing;


namespace CV
{


    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(ChromeDriver))]

    public class YourSurgeCard<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        private IWebDriver _driver;

        [TestMethod]
        [TestCase()]
        public void YourSurgeCard_Desktop()
        {
           
            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.7 Surge-DM - wo rez#");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.7 Surge-DM - wo rez#");

            int DataCounter = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCounter; i++)
            {
               
                _driver = new TWebDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourSurgeCardUrl"].ToString());

                

                #region page init

                // var _homepage = new HomePage(Browser.Driver);
                var _page1 = new TestYourSurgeCard_Step1_Page(_driver);
                var _page2 = new TestYourSurgeCard_Step2_Page(_driver);
                var _page3 = new TestYourSurgeCard_Step3_Page(_driver);
                var _page4 = new TestYourSurgeCard_Step4_Page(_driver);
                var _ConfPage = new TestYourSurgeCard_Confirmation_Page(_driver);

                #endregion

                // _homepage.ClickNoReservationButton();



                _page1.FillStepOneEntries();
                _page1.ClickNextButton();

                #region FillingdataPage2
                _page2.FillStepTwoEntries(i);
                _page2.YesHaveCreditCard();
                _page2.AdditionalCardNo();
                _page2.ClickNextButton();

                #endregion


                #region FillingDataPage3

                _page3.FillStepThreeEntries();

                #endregion


                #region FillingDataPage4

                _page4.AgreeAndSubmit();

                #endregion

                _ConfPage.GetReferenceNumber();

                Assert.IsTrue(_driver.PageSource.Contains(Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString()));


                if (i < DataCounter)
                {
                    counter++;

                    goto Next;
                }
               
            }

            _driver.Close();
            _driver.Quit();
        }
            [Test]
        public void YourSurgeCard_Mobile()
        {

               
            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.7 Surge-DM - wo rez#");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.7 Surge-DM - wo rez#");

            int DataCounter = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCounter; i++)
            {
               
                _driver = new TWebDriver();

                 _driver.Manage().Window.Size = new Size(480, 320);
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourSurgeCardUrl"].ToString());

                

                #region page init

                // var _homepage = new HomePage(Browser.Driver);
                var _page1 = new TestYourSurgeCard_Step1_Page(_driver);
                var _page2 = new TestYourSurgeCard_Step2_Page(_driver);
                var _page3 = new TestYourSurgeCard_Step3_Page(_driver);
                var _page4 = new TestYourSurgeCard_Step4_Page(_driver);
                var _ConfPage = new TestYourSurgeCard_Confirmation_Page(_driver);

                #endregion

                // _homepage.ClickNoReservationButton();



                _page1.FillStepOneEntries();
                _page1.ClickNextButton();

                #region FillingdataPage2
                _page2.FillStepTwoEntries(i);
                _page2.YesHaveCreditCard();
                _page2.AdditionalCardNo();
                _page2.ClickNextButton();

                #endregion


                #region FillingDataPage3

                _page3.FillStepThreeEntries();

                #endregion


                #region FillingDataPage4

                _page4.AgreeAndSubmit();

                #endregion

                _ConfPage.GetReferenceNumber();

                Assert.IsTrue(_driver.PageSource.Contains(Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString()));


                if (i < DataCounter)
                {
                    counter++;

                    goto Next;
                }
               
            }

            _driver.Close();
            _driver.Quit();
        }
    }
}

