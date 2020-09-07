using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace NunitDDF.Generic
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlreporter;
        private static ExtentReports extent;
        
        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string parentfolder = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                Console.WriteLine("parent directory " + parentfolder);
                htmlreporter = new ExtentHtmlReporter(parentfolder + "/Report/");
                extent = new ExtentReports();
                extent.AttachReporter(htmlreporter); 
            }
            return extent;
        }
    }
}
