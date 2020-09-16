using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using ExcelObj = Microsoft.Office.Interop.Excel;

namespace ConsoleApp1
{
    public class Excel
    {
        public string Path { get; set; } = string.Empty;
        _Application excel = new ExcelObj.Application();
        Workbook wb;
        Worksheet ws;
        

        public Excel(string i_Path, int i_Sheet)
        {
            Path = i_Path;
            wb = excel.Workbooks.Open(Path);
            ws = wb.Worksheets[i_Sheet];
        }

        public string ReadCell(int i_Row, int i_Col)
        {
            i_Row++;
            i_Col++;
            if (ws.Cells[i_Row,i_Col].Value2 != null)
            {
                Console.WriteLine(ws.Cells[i_Row, i_Col].Value2);
              
                return "OK";
            }
            else
            {
                return string.Empty;
            }
        }

        internal void closeConnection()
        {
            wb.Close();
        }
    }
}
