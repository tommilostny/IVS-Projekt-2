using System;
using MathLib;

namespace Profiling
{
	class Program
	{
		static void Main()
		{
			double s = 0; //result standard deviation
			uint N = 0; //N = count of numbers x
			double xi_sum = 0;
			//loading input numbers from stdin
			string line = Console.In.ReadLine();
			while (line != null && line != "")
			{
				try
				{
					double number = Convert.ToDouble(line);
					s = MathClass.Add(s, MathClass.Pow(number, 2)); // sum( xi^2 )

					N = (uint)MathClass.Add(N, 1);

					xi_sum = MathClass.Add(xi_sum, number); // sum(xi)

					line = Console.In.ReadLine();
				}
				catch (Exception e) { Console.WriteLine(e.Message); return; }
			}

			try
			{
				double xx = MathClass.Divide(xi_sum, N); // x' = 1/N * sum(xi) = sum(xi)/N

				xx = MathClass.Pow(xx, 2); // x'^2

				xx = MathClass.Mul(N, xx); // N * x'^2

				s = MathClass.Subract(s, xx); // sum(xi^2) - (N * x'^2)

				s = MathClass.Divide(s, N - 1); // 1/(N-1) * (sum(xi^2) - (N * x'^2))

				s = MathClass.Sqrt(2, s); // square root of   1/(N-1) * (sum(xi^2) - (N * x'^2))

				Console.WriteLine(s);
			}
			catch (Exception e) { Console.WriteLine(e.Message); }
			return;
		}
	}
}
