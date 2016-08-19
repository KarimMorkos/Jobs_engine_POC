from selenium.webdriver.common.alert import *
from selenium.webdriver.common.action_chains import *
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.common import exceptions
from Utilities.Browser import Browser


class BasicActions(Browser):

    def __init__(self):
        super(BasicActions, self).__init__()

    @staticmethod
    def navigate(url):
        Browser._driver.get(url)

    @staticmethod
    def maximize_window():
        Browser._driver.maximize_window()

    @staticmethod
    def get_page_title():
        return Browser._driver.title

    @staticmethod
    def get_page_source():
        return Browser._driver.page_source

    @staticmethod
    def implicit_wait(time_to_wait):
        Browser._driver.implicitly_wait(time_to_wait)

    @staticmethod
    def switch_to(keyword=None, window_name=None):
        if keyword == 'alert':
            Browser._driver.switch_to_alert()
        elif keyword == 'frame':
            Browser._driver.switch_to_frame()
        elif keyword == 'window':
            Browser._driver.switch_to_window(window_name)
        else:
            Browser._driver.switch_to_active_element()

    @staticmethod
    def send_enter_key():
        action = ActionChains(Browser._driver)
        action.send_keys(Keys.ENTER)
        action.perform()

    @staticmethod
    def open_new_window():
        action = ActionChains(Browser._driver)
        action.send_keys(Keys.CONTROL+'n')
        action.perform()

    @staticmethod
    def accept_alert():
        Alert(Browser._driver).accept()

    @staticmethod
    def dismiss_alert():
        Alert(Browser._driver).accept().dismiss()

    def check_element_exists_id(element_id):
        try:
            Browser._driver.find_element_by_id(element_id)
        except exceptions.NoSuchElementException:
            return False
        return True

    def check_element_exists_xpath(element_xpath):
        try:
            Browser._driver.find_element_by_xpath(element_xpath)
        except exceptions.NoSuchElementException:
            return False
        return True

    @staticmethod
    def explicit_wait(time_secs, elem_locator_method):
        try:
            element = WebDriverWait(Browser._driver, timeout=time_secs).until(
                EC.presence_of_element_located(locator=elem_locator_method)
            )
            return element
        except exceptions.NoSuchElementException:
            print("Element Not Found!")
            return
