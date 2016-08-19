using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System.Collections;
using CV.DataSource;
using System.Threading;

namespace PageObjects
{
   public class YourCreditSurgeStep1_Page
    {
        //Home Page "http://yourcreditsurge.jbrdevelopment.com/SurgeMC/ApplyStepOne.aspx?sid=9901&cd=501859&hid=123459901"
       // This for the application Step1 
        #region PageObjects
       
       // First Name Field
       [FindsBy(How = How.Id, Using = "FIRST_NAME")]
       public IWebElement _FIRST_NAME_Txt;


       // Middle Name Field
       [FindsBy(How = How.Id, Using = "MIDDLE_NAME")]
       public IWebElement _MIDDLE_NAME_Txt;


       // Last Name Field
       [FindsBy(How = How.Id, Using = "LAST_NAME")]
       public IWebElement _LAST_NAME_Txt;


       // Home Address Field
       [FindsBy(How = How.Id, Using = "ADDRESS1")]
       public IWebElement _ADDRESS1_Txt;

       // Address 2
       [FindsBy(How = How.Id, Using = "ADDRESS2")]
       public IWebElement _ADDRESS2_Txt;

       // City Field
       [FindsBy(How = How.Id, Using = "CITY")]
       public IWebElement _CITY_Txt;

       // State Drop Down
       [FindsBy(How = How.Id, Using = "STATE")]
       public IWebElement _STATE_DDL;

       //Zip Code Field
       [FindsBy(How = How.Id, Using = "ZIP")]
       public IWebElement _ZIP_Txt;

       //Email Address Field
       [FindsBy(How = How.Id, Using = "EMAIL")]
       public IWebElement _EMAIL_Txt;

       // Home Phone Area Field
       [FindsBy(How = How.Id, Using = "HOME_PHONE_AREA")]
       public IWebElement _HOME_PHONE_AREA_Txt;

       // Home Phone Prefix Field
       [FindsBy(How = How.Id, Using = "HOME_PHONE_PREFIX")]
       public IWebElement _HOME_PHONE_PREFIX_Txt;

       // Home Phone Suffix Field
       [FindsBy(How = How.Id, Using = "HOME_PHONE_SUFFIX")]
       public IWebElement _HOME_PHONE_SUFFIX_Txt;


       // Mobile Phone Area Field
       [FindsBy(How = How.Id, Using = "MOBILE_PHONE_AREA")]
       public IWebElement _MOBILE_PHONE_AREA_Txt;

       // Mobile Phone Prefix Field
       [FindsBy(How = How.Id, Using = "MOBILE_PHONE_PREFIX")]
       public IWebElement _MOBILE_PHONE_PREFIX_Txt;

       // Mobile Phone Suffix Field
       [FindsBy(How = How.Id, Using = "MOBILE_PHONE_SUFFIX")]
       public IWebElement _MOBILE_PHONE_SUFFIX_Txt;

       // Have Active Checking Account Radio
       [FindsBy(How = How.Id, Using = "rbtnHasCheckingAccountYes")]
       public IWebElement _HasCheckingAccountYes_rbtn;

       // Have NO Active Checking Account Radio
       [FindsBy(How = How.Id, Using = "rbtnHasCheckingAccountNo")]
       public IWebElement _HasCheckingAccountNO_rbtn;

       // I Certify My US Residency
       [FindsBy(How = How.Id , Using = "TERMS")]
       public IWebElement _TERMS_ChkBox;

       // Terms Agreement Second Check box
       [FindsBy(How = How.Id, Using = "TERMS2")]
       public IWebElement _TERMS2_ChkBox;

       //Continue Your Application Button
       [FindsBy(How = How.Id, Using = "SUBMIT")]
       public IWebElement _SUBMIT_Btn;

        #endregion



        public YourCreditSurgeStep1_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

        public void FillStepOneEntries()
        {
            try
            {
                ArrayList x = DataGeneration.DataGeneration_YourVerCard();
                Thread.Sleep(1000);
                
                
                _FIRST_NAME_Txt.SendKeys(x[0].ToString());

                Thread.Sleep(1000);
                _MIDDLE_NAME_Txt.Clear();
                _MIDDLE_NAME_Txt.SendKeys(x[1].ToString());

                Thread.Sleep(1000);
                _LAST_NAME_Txt.Clear();
                _LAST_NAME_Txt.SendKeys(x[2].ToString());

                Thread.Sleep(1000);
                _ADDRESS1_Txt.Clear();
                _ADDRESS1_Txt.SendKeys("2306 York Road");

                Thread.Sleep(1000);
                _CITY_Txt.Clear();
                _CITY_Txt.SendKeys("Timonium");

                Thread.Sleep(1000);
                _STATE_DDL.SendKeys("MD");

                Thread.Sleep(1000);
                _ZIP_Txt.Clear();
                _ZIP_Txt.SendKeys("21093");

                Thread.Sleep(1000);
                _EMAIL_Txt.Clear();
                _EMAIL_Txt.SendKeys(x[7].ToString());

                Thread.Sleep(1000);
                _HOME_PHONE_PREFIX_Txt.Clear();
                _HOME_PHONE_PREFIX_Txt.SendKeys(x[8].ToString());
                _HOME_PHONE_AREA_Txt.SendKeys(x[8].ToString());
                _HOME_PHONE_SUFFIX_Txt.SendKeys(x[8].ToString());

                Thread.Sleep(1000);
                _MOBILE_PHONE_PREFIX_Txt.SendKeys(x[8].ToString());
                _MOBILE_PHONE_AREA_Txt.SendKeys(x[8].ToString());
                _MOBILE_PHONE_SUFFIX_Txt.SendKeys(x[8].ToString());

                Thread.Sleep(1000);
                _HasCheckingAccountYes_rbtn.Click();
                _TERMS2_ChkBox.Click();
                _TERMS_ChkBox.Click();
                _SUBMIT_Btn.Click();
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
        }

    

    }
}
