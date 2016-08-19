from selenium.webdriver.common.by import By
from selenium.common import exceptions


class LoginPage(object):

    _username = (By.ID, 'loginIas_UserName')
    _userpassword = (By.ID, 'loginIas_Password')
    _loginbutton = (By.ID, 'loginIas_LoginButton')
    _usernamelink = (By.ID, 'ctl00_globalNavigation_logonNameLogo')
    _signoutlink = (By.ID, 'ctl00_globalNavigation_logonStatusMenu')
    _invalicredentials = (By.ID, 'loginIas_FailureText')

    def __init__(self, driver):
        self._driver = driver

    def Login(self, username, password):
        # fill user name field
        self._driver.find_element(*LoginPage._username).clear()
        self._driver.find_element(*LoginPage._username).send_keys(username)

        # fill password field
        self._driver.find_element(*LoginPage._userpassword).clear()
        self._driver.find_element(*LoginPage._userpassword).send_keys(password)

        # click login button
        self._driver.find_element(*LoginPage._loginbutton).click()

    def check_element_exists(self, element_id):
        try:
            self._driver.find_element_by_id(element_id)
        except exceptions.NoSuchElementException:
            return False
        return True

    def clickSignOut(self):
        self._driver.find_element(*LoginPage._signoutlink).click()

    def getLoggedUser(self):
        return self._driver.find_element(*LoginPage._usernamelink).text