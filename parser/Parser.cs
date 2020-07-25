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

        internal  string ExceptionMessage { get; private set; } = "";
        internal  bool IsParseSuccessful { get; private set; } = true;
        internal decimal[] Result { get; private set; } 

        internal  void TryToConvert(string sourceData)
        {
            string[] coordinates = sourceData.Split(',');
            CheckCountOfCoordinates(coordinates.Length);            
            if (IsParseSuccessful)
            {
                CheckForEmptyCoordinate(coordinates);
            }
            if (IsParseSuccessful)
            {
                TryToConvertToDecimal(coordinates);
            }

        }

        private  void CheckForEmptyCoordinate(string[] coordinates)
        {
            //check for an empty coordinate value, or consisting of spaces, with an error message
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(coordinates[i]))
                {
                    ExceptionMessage += $"Похоже, что {i + 1}-е значение не задано; ";
                    IsParseSuccessful = false;
                }
            }
        }

        private  void CheckCountOfCoordinates(int coordinatesCount)
        {
            //Checking that there were exactly 2 numbers in the line with warnings, otherwise
            if (coordinatesCount != 2)
            {
                ExceptionMessage += $"Вы вели {coordinatesCount} координат, требуется 2; ";
                IsParseSuccessful = false;
            }
        }

        private  void TryToConvertToDecimal(string[] coordinates)
        {
            Result = new decimal[coordinates.Length];
            for (int i = 0; i < coordinates.Length; i++)
            {
                try
                {
                    Result[i] = decimal.Parse(coordinates[i]);
                }
                catch (FormatException)
                {
                    ExceptionMessage += $"Неверный формат {i + 1} координаты; ";
                    IsParseSuccessful = false;
                }
            }
        }



    }
}
