using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    /// <summary>
    /// Класс для выведения служебных сообщений приложения
    /// </summary>
    class Message
    {
        /// <summary>
        /// выводит окрашенное в желтый цвет вообщение в консоль
        /// </summary>
        /// <param name="message"></param>
        public static void System(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        
       
        /// <summary>
        /// выводит окрашенное в красный цвет вообщение в консоль
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }



        /// <summary>
        /// выводит угловую скобку, после которой  ждет вовда данных от пользователя
        /// </summary>
        public static string UserInput()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
