using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;

namespace GreatestCommonFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Приложение ищет наибольший общий делитель для двух положительных целых чисел. Есть возможность ипользовать два варианта алгоритмов. ");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("По какому алгоритму бумем считать? Введите @ для выхода из программы");
                Console.WriteLine("1. Евклида - принимает неограниченное количество значений");
                Console.WriteLine("2. Стейна - примимает всего 2 значения, зато работает быстрее");

           
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                var switcher = Console.ReadLine();

                switch (switcher)
                {
                    case "1":
                        EuclidAlgorithm();
                        break;
                    case "2":
                        SteinAlgorithm();
                        break;
                    case "@":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Нет такого пункта в меню. Введите 1, 2 или @");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                }
            }
            
            
        }



        static void EuclidAlgorithm()
        {
            var setOfIntegers = new List<int>();
            
            PrintGreating();
            do
            {
                //user input
                Console.Write("> ");
                var tempVar = Console.ReadLine();

                if (tempVar == "@")
                {
                    break;
                }

                //do not respond to the input of an empty value and require further input
                if (string.IsNullOrWhiteSpace(tempVar))
                {
                    continue;
                }

                if (tempVar == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите значение отличное от 0!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                //trying to add a new item to the collection otherwise handle exceptions
                try
                {
                    setOfIntegers.Add(int.Parse(tempVar));
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пустое значение!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Похоже, что это не число!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Слишком большое число!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (true);

            //checking for the number of elements in the collection to give the arguments correctly
            if (setOfIntegers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы не ввели ни одного значения!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else if (setOfIntegers.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели только одно значение!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else 
            {
                int a = setOfIntegers[0];
                int b = setOfIntegers[1];
                setOfIntegers.RemoveAt(0);
                setOfIntegers.RemoveAt(0);
                int[] c = new int[setOfIntegers.Count];
                for (var i = 0; i < setOfIntegers.Count; i++)
                {
                    c[i] = setOfIntegers[i];
                }

                double timer;
                int result = TimeCounterForEuclidAlgorithm(a, b, c, out timer);
                OutputTheResults(result, timer);
                
            }
        }

        static void OutputTheResults(int result, double timer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Наибольший общий делитель для введенных чисел = ");
            Console.ForegroundColor = ConsoleColor.White; 
            Console.WriteLine(result);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Время расчетов составило: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{timer} сек.");
            Console.WriteLine();
        }


        static int TimeCounterForEuclidAlgorithm(int a, int b,  int[] c, out double timer)
        {
            Stopwatch sw = new Stopwatch();
            var gcf = new GreatestCommonFactorCounter();

            sw.Start();
            var result = gcf.FactorCounter(a, b, c);
            sw.Stop();

            timer = sw.Elapsed.TotalMilliseconds;
            return result;
        }

        static int TimeCounterForSteinAlgorithm(int a, int b, out double timer)
        {
            Stopwatch sw = new Stopwatch();
            var gcf = new GreatestCommonFactorCounter();

            sw.Start();
            var result = gcf.Stein(a, b);
            sw.Stop();

            timer = sw.Elapsed.TotalMilliseconds;
            return result;
        }

        static void PrintGreating()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите числа, для которых хотите найти наибольший общий делитель,  \"@\" - закончить ввод.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static int ParseToIntWithWarnings(string value)
        {
            string errorMessage;
            int parseedInt;

            try
            {
                parseedInt = int.Parse(value);
                return parseedInt;
            }
            catch (ArgumentNullException)
            {
                errorMessage = "Пустое значение!";
                return -1;
            }
            catch (FormatException)
            {
                Console.WriteLine("Похоже, что это не число!");
                return -1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Слишком большое число!");
                return -1;
            }
        }

        static void SteinAlgorithm()
        {   
            var setOfIntegers = new List<int>();
            PrintGreating();

            do
            {
                Console.Write("> ");
                var tempVar = Console.ReadLine();

                if (tempVar == "@")
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(tempVar))
                {
                    break;
                }
                if (tempVar == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите значение отличное от 0!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                setOfIntegers.Add(ParseToIntWithWarnings(tempVar));

                
            } while (true);

            var result = TimeCounterForSteinAlgorithm(setOfIntegers[0], setOfIntegers[1], out var timer);
            OutputTheResults(result, timer);
           
        }
    }
}
