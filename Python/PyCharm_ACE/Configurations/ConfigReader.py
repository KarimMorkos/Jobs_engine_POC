from configobj import ConfigObj
from Utilities import FileLocator


def readconfig(section_name, key):
    _file_path = FileLocator.get_file_location('Configurations\Configuration.py')
    _conf_obj = ConfigObj(_file_path)
    _config = _conf_obj.get(section_name)[key]
    return _config
