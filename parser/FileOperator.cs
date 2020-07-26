using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser
{
    class FileOperator
    {
        internal string SourceFileAddress { get; set; }
        internal string ResultFileAddress { get; set; }
        internal bool IsBreakOperation { get; set; } = false;
        
        internal void TryToFindSourceFile()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите адрес файла с исходными данными или @ для выхода в меню:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("> ");
            SourceFileAddress = Console.ReadLine();
            if (SourceFileAddress == "@") 
            {
                IsBreakOperation = true; 
                return; 
            }
            if (!System.IO.File.Exists(SourceFileAddress))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл не найден!");
                Console.ForegroundColor = ConsoleColor.White;
                IsBreakOperation = true;
                return;
            }
        }

        internal void TryToGetResultFile()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите адрес файла для записи или @ для выхода в меню");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                ResultFileAddress = Console.ReadLine();
                if (ResultFileAddress == "@")
                {
                    IsBreakOperation = true;
                    return;
                }
                if (!System.IO.File.Exists(ResultFileAddress))
                {
                    try
                    {
                        File.Create(ResultFileAddress).Close();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Невозможно создать файл!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        continue;
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Файл \"{ResultFileAddress}\" уже существует!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Как вы хотите поступить?");
                        Console.WriteLine("1. Записать в конец файла");
                        Console.WriteLine("2. Перезаписать содержимое файла");
                        Console.WriteLine("0. выйти в главное меню");
                        Console.ForegroundColor = ConsoleColor.White;
                        var choiseWhenFileExist = Console.ReadLine();

                        switch (choiseWhenFileExist)
                        {
                            case "1":
                                return;
                                break;
                            case "2":
                                File.Delete(ResultFileAddress);
                                File.Create(ResultFileAddress).Close();
                                return;
                                break;
                            case "0":
                                IsBreakOperation = true;
                                return;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Нет такого пункта в меню!");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                continue;
                                break;
                        }
                    }

                }
            }
        }




        
    }
}
