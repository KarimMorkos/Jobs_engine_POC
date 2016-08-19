using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using KKamal_CaDevelopmentPlan.Tools;

namespace KKamal_CaDevelopmentPlan.PageObjects
{
   public class ACE_LoginPage
   {
       # region Page Elements
       [FindsBy(How = How.Id, Using = "loginIas_UserName")]
       public IWebElement _UserName_Txt;

       [FindsBy(How = How.Id, Using = "loginIas_Password")]
       public IWebElement _UserPwd_Txt;

       [FindsBy(How = How.Id, Using = "loginIas_LoginButton")]
       public IWebElement _Login_Btn;


       //User Name with Name Locator
       [FindsBy(How = How.Name, Using = "loginIas$UserName")]
       public IWebElement _UserNameLocator_Txt;

       //User Password with Name Locator
       [FindsBy(How = How.Name, Using = "loginIas$Password")]
       public IWebElement _UserPasswordLocator_Txt;

       # endregion
       public ACE_LoginPage(IWebDriver driver)
       {
           if (Browser.Driver !=null)
               driver = Browser.Driver;
               PageFactory .InitElements(driver,page: this);
       }

       #region Methods
       public void login(string UserName, string Password)
       {
           try
           {
               //Fill User Name Field
               _UserName_Txt.Clear();
               _UserName_Txt.SendKeys(UserName);

               //Fill Password Field
               _UserPwd_Txt.Clear();
               _UserPwd_Txt.SendKeys(Password);

               //Click Sign in Button
               _Login_Btn.Click();


           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void loginWithNameLocators(string UserName, string Password)
       {
           try
           {
               //Fill User Name Field
               _UserNameLocator_Txt.Clear();
               _UserNameLocator_Txt.SendKeys(UserName);

               //Fill Password Field
               _UserPasswordLocator_Txt.Clear();
               _UserPasswordLocator_Txt.SendKeys(Password);

               //Click Sign in Button
               _Login_Btn.Click();


           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       #endregion

   }
}
