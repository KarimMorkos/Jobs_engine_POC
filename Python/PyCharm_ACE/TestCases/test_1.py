import time
import unittest
import requests
from Configurations import ConfigReader
from PageObjects import LoginPage_Objects
from Utilities.Browser import Browser
from Utilities import DemoTranslator
from Utilities import FileLocator
from Utilities.PageActions import BasicActions
from Utilities import HTMLTestRunner


class Test1(unittest.TestCase):

    @classmethod
    def setUp(cls):
        Browser.initialize_driver('ie')
        BasicActions.maximize_window()
        BasicActions.navigate(ConfigReader.readconfig('ConfigurationSettings', 'LoginURL'))
        BasicActions.open_new_window()

    def test_ADO(self):
        _fileLocation = FileLocator.read_config_get_file_location('ExcelConfiguration', 'DataSourcefileLocation')
        _sheetName = ConfigReader.readconfig('ExcelConfiguration', 'ExcelSheetName_3')
        result = DemoTranslator.getdata(self, _fileLocation, _sheetName)
        print(result)
        print(result[0][0])
        print(result[0][1])
        print(result[1][0])
        print(result[1][1])
        print(result[2][0])
        print(result[2][1])

        for x in range(0,3):
            for y in range(0,2):
                print(result[x][y])    

    def test_login_ADO(self):
        _fileLocation = FileLocator.read_config_get_file_location('ExcelConfiguration', 'DataSourcefileLocation')
        _loginsheetName = ConfigReader.readconfig('ExcelConfiguration', 'ExcelSheetName_3')

        Loginresult = DemoTranslator.getdata(self,_fileLocation,_loginsheetName)
        loginPage = LoginPage_Objects.LoginPage(Browser._driver)
        loginPage.Login(Loginresult[0][0], Loginresult[0][1])
        time.sleep(5)
        self.assertEqual(Loginresult[0][0], loginPage._usernamelink.text,
                         msg="logged User and Displayed User are not Identical!")
        loginPage.clickSignOut()

    def test_testing_page_response(self):
        res = requests.get('http://google.com')
        print(res.status_code)

    @classmethod
    def tearDown(cls):
        Browser.close_driver()

if __name__ == '__main__':
    HTMLTestRunner.main()