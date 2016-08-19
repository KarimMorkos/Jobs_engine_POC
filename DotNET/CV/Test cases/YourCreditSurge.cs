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
using PageObjects;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium.IE;
using System.Drawing;
using OpenQA.Selenium.Firefox;
namespace CV
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class YourCreditSurge<TWebDriver> where TWebDriver : IWebDriver, new()
    {


        private IWebDriver _driver;
        [TestMethod]
        [TestCase()]
        public void YourCreditSurge_Desktop()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "2. Surge-iNet");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "2. Surge-iNet");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourCreditSurgeUrl"].ToString());

                #region page init

                var _page1 = new YourCreditSurgeStep1_Page(_driver);
                var _page2 = new YourCreditSurgeStep2_Page(_driver);
                var _page3 = new YourCreditSurgeStep3_Page(_driver);


                #endregion




                #region FillingdataPage1

                _page1.FillStepOneEntries();

                #endregion FillingdataPage1


                #region FillingdataPage2

                _page2.FillStepTwoEntries(i);

                #endregion


                #region FillingDataPage3

                _page3.FillStepThreeEntries();
                #endregion


                #region FillingDataPage4

                _page3._ACKAgrement_ChckBox.Click();
                _page3._SubmitButton.Click();

                #endregion
                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();

                //  _ConfPage.GetReferenceNumber();

                 Assert.IsTrue(Browser.Driver.PageSource.Contains(ExpectedResult));


                if (i < DataCount)
                {
                    counter++;

                    goto Next;
                }


            }

            _driver.Close();
            _driver.Quit();
        }
        [Test]
        public void YourCreditSurge_Mobile()
        {
          
            
            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "Surge-iNet");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "Surge-iNet");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

               
                _driver = new TWebDriver();
                _driver.Manage().Window.Size = new Size(480, 320);
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["YourCreditSurgeUrl"].ToString());

                #region page init

                var _page1 = new YourCreditSurgeStep1_Page(_driver);
                var _page2 = new YourCreditSurgeStep2_Page(_driver);
                var _page3 = new YourCreditSurgeStep3_Page(_driver);


                #endregion




                #region FillingdataPage1

                _page1.FillStepOneEntries();

                #endregion FillingdataPage1


                #region FillingdataPage2

                _page2.FillStepTwoEntries(i);

                #endregion


                #region FillingDataPage3

                _page3.FillStepThreeEntries();
                #endregion


                #region FillingDataPage4

                _page3._ACKAgrement_ChckBox.Click();
                _page3._SubmitButton.Click();

                #endregion
                var ExpectedResult = Excel_Translator.ReadData(i + 1, "RN Expected Result").ToString();

                //  _ConfPage.GetReferenceNumber();

                 Assert.IsTrue(Browser.Driver.PageSource.Contains(ExpectedResult));


                if (i < DataCount)
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
