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
    public class WebTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver _driver;
        [Test]
        public void WebTest_Desktop()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.2 Verve");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.2 Verve");

            int Datacount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < Datacount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(
                    System.Configuration.ConfigurationManager.AppSettings["WebTestUrl"].ToString());


                #region page init

                var _Home = new WebTest_Home(_driver);
                var _page1 = new WebTest_Home_Step1_Page(_driver);
                var _page2 = new WebTest_Home_PageStep2_Page(_driver);
                var _page3 = new WebTest_Home_Step3_Page(_driver);

                #endregion


                _Home._NOReserv_Btn.Click();

                Thread.Sleep(1000);
                _page1._FirstName.SendKeys(x[0].ToString());

                Thread.Sleep(1000);
                _page1._MiddInitial.Clear();
                _page1._MiddInitial.SendKeys(x[1].ToString());

                Thread.Sleep(1000);
                _page1._LastName.Clear();
                _page1._LastName.SendKeys(x[2].ToString());

                Thread.Sleep(1000);
                _page1._Address.Clear();
                _page1._Address.SendKeys(x[3].ToString());

                Thread.Sleep(1000);
                _page1._City.Clear();
                _page1._City.SendKeys(x[4].ToString());

                Thread.Sleep(1000);
                _page1._StateDropDownList.SendKeys("WY");

                Thread.Sleep(1000);
                _page1._ZipCode.Clear();
                _page1._ZipCode.SendKeys(x[6].ToString());

                Thread.Sleep(1000);
                _page1._EmailAddress.Clear();
                _page1._EmailAddress.SendKeys(x[7].ToString());

                Thread.Sleep(1000);
                _page1._PrimaryPhone.Clear();
                _page1._PrimaryPhone.SendKeys(x[8].ToString());

                Thread.Sleep(1000);
                _page1._SecondaryPhone.Clear();
                _page1._SecondaryPhone.SendKeys((x[9].ToString()));

                Thread.Sleep(1000);
                _page1._HasCheckingYes.Click();
                _page1.ClickNextButton();




                #region FillingdataPage2

                Thread.Sleep(2000);
                _page2._DOB.Clear();
                _page2._DOB.SendKeys(x[10].ToString());

                Thread.Sleep(2000);
                _page2._SSN.Clear();
                _page2._SSN.SendKeys(Excel_Translator.ReadData(i + 1, "SSN Format").ToString());

                Thread.Sleep(2000);
                _page2._GrossMonthlyIncome.Clear();
                _page2._GrossMonthlyIncome.SendKeys((x[11].ToString()));
                _page2.YesHaveCreditCard();
                _page2.AdditionalCardNo();
                _page2.ClickNextButton();

                #endregion


                #region FillingDataPage3

                _page3.Agree();
                Thread.Sleep(1000);
                _page3._CreditProtectionNo.Click();

                Thread.Sleep(1000);
                _page3._ConfirmInitials.SendKeys(x[12].ToString());
                _page3.ClickNext();

                #endregion





                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();


                  //_ConfPage.GetReferenceNumber();

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
        public void WebTest_Mobile()
        {



            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.2 Verve");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.2 Verve");

            int Datacount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < Datacount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Size = new Size(480, 320);
                _driver.Navigate().GoToUrl(
                    System.Configuration.ConfigurationManager.AppSettings["WebTestUrl"].ToString());


                #region page init

                var _Home = new WebTest_Home(Browser.Driver);
                var _page1 = new WebTest_Home_Step1_Page(_driver);
                var _page2 = new WebTest_Home_PageStep2_Page(_driver);
                var _page3 = new WebTest_Home_Step3_Page(_driver);

                #endregion


                _Home._NOReserv_Btn.Click();

                Thread.Sleep(1000);
                _page1._FirstName.SendKeys(x[0].ToString());

                Thread.Sleep(1000);
                _page1._MiddInitial.Clear();
                _page1._MiddInitial.SendKeys(x[1].ToString());

                Thread.Sleep(1000);
                _page1._LastName.Clear();
                _page1._LastName.SendKeys(x[2].ToString());

                Thread.Sleep(1000);
                _page1._Address.Clear();
                _page1._Address.SendKeys(x[3].ToString());

                Thread.Sleep(1000);
                _page1._City.Clear();
                _page1._City.SendKeys(x[4].ToString());

                Thread.Sleep(1000);
                _page1._StateDropDownList.SendKeys("WY");

                Thread.Sleep(1000);
                _page1._ZipCode.Clear();
                _page1._ZipCode.SendKeys(x[6].ToString());

                Thread.Sleep(1000);
                _page1._EmailAddress.Clear();
                _page1._EmailAddress.SendKeys(x[7].ToString());

                Thread.Sleep(1000);
                _page1._PrimaryPhone.Clear();
                _page1._PrimaryPhone.SendKeys(x[8].ToString());

                Thread.Sleep(1000);
                _page1._SecondaryPhone.Clear();
                _page1._SecondaryPhone.SendKeys((x[9].ToString()));

                Thread.Sleep(1000);
                _page1._HasCheckingYes.Click();
                _page1.ClickNextButton();




                #region FillingdataPage2

                Thread.Sleep(2000);
                _page2._DOB.Clear();
                _page2._DOB.SendKeys(x[10].ToString());

                Thread.Sleep(2000);
                _page2._SSN.Clear();
                _page2._SSN.SendKeys(Excel_Translator.ReadData(i + 1, "SSN Format").ToString());

                Thread.Sleep(2000);
                _page2._GrossMonthlyIncome.Clear();
                _page2._GrossMonthlyIncome.SendKeys((x[11].ToString()));
                _page2.YesHaveCreditCard();
                _page2.AdditionalCardNo();
                _page2.ClickNextButton();

                #endregion


                #region FillingDataPage3

                _page3.Agree();
                Thread.Sleep(1000);
                _page3._CreditProtectionNo.Click();

                Thread.Sleep(1000);
                _page3._ConfirmInitials.SendKeys(x[12].ToString());
                _page3.ClickNext();

                #endregion





                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();


                 // _ConfPage.GetReferenceNumber();

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

    }
}

