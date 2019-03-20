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
            SaveLog.LogMessage("new test", 1, 2);
        }

        [TestMethod]
        public void TestMethodSaveLog_2()
        {
            SaveLog.LogMessage("new test 2", 2, 1);
        }

        [TestMethod]
        public void TestMethodSaveLog_3()
        {
            SaveLog.LogMessage("new test 3", 3, 3);
        }
        [TestMethod]
        public void TestMethodSaveLog_4()
        {
            SaveLog.LogMessage("new test 4", 3, 0);
        }

        [TestMethod]
        public void TestMethodSaveLog_5()
        {
            SaveLog.LogMessage("new test 4", 0, 0);
        }
    }
}