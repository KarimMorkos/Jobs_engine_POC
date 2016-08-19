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
using OpenQA.Selenium.Interactions;

namespace KKamal_CaDevelopmentPlan.PageObjects
{
    public class OpenQAPage
    {
        #region PageObjects

        [FindsBy (How = How.Id , Using = "timingAlert")]
        public IWebElement _TimingAlert_Btn;

        [FindsBy(How = How.Id, Using = "alert")]
        public IWebElement _ShowAlert_Btn;

        [FindsBy(How = How.Name, Using = "selenium_commands")]
        public IWebElement _SeleniumCommands;

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/p[3]/button")]
        public IWebElement _SwitchTiWindowButton_Btn;

        #endregion

        #region Initializatoin
        public OpenQAPage(IWebDriver driver)
        {
            if(Browser.Driver != null)
                driver = Browser.Driver;
                PageFactory.InitElements(Browser.Driver,page:this);
        }
        #endregion

        #region Methods
        public void ClickTimingAlertButton()
        {
            try
            {
                _TimingAlert_Btn.Click();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }

        public void AcceptAlert()
        {
            try
            {
                Browser.Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }

        public void PlaywithSelection()
        {
            try
            {
                SelectElement _SeleniumCommands_SLctLst = new SelectElement(_SeleniumCommands);


                //Select & deselect Browser Command option by index
                _SeleniumCommands_SLctLst.SelectByIndex(0);
                _SeleniumCommands_SLctLst.DeselectByIndex(0);

                // select & deselect Navigation Command option by visible text
                _SeleniumCommands_SLctLst.SelectByText("Navigation Commands");
                _SeleniumCommands_SLctLst.DeselectByText("Navigation Commands");



                // Select all options and print all selection
                _SeleniumCommands_SLctLst.SelectByIndex(0);
                SelectAllElements(Browser.Driver);

                if (_SeleniumCommands_SLctLst.AllSelectedOptions.Count == _SeleniumCommands_SLctLst.Options.Count)
                {

                    foreach (var option in _SeleniumCommands_SLctLst.AllSelectedOptions)
                    {
                        Console.Out.WriteLine(option.Text);
                    }
                }
                else
                {
                    Console.Out.WriteLine("Not all Elements are Selected!");
                }

                //Deselect all the selected options
                _SeleniumCommands_SLctLst.DeselectAll();

            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }
        
        public void SelectAllElements(IWebDriver driver)
        {
            try
            {
                Actions ScrollAction = new Actions(driver);
                ScrollAction.SendKeys(Keys.Shift + Keys.End).Perform();

            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }       
           
        }

        public void ClickSwithToWindowButton()
        {
            try
            {
                _SwitchTiWindowButton_Btn.Click();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }

        public void ClickAlertButton()
        {
            try
            {
                _ShowAlert_Btn.Click();
            }
            catch (Exception ex)
            {
                
                Console.Out.WriteLine(ex.StackTrace.ToString());
            }
            
        }
        
        #endregion

    }


}
