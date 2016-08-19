using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System.Configuration;


namespace PageObjects
{
   public class WebTest_Home_Step1_Page

    {
        #region
       [FindsBy(How = How.Id, Using = "entry_first_name")]
       public IWebElement _FirstName;

       [FindsBy(How = How.Id, Using = "entry_mi")]
       public IWebElement _MiddInitial;

       [FindsBy(How = How.Id, Using = "entry_last_name")]
       public IWebElement _LastName;


       [FindsBy(How = How.Id, Using = "entry_address")]
       public IWebElement _Address;

       [FindsBy(How = How.Id, Using = "entry_apt")]
       public IWebElement _Apt;

       [FindsBy(How = How.Id, Using = "entry_city")]
       public IWebElement _City;

       [FindsBy(How = How.ClassName, Using = "entry_state")]
       public IWebElement _StateDropDownList;

       [FindsBy(How = How.Id, Using = "entry_zip")]
       public IWebElement _ZipCode;

       [FindsBy(How = How.Id, Using = "entry_email")]
       public IWebElement _EmailAddress;

       [FindsBy(How = How.Id, Using = "entry_primary_phone")]
       public IWebElement _PrimaryPhone;

       [FindsBy(How = How.Id, Using = "entry_secondary_phone")]
       public IWebElement _SecondaryPhone;


       [FindsBy(How = How.Id, Using = "entry_has_checking_account_yes")]
       public IWebElement _HasCheckingYes;

       [FindsBy(How = How.Id, Using = "entry_has_checking_account_no")]
       public IWebElement _HasCheckingNo;
     
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[3]")]
       public IWebElement _NextButton;

        #endregion

       public WebTest_Home_Step1_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

       public void FillStepOneEntries() 
       {
           try
           {
               Thread.Sleep(1000);
               _FirstName.Clear();
               _FirstName.SendKeys("");

               Thread.Sleep(1000);
               _MiddInitial.Clear();
               _MiddInitial.SendKeys("");

               Thread.Sleep(1000);
               _LastName.Clear();
               _LastName.SendKeys("");

               Thread.Sleep(1000);
               _Address.Clear();
               _Address.SendKeys("");

               Thread.Sleep(1000);
               _City.Clear();
               _City.SendKeys("");

               Thread.Sleep(1000);
               _StateDropDownList.SendKeys("");

               Thread.Sleep(1000);
               _ZipCode.Clear();
               _ZipCode.SendKeys("");

               Thread.Sleep(1000);
               _EmailAddress.Clear();
               _EmailAddress.SendKeys("");

               Thread.Sleep(1000);
               _PrimaryPhone.Clear();
               _PrimaryPhone.SendKeys("");

               Thread.Sleep(1000);
               _SecondaryPhone.Clear();
               _SecondaryPhone.SendKeys("");

               
           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
}

       //Have Checking Account
       public void HasChecking_Yes() 
       {
           try
           {
               _HasCheckingYes.Click();
           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
       }

       // Don't have Checking Account
       public void Haschecking_NO() 
       {
           try
           {
               _HasCheckingNo.Click();
           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
       }

       // click Next button
       public void ClickNextButton()
       {
           try
           {
               _NextButton.Click();
           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
       }

    }
}
