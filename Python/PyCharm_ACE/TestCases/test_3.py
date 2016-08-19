import unittest
import time
from selenium import webdriver
from selenium.webdriver.common.action_chains import *


class MyTestCase(unittest.TestCase):
    @classmethod
    def setUp(cls):
        cls.driver = webdriver.Firefox()
        cls.driver.implicitly_wait(time_to_wait=30)
        cls.driver.maximize_window()
        print(cls.driver.title)

    def test_A(self):
        # Go to Google website
        self.driver.get('http://google.com')

        # Execute Action Chain
        action = ActionChains(self.driver)
        action.send_keys(Keys.CONTROL+'n')
        action.perform()

        # switch to the other window
        self.driver.switch_to.window(self.driver.window_handles[1])

        # Go to Yahoo website
        self.driver.get('http://yahoo.com')
        time.sleep(5)

    @classmethod
    def tearDown(cls):
        cls.driver.quit()

if __name__ == '__main__':
    unittest.main()
