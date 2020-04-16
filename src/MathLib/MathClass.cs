using System;

namespace MathLib
{
    public static class MathClass
    {
        /// <summary>
        /// Calculate prime number after certain number.
        /// </summary>
        /// <remarks>Autor: Michal Rivola (xrivol01)</remarks>
        /// <exception cref="System.OverflowException">
        /// Thrown if a HUUUGE number is entered.
        /// </exception>
        /// <param name="number">Number from which start calculating Prime number</param>
        /// <returns>Calculated division.</returns>
        public static long FirstPrimeNumberAfterNumber(double number)
        {
            number = Math.Floor(number);
            if (number < 2) return 2; // 2 is first prime number
            if (number % 2 == 0) number--;   // Make number odd
            bool finded = false;
            bool findedFactor;
            while (!finded)
            {
                findedFactor = true;
                number += 2;
                for (int i = 3; i <= Math.Sqrt(number); i += 2)
                {    // ----TODO: Replace with our Sqrt function
                    if (number % i == 0)
                    {
                        findedFactor = false;
                        break;
                    }
                }
                if (findedFactor)
                {
                    finded = true;
                }
            }
            return Convert.ToInt64(number);
        }

        /// <summary>
        /// Function to calculate the division of two number.
        /// </summary>
        /// <remarks>Autor: Michal Rivola (xrivol01)</remarks>
        /// <exception cref="System.DivideByZeroException">
        /// Thrown if second number is 0
        /// </exception>
        /// <param name="number1">Dividend</param>
        /// <param name="number2">Divisor</param>
        /// <returns>Calculated division.</returns>
        public static double Divide(double number1, double number2)
        {
            if (number2 == 0) throw new DivideByZeroException("Nelze dělit 0.");
            return number1 / number2;
        }

        /// <summary>
        /// Function to calculate the factorial of a number.
        /// </summary>
        /// <remarks>Autor: Tomáš Milostný (xmilos02)</remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown if number is out of range 0+
        /// </exception>
        /// <param name="number">Number to calculate factorial from.</param>
        /// <returns>Calculated factorial.</returns>
        public static double Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException();

            if (number <= 1)
                return 1;

            double result = 2;
            for (double i = 3; i <= number; i++)
            {
                result *= i;
                if (double.IsInfinity(result))
                    throw new OverflowException();
            }
            return result;
        }

        /// <summary>
        /// Subtract num2 from num1.
        /// </summary>
        /// <remarks>Author: Tomáš Milostný (xmilos02)</remarks>
        /// <param name="num1">Number to subtract from.</param>
        /// <param name="num2">Subtracted number.</param>
        /// <returns>Number 1 minus Number 2.</returns>
        public static double Subract(double num1, double num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Function to calculate the radical.
        /// </summary>
        /// <remarks>Autor: Daniel Ponížil (xponiz01)</remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// /// <exception cref="System.ArgumentException">
        /// <param name="num1">Index (degree) of the root.</param>
        /// <param name="num2">Root number.</param>
        /// <returns>Calculated radical.</returns>
        public static double Sqrt(double num1, double num2)
        {
            double result = 0;
            if (num2 < 0 && num1 %2 == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (num2 < 0 && num1 %2 != 0)
            {
                double tmp = Math.Abs(num2);
                result = Math.Pow(tmp, 1.0 / num1);
                return -result;
            }

            if (num2 == 0)
                return result;

            if (num1 < 1)
                throw new ArgumentException();

            result = Math.Pow(num2, 1.0 / num1);
            return result;
        }

        /// <summary>
        /// Function to calculate the multiplication.
        /// </summary>
        /// <remarks>Autor: Daniel Ponížil (xponiz01)</remarks>
        /// <param name="num1">First number for multiplication.</param>
        /// <param name="num2">Second number for multiplication.</param>
        /// <returns>Calculated multiplication.</returns>
        public static double Mul(double num1, double num2)
        {
            return num1 * num2;
        }

        // <summary>
        /// Function to calculate the exponentiotion.
        /// </summary>
        /// <remarks>Autor: Daniel Ponížil (xponiz01)</remarks>
        /// <param name="num1">Number for exponentiation.</param>
        /// <param name="num2">Potentiator.</param>
        /// <returns>Calculated exponentiation.</returns>
        public static double Pow(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }

        // <summary>
        /// Function to calculate the exponentiotion.
        /// </summary>
        /// <remarks>Autor: Daniel Ponížil (xponiz01)</remarks>
        /// <param name="num1">Number for exponentiation.</param>
        /// <param name="num2">Potentiator.</param>
        /// <returns>Calculated exponentiation.</returns>
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}