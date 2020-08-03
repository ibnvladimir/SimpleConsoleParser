using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqrt
{
    class NewtonSqrt1
    {
        static void someMethod()
        {
            Console.WriteLine(NewtonSqrtMethod(2, 5));
            Console.ReadKey();
        }

        static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) 
            { 
                result *= a; 
            }
            return result;
        }

        static double NewtonSqrtMethod(double exponent, double baseNumber, double eps = 0.0001)
        {
            var x0 = baseNumber / exponent;
            var x1 = (1 / exponent) * ((exponent - 1) * x0 + baseNumber / Pow(x0, (int)exponent - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / exponent) * ((exponent - 1) * x0 + baseNumber / Pow(x0, (int)exponent - 1));
            }

            return x1;
        }
    }
}
