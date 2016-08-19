import unittest
from Utilities.Browser import Browser
from Configurations import ConfigReader
from Utilities.PageActions import BasicActions as Action
from PageObjects import OpenQAPage_Objects


class OpenQaPageTest(unittest.TestCase):

    def setUp(self):
        Browser.initialize_driver('ie')
        Action.maximize_window()
        Action.navigate(ConfigReader.readconfig('ConfigurationSettings', 'OpenQAURL'))

    def test_switchToAlert(self):        
        openqapage = OpenQAPage_Objects.OpenQaPage(Browser._driver)
        openqapage.clickalertbutton()
        Action.accept_alert()

    def test_getPageSource(self):
        print(Action.get_page_source())

    def test_getPageTitle(self):
        print(Action.get_page_title())

    def tearDown(self):
        Browser.close_driver()

if __name__ == '__main__':
    unittest.main()
