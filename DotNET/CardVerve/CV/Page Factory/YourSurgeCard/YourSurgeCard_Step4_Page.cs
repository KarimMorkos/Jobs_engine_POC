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

namespace PageObjects
{
   public class YourSurgeCard_Step4_Page
    {
        #region PageObjects

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[4]")]
       public IWebElement _AgreeAndSubmit;

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[2]")]
       public IWebElement _PreviousButton;

        #endregion

       public YourSurgeCard_Step4_Page(IWebDriver driver)
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
