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
            string line;
            List<double> xi = new List<double>();

            //loading input numbers from stdin
            while ((line = Console.ReadLine()) != null)
            {
                xi.Add(Convert.ToDouble(line));
            }

            int N = xi.Count; //N = count of numbers x

            double s = xi.Sum(a => Math.Pow(a, 2)); // sum( xi^2 )     (TODO replace with out power method)

            double xx = MathClass.Divide(xi.Sum(), N); // x' = 1/N * sum(xi) = sum(xi)/N

            xx = Math.Pow(xx, 2); // x' ^ 2     (TODO: replace with our power method)

            xx = N * xx; // N * x'^2     (TODO: replace with our multiplication method)

            s = MathClass.Subract(s, xx); // sum(xi^2) - (N * x'^2)

            s = MathClass.Divide(s, N - 1); // 1/(N-1) * (sum(xi^2) - (N * x'^2))

            //TODO: replace with our square root method
            s = Math.Sqrt(s); // second square root of   1/(N-1) * (sum(xi^2) - (N * x'^2))

            Console.WriteLine(s);
        }
    }
}
