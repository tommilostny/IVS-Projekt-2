using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;
using System;

namespace MathLibraryTests
{
    [TestClass]
    public class PrimeNumber_UnitTest
    {
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
    }

    [TestClass]
    public class Factorial_UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FactorialNegatives_Test()
        {
            MathClass.Factorial(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void FactorialBigNumbers_Test()
        {
            MathClass.Factorial(12345);
        }

        [TestMethod]
        public void FactorialResults_Test()
        {
            long[] numbers = { 0, 1, 2, 3, 4, 5, 6, 11, 20 };
            long[] results = { 1, 1, 2, 6, 24, 120, 720, 39916800, 2432902008176640000 };

            for (int i = 0; i < numbers.Length; i++)
                Assert.AreEqual(results[i], MathClass.Factorial(numbers[i]));
        }
    }

    [TestClass]
    public class BasicArithmetic_UnitTest
    {
        [TestMethod]
        public void Subtract_Test()
        {
            Assert.AreEqual(7, MathClass.Subract(10, 3)); //10-3=7

            for (int i = -23; i <= 23; i++)
                Assert.AreEqual(0, MathClass.Subract(i, i));

            Assert.AreEqual(10, MathClass.Subract(5, -5)); //5 - -5 = 5 + 5 = 10 
        }

        [TestMethod]
        public void DivisionTest()
        {
            Assert.AreEqual(1, MathClass.Divide(2, 2));
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