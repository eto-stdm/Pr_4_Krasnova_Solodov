using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практическая_работа_4_Краснова_Солодов.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Page1_1()
        {
            var page = new Page1();
            Assert.IsTrue(page.IsAbleToCalculate("1", "2", "4"));
        }
        [TestMethod]
        public void Page1_2()
        {
            var page = new Page1();
            Assert.IsFalse(page.IsAbleToCalculate("wewedw", "2", "4"));
        }
        [TestMethod]
        public void Page3_1()
        {
            var page = new Page3();
            Assert.IsFalse(page.IsAbleToCalculate("32"));
        }
        [TestMethod]
        public void Page3_2()
        {
            var page = new Page3();
            Assert.IsFalse(page.IsAbleToCalculate("exw"));
        }
    }
}
