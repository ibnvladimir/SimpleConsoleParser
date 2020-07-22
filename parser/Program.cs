using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser
{
    class Program
    {
        static void Main(string[] args)
        {
            //    //23.8976,12.3218
            //    //25.76,11.9463
            //    //24.8293,12.67
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Каким образом вы хотите работьать с данными?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Ввести значение вручную >> Результат вывести на консоль");
                Console.WriteLine("0. Выйти из программы");
                Console.Write("> ");
                var switcher = Console.ReadLine();

                switch (switcher)
                {
                    case "1":
                        ManualInput();
                        break;
                    case "0":
                        return;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выберите один из представленных пунктов меню");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                        break;
                }
            }

        }

        static void ManualInput()
        {
            while (true)
            {
                DataInput:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите данные или @ для выхода в меню");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                string sourceData = Console.ReadLine();
                if (sourceData == "@") { break; }

                string[] coordinates = sourceData.Split(',');
                if (!CheckCountOfCoordinates(coordinates)) { continue; }
                if (!CheckForEmptyCoordinate(coordinates)) { continue; }

                decimal[] FormatedCoordinates = new decimal[coordinates.Length];
                for (int i = 0; i < coordinates.Length; i++)
                {
                    try
                    {
                        FormatedCoordinates[i] = decimal.Parse(coordinates[i]);
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный формат координаты");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto DataInput;
                    }
                }
                Point point = new Point(FormatedCoordinates[0], FormatedCoordinates[1]);
                point.PrintCordinateToConsole();
            }

        }

        
        static bool CheckForEmptyCoordinate(string[] coordinates)
        {
            //check for an empty coordinate value, or consisting of spaces, with an error message
            foreach (string coordinate in coordinates)
            {
                if (String.IsNullOrWhiteSpace(coordinate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Похоже, что одно из значений не задано");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
            return true;
        }

        static bool CheckCountOfCoordinates(string[] coordinates)
        {
            //Checking that there were exactly 2 numbers in the line with warnings, otherwise
            if (coordinates.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Похоже, что вы ввели меньше 2 координат");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else if (coordinates.Length > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Похоже, что вы ввели больше 2 координат");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else
            {
                return true;
            }
        }






        //Console.ForegroundColor = ConsoleColor.Red;
        //Console.BackgroundColor = ConsoleColor.Yellow;
        //Console.WriteLine("Вычисления c и s круга");
        //Console.WriteLine("");
        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.BackgroundColor = ConsoleColor.Black;
        //Console.Write("Введите радиус > ");
        //double r = Convert.ToDouble(Console.ReadLine());
        ////длина окружности:
        //double c = 2 * Math.PI * r;
        ////площадь круга:
        //double s = Math.PI * r * r;
        ////округляем значения:
        //c = Math.Round(c, 2);
        //s = Math.Round(s, 2);
        ////печатаем результаты вычислений в консольном окне:
        //Console.ForegroundColor = ConsoleColor.Green;
    }

}

