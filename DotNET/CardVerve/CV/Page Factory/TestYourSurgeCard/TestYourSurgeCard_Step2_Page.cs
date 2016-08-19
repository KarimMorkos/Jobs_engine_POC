using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System.Threading;
using CV.DataSource;

namespace CV
{
    public class TestYourSurgeCard_Step2_Page
    {
        #region PageObjects

        [FindsBy(How = How.Id, Using = "birth_date")]
        public IWebElement _DOB;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[3]/div[2]/div[1]/div[2]/input")]
        public IWebElement _SSN;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[3]/div[2]/div[1]/div[3]/input")]
        public IWebElement _GrossMonthlyIncome;


        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[3]/div[2]/div[2]/div/input[1]")]
        public IWebElement _HaveCreditYes;


        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[2]/div/input[2]")]
        public IWebElement _HaveCreditNo;
    
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[3]/input[1]")]
        public IWebElement _AdditionalCardYes;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[3]/div[2]/div[3]/input[2]")]
        public IWebElement _AdditionalCardNO;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[8]/button[2]")]
        public IWebElement _NextButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[2]")]
        public IWebElement _PreviousButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[1]/div[3]/input")]
        public IWebElement _Gross_Reg;
       
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[2]/div/input[1]")]
        public IWebElement _Credit_Yes_Reg;
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[4]/div[2]/div[3]/input[2]")]
        public IWebElement _Credit_No_Reg;

        [FindsBy(How = How.XPath, Using ="//*[@id='validated_form']/div/div[10]/button[2]")]
        public IWebElement _Next_Reg;

        
        #endregion


        public TestYourSurgeCard_Step2_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }
        # region Methods
        public void FillStepTwoEntries(int Iteration )
        {
            try
            {
                
                ArrayList x = DataGeneration.DataGeneration_YourVerCard();
                Thread.Sleep(2000);
                _DOB.Clear();
                _DOB.SendKeys(x[10].ToString());

                Thread.Sleep(2000);
                _SSN.Clear();
                _SSN.SendKeys(Excel_Translator.ReadData(Iteration + 1, "SSN Format").ToString());

                Thread.Sleep(2000);
                _GrossMonthlyIncome.Clear();
                _GrossMonthlyIncome.SendKeys((x[11].ToString()));
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString());}


        }
        public void FillStepTwoEntries_reg()
        {
            try
            {
                ArrayList x = DataGeneration.DataGeneration_YourVerCard();
                Thread.Sleep(2000);
                _DOB.Clear();
                _DOB.SendKeys(x[10].ToString());
                Thread.Sleep(2000);
                _Gross_Reg.Clear();
                _Gross_Reg.SendKeys((x[11].ToString()));
                _Credit_No_Reg.Click();
                _Credit_Yes_Reg.Click();
                _Next_Reg.Click();
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }


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

        
        #endregion

    }
}