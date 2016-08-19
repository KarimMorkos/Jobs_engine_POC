using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office;
using Microsoft.Office.Tools;
using OfficeOpenXml;
using System.Configuration;
using KKamal_CaDevelopmentPlan.Tools;
using System.Data;
using System.Data.OleDb;
using System.Xml;






namespace KKamal_CaDevelopmentPlan.Tools
{
    public class ExcelDataReader
    {

        
        #region Without Oledb
        //string ColValues;
        //int Row;
        //int Col;

        //public IReadOnlyCollection<string> ReadExcelDataWithoutOledb(string FileName, string WorkSheetName)
        //{

        //    try
        //    {
                
        //        ExcelPackage package = new ExcelPackage(new FileInfo(FileName));
        //        ExcelWorksheet worksheet = package.Workbook.Worksheets[WorkSheetName];

        //        var StartPoint = worksheet.Dimension.Start;
        //        var EndPoint = worksheet.Dimension.End;

        //        if (worksheet != null)
        //        {
        //            for (Row = 2; !(Row > EndPoint.Row); Row++)
        //            {
        //                for (Col = 1; !(Col > EndPoint.Column); Col++)
        //                {
        //                    if (Browser.Driver == null) continue;
        //                    mycollection = package.Workbook.Worksheets[1].Cells[Row,Col].Count<string>;
        //                }
        //            }
        //        }

        //        else { Console.Out.WriteLine("No Data Found!"); }
                
        //    }
        //    catch (Exception ex)
        //    {
                
        //        Console.Out.WriteLine(ex.StackTrace.ToString());
        //    }

        //    return mycollection;

        //}
        #endregion

        public static string connectionStringBuilder(string ExcelfileName)
        {
            string connectionString = "";
            string dataSource = ExcelfileName;
            
            
            if (Path.GetExtension(ExcelfileName) == ".xlsx")
                connectionString = "Data Source= " + dataSource + ConfigurationManager.ConnectionStrings["ExcelDataSourceExtXLSX"];
            if (Path.GetExtension(ExcelfileName) == ".xls")
                connectionString = "Data Source= " + dataSource + ConfigurationManager.ConnectionStrings["ExcelDataSourceExtXLS"];

            return connectionString;

        }

        #region With Oledb
        public DataTable ReadDataWithOleDB(string excelFileName, string workBookName)
        {
            try
            {
                var oleDbDataTable = new DataTable();
                string connectionString = connectionStringBuilder(excelFileName);

                if (!string.IsNullOrEmpty(connectionString))
                {
                    var oleDbConnection = new OleDbConnection(connectionString);

                    string commandtext = "Select * from [" + workBookName + "$]";


                    var oleDbCommand = new OleDbCommand(commandtext, oleDbConnection);
                    var oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand.CommandText, oleDbConnection.ConnectionString);

                    oleDbConnection.Open();

                    oleDbDataAdapter.Fill(oleDbDataTable);

                    oleDbConnection.Close();
                }
                return oleDbDataTable;

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace.ToString());
                return null;
            }
    
        }
        
        #endregion


    }
}
