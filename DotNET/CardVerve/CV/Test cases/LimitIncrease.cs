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
    public class LimitIncrease<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        private IWebDriver _driver;
        [TestMethod]
        [TestCase()]
        public void LimitIncrease_Desktop()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.8  Web – CLI");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.8  Web – CLI");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN Format").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["LimitIncreasePage"].ToString());

                #region page init

                var _homepage = new LimitIncrease_Home(_driver);
                
                #endregion


                #region  Fill Information Entries

                _homepage.FillInformationEntries();

                #endregion FillingdataPage1


                #region Submit Request

                _homepage.ClickSubmitButton();

                #endregion


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
        public void LimitIncrease_Mobile()
        {

            ArrayList x = DataGeneration.DataGeneration_YourVerCard();

            var table = Excel_Translator.ExcelToDataTable(Excel_Translator.GetDataFileLocation(),
                "1.8  Web – CLI");
            Excel_Translator.PopulateInCollection(Excel_Translator.GetDataFileLocation(), "1.8  Web – CLI");

            int DataCount = table.Rows.Count;

            int counter = 0;
        Next:
            for (int i = counter; i < DataCount; i++)
            {

                var result = (Excel_Translator.ReadData(i + 1, "SSN").ToString());
                _driver = new TWebDriver();
                _driver.Manage().Window.Size = new Size(480, 320);
                _driver.Navigate().GoToUrl(System.Configuration.ConfigurationManager.AppSettings["LimitIncreasePage"].ToString());

                #region page init

                var _homepage = new LimitIncrease_Home(_driver);

                #endregion

                #region  Fill Information Entries

                _homepage.FillInformationEntries();

                #endregion


                #region Submit Request

                _homepage.ClickSubmitButton();

                #endregion



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






























