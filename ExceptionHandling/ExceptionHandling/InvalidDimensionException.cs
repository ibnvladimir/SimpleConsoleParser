﻿using System;

namespace ExceptionHandling
{
    /// <summary>
    /// Выбрасывается в случае несоответветствия размерности матрицы условиям необходимым для совершения операции
    /// </summary>
    public class InvalidDimensionException: Exception
    {
        public InvalidDimensionException(string message) : base(message)
        {
        }
       
    }
}