from selenium.webdriver.common.by import By
from selenium.common import exceptions


class HomePage(object):
    """  region Clinical section Page Elements """
    _infusionslink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl00_MenuLink')
    _datasetslink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl01_MenuLink')
    _deploymentgrouplink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl02_MenuLink')
    _pumpdataassoclink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl01_ctl00_ctl03_MenuLink')

    """Devices section Page Elements """
    _dockingstationslink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl02_ctl00_ctl00_MenuLink')
    _pumpslink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl02_ctl00_ctl01_MenuLink')
    _serverlogslink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl02_ctl00_ctl02_MenuLink')

    """ region Administration Section page elements """
    _roleslink= (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl00_MenuLink')
    _usersmgmgtlink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl01_MenuLink')
    _hospitalstructlink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl02_MenuLink')
    _audittrailslink = (By.ID, 'ctl00_MasterPageContent_rptHomeMenu_ctl03_ctl00_ctl03_MenuLink')

    def __init__(self, driver):
        self._driver = driver

    """ Methods """
    def click_DataSetsLink(self):
        try:
            # Click data sets link
            self._driver.find_element(*HomePage._datasetslink).click()
        except exceptions.NoSuchElementException():
            print("Data set link not found!")

