using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using NUnit.Framework;
using System.Configuration;


namespace CV.DataSource
{
    public class Excel_Translator
    {

        //class DataTable Represents one table of in-memory data.
        internal static DataTable ExcelToDataTable(string filename, string sheetName)
        {
            var stream = File.Open(filename, FileMode.Open, FileAccess.Read);

            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                //Reading from a OpenXml Excel file (2007 format; *.xlsx)

            excelReader.IsFirstRowAsColumnNames = true; // DataSet - Create column names from first row

            /* DataSet - Create column names from first row*/
            var result = excelReader.AsDataSet();
            var table = result.Tables;
            var resulTable = table[sheetName];

            return resulTable;

        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                // 2. Query creation.
                var data = (from colData in DataCol
                    where colData.ColName == columnName && colData.RowNumber == rowNumber
                    select colData.ColValue).FirstOrDefault();
                return data;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        //  1. Data source.
        public static readonly List<Datacollection> DataCol = new List<Datacollection>();

        public static void PopulateInCollection(string fileName, string sheetName)
        {
            var table = ExcelToDataTable(fileName, sheetName);

            // 3. Query execution.
            //Iterate through the rows and columns of the Table
            for (var row = 1; row <= table.Rows.Count; row++)
            {
                for (var col = 0; col < table.Columns.Count; col++)
                {
                    var dtTable = new Datacollection
                    {
                     RowNumber = row,
                        ColName = table.Columns[col].ColumnName,
                        ColValue = table.Rows[row - 1][col].ToString(),
                    };
                    //Add all the details for each row
                   DataCol.Add(dtTable);
                }
            }
        }
        public static string GetDataFileLocation()
        {
            var startDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string Location = startDirectory + ConfigurationManager.AppSettings["ExcelDataSource"];
            return Location;
        }


        public static string ColName { get; set; }

        public static string ColValue { get; set; }

        public static int RowNumber { get; set; }
    }
}
    
