from selenium.webdriver.common.by import By
from selenium.common import exceptions


class OpenQaPage(object):

    _alertbutton = (By.XPATH, '//*[@id="alert"]')

    def __init__(self,driver):
        self._driver = driver

    def clickalertbutton(self):
        try:
            self._driver.find_element(*OpenQaPage._alertbutton).click()
        except exceptions.NoSuchElementException():
            print("Alert Button not found!")