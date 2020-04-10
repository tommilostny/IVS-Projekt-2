using System;
using System.Collections.Generic;
using System.Linq;
using MathLib;

namespace Profiling
{
    class Program
    {
        static void Main(string[] args)
        {
            double s = 0; //result standard deviation
            int N = 0; //N = count of numbers x
            double xi_sum = 0;

            //loading input numbers from stdin
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                try
                {
                    double number = Convert.ToDouble(line);

                    s = s + Math.Pow(number, 2); // sum( xi^2 )     //TODO: replace with our add, power methods

                    N = N + 1; // TODO: replace with our add

                    xi_sum = xi_sum + number; // sum(xi)   // TODO: replace with our add
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

            try
            {
                double xx = MathClass.Divide(xi_sum, N); // x' = 1/N * sum(xi) = sum(xi)/N

                xx = Math.Pow(xx, 2); // x'^2     //TODO: replace with our power method

                xx = N * xx; // N * x'^2      //TODO: replace with our multiplication method

                s = MathClass.Subract(s, xx); // sum(xi^2) - (N * x'^2)

                s = MathClass.Divide(s, N - 1); // 1/(N-1) * (sum(xi^2) - (N * x'^2))

                //TODO: replace with our square root method
                s = Math.Sqrt(s); // second square root of   1/(N-1) * (sum(xi^2) - (N * x'^2))

                Console.WriteLine(s);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
