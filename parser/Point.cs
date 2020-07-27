using System;
using System.Globalization;

namespace ConsoleParser
{
    internal class Point
    {
        private decimal CoordinateX;
        private decimal CoordinateY;
        internal Point(decimal x, decimal y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }

        internal void PrintCordinateToConsole()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("X: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(CoordinateX.ToString(CultureInfo.CreateSpecificCulture("ru-RU")));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" | ");
            Console.Write("Y: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CoordinateY.ToString(CultureInfo.CreateSpecificCulture("ru-RU")));
        }

        internal void PrintCordinateToFile(string sourceFileAddress)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(sourceFileAddress, true);
            writer.WriteLine($"X: {CoordinateX} | Y: {CoordinateY}");
            writer.Close();
        }








    }
}