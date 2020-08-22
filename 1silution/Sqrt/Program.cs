using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqrt
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            double baseNumber;
            int exponent;
            double accuracy;

            while (true)
            {
                while (true)//InputBaseNumber
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
                        if (baseNumber <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Я не умею извлекать корень из отрицательного числа и 0!");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        break;
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
                }

                while (true) //InputExponent
                {
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
                        if (exponent <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Я не умею извлекать корни отрицательной степени и со степенью 0!");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        break;
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

                    
                   

                }

                while (true) //InputAccuracy
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Введите желаемую точность расчета (по умолчанию 0.01) или @ для выхода из программы:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("> ");
                    var accuracyAsString = Console.ReadLine();
                    if (accuracyAsString == "@") { return; }
                    if (String.IsNullOrWhiteSpace(accuracyAsString))
                    {
                        Console.WriteLine("> принято значение по умолчанию = 0.01");
                        accuracy = 0.01;
                        break;
                    }

                    try
                    {
                        accuracy = double.Parse(accuracyAsString);
                        if (accuracy <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Отрицательная и нулевая точность не допустимы!");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        break;
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
                }

                var newton = new NewtonSqrt();
                Console.WriteLine("Вычисленно по алгоритму Ньютона:" + newton.NewtonSqrtMethod(exponent, baseNumber, accuracy));
                Console.WriteLine("Стандартный метод C#           :" + Math.Pow(baseNumber, 1f / exponent));
            }

        }
    }
}
