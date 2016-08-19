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
    public class ACE_PumpsPage
    {
        #region PageObjects

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_toggleFilterIndicator")]
        public IWebElement _FilterButton_Ctrl;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_BtnFilter_btnApplyFilters")]
        public IWebElement _ApplyFilterButton_Btn;

        [FindsBy(How = How.XPath, Using="//*[@id='ctl00_ctl00_MasterPageContent_cpv_radbtnLstConnectionStatus']/tbody/tr[1]/td/label")]
        public IWebElement _ConnectionStatus_All_rdBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_MasterPageContent_cpv_radbtnLstConnectionStatus']/tbody/tr[2]/td/label")]
        public IWebElement _ConnectionStatus_Connected_rdBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_MasterPageContent_cpv_radbtnLstConnectionStatus']/tbody/tr[3]/td/label")]
        public IWebElement _ConnectionStatus_Disconnected_rdBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_MasterPageContent_cpv_radbtnLstConnectionStatus']/tbody/tr[4]/td/label")]
        public IWebElement _ConnectionStatus_Imported_rdBtn;

       

        #endregion


        public ACE_PumpsPage(IWebDriver driver) 
        {
            if (Browser.Driver != null)
                driver = Browser.Driver;
            PageFactory.InitElements(driver , page: this);

        }

        #region Methods
        public void ClickFilter() 
        {
            try
            {
                _FilterButton_Ctrl.Click();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }

        public void ClickApplyFilterButton()
        {
            try
            {
                _ApplyFilterButton_Btn.Click();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }

            
        }

        public void SelectConnectionStatusAll()
        {
            try
            {
                _ConnectionStatus_All_rdBtn.Click();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }

        public void SelectConnectionStatusConnected()
        {
            try
            {
                _ConnectionStatus_Connected_rdBtn.Click();
            }
            catch (Exception ex)
            {

                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }

        public void SelectConnectionStatusDisconnected()
        {
            try
            {
                _ConnectionStatus_Disconnected_rdBtn.Click();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }


        public void SelectConnectionStatusImported()
        {
            try
            {
                _ConnectionStatus_Imported_rdBtn.Click();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }


        #endregion
    }
}
