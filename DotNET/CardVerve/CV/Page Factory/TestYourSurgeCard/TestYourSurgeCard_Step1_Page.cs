using System;
using System.Collections;
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
using CV.DataSource;


namespace CV
{
   public class TestYourSurgeCard_Step1_Page
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

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[8]/button[2]")]
       public IWebElement _NextButton;

       
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[10]/button[2]")]
       public IWebElement _NextButton_reg;

        #endregion

       public TestYourSurgeCard_Step1_Page(IWebDriver driver)
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
               _FirstName.SendKeys(x[0].ToString());

               Thread.Sleep(1000);
               _MiddInitial.Clear();
               _MiddInitial.SendKeys(x[1].ToString());

               Thread.Sleep(1000);
               _LastName.Clear();
               _LastName.SendKeys(x[2].ToString());

               Thread.Sleep(1000);
               _Address.Clear();
               _Address.SendKeys(x[3].ToString());

               Thread.Sleep(1000);
               _City.Clear();
               _City.SendKeys(x[4].ToString());

               Thread.Sleep(1000);
               _StateDropDownList.SendKeys("WY");

               Thread.Sleep(1000);
               _ZipCode.Clear();
               _ZipCode.SendKeys(x[6].ToString());

               Thread.Sleep(1000);
               _EmailAddress.Clear();
               _EmailAddress.SendKeys(x[7].ToString());

               Thread.Sleep(1000);
               _PrimaryPhone.Clear();
               _PrimaryPhone.SendKeys(x[8].ToString());

               Thread.Sleep(1000);
               _SecondaryPhone.Clear();
               _SecondaryPhone.SendKeys((x[9].ToString()));

               Thread.Sleep(1000);
               _HasCheckingYes.Click();
           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
}
       public void FillStepOneEntries_reg()
       {
           try
           {
               ArrayList x = DataGeneration.DataGeneration_YourVerCard();
               Thread.Sleep(1000);
              
               _EmailAddress.Clear();
               _EmailAddress.SendKeys(x[7].ToString());

               Thread.Sleep(1000);
               _PrimaryPhone.Clear();
               _PrimaryPhone.SendKeys(x[8].ToString());

               Thread.Sleep(1000);
               _SecondaryPhone.Clear();
              _SecondaryPhone.SendKeys((x[9].ToString()));

               Thread.Sleep(1000);
               _HasCheckingYes.Click();
             

           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
       }

       public string GetInit_reg()
       {
           string Init;
           var FistName = _FirstName.GetAttribute("value").Substring(0, 1);
           var MiddleName = _MiddInitial.GetAttribute("value");
           var LastName = _LastName.GetAttribute("value").Substring(0, 1);
           if (_MiddInitial.GetAttribute("value")=="")
           {
               
               Init = FistName + LastName;
           
           
           }
           else
           {
               MiddleName.Substring(0, 1);
               Init = FistName + MiddleName + LastName;
           }
          
          
           return Init;
       }

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
