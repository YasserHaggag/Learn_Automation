using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace Learn_Automation
{
    public class Help
    {
       public string ExcelSetup(int x,int y)
        {
            excel.Application Xapp = new excel.Application();
            excel.Workbook Xworkbook = Xapp.Workbooks.Open("E:\\Selenium needs\\SearchDataFile");
            excel._Worksheet Xworksheet = Xworkbook.Sheets[1];
            excel.Range Xrange = Xworksheet.UsedRange;
           return Xrange.Cells[x][y].value2;
            

        }
        
        


       
      

    }
}
