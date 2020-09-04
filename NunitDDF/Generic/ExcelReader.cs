﻿using System;
namespace NunitDDF.Generic
{
    public List<TestCaseData> ReadExcelData(string excelFile, string cmdText = "SELECT * FROM [Feuil1$]")
    {
        if (!File.Exists(excelFile))
            throw new Exception(string.Format("File name: {0}", excelFile), new FileNotFoundException());
        string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", excelFile);
        var ret = new List<TestCaseData>();
        using (var connection = new OleDbConnection(connectionStr))
        {
            connection.Open();
            var command = new OleDbCommand(cmdText, connection);
            var reader = command.ExecuteReader();
            if (reader == null)
                throw new Exception(string.Format("No data return from file, file name:{0}", excelFile));
            while (reader.Read())
            {
                var row = new List<string>();
                var feildCnt = reader.FieldCount;
                for (var i = 0; i < feildCnt; i++)
                    row.Add(reader.GetValue(i).ToString());
                ret.Add(new TestCaseData(row.ToArray()));
            }
        }
        return ret;
    }
}