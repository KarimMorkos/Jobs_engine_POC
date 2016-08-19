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
   public class ACE_HomePage
   {
       # region Page Elements
       [FindsBy(How = How.Id, Using = "ctl00_globalNavigation_logonStatusMenu")]
       public IWebElement _LoggingUserStatus_Txt;

       [FindsBy(How = How.Id, Using = "ctl00_globalNavigation_logonNameLogo")]
       public IWebElement _UserLoggedName_Txt;

       [FindsBy(How = How.Id, Using = "ctl00_globalNavigation_linkHelp")]
       public IWebElement _Help_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl00_MenuLink")]
       public IWebElement _Infusions_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl01_MenuLink")]
       public IWebElement _DataSets_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl02_MenuLink")]
       public IWebElement _DeploymentGroups_Link;

       //Locate deployment group by partial link
       [FindsBy(How = How.PartialLinkText, Using = "ManageDeploymentGroups.aspx")]
       public IWebElement _DeploymentGroupByPartial_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl03_MenuLink")]
       public IWebElement _PumpsDatasetAssociation_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl02_ctl00_ctl00_MenuLink")]
       public IWebElement _DockingStations_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl02_ctl00_ctl01_MenuLink")]
       public IWebElement _Pumps_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl02_ctl00_ctl02_MenuLink")]
       public IWebElement _ServerLogs_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl00_MenuLink")]
       public IWebElement _Roles_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl01_MenuLink")]
       public IWebElement _Users_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl02_MenuLink")]
       public IWebElement _HospitalStructure_Link;

       [FindsBy(How = How.Id, Using = "ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl03_MenuLink")]
       public IWebElement _AuditTrails_Link;

       # endregion
       public ACE_HomePage(IWebDriver driver)
       {
           if (Browser.Driver !=null)
               driver = Browser.Driver;
               PageFactory .InitElements(driver,page: this);
       }

       #region Methods
       public void ClickHelp(string UserName, string Password)
       {
           try
           {
               //Click Help Link
               _Help_Link.Click();

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void ClickSignOut()
       {
           try
           {
               //Click Help Link
               _LoggingUserStatus_Txt.Click();

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       
       public string  GetLoggedInUser()
       {
           if (_UserLoggedName_Txt.Displayed)
           {
               return _UserLoggedName_Txt.Text;
           }
           return "Error Element Not Present";
       }

       public void OpenInfusionsLink()
       {
           try
           {
               _Infusions_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenDatasetsLink()
       {
           try
           {
               _DataSets_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenDeploymentGroupsLink()
       {
           try
           {
               _DeploymentGroups_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenPumpDataAssociationGroupLink()
       {
           try
           {
               _PumpsDatasetAssociation_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenDockingStationsLink()
       {
           try
           {
               _DockingStations_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenPumpsLink()
       {
           try
           {
               _Pumps_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenServerLogsLink()
       {
           try
           {
               _ServerLogs_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenRolesLink()
       {
           try
           {
               _Roles_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenUsersLink()
       {
           try
           {
               _Users_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenHospitalStructureLink()
       {
           try
           {
               _HospitalStructure_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenAuditTrailsLink()
       {
           try
           {
               _AuditTrails_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void OpenDeploymentGroupByPartial()
       {
           try
           {
               _DeploymentGroupByPartial_Link.Click();
           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       #endregion

   }
}
