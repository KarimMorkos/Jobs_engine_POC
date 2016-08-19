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
using System.Windows.Forms;

namespace KKamal_CaDevelopmentPlan.PageObjects
{
   public class ACE_AdministrationDatasetPage
   {
       # region Page Elements
       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_lblBtnImport")]
       public IWebElement _Import_Btn;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_txtActionPassword")]
       public IWebElement _LoginPassword_Txt;

       [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[3]/div/button[1]")]
       public IWebElement _SubmitPassword_Txt;


       [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[3]/div/button[1]")]
       public IWebElement _SubmitPassword_Btn;

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_lblSelectedFileName")]
       public IWebElement _FileInput_Lbl;

      
       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_ctlFileUpload")]
       public IWebElement _UploadFile_Btn;

      
       [FindsBy(How = How.XPath, Using = "/html/body/div[6]/div[3]/div/button[1]")]
       public IWebElement _Continue_Btn;


       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_txtImportDSCode")]
       public IWebElement _VerificationCode_Txt;

       //ctl00_ctl00_MasterPageContent_cpv_lblDSIDCodeValue
       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_lblDSIDCodeValue")]
       public IWebElement _lblDSIDCodeValue;


       [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[3]/div/button[1]")]
       public IWebElement _ImportDS_Btn;  

       [FindsBy(How = How.Id, Using = "ctl00_ctl00_MasterPageContent_cpv_lstDatasets_itemPlaceholderContainer")]
       public IWebElement _DatasetTable;
       
       # endregion
       public ACE_AdministrationDatasetPage(IWebDriver driver)
       {
           if (Browser.Driver !=null)
               driver = Browser.Driver;
               PageFactory .InitElements(driver,page: this);
       }

       #region Methods
       public void Import()
       {
           try
           {

               _Import_Btn.Click(); 

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void FillUploaderPassword(string password)
       {
           try
           {
               _LoginPassword_Txt.Clear();
               _LoginPassword_Txt.SendKeys(password);

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }
       public void ClickSubmitButton()
       {
           try
           {
               
               _SubmitPassword_Btn.Click();

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }
       public void ClickBrowseButton()
       {
           try
           {
               
               _UploadFile_Btn.Click();

           }
           catch (Exception ex)
           {
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void ClickContinueButton()
       {
           try
           {
               _Continue_Btn.Click();

           }
           catch (Exception ex)
           {
               
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }

       public void SubmitFileDialog(string fileName)
       {
           SendKeys.SendWait(@fileName);
           SendKeys.SendWait(@"{Enter}");
       }

       public string ProvideDScode(string verificationCode) 
       {
           try
           {
               _VerificationCode_Txt.Clear();
               _VerificationCode_Txt.SendKeys(verificationCode);
               return verificationCode;
           }
           catch (Exception ex)
           {
               
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
           return null;
       }

       public void ClickImportDSbutton()
       {
           try
           {
               CommonActions.implicitWait(3);
               _ImportDS_Btn.Click();
           }
           catch (Exception ex)
           {
               
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
       }


       public string getTableData()
       {
           
           try
           {
                int RowCount = Browser.Driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_MasterPageContent_cpv_lstDatasets_itemPlaceholderContainer']/tbody/tr")).Count;
                int cellCount = Browser.Driver.FindElements(By.XPath("//*[@id='ctl00_ctl00_MasterPageContent_cpv_lstDatasets_itemPlaceholderContainer']/tbody/tr/th")).Count;
                string TableResults=""; 

                for (int i = 2; i <= RowCount; i++)
                {  
                    for (int y = 1; y <= cellCount; y++)
                    {
                         TableResults +=
                                 Browser.Driver.FindElement(By.XPath(@"//*[@id='ctl00_ctl00_MasterPageContent_cpv_lstDatasets_itemPlaceholderContainer']/tbody/tr[" + i + "]/td[" + y + "]")).Text;
                    }
                    
                }

                return TableResults;  

           }
           catch (Exception ex)
           {
               
               Console.Out.WriteLine(ex.StackTrace.ToString());
           }
           return null;
          

        }



       #endregion

   }
}
