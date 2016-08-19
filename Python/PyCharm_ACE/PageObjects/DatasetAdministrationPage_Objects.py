from selenium.webdriver.common.by import By
from selenium.common import exceptions


class DataSetAdministrationPage(object):

    _importbutton = (By.ID, 'ctl00_ctl00_MasterPageContent_cpv_lblBtnImport')
    _passwordforuploadfield = (By.ID, 'ctl00_ctl00_MasterPageContent_cpv_txtActionPassword')
    _submitbutton = (By.XPATH, '/html/body/div[5]/div[3]/div/button[1]')
    _browsefilebutton = (By.ID, 'ctl00_ctl00_MasterPageContent_cpv_ctlFileUpload')
    _continuebutton = (By.XPATH, '/html/body/div[6]/div[3]/div/button[1]')
    _dsverificationcodetxt = (By.ID, 'ctl00_ctl00_MasterPageContent_cpv_txtImportDSCode')
    _importdatasetbutton = (By.XPATH, '/html/body/div[3]/div[3]/div/button[1]')

    def __init__(self, driver):
        self._driver = driver

    def click_importbutton(self):
        try:
            self._driver.find_element(*DataSetAdministrationPage._importbutton).click()
        except exceptions.NoSuchElementException():
            print("Import button not found!")

    def fill_passwordforuploadfield(self, password):
        try:
            self._driver.find_element(*DataSetAdministrationPage._passwordforuploadfield).clear()
            self._driver.find_element(*DataSetAdministrationPage._passwordforuploadfield).send_keys(password)
        except exceptions.NoSuchElementException():
            print("Uploader password not found!")

    def click_submitbutton(self):
        try:
            self._driver.find_element(*DataSetAdministrationPage._submitbutton).click()
        except exceptions.NoSuchElementException():
            print("password submit button doesn't exist")

    def send_filelocation(self, datasetpath):
        try:
            self._driver.find_element(*DataSetAdministrationPage._browsefilebutton).send_keys(datasetpath)
        except exceptions.NoSuchElementException():
            print("file Browser not found!")

    def click_continuebutton(self):
        try:
            self._driver.find_element(*DataSetAdministrationPage._continuebutton).click()
        except exceptions.NoSuchElementException():
            print("Continue button not found!")

    def fill_dsverificationcode(self, verificationcode):
        try:
            self._driver.find_element(*DataSetAdministrationPage._dsverificationcodetxt).clear()
            self._driver.find_element(*DataSetAdministrationPage._dsverificationcodetxt).send_keys(verificationcode)
        except exceptions.NoSuchElementException():
            print("Verification code field is not Found!")

    def click_importdatasetbutton(self):
        try:
            self._driver.find_element(*DataSetAdministrationPage._importdatasetbutton).click()
        except exceptions.NoSuchElementException():
            print("Import data set button not found!")