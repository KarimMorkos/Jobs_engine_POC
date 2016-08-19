import unittest
import datetime as dt
# from TestCases.test_LoginPage_Test import LoginPageTest
from TestCases.test_HomePage_Test import HomePageTest
from TestCases.test_OpenQAPage_Test import OpenQaPageTest
from Utilities import HTMLTestRunner
from Utilities import FileLocator as FL


# get all test from LoginPage_Test and HomePage_Test
# login_tests = unittest.TestLoader().loadTestsFromTestCase(LoginPageTest)
home_page_tests = unittest.TestLoader().loadTestsFromTestCase(HomePageTest)
open_qa_tests = unittest.TestLoader().loadTestsFromModule(OpenQaPageTest)

# create a test Suite combining the tests
tests = unittest.TestSuite([home_page_tests, open_qa_tests])
# Create Test Report Name
report_name = 'TestReport_' + dt.datetime.now().strftime("%Y-%m-%d_%H %M %S")
# set the test report file location
file_location = FL.get_file_location('PyCharm_ACE\\TestReports')

# open the report file
outfile = open(file_location + '\\' + report_name + '.html',
               'x')
# Configure HTMLTestRunner options
runner = HTMLTestRunner.HTMLTestRunner(stream=outfile,
                                       title='Test Report',
                                       description='Test Suite Report'
                                       )

# run the suite using HTMLTEstRunner
runner.run(tests)
