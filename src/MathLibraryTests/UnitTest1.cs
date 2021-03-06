﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void FactorialNegatives_Test()
		{
			MathClass.Factorial(-1);
		}

		[TestMethod]
		public void FactorialResults_Test()
		{
			int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 11, 20 };
			double[] results = { 1, 1, 2, 6, 24, 120, 720, 39916800, 2432902008176640000 };

			for (int i = 0; i < numbers.Length; i++)
				Assert.AreEqual(results[i], MathClass.Factorial(numbers[i]));
		}

		[TestMethod]
		[ExpectedException(typeof(OverflowException))]
		public void FactorialOverflow_Test()
		{
			MathClass.Factorial(333);
		}
	}

	[TestClass]
	public class BasicArithmetic_UnitTest
	{
		[TestMethod]
		public void Subtract_Test()
		{
			Assert.AreEqual(7, MathClass.Subtract(10, 3)); //10-3=7

			for (int i = -23; i <= 23; i++)
				Assert.AreEqual(0, MathClass.Subtract(i, i));

			Assert.AreEqual(10, MathClass.Subtract(5, -5)); //5 - -5 = 5 + 5 = 10 
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

		[TestMethod]
		public void Mul_Test()
		{
			Assert.AreEqual(8, MathClass.Multiply(2, 4)); //2 * 4 = 8
			Assert.AreEqual(-10, MathClass.Multiply(2, -5)); //2 * (-5) = -10
			Assert.AreEqual(-12, MathClass.Multiply(-4, 3)); //-4 * 3 = -12
			Assert.AreEqual(6, MathClass.Multiply(-2, -3)); //-2 * (-3) = 6

			for (double i = -15; i <= 15; i++)
				Assert.AreEqual(Math.Pow(i, 2), MathClass.Multiply(i, i));
		}

		[TestMethod]
		public void Pow_Test()
		{
			Assert.AreEqual(4, MathClass.Power(2, 2)); //2^2 = 4
			Assert.AreEqual(125, MathClass.Power(5, 3)); //5^3 = 125
			Assert.AreEqual(0.0625, MathClass.Power(4, -2)); //-4^(-2) = 0.0625
			Assert.AreEqual(0.001, MathClass.Power(10, -3)); //10^(-3) = 0.001
			Assert.AreEqual(0.25, MathClass.Power(0.5, 2)); //0.5^2 = 0.25
		}

		[TestMethod]
		public void Add_Test()
		{
			Assert.AreEqual(4, MathClass.Add(2, 2)); //2+2 = 4
			Assert.AreEqual(10, MathClass.Add(0, 10)); //0+10 = 10
			Assert.AreEqual(20, MathClass.Add(20, 0)); //20+0 = 20
			Assert.AreEqual(-3, MathClass.Add(5, -8)); //5-8 = -3
			Assert.AreEqual(1, MathClass.Add(-6, 7)); //(-6)+7 = 1

			for (double i = -15; i <= 15; i++)
				Assert.AreEqual(0, MathClass.Add(-i, i));
		}
	}

	[TestClass]
	public class Sqrt_UnitTest
	{
		[TestMethod]
		public void Sqrt_Test()
		{
			Assert.AreEqual(3, MathClass.Sqrt(2, 9)); // 2√9 = 3
			Assert.AreEqual(3, MathClass.Sqrt(3, 27)); // 3√27 = 3
			Assert.AreEqual(3, MathClass.Sqrt(4, 81)); // 4√81 = 3
			Assert.AreEqual(-2, MathClass.Sqrt(3, -8)); // 3√(-8) = -2
			Assert.AreEqual(-2, MathClass.Sqrt(5, -32)); // 5√(-32) = -2
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SqrtError_Test1()
		{
			MathClass.Sqrt(2, -9);
			MathClass.Sqrt(4, -16);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void SqrtError_Test2()
		{
			MathClass.Sqrt(-2, 9);
			MathClass.Sqrt(0.5, -16);
		}
	}
}
