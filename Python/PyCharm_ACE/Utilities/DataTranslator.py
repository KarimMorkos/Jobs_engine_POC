import win32com.client

class ExcelDocument(object):
    """ Represents an opened Excel document.
    """

    def __init__(self,filename):
        self.connection = win32com.client.Dispatch('ADODB.Connection')
        self.connection.Open(
            'PROVIDER=Microsoft.ACE.OLEDB.12.0;'+
            'DATA SOURCE=%s'%filename+
            ';Extended Properties="Excel 12.0 Xml;HDR=1;IMEX=1"'
        )

    def sheets(self):
        """ Returns a list of the name of the sheets found in the document.
        """
        result = []
        recordset = self.connection.OpenSchema(20)
        while not recordset.EOF:
            result.append(recordset.Fields[2].Value)
            recordset.MoveNext()
        recordset.Close()
        del recordset
        return result

    def sheet(self,name,encoding=None,order_by=None):
        """ Returns a sheet object by name. Use sheets() to obtain a list of
            valid names. encoding is a character encoding name which is used
            to encode the unicode strings returned by Excel, so that you get
            plain Python strings.
        """
        return ExcelSheet(self,name,encoding,order_by)
            
    def __del__(self):
        self.close()

    def close(self):
        """ Closes the Excel document. It is automatically called when
            the object is deleted.
        """
        try:
            self.connection.Close()
            del self.connection
        except:
            pass

def strip(value):
    """ Strip the input value if it is a string and returns None
        if it had only whitespaces """
    if isinstance(value,str):
        value = value.strip()
        if len(value)==0:
            return None
    return value


class ExcelSheet(object):
    """ Represents an Excel sheet from a document, gives methods to obtain
        column names and iterate on its content.
    """
    def __init__(self,document,name,encoding,order_by):
        self.document = document
        self.name = name
        self.order_by = order_by
        if encoding:
            def encoder(value):
                if isinstance(value,unicode):
                    value = value.strip()
                    if len(value)==0:
                        return None
                    else:
                        return value.encode(encoding)
                elif isinstance(value,str):
                    value = value.strip()
                    if len(value)==0:
                        return None
                    else:
                        return value 
                else:
                    return value
            self.encoding = encoder
        else:
            self.encoding = strip

    def columns(self):
        """ Returns a list of column names for the sheet.
        """
        recordset = win32com.client.Dispatch('ADODB.Recordset')
        recordset.Open('SELECT * FROM ' + '[' + self.name + ']',self.document.connection,0,1)
        try:
            return [self.encoding(field.Name) for field in recordset.Fields]
        finally:
            recordset.Close()
            del recordset
                
    def __iter__(self):
        """ Returns a paged iterator by default. See paged().
        """
        return self.paged()


    def getData(self,pagesize=128):
        recordset = win32com.client.Dispatch('ADODB.Recordset')
        if self.order_by:
            recordset.Open('SELECT * FROM ' + '[' + self.name + ']' + 'ORDER BY '.format(self.order_by),self.document.connection,0,1)
        else:
            recordset.Open('SELECT * FROM ' + '[' + self.name + ']',self.document.connection,0,1)
        try:
            fields = [self.encoding(field.Name) for field in recordset.Fields]
            ok = True
            while ok: 
                rows = zip(*recordset.GetRows(pagesize))
                
                if recordset.EOF:
                    # close the recordset as soon as possible
                    recordset.Close()
                    recordset = None
                    ok = False

                for row in rows:
                    yield dict(zip(fields, map(self.encoding,row)))
        except:
            if recordset is not None:
                recordset.Close()
                del recordset
            raise
        