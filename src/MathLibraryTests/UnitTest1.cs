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
    }

    [TestClass]
    public class Factorial_UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FactorialNegatives_Test()
        {
            MathClass.Factorial(-1);
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
}