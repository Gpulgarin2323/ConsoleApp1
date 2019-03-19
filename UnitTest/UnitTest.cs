using System;
using Logs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodHelperSaveLogger()
        {
            SaveLog.LogMessage("prueba nueva", 3, 2);
        }
    }
}
