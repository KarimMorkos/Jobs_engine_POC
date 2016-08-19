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
    public class YourCreditSurgeStep2_Page
    {
        #region PageObjects

        //DOB Month DropDown
        [FindsBy(How = How.Id, Using = "DOB_MONTH")]
        public IWebElement _DOB_MONTH_DDL;

        //DOB Day DropDown
        [FindsBy(How = How.Id, Using = "DOB_DAY")]
        public IWebElement _DOB_DAY_DDL;


        //DOB Year DropDown
        [FindsBy(How = How.Id, Using = "DOB_YEAR")]
        public IWebElement _DOB_YEAR_DDL;


        // 1st SSN Field
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[3]/div[2]/div/div/div/div/div[1]/input")]
        public IWebElement _SSN_Fld1;

        // 2nd SSN Field
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[3]/div[2]/div/div/div/div/div[2]/input")]
        public IWebElement _SSN_Fld2;

        // 3rd SSN Field
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[3]/div[2]/div/div/div/div/div[3]/input")]
        public IWebElement _SSN_Fld3;
         
        //Gross Monthly Income Field  
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[4]/div/div/label/input")]
        public IWebElement _GrossMonthlyIncome;

        //Have credit Card
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[5]/div/div/div/input[1]")]
        public IWebElement _HaveCreditYes;

        //Don't have Credit Card
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[6]/div/div/div/input[2]")]
        public IWebElement _HaveCreditNo;

        // Like to issue additional card
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[6]/div/div/div/input[1]")]
        public IWebElement _AdditionalCardYes;

        //Don't like to issue additional card
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[6]/div/div/div/input[2]")]
        public IWebElement _AdditionalCardNO;

        //Continue to next Step button
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[6]/div[2]/div/div[9]/div/button")]
        public IWebElement _NextButton;


        #endregion


        public YourCreditSurgeStep2_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }
        # region Methods
        public void FillStepTwoEntries(int Iteration)
        {
            try
            {
                ArrayList x = DataGeneration.DataGeneration_YourVerCard();
                Thread.Sleep(2000);

                _DOB_DAY_DDL.SendKeys(x[10].ToString());



                _DOB_MONTH_DDL.SendKeys(x[10].ToString());


                _DOB_YEAR_DDL.SendKeys("1980");


                Thread.Sleep(2000);
                _SSN_Fld1.Clear();
                var SSN1 = Excel_Translator.ReadData(Iteration + 1, "SSN Format").ToString().Substring(0, 3);
                var SSN2 = Excel_Translator.ReadData(Iteration + 1, "SSN Format").ToString().Substring(3, 2);
                var SSN3 = Excel_Translator.ReadData(Iteration + 1, "SSN Format").ToString().Substring(5, 4);

                _SSN_Fld1.SendKeys(SSN1);
                _SSN_Fld1.SendKeys(Keys.Tab);
                _SSN_Fld2.SendKeys(SSN2);
                _SSN_Fld2.SendKeys(Keys.Tab);
                _SSN_Fld3.SendKeys(SSN3);

                Thread.Sleep(2000);
                _GrossMonthlyIncome.Clear();
                _GrossMonthlyIncome.SendKeys((x[11].ToString()));
                YesHaveCreditCard();
                AdditionalCardNo();
                ClickNextButton();
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