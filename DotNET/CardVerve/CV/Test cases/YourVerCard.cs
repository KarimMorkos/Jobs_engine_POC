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

    [TestClass]


    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(ChromeDriver))]



    public class YourVerCard<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        private IWebDriver _driver;

        [Test]
        public void YourVerCard_Desktop()
        {

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(), "1.4 Verve - wo rez#");

            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.4 Verve - wo rez#");

            int Datacount = table.Rows.Count;
            int counter = 0;
        Next:
            for (int i = counter; i < Datacount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());

                _driver = new TWebDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourVerCardUrl"].ToString());


                #region page init

                var _homepage = new YourVerCard_HomePage(_driver);
                var _page1 = new YourVerCard_Step1_Page(_driver);
                var _page2 = new YourVerCard_Step2_Page(_driver);
                var _page3 = new YourVerCard_Step3_Page(_driver);
                var _page4 = new YourVerCard_Step4_Page(_driver);
                var _ConfPage = new YourVerCard_Confirmation_Page(_driver);

                #endregion

               // _homepage.ClickNoReservationButton();


                #region FillingdataPage1


                _page1.FillStepOneEntries();
                _page1.ClickNextButton();
                #endregion FillingdataPage1


                #region FillingdataPage2

                _page2.FillStepTwoEntries(i);
                _page2.AdditionalCardNo();
                _page2.YesHaveCreditCard();
                _page2.ClickNextButton();
                #endregion


                #region FillingDataPage3


                _page3.FillStepThreeEntries();

                #endregion


                #region FillingDataPage4
                _page4._Agree.Click();
                _page4.AgreeAndSubmit();
                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();
                #endregion

                _ConfPage.GetReferenceNumber();

                Assert.IsTrue(_driver.PageSource.Contains(ExpectedResult));


                if (i < Datacount)
                {
                    counter++;
                    _driver.Close();
                    goto Next;
                }


            }

            _driver.Close();
            _driver.Quit();
        }


        [Test]
        public void YourVerCard_Mobile()
        {


            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(), "1.4 Verve - wo rez#");

            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.4 Verve - wo rez#");

            int Datacount = table.Rows.Count;
            int counter = 0;
        Next:
            for (int i = counter; i < Datacount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());

                _driver = new TWebDriver();
                _driver.Manage().Window.Size = new Size(480, 320);
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourVerCardUrl"].ToString());


                #region page init

                var _homepage = new YourVerCard_HomePage(_driver);
                var _page1 = new YourVerCard_Step1_Page(_driver);
                var _page2 = new YourVerCard_Step2_Page(_driver);
                var _page3 = new YourVerCard_Step3_Page(_driver);
                var _page4 = new YourVerCard_Step4_Page(_driver);
                var _ConfPage = new YourVerCard_Confirmation_Page(_driver);

                #endregion

               // _homepage.ClickNoReservationButton();


                #region FillingdataPage1


                _page1.FillStepOneEntries();
                _page1.ClickNextButton();
                #endregion FillingdataPage1


                #region FillingdataPage2

                _page2.FillStepTwoEntries(i);
                _page2.AdditionalCardNo();
                _page2.YesHaveCreditCard();
                _page2.ClickNextButton();
                #endregion


                #region FillingDataPage3


                _page3.FillStepThreeEntries();

                #endregion


                #region FillingDataPage4
                _page4._Agree.Click();
                _page4.AgreeAndSubmit();
                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();
                #endregion

              //  _ConfPage.GetReferenceNumber();

              //  Assert.IsTrue(_driver.PageSource.Contains(ExpectedResult));


                if (i < Datacount)
                {
                    counter++;
                    _driver.Close();
                    goto Next;
                }


            }

            _driver.Close();
            _driver.Quit();


        }
    }
}
