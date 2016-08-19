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

namespace CV
{
   public class YourVerCard_Step4_Page
    {
        #region PageObjects

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[8]/button[3]")]
        public IWebElement _AgreeAndSubmit;

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[8]/button[1]")]
       public IWebElement _PreviousButton;
        [FindsBy(How = How.Id, Using = "tc_consent")]
       public IWebElement _Agree;
       
        #endregion

       public YourVerCard_Step4_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

        #region Methods

       public void AgreeAndSubmit() 
       {

           Thread.Sleep(2000);
           _AgreeAndSubmit.Click();
       }

       public void ClickPreviousButton()
       {
           _PreviousButton.Click();
       }

        #endregion
    }
}
