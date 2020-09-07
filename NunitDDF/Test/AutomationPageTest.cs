using System;
using NUnit.Framework;
using NunitDDF.Pages;

namespace NunitDDF.Test
{
    public class AutomationPageTest: BrowserDriver
    {
        AutomationPage automationPage;

        [SetUp]
        public void Initialization()
        {
            automationPage = new AutomationPage(driver);
        }

        [Test]
        public void TitleTest()
        {
            automationPage.GoToLink();
            string expected = "Automation Practice - Ultimate QA";
            string actual = automationPage.PageTitle();
            Assert.AreEqual(expected, actual);
        }
    }
}
