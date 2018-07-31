using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Common;
using DAO;
using BLL;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ThoiKhoaBieuBLL dt = new ThoiKhoaBieuBLL();
            DateTime dtime = DateTime.UtcNow;
            DateTime newdt = dtime.AddDays(28);
           // dt.GetByMaGV("GV01");
        }
    }
}
