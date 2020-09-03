using System;
using System.IO;
using AventStack.ExtentReports;
using NUnit.Framework;
using NunitDDF.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitDDF
{
    public class BrowserDriver
    {
        private IWebDriver driver;
        ExtentReports extentReports;
        ExtentTest extent;
         

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"/Users/michaelwitter/Downloads");
            extentReports = ExtentManager.getInstance();
        }

        [TearDown]
        public void ShutDown()
        {
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