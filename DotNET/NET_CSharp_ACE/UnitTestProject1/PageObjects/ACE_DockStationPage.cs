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
using System.Data;
using System.Windows;




namespace KKamal_CaDevelopmentPlan.PageObjects
{
    class ACE_DockStationPage
    {
        #region PageObjects

        [FindsBy(How = How.XPath, Using="//*[@id='ctl00_ctl00_MasterPageContent_cpv_listAGWs_itemPlaceholderContainer']/tbody")]
        public IWebElement TableBody;

        [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_linkEventLogs")]
        public IWebElement _ServerDockStationsLog_Btn ;

       

        #endregion

        public ACE_DockStationPage(IWebDriver driver)
        {
            if (Browser.Driver != null)
                driver = Browser.Driver;
                PageFactory.InitElements(driver, page: this);
        }


        #region Methods
        public void GetTableData()
        {
            int RowCount = Browser.Driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_MasterPageContent_cpv_listAGWs_itemPlaceholderContainer']/tbody/tr")).Count;
            int cellCount = Browser.Driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_MasterPageContent_cpv_listAGWs_itemPlaceholderContainer']/tbody/tr/th")).Count;
            for (int i = 2; i <= RowCount; i++)
            {
                

                for (int y = 1; y <= cellCount; y++)
                {
                    Console.Out.WriteLine(
                       Browser.Driver.FindElement(By.XPath("//*[@id='ctl00_ctl00_MasterPageContent_cpv_listAGWs_itemPlaceholderContainer']/tbody/tr[" + i + "]/td[" + y + "]")).Text);
                }
             
            }


        }
          
        #endregion


    }


}
