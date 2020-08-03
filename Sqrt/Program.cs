using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqrt
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double baseNumber;
            int exponent;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите число из которого хотите извлечь корень или @ для выхода из программы:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                var baseNumberAsSring = Console.ReadLine();
                if (baseNumberAsSring == "@") { return; }
                if (String.IsNullOrWhiteSpace(baseNumberAsSring)) { continue; }

                try
                {
                    baseNumber = double.Parse(baseNumberAsSring);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Что-то не так с этим числом!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Слишком много знаков!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите степень корня (целое число) или @ для выхода из программы:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                var exponentAsString = Console.ReadLine();
                if (exponentAsString == "@") { return; }
                if (String.IsNullOrWhiteSpace(exponentAsString)) { continue; }

                try
                {
                    exponent = int.Parse(exponentAsString);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Что-то не так с этим числом!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Слишком много знаков!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                var newton = new NewtonSqrt();
                Console.WriteLine("Вычисленно по алгоритму Ньютона:" + newton.NewtonSqrtMethod(exponent, baseNumber));
                Console.WriteLine("Стандартный метод C#           :" + Math.Pow(baseNumber, 1f / exponent));

            }
           
            
            
        
        }
    }
}
