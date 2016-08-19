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
   public class ACE_UsersMgmtPage
   {
       # region Page Elements
       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_lbCreate")]
       public IWebElement _CreateUser_Btn;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _UserLoggedName_Txt;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _Help_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _Infusions_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _DataSets_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _DeploymentGroups_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _PumpsDatasetAssociation_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _DockingStations_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _Pumps_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _ServerLogs_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _Roles_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _Users_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _HospitalStructure_Link;

       [FindsBy(How = How.Id, Using = "")]
       public IWebElement _AuditTrails_Link;

       # endregion
       public ACE_UsersMgmtPage(IWebDriver driver)
       {
           if (Browser.Driver !=null)
               driver = Browser.Driver;
               PageFactory.InitElements(driver,page: this);
       }

       #region Methods
       public void ClickCreateUserBtn()
       {
           try
           {
               //Click Create User Button
               _CreateUser_Btn.Click();

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }


       #endregion

   }
}
