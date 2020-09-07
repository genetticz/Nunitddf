using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace NunitDDF.Generic
{
    public class ExcelReader
    {
       
        public static IEnumerable ReadExcel()
        {
            string fileName = @"/Users/michaelwitter/Projects/NunitDDF/NunitDDF/Resources/testusers.xlsx";
            try
            {
                IWorkbook workbook = null;
                List<string[]> keeper = new List<string[]>();
                
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);
                //First sheet
                ISheet sheet = workbook.GetSheetAt(0);
                //Console.WriteLine("Rows " + sheet.LastRowNum);
                if (sheet != null)
                {
                    int rowCount = sheet.LastRowNum; // This may not be valid row count.
                // If first row is table head, i starts from 1
                for (int i = 1; i <= rowCount; i++)
                    {
                        IRow curRow = sheet.GetRow(i);
                        // Works for consecutive data. Use continue otherwise 
                        if (curRow == null)
                        {
                            // Valid row count
                            rowCount = i - 1;
                            break;
                        }
                    //PhysicalNumberOfCells is 0 if cell is empty
                    if (curRow.PhysicalNumberOfCells > 0)

                    {
                        // Get data from the 4th column (4th cell of each row)
                        //var cellValue = curRow.GetCell(3).StringCellValue.Trim();
                        //Console.WriteLine(cellValue);

                        //2d array is declared as [1, 2] for 1 row and 2 columns.But indexed as 0, 1 for column 1 and column 2
                        string[] _cellVals = new string[curRow.LastCellNum];
  
                        for (int j = 0; j < curRow.LastCellNum; j++)
                        {
                            _cellVals[j] = curRow.GetCell(j).StringCellValue;
                           
                        }
                        keeper.Add(_cellVals);
                    }
                   

                }
                }
            return keeper;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
            
               


                    


