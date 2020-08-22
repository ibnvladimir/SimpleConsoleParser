using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите стороны треугольника для расчета его периметра и площади");
                Console.ForegroundColor = ConsoleColor.White;

                double[] sides = new double[3];

                int i = 0;
                while ( i < sides.Length)
                {
                    Console.Write("> ");
                    var sideCandidateAsString = Console.ReadLine();

                    if (!(double.TryParse(sideCandidateAsString, out var sideCandidate)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ErrorMessage(sideCandidateAsString));
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    if (IsZeroOrLess(sideCandidate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Сторона треугольника не может быть меньше или равна 0!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    sides[i] = sideCandidate;
                    i++;
                }

                if (!IsTriangleExists(sides[0], sides[1], sides[2]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Треугольник с такими сторонами не может существовать!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    var triangle = new Triangle(sides[0], sides[1], sides[2]);
                    Console.WriteLine($"Периметр треугольника = {triangle.GetPerimeter()}");
                    Console.WriteLine($"Площадь треугольника = {triangle.GetSquare()}");
                }

        }

        /// <summary>
        /// It is only needed to check what kind of error occurred
        /// </summary>
        /// <param name="stringCandidate"></param>
        /// <returns></returns>
        public static string ErrorMessage(string stringCandidate)
        {
            try
            {
                var d = double.Parse(stringCandidate);
            }
            catch (ArgumentNullException)
            {
                return  "Пустое значение!";
            }
            catch (FormatException)
            {
                return "Не верный формат, возможно вы ввели не число!";
            }
            catch (OverflowException)
            {
                return "Слишком длиннное число!";
            }
            return "Произошла неизвестная ошибка, пожалуйста, попробуйте ещё раз!";
        }

        public static bool IsZeroOrLess(double sideCandidate)
        {
            if (sideCandidate <= 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsTriangleExists(double a, double b, double c)
        {
            if (a + b <= c || b + c <= a || c + a <= b)
            {
                return false;
            }

            return true;
        }
    }
}
