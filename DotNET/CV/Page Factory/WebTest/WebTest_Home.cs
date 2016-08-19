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
    public class WebTest_Home
    {
        #region PageObjects

        // Reservation Number Field
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[1]/input")]
        public IWebElement _ReservationNumber_Txt;


        // SSN Field
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[2]/input")]
        public IWebElement _SSN_Txt;


        // Confirm Reservation Button
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[3]/button")]
        public IWebElement _CnfrmReserv_Btn;


        // No Reservation Button
        [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[1]")]
        public IWebElement _NOReserv_Btn;

        #endregion


        #region Methods
        public WebTest_Home(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

        public void ClickNoReservationButton()
        {
            try
            {
                _NOReserv_Btn.Click();
            }

            catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
        }

        public void ClickConfirmReservationButton()
        {

            try
            {
                _CnfrmReserv_Btn.Click();
            }

            catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }

        }


    }
        #endregion
}
