using System;

namespace MathLib
{
    public static class MathClass
    {
        // Zde doplňte vaše matematické funkce

        // Return first prime number after given number.
        public static long FirstPrimeNumberAfterNumber(long number){
            if (number < 2) return 2; // 2 is first prime number
            if(number % 2 == 0) number--;   // Make number odd
            bool finded = false;  
            bool findedFactor;
            while(!finded){
                findedFactor = true;
                number+=2;
                for(int i = 3;i <= Math.Sqrt(number); i += 2){    // ----TODO: Replace with our Sqrt function
                    if(number % i == 0) {
                        findedFactor = false;
                        break;
                    }
                }
                if(findedFactor){
                        finded = true;
                }
            }
            return number;    
        }
        // Return division of 2 number, num1/num2, if num 2 is 0 exception is throwned
        public static double Divide(double num1, double num2)
        {
            if (num2 == 0) throw new DivideByZeroException();
            return num1 / num2;
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
        public static long Factorial(long number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException();

            if (number <= 1)
                return 1;

            long result = 2;
            for (int i = 3; i <= number; i++)
            {
                result *= i;
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
    }
}