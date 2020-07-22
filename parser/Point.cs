﻿using System;

namespace parser
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
            Console.Write(CoordinateX);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" | ");
            Console.Write("Y: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(CoordinateY);
        }





    }
}