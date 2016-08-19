import unittest
import os
import time
from selenium import webdriver
from selenium.webdriver.common.desired_capabilities import DesiredCapabilities


class MyTestCase(unittest.TestCase):

    @classmethod
    def setUp(cls):

        # cmd = 'java -jar selenium-server-standalone-2.25.0.jar -port 4444 -role hub'
        # os.system(cmd)
        # time.sleep(5)
        cls.driver = webdriver.Remote(command_executor='http://127.0.0.1:5555/wd/hub',
                                      desired_capabilities=DesiredCapabilities.FIREFOX
                                      )

    def test_A(self):
        self.driver.get('http://google.com')
        self.assertEqual(self.driver.title, "Google")

    @classmethod
    def tearDown(cls):
        cls.driver.quit()

if __name__ == '__main__':
    unittest.main()
