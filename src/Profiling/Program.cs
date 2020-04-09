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
            List<double> x = new List<double>();

            while ((line = Console.ReadLine()) != null)
            {
                x.Add(Convert.ToDouble(line));
            }

            double s; //výsledná směrodatná odchylka
            int N = x.Count; //počet načtených hodnot x
        }
    }
}
