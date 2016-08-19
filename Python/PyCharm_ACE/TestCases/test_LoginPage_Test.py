import unittest
from ddt import ddt, data, unpack
from Configurations import ConfigReader
from PageObjects import LoginPage_Objects
from Utilities.Browser import Browser
from Utilities import ExcelTranslator
from Utilities import FileLocator
from Utilities.PageActions import BasicActions


@ddt
class LoginPageTest(unittest.TestCase):

    _fileLocation = FileLocator.read_config_get_file_location('ExcelConfiguration', 'DataSourcefileLocation')
    _sheetName = ConfigReader.readconfig('ExcelConfiguration', 'ExcelSheetName_1')
    result = ExcelTranslator.ExcelReader.read_Excel(_fileLocation, _sheetName, HDR=True)

    @classmethod
    def setUp(cls):
        Browser.initialize_driver('ie')
        BasicActions.maximize_window()
        BasicActions.navigate(ConfigReader.readconfig('ConfigurationSettings', 'LoginURL'))

    @data(*result)
    @unpack
    def test_loginWithDdt(self, user_name, user_pass):
        loginpage = LoginPage_Objects.LoginPage(Browser._driver)
        loginpage.Login(username=user_name, password=user_pass)
        if loginpage.check_element_exists('loginIas_FailureText')==False:
            self.assertEqual(user_name,
                             loginpage.getLoggedUser(),
                             'Invalid username or password!')
            loginpage.clickSignOut()
        else:
            print('Invalid username or password!')

    def test_LoginWithExcelReader(self):
        loginpage = LoginPage_Objects.LoginPage(Browser._driver)
        loginpage.Login(username=self.result[0][0],
                        password=self.result[0][1])
        if loginpage.check_element_exists('loginIas_FailureText')==False:
            self.assertEqual(self.result[0][0],
                             loginpage.getLoggedUser(),
                             'Invalid User Name or Password !')
            loginpage.clickSignOut()
        else:
            print('Invalid username or password!')

    @classmethod
    def tearDown(cls):
        Browser.close_driver()
# endregion

if __name__ == '__main__':
    unittest.main()
