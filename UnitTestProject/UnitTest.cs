using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практическая_работа_4_Краснова_Солодов.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Page1_RightData()
        {
            var page = new Page1();
            Assert.IsTrue(page.Calculate("1", "2", "4"));
        }
        [TestMethod]
        public void Page1_BadData()
        {
            var page = new Page1();
            Assert.IsFalse(page.Calculate("wewedw", "2", "4"));
        }
        [TestMethod]

        public void Page2_RightDataVar1()
        {
            var page = new Page2();
            Assert.IsTrue(page.Calculate("1", "1", "var1"));
        }

        [TestMethod]
        public void Page2_RightDataVar2()
        {
            var page = new Page2();
            Assert.IsTrue(page.Calculate("1", "1", "var2"));
        }
        [TestMethod]
        public void Page2_RightDataVar3()
        {
            var page = new Page2();
            Assert.IsTrue(page.Calculate("1", "1", "var3"));
        }
        [TestMethod]
        public void Page2_BadData()
        {
            var page = new Page2();
            Assert.IsFalse(page.Calculate("e", "1", "var3"));
        }
        [TestMethod]
        public void Page2_LongData()
        {
            var page = new Page2();
            Assert.IsFalse(page.Calculate("223413223413223413223413223413223413223413223413223413223413223413223413223413223413223413223413223413223413223413", "1", "var3"));
        }

        [TestMethod]
        public void Page3_RightData()
        {
            var page = new Page3();
            Assert.IsTrue(page.Calculate("32"));
        }
        [TestMethod]
        public void Page3_BadData()
        {
            var page = new Page3();
            Assert.IsFalse(page.Calculate("exw"));
        }
        [TestMethod]
        public void Page3_OverflowException()
        {
            var page = new Page3();
            Assert.IsFalse(page.Calculate("-1"));
        }
        [TestMethod]
        public void Page3_DivideByZeroException()
        {
            var page = new Page3();
            Assert.IsFalse(page.Calculate("0"));
        }
    }
}
