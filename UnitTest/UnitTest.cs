using Logs;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodSaveLog()
        {
            SaveLog.LogMessage("prueba nueva", 3, 2);
        }
    }
}