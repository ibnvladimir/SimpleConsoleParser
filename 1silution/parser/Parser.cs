﻿using System;

namespace ConsoleParser
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

        internal void TryToConvertToDecimal(string[] coordinates)
        {
            Result = new decimal[coordinates.Length];
            for (int i = 0; i < coordinates.Length; i++)
            {
               
                    IsParseSuccessful = decimal.TryParse(coordinates[i], out Result[i]);
               
                if (IsParseSuccessful)
                {
                    ExceptionMessage += $"Неверный формат {i + 1} координаты; ";
                    
                }
            }
        }




    }
}