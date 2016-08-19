import os
from Configurations import ConfigReader


def read_config_get_file_location(_config_section_name, _config_key_value):
    _file_location = (os.path.dirname(os.getcwd())) + \
                      '\\' + (ConfigReader.readconfig(_config_section_name, _config_key_value))
    return _file_location


def get_file_location(_file_subdir):
    _file_location = os.path.dirname(os.getcwd()) + '\\' + _file_subdir
    return _file_location
