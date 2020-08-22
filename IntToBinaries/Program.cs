using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToBinaries
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите целое положительное число");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                uint value;
                
                try
                {
                    value = Convert.ToUInt32(Console.ReadLine());
                    var myInt = new IntAsBinary(value);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Это число в двоичном представлении:");
                    Console.Write("Авторский способ:   ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(myInt.ToString());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Стандартный способ: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Convert.ToString(value, 2));
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Что-то не так с этим числом! Попробуйте другое...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("");
            }
            
        }
    }
}
