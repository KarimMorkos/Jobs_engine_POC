using System;
using Microsoft.VisualStudio.TestTools;
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
    public class ACE_CreateUserWindow
   {
       # region Page Elements
       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_txtFirstName")]
       public IWebElement _FirstName_Txt;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_txtLastName")]
       public IWebElement _LastName_Txt;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_drpTitle")]
       public IWebElement _SelectTitle;

       SelectElement _SelectTitle_DropDownList;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_txtEmployeeId")]
       public IWebElement _EmployeeID_Txt;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_checkboxWardAll")]
       public IWebElement _Ward_ChkBox;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_txtPassword")]
       public IWebElement _Password_Txt;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_txtRetypePassword")]
       public IWebElement _RetypePassword_Txt;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_rblPasswordExpires_0")]
       public IWebElement PwdExpireNever_RdBtn;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_rblPasswordExpires_1")]
       public IWebElement _PwdExpires_RdBtn;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_drpLanguage")]
       public IWebElement _Language_DropDownList;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_rblStatus_0")]
       public IWebElement _StatusActive_RdBtn;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_rblStatus_1")]
       public IWebElement StatusInactive_RdBtn;

       [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[3]/div/button[1]")]
       public IWebElement Create_Btn;

       [FindsBy(How = How.Id, Using = "/html/body/div[3]/div[3]/div/button[2]")]
       public IWebElement Cancel_Btn;

       # endregion
       public ACE_CreateUserWindow(IWebDriver driver)
       {
           if (Browser.Driver !=null)
               driver = Browser.Driver;
               PageFactory.InitElements(driver,page: this);
       }

       #region Methods
       public void SelectTitleByIndex()
       {
           try
           {
               _SelectTitle_DropDownList = new SelectElement(_SelectTitle);
               _SelectTitle_DropDownList.SelectByIndex(1);

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void SelectTitleByVisibleTxt()
       {
           try
           {
               _SelectTitle_DropDownList = new SelectElement(_SelectTitle);
               _SelectTitle_DropDownList.SelectByText("Mrs");

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void PrintAllOptionsForTitle()
       {
           try
           {
               _SelectTitle_DropDownList = new SelectElement(_SelectTitle);
              _SelectTitle_DropDownList.SelectByText("Mrs");
              Console.Out.WriteLine("Selected Value For Title is: "+_SelectTitle_DropDownList.SelectedOption.Text);
              for (int i = 0; i < _SelectTitle_DropDownList.Options.Count; i++)
              {
                  Console.Out.WriteLine(i+1+ "."+_SelectTitle_DropDownList.Options[i].Text.ToString());
 
              }

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       #endregion

   }
}
