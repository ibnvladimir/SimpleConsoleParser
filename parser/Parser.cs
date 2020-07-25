using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parser
{
    class Parser
    {

        private static string _exceptionMessage { get; set; }
        private static bool _isParseSuccessful { internal get;  set; }
        private static decimal _result { get; set; }

        internal static void TryToConvert(string sourceData)
        {
            string[] coordinates = sourceData.Split(',');
            CheckForEmptyCoordinate(coordinates);
            CheckCountOfCoordinates(coordinates);
        }

        private static void CheckForEmptyCoordinate(string[] coordinates)
        {
            //check for an empty coordinate value, or consisting of spaces, with an error message
            foreach (string coordinate in coordinates)
            {
                if (String.IsNullOrWhiteSpace(coordinate))
                {
                    _exceptionMessage = "Похоже, что одно из значений не задано; ";
                    _isParseSuccessful = false;
                }
            }
            _isParseSuccessful = true;
        }

        private static void CheckCountOfCoordinates(string[] coordinates)
        {
            //Checking that there were exactly 2 numbers in the line with warnings, otherwise
            if (coordinates.Length < 2)
            {
                _exceptionMessage += "Похоже, что вы ввели меньше 2 координат; ";
                _isParseSuccessful = false;
            }
            else if (coordinates.Length > 2)
            {               
                Console.WriteLine("Похоже, что вы ввели больше 2 координат");
                _isParseSuccessful = false;
            }
            else
            {
                _isParseSuccessful = true;
            }
        }

    }
}
