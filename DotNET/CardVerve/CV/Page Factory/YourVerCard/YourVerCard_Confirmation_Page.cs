using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects;

namespace CV
{
   public class YourVerCard_Confirmation_Page
    {
       public string _RefNum;

        #region PageObjects

       [FindsBy(How = How.ClassName, Using = "ref_number")]
       public IWebElement _RefNumPlaceHolder;

        #endregion



       public YourVerCard_Confirmation_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

        #region Methods

       public string GetReferenceNumber() 
       {
           try
           {
               _RefNum = _RefNumPlaceHolder.Text;
               Console.Out.WriteLine("Reference Number is: " + _RefNum);

           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }  
           return _RefNum;
       }

        #endregion
    }
}
