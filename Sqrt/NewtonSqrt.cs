using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqrt
{
    public class NewtonSqrt
    {
        public double Pow(double x0, int exponent)
        {
            double result = 1;
            for (int i = 0; i < exponent; i++) 
            { 
                result *= x0; 
            }
            return result;
        }

        public  double NewtonSqrtMethod(int exponent, double baseNumber, double accuracy = 0.01)
        {
            var x0 = Math.Sqrt(baseNumber);
            var x1 = NewtonSqrtFormula(exponent, baseNumber, x0);
            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = NewtonSqrtFormula(exponent, baseNumber, x0);
            }
            return x1;
        }

        public double NewtonSqrtFormula(int exponent, double baseNumber, double x0)
        {
            double pow = Pow(x0, exponent - 1);
            double result = (1f / exponent) * ((exponent - 1) * x0 + baseNumber / pow);
                                                                  
            return result; 
        }
    }
}
