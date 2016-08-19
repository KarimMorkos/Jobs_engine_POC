using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System.Threading;
using System.Collections;
using CV.DataSource;

namespace PageObjects
{
    public class YourSurgeCard_Step2_Page
    {
        #region PageObjects

        [FindsBy(How = How.Id, Using = "birth_date")]
        public IWebElement _DOB;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[1]/div[2]/input")]
        public IWebElement _SSN;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[1]/div[3]/input")]
        public IWebElement _GrossMonthlyIncome;


        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[2]/div/input[1]")]
        public IWebElement _HaveCreditYes;


        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[2]/div/input[2]")]
        public IWebElement _HaveCreditNo;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[3]/input[1]")]
        public IWebElement _AdditionalCardYes;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[3]/input[2]")]
        public IWebElement _AdditionalCardNO;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[3]")]
        public IWebElement _NextButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[2]")]
        public IWebElement _PreviousButton;

        #endregion


        public YourSurgeCard_Step2_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }
      
        public void FillStepTwoEntries(int Iteration)
        {
            try
            {
                


                #region FillingdataPage2
                ArrayList x = DataGeneration.DataGeneration_YourVerCard();
                Thread.Sleep(2000);
                _DOB.Clear();
                _DOB.SendKeys(x[10].ToString());

                Thread.Sleep(2000);
                //_page2._SSN.Clear();
                _SSN.SendKeys(Excel_Translator.ReadData(Iteration + 1, "SSN").ToString());

                Thread.Sleep(2000);
                _GrossMonthlyIncome.Clear();
                _GrossMonthlyIncome.SendKeys((x[11].ToString()));
                YesHaveCreditCard();
                AdditionalCardNo();
                ClickNextButton();
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString());}


        }

        public void YesHaveCreditCard() 
        {
            Thread.Sleep(2000);
            _HaveCreditYes.Click();
        }

        public void HaveNoCreditCard()
        {
            Thread.Sleep(2000);
            _HaveCreditNo.Click();
        }

        public void AdditionalCardYes()
        {
            Thread.Sleep(2000);
            _AdditionalCardYes.Click();
        }

        public void AdditionalCardNo()
        {
            Thread.Sleep(2000);
            _AdditionalCardNO.Click();
        }
        public void ClickNextButton() 
        {
            Thread.Sleep(2000);
            _NextButton.Click();
        }

        public void ClickPrevious()
        {
            Thread.Sleep(2000);
            _PreviousButton.Click();
        }
        #endregion

    }
}