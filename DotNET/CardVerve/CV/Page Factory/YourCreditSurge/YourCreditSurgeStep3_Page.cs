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
using System.Collections;
using CV.DataSource;

namespace PageObjects
{
    public class YourCreditSurgeStep3_Page
    {
        #region PageObjects

        // i agree check box
        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div/div[2]/div[1]/label")]
        public IWebElement _IAgreeCheckBox;

        //protect option enabled
        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[1]/div/div[11]/div/div/div[1]/div/div[3]/div/div[1]/label")]
        public IWebElement _CreditProtectionYEs;

        //protect option disabled
        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[1]/div/div[11]/div/div/div[1]/div/div[3]/div/div[2]/p/label")]
        public IWebElement _CreditProtectionNo;

        // Confirm Initials
        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[1]/div/div[11]/div/div/div[2]/div/div[3]/div/div/div/input")]
        public IWebElement _ConfirmInitials;

        // Agree on Acknowledge
        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[1]/div/div[15]/div/div/div/div/div/div[2]/div[1]/p/label")]
        public IWebElement _ACKAgrement_ChckBox;

        // Click Submit Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[1]/div/p[3]/button[2]")]
        public IWebElement _SubmitButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[1]/div/p[3]/button[1]")]
        public IWebElement _PreviousButton;

        [FindsBy(How = How.XPath, Using =" //*[@id='optIn-05']")]
        public IWebElement _Agree;
        

        #endregion


        public YourCreditSurgeStep3_Page(IWebDriver driver)
        {
            if (Browser.Driver != null) driver = Browser.Driver;
            PageFactory.InitElements(driver, page: this);
        }

        #region Methods
        public void Agree()
        {
            Thread.Sleep(1000);
            _IAgreeCheckBox.Click();
        }

        public void ProtectYourCreditYes()
        {
            Thread.Sleep(1000);
            _CreditProtectionYEs.Click();

            Thread.Sleep(1000);
            _ConfirmInitials.SendKeys(System.Configuration.ConfigurationSettings.AppSettings["InitConfirm"]);

        }


        public void ProtectYourCreditYNo()
        {
            Thread.Sleep(1000);
            _CreditProtectionNo.Click();

            Thread.Sleep(1000);
            _ConfirmInitials.SendKeys("");

        }

        public void ClickNext()
        {
            Thread.Sleep(1000);
            _SubmitButton.Click();
        }

        public void ClickPrevious()
        {
            Thread.Sleep(1000);
            _PreviousButton.Click();
        }
        public void FillStepThreeEntries()
        {
            try
            {
                ArrayList x = DataGeneration.DataGeneration_YourVerCard();
                Agree();
                Thread.Sleep(1000);
                _CreditProtectionNo.Click();

                Thread.Sleep(1000);
                _ConfirmInitials.SendKeys(x[12].ToString());
               
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }
        }

    }


        #endregion
}
