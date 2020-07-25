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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите данные или @ для выхода в меню");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                string sourceData = Console.ReadLine();
                if (sourceData == "@" ) { break; }
                if (sourceData == "") { continue; }

                    var parser = new Parser();
                parser.TryToConvert(sourceData);
                if (!parser.IsParseSuccessful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(parser.ExceptionMessage);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }                
                Point point = new Point(parser.Result[0], parser.Result[1]);
                point.PrintCordinateToConsole();
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

