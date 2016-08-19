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
using OpenQA.Selenium.IE;
using System.Drawing;
using OpenQA.Selenium.Firefox;


namespace CV
{

    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class TestYourSurgeCard<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        private IWebDriver _driver;
        [TestMethod]
        [TestCase()]
        public void TestYourSurgeCard_Desktop()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.4 Verve - wo rez#");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.4 Verve - wo rez#");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourVerCardUrl"].ToString());

                #region page init

                var _homepage = new YourVerCard_HomePage(_driver);
                var _page1 = new TestYourSurgeCard_Step1_Page(_driver);
                var _page2 = new TestYourSurgeCard_Step2_Page(_driver);
                var _page3 = new TestYourSurgeCard_Step3_Page(_driver);
                var _page4 = new TestYourSurgeCard_Step4_Page(_driver);
                var _ConfPage = new TestYourSurgeCard_Confirmation_Page(_driver);

                #endregion

                // _homepage.ClickNoReservationButton();


                #region  Fill Step1 Entries

                _page1.FillStepOneEntries();
                _page1.ClickNextButton();

                #endregion FillingdataPage1


                #region Fill Step2 Entries

                _page2.FillStepTwoEntries(i);
                _page2.YesHaveCreditCard();
                _page2.AdditionalCardNo();
                _page2.ClickNextButton();

                #endregion


                #region Fill Step3 Entries

                _page3.FillStepThreeEntries();


                #endregion


                #region Fill Step4 Entries

                _page4.AgreeAndSubmit();
                _page4.ClickSignAndSubmit();

                #endregion

                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();
                _ConfPage.GetReferenceNumber();

                Assert.IsTrue(_driver.PageSource.Contains(ExpectedResult));


                if (i < DataCount)
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
        public void TestYourSurgeCard_Mobile()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.4 Verve - wo rez#");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.4 Verve - wo rez#");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Size = new Size(480, 320);
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["TestYourSurgeCardUrl"].ToString());

                #region page init

                var _homepage = new YourVerCard_HomePage(_driver);
                var _page1 = new TestYourSurgeCard_Step1_Page(_driver);
                var _page2 = new TestYourSurgeCard_Step2_Page(_driver);
                var _page3 = new TestYourSurgeCard_Step3_Page(_driver);
                var _page4 = new TestYourSurgeCard_Step4_Page(_driver);
                var _ConfPage = new TestYourSurgeCard_Confirmation_Page(_driver);

                #endregion

                // _homepage.ClickNoReservationButton();


                #region  Fill Step1 Entries

                _page1.FillStepOneEntries();
                _page1.ClickNextButton();

                #endregion FillingdataPage1


                #region Fill Step2 Entries

                _page2.FillStepTwoEntries(i);
                _page2.YesHaveCreditCard();
                _page2.AdditionalCardNo();
                _page2.ClickNextButton();

                #endregion


                #region Fill Step3 Entries

                _page3.FillStepThreeEntries();


                #endregion


                #region Fill Step4 Entries

                _page4.AgreeAndSubmit();
                _page4.ClickSignAndSubmit();

                #endregion

                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();


                _ConfPage.GetReferenceNumber();

                Assert.IsTrue(_driver.PageSource.Contains(ExpectedResult));


                if (i < DataCount)
                {
                    counter++;
                    _driver.Close();
                    goto Next;
                }


            }

            _driver.Close();
            _driver.Quit();
        }

        [TestMethod]
        [TestCase()]
        public void TestYourSurgeCard_Desktop_withRegistered()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.6 Surge-DM - w rez#");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.6 Surge-DM - w rez#");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

                var ReservationNo = (Excel_Translator.ReadData(i + 1, "ReservationNo").ToString());
                var SSN = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());

                _driver = new TWebDriver();
               
                _driver.Manage().Window.Maximize();

                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourSurgeCardUrlReg"].ToString());

                #region page init

                var _homepage = new TestYourSurgeCard__HomePage(_driver);
                var _page1 = new TestYourSurgeCard_Step1_Page(_driver);
                var _page2 = new TestYourSurgeCard_Step2_Page(_driver);
                var _page3 = new TestYourSurgeCard_Step3_Page(_driver);
                var _page4 = new TestYourSurgeCard_Step4_Page(_driver);
                var _ConfPage = new TestYourSurgeCard_Confirmation_Page(_driver);

                #endregion
                _homepage._ReservationNo_Txt.Clear();
                _homepage._ReservationNo_Txt.SendKeys(ReservationNo);
                _homepage._SSN_Txt.Clear();
                _homepage._SSN_Txt.SendKeys(SSN);
                _homepage._ConfirmReservation_Btn.Click();

                #region  Fill Step1 Entries


                _page1.FillStepOneEntries_reg();
                string Init = _page1.GetInit_reg();
                _page1._NextButton_reg.Click();
                #endregion FillingdataPage1


                #region Fill Step2 Entries


                _page2.FillStepTwoEntries_reg();
                #endregion


                #region Fill Step3 Entries


                _page3.FillStepThreeEntries_reg(Init);

                #endregion


                #region Fill Step4 Entries

                _page4.AgreeAndSubmit();
                _page4._AgreeAndSubmit_reg.Click();

                #endregion

                  var ExpectedResult = Excel_Translator.ReadData(i + 1, "Expected").ToString();
                _ConfPage.GetReferenceNumber();

                 Assert.IsTrue(_driver.PageSource.Contains(ExpectedResult));


                if (i < DataCount)
                {
                    counter++;
                    _driver.Close();
                    goto Next;
                }


            }

            _driver.Close();
            _driver.Quit();
        }

        [TestMethod]
        [TestCase()]
        public void TestYourSurgeCard_Mobile_withRegistered()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.6 Surge-DM - w rez#");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.6 Surge-DM - w rez#");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

                var ReservationNo = (Excel_Translator.ReadData(i + 1, "ReservationNo").ToString());
                var SSN = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Size = new Size(480, 320);

                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourSurgeCardUrlReg"].ToString());

                #region page init

                var _homepage = new TestYourSurgeCard__HomePage(_driver);
                var _page1 = new TestYourSurgeCard_Step1_Page(_driver);
                var _page2 = new TestYourSurgeCard_Step2_Page(_driver);
                var _page3 = new TestYourSurgeCard_Step3_Page(_driver);
                var _page4 = new TestYourSurgeCard_Step4_Page(_driver);
                var _ConfPage = new TestYourSurgeCard_Confirmation_Page(_driver);

                #endregion
                _homepage._ReservationNo_Txt.Clear();
                _homepage._ReservationNo_Txt.SendKeys(ReservationNo);
                _homepage._SSN_Txt.Clear();
                _homepage._SSN_Txt.SendKeys(SSN);
                _homepage._ConfirmReservation_Btn.Click();

                #region  Fill Step1 Entries


                _page1.FillStepOneEntries_reg();
                string Init = _page1.GetInit_reg();
                _page1._NextButton_reg.Click();
                #endregion FillingdataPage1


                #region Fill Step2 Entries


                _page2.FillStepTwoEntries_reg();
                #endregion


                #region Fill Step3 Entries


                _page3.FillStepThreeEntries_reg(Init);

                #endregion


                #region Fill Step4 Entries

                _page4.AgreeAndSubmit();
                _page4._AgreeAndSubmit_reg.Click();

                #endregion

                  var ExpectedResult = Excel_Translator.ReadData(i + 1, "Expected").ToString();
                _ConfPage.GetReferenceNumber();

                 Assert.IsTrue(_driver.PageSource.Contains(ExpectedResult));


                if (i < DataCount)
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






























