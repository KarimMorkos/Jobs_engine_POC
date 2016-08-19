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
   public class TestYourSurgeCard__HomePage
    {
        #region PageObjects
       [FindsBy(How = How.XPath, Using ="//*[@id='validated_form']/div/div[9]/button[1]")]
       public IWebElement _NoreservationButton;

       // Reservation Number Field
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[1]/input")]
       public IWebElement _ReservationNo_Txt;

       //SSN Field
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[2]/input")]
       public IWebElement _SSN_Txt;

       //Confirm Reservation button
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[2]/div/div[2]/div[3]/button")]
       public IWebElement _ConfirmReservation_Btn;

        #endregion



       public TestYourSurgeCard__HomePage(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

        public void ClickNoReservationButton()
        {
            try
            {

                _NoreservationButton.Click();
            }

            catch (Exception ex)
            { Console.Out.WriteLine(ex.StackTrace.ToString()); }
        }

        public void FillReservationInfo(string ReservationNumber, String SSN)
        {
            // fill in the reservation number
            _ReservationNo_Txt.Clear();
            _ReservationNo_Txt.SendKeys(ReservationNumber);

            // Fill in the SSN number
            _SSN_Txt.Clear();
            _SSN_Txt.SendKeys(SSN);

            // Click Confirm reservation number
            _ConfirmReservation_Btn.Click();
        }

    }
}
