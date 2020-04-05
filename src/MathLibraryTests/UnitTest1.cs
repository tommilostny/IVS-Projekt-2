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
            Assert.Equals(2, MathClass.FirstPrimeNumberAfterNumber(-99999));
            Assert.Equals(2, MathClass.FirstPrimeNumberAfterNumber(0));
            Assert.Equals(2, MathClass.FirstPrimeNumberAfterNumber(1));
            Assert.Equals(3, MathClass.FirstPrimeNumberAfterNumber(2));
            Assert.Equals(5, MathClass.FirstPrimeNumberAfterNumber(3));
            Assert.Equals(5, MathClass.FirstPrimeNumberAfterNumber(4));
            Assert.Equals(29, MathClass.FirstPrimeNumberAfterNumber(25));
            Assert.Equals(149, MathClass.FirstPrimeNumberAfterNumber(139));
            Assert.Equals(149, MathClass.FirstPrimeNumberAfterNumber(141));
            Assert.Equals(149, MathClass.FirstPrimeNumberAfterNumber(144));
        }
        [TestMethod]
        public void DivisionTest()
        {
            Assert.Equals(1 , MathClass.Divide(2, 2));
            Assert.Equals(0.5, MathClass.Divide(2, 4));
            Assert.Equals(-2, MathClass.Divide(2, -1));
            Assert.Equals(-1, MathClass.Divide(2, -2));
            Assert.Equals(2, MathClass.Divide(-6, -3));

            //Must throw an expetion.
            Assert.ThrowsException<DivideByZeroException>(() => MathClass.Divide(1, 0));
            Assert.ThrowsException<DivideByZeroException>(() => MathClass.Divide(1, 0));

        }

    }
}
