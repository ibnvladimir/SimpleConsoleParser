using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParser
{
    class Program
    {
        
        static void Main(string[] args)//finish
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Каким образом вы хотите работать с данными?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Ввести значение вручную >> Результат вывести на консоль");
                Console.WriteLine("2. Взять значения из файла >> Результат записать в файл");
                Console.WriteLine("3. Взять значения из файла >> Результат вывести на консоль");
                Console.WriteLine("4. Ввести значение вручную >> Результат записать в файл");
                Console.WriteLine("0. Выйти из программы");
                Console.Write("> ");
                var switcher = Console.ReadLine();

                switch (switcher)
                {
                    case "1":
                        ManualInput_WriteToConsole();
                        break;
                    case "2":
                        ReadFromFIle_WriteToFile();
                        break;
                    case "3":
                        ReadFromFIle_WriteToConsole();
                        break;
                    case "4":
                        ManualInput_WriteToFile();
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

        static void ManualInput_WriteToConsole()//finish
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

        static void ReadFromFIle_WriteToFile()//ToDo
        {
            FileOperator fileOperator = new FileOperator();         
            fileOperator.TryToFindSourceFile();
            if (fileOperator.IsBreakOperation) { return; }
            fileOperator.TryToGetResultFile();
            if (fileOperator.IsBreakOperation) { return; }

            StreamReader streamReader = new StreamReader(fileOperator.SourceFileAddress);
            while (!streamReader.EndOfStream)
            {
                var parser = new Parser();                
                parser.TryToConvert(streamReader.ReadLine());
                if (!parser.IsParseSuccessful) { continue; }
                Point point = new Point(parser.Result[0], parser.Result[1]);
                point.PrintCordinateToFile(fileOperator.ResultFileAddress);
            }
            streamReader.Close();
        }

        static void ReadFromFIle_WriteToConsole()//ToDo
        {
            FileOperator fileOperator = new FileOperator();
            fileOperator.TryToFindSourceFile();
            if (fileOperator.IsBreakOperation) { return; }            

            string nextString;
            using (var f = new StreamReader(fileOperator.SourceFileAddress))
            {
                while ((nextString = f.ReadLine()) != null)
                {
                    var parser = new Parser();
                    parser.TryToConvert(nextString);
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

        }
        static void ManualInput_WriteToFile()//finish
        {
            FileOperator fileOperator = new FileOperator();
            fileOperator.TryToGetResultFile();
            if (fileOperator.IsBreakOperation) { return; }


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите данные или @ для выхода в меню");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                string sourceData = Console.ReadLine();
                if (sourceData == "@") { break; }
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
                point.PrintCordinateToFile(fileOperator.ResultFileAddress);
            }
                
           
        }

        

    }
}

