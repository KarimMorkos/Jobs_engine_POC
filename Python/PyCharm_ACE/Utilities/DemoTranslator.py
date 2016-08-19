import win32com

def getdata(self,filename,sheetname):
    self.oConn = win32com.client.Dispatch('ADODB.Connection')
    self.oConn.Open(
        'PROVIDER=Microsoft.ACE.OLEDB.12.0;'+
        'DATA SOURCE=%s'%filename+
        ';Extended Properties="Excel 12.0 Xml;HDR=1;IMEX=1"'
        )
    oRS = win32com.client.Dispatch('ADODB.Recordset')
    oRS.Open('SELECT * FROM ' + '[' + sheetname + ']',self.oConn)   
     
    result = []
     
    while not oRS.EOF:
        cols = [] 
        for x in range(0,len(oRS.Fields)):            
            cols.append(oRS.Fields(x).Value)
        result.append(cols) 
        oRS.MoveNext()                 
    oRS.Close()
    del oRS
    return result