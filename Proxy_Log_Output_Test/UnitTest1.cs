using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proxy_Log_Output;

namespace Proxy_Log_Output_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SampleClass cls = new SampleClass();

            cls.SampleMethod("");
            int exp = 10;
            int act = 5 + 5;
            Assert.AreEqual(exp, act);
        }
    }
}
