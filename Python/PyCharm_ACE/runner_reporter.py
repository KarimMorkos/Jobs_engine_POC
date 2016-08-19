import glob
from subprocess import Popen


tests = glob.glob('TestSuites\\Suite1.py')
processes = []
for test in tests:
    processes.append(Popen('python %s' % test, shell=True))
for process in processes:
    process.wait()
