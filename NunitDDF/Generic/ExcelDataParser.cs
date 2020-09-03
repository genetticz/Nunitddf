using System;
namespace NunitDDF.Generic
{
    public class ExcelDataParser
    {
        static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        //static string projectPath = new Uri(actualPath).LocalPath;
        static string excelPath = @"";

        public static IEnumerable<TestCaseData> BudgetData
        {
            get
            {
                List<TestCaseData> testCaseDataList = new ExcelReader().ReadExcelData(excelPath);

                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }
    }
}
