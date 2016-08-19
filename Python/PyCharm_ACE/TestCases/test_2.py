import unittest
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.common.by import By
from selenium import webdriver
from selenium.webdriver.support import expected_conditions as EC


class MyTestCase(unittest.TestCase):

    def get_product_count(self):
        elem = WebDriverWait(driver=self.driver, timeout=5).until(
            EC.presence_of_all_elements_located(locator=(By.CLASS_NAME, "name")))
        prod_count = len(elem)
        return prod_count

    @classmethod
    def setUp(cls):
        cls.driver = webdriver.Firefox()
        cls.driver.maximize_window()
        cls.driver.get('https://olyve.com')
        cls.driver.implicitly_wait(time_to_wait=5)

    def test_go_to_product(self):
        res = []
        for x in range(0, self.get_product_count()):
            elem = WebDriverWait(driver=self.driver, timeout=5).until(
                EC.presence_of_all_elements_located(locator=(By.CLASS_NAME, "name")))
            res.append(elem[x].text)
            self.driver.find_element_by_link_text(elem[x].text).click()
            self.driver.implicitly_wait(2)
            """ uncomment this line of code and replace the url with the URL data source """
            # self.assertEqual(self.driver.current_url, 'https://olyve.com/products/olyve-alexandra')
            self.driver.back()
            self.driver.refresh()
            self.driver.implicitly_wait(5)

    @classmethod
    def tearDown(cls):
        cls.driver.quit()

if __name__ == '__main__':
    unittest.main()
