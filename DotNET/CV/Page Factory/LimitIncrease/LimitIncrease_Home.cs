using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects;

namespace PageObjects
{
   public class LimitIncrease_Home
    {
        #region PageObjects
       
       // Credit Card Number Field
       [FindsBy(How = How.XPath, Using ="//*[@id='validated_form']/div/div[2]/div/section[2]/div[3]/div[2]/input")]
       public IWebElement _CreditCardNumber_Txt;


       // SSN Field
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/section[2]/div[2]/div[2]/input")]
       public IWebElement _SSN_Txt;


       // Monthly Income Field
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/section[2]/div[4]/div[2]/input")]
       public IWebElement _MonthlyIncome_Txt;


       // Submit Request Button
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/section[2]/div[5]/button")]
       public IWebElement _Submit_Btn; 
        
        #endregion


       #region Methods
       public LimitIncrease_Home(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

       public void FillInformationEntries()
       {
           try
           {
               _SSN_Txt.Clear();
               _SSN_Txt.SendKeys("");

               _CreditCardNumber_Txt.Clear();
               _CreditCardNumber_Txt.SendKeys("");

               _MonthlyIncome_Txt.Clear();
               _MonthlyIncome_Txt.SendKeys("");
           }

           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
       }

       public void ClickSubmitButton() 
       {

           try
           {
               _Submit_Btn.Click();
           }

           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }

       }


    }
       #endregion
}
