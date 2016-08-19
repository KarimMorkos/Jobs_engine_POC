import unittest
from Utilities.Browser import Browser
from Utilities import ExcelTranslator
from Utilities import FileLocator
from Utilities.PageActions import BasicActions
from Configurations import ConfigReader
from PageObjects import LoginPage_Objects
from PageObjects import HomePage_Objects
from PageObjects import DatasetAdministrationPage_Objects
from selenium.webdriver.common.by import By


class HomePageTest(unittest.TestCase):

    @classmethod
    def setUp(cls):
        Browser.initialize_driver('chrome')
        BasicActions.maximize_window()
        BasicActions.navigate(ConfigReader.readconfig('ConfigurationSettings', 'LoginURL'))

    def test_upload_data_set(self):

        homepage = HomePage_Objects.HomePage(Browser._driver)
        login_page = LoginPage_Objects.LoginPage(Browser._driver)
        dataset_admn_page = DatasetAdministrationPage_Objects.DataSetAdministrationPage(Browser._driver)

        file_location = FileLocator.read_config_get_file_location('ExcelConfiguration', 'DataSourcefileLocation')
        login_sheet_name = ConfigReader.readconfig('ExcelConfiguration', 'ExcelSheetName_1')
        dataset_sheet_name = ConfigReader.readconfig('ExcelConfiguration', 'ExcelSheetName_2')
        login_param = ExcelTranslator.ExcelReader.readExcel(file_location,
                                                            login_sheet_name, HDR=True)
        dataset_files_param = ExcelTranslator.ExcelReader.readExcel(file_location,
                                                                    dataset_sheet_name, HDR=True)

        # Login with valid user
        login_page.Login(login_param[0][0], login_param[1][0])
        # click on the data set link under clinical section
        homepage.click_DataSetsLink()
        # click import button
        dataset_admn_page.click_importbutton()
        # fill Submit button
        dataset_admn_page.fill_passwordforuploadfield(login_param[1][0])
        # click submit button
        dataset_admn_page.click_submitbutton()
        # send data set file location
        dataset_admn_page.send_filelocation(dataset_files_param[0][0])
        # click continue button
        dataset_admn_page.click_continuebutton()
        # fill data set verification code
        dataset_admn_page.fill_dsverificationcode(dataset_files_param[1][0])
        # click import data set button
        dataset_admn_page.click_importdatasetbutton()
        # wait a while
        BasicActions.explicit_wait(10, (By.ID, 'ctl00_ctl00_MasterPageContent_cpv_lblBtnImport'))

    @classmethod
    def tearDown(cls):
        Browser.close_driver()

if __name__ == '__main__':
    unittest.main()
