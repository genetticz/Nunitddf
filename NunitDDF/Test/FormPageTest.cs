using NUnit.Framework;
using NunitDDF.Pages;

namespace NunitDDF.Test
{
    public class FormPageTest: BrowserDriver
    {
        public AutomationPage automationPage;
        public FormPage formpage;

        [SetUp]
        public void Initialization()
        {
            automationPage = new AutomationPage(driver);
            formpage = new FormPage(driver);
        }

        //[Test, TestCaseSource(typeof(ExcelReader), nameof(ExcelReader.ReadExcel))]
        //public void SimpleTest(IList<string> list)
        //{
        //    Console.WriteLine("Output " + list[0]);
        //}

        [Test]
        public void FormTest()
        {
            automationPage.GoToLink();
            automationPage.FormLink();
            formpage.FormClick();
            string expected = "Please, fill in the following fieldss:";
            string actual = formpage.FormErr();
            Assert.AreEqual(expected, actual);
        }
    }
}
