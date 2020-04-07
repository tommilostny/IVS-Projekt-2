using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;
using System;

namespace MathLibraryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void PrimeNumberTest()
        {
            Assert.AreEqual(2, MathClass.FirstPrimeNumberAfterNumber(-99999));
            Assert.AreEqual(2, MathClass.FirstPrimeNumberAfterNumber(0));
            Assert.AreEqual(2, MathClass.FirstPrimeNumberAfterNumber(1));
            Assert.AreEqual(3, MathClass.FirstPrimeNumberAfterNumber(2));
            Assert.AreEqual(5, MathClass.FirstPrimeNumberAfterNumber(3));
            Assert.AreEqual(5, MathClass.FirstPrimeNumberAfterNumber(4));
            Assert.AreEqual(29, MathClass.FirstPrimeNumberAfterNumber(25));
            Assert.AreEqual(149, MathClass.FirstPrimeNumberAfterNumber(139));
            Assert.AreEqual(149, MathClass.FirstPrimeNumberAfterNumber(141));
            Assert.AreEqual(149, MathClass.FirstPrimeNumberAfterNumber(144));
        }
        [TestMethod]
        public void DivisionTest()
        {
            Assert.AreEqual(1 , MathClass.Divide(2, 2));
            Assert.AreEqual(0.5, MathClass.Divide(2, 4));
            Assert.AreEqual(-2, MathClass.Divide(2, -1));
            Assert.AreEqual(-1, MathClass.Divide(2, -2));
            Assert.AreEqual(2, MathClass.Divide(-6, -3));

            //Must throw an expetion.
            Assert.ThrowsException<DivideByZeroException>(() => MathClass.Divide(1, 0));
            Assert.ThrowsException<DivideByZeroException>(() => MathClass.Divide(-1, 0));

        }

    }
}
