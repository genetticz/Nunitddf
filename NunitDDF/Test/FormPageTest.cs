using System;
using System.Collections.Generic;
using NUnit.Framework;
using NunitDDF.Generic;

namespace NunitDDF.Test
{
    public class FormPageTest
    {
        [Test, TestCaseSource(typeof(ExcelReader), nameof(ExcelReader.ReadExcel))]
        public void SimpleTest(IList<string> mike)
        {
            Console.WriteLine("Output " + mike[0]);
        }
    }
}
