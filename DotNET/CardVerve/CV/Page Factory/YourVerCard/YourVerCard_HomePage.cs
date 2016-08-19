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
   public class YourVerCard_HomePage
    {
        #region PageObjects
       [FindsBy(How = How.XPath, Using ="//*[@id='validated_form']/div/div[9]/button[1]")]
       public IWebElement _NoreservationButton;
       [FindsBy(How = How.XPath, Using =  "//*[@id='validated_form']/div/div[2]/div/div[2]/div[1]/input")]
       public IWebElement _ReservationNo;
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[2]/input")]
       public IWebElement _SSN;

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[3]/button")]
       public IWebElement _ConfirmReservation;
       
       
        #endregion



        public YourVerCard_HomePage(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

       public void ClickNoReservationButton()
       {

           _NoreservationButton.Click();
       }

    }
}
