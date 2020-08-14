using System;

namespace TriangleApp
{
    public class Triangle
    {
        double A { get; }
        double B { get; }
        double C { get; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

         ///<summary>
         /// Calculates the perimeter of triangle from the sum of the three sides.
         ///</summary>
        public  double GetPerimeter()
        {

            var perimeter = A + B + C;
            return perimeter;
        }

        ///<summary>
        /// Uses Heron's formula to find area. You need to know all three sides.
        ///</summary>
        public double GetSquare()
        {
            // ReSharper disable once PossibleLossOfFraction
            var halfPerimeter = GetPerimeter() / 2;
            var square = Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
            return square;
        }
    }
}
