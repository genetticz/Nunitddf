using System;
using System.IO;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NunitDDF.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitDDF
{
    public class BrowserDriver
    {
        public IWebDriver driver;
        ExtentReports extentReports;
        ExtentTest extent;
         

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"/Users/michaelwitter/Downloads");
            extentReports = ExtentManager.getInstance();
            extent = extentReports.CreateTest(TestContext.CurrentContext.Test.MethodName, TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void ShutDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.Empty + TestContext.CurrentContext.Result.StackTrace + string.Empty;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", string.Empty);
                    string finalpth = path + "Defect_Screenshots\\" + DateTime.Now.ToString("yyyyMMMdd") + "\\testImage.png";
                    extent.Log(logstatus, "Test steps NOT Completed for Test case " + TestContext.CurrentContext.Test.Name + " ");
                    extent.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                    extent.Log(logstatus, "Snapshot below for Test Case :  " + TestContext.CurrentContext.Test.Name + " " + extent.AddScreenCaptureFromPath(finalpth));
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    extent.Log(logstatus, "Test ended with " + logstatus);
                    break;
                default:
                    logstatus = Status.Pass;
                    extent.Log(Status.Pass, "Test steps finished for test case " + TestContext.CurrentContext.Test.Name);
                    extent.Log(logstatus, "Test ended with " + logstatus);
                    break;
            }
            extentReports.Flush();
            driver.Quit();
        }

        public string Capture(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenShotName = "screenShotName_" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_fff");
            string workingDirectory = Environment.CurrentDirectory;
            string parentfolder = Directory.GetParent(workingDirectory).Parent.Parent.FullName;//Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string finalpth = parentfolder + @"/screenshots/";
            string screenshotDir = finalpth + screenShotName + ".png";
            string localpath = new Uri(screenshotDir).LocalPath;
            System.IO.Directory.CreateDirectory(finalpth);
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }
    }
}