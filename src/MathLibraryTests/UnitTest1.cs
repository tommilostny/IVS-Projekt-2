using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;

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
    }
}
