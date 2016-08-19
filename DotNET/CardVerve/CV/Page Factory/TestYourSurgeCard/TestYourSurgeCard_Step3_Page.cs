using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System.Threading;
using CV.DataSource;

namespace CV
{
   public class TestYourSurgeCard_Step3_Page
    {
        #region PageObjects

       [FindsBy(How = How.Id, Using = "esign_consent")]
       public IWebElement _IAgreeCheckBox;

       [FindsBy(How = How.Id, Using = "credit_protection_yes")]
       public IWebElement _CreditProtectionYEs;

       [FindsBy(How = How.Id, Using = "credit_protection_no")]
       public IWebElement _CreditProtectionNo;


       [FindsBy(How = How.XPath, Using =  "//*[@id='validated_form']/div/div[4]/div[2]/div[6]/div[2]/div[2]/input")]
       public IWebElement _ConfirmInitials;

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[8]/button[2]")]
       public IWebElement _NextButton;

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[9]/button[2]")]
       public IWebElement _PreviousButton;
       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[5]/div[2]/div[6]/div[2]/div[2]/input")]
       public IWebElement _ConfirmInitials_reg;
        #endregion

       [FindsBy(How = How.XPath, Using = "//*[@id='validated_form']/div/div[10]/button[2]")]
       public IWebElement _NextButton_reg;
       

       public TestYourSurgeCard_Step3_Page(IWebDriver driver)
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
           
          ArrayList x = DataGeneration.DataGeneration_YourVerCard();
           Thread.Sleep(1000);
           _CreditProtectionNo.Click();

           Thread.Sleep(1000);
           _ConfirmInitials.SendKeys(x[12].ToString());

       }

       public void ClickNext()
       {
           Thread.Sleep(1000);
           _NextButton.Click();
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
               _ConfirmInitials.SendKeys("ABC");
               ClickNext();
           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }


       }
       public void FillStepThreeEntries_reg(string Init)
       {
           try
           {
               Agree();
               Thread.Sleep(1000);
               _CreditProtectionNo.Click();

               Thread.Sleep(1000);
               _ConfirmInitials_reg.SendKeys(Init);
               _NextButton_reg.Click();
           }
           catch (Exception ex) { Console.Out.WriteLine(ex.StackTrace.ToString()); }


       }

    }

       #endregion
}
