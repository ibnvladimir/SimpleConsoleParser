using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        private static Matrix matrixA;
        private static Matrix matrixB;

        static void Main(string[] args)
        {
            while (true)
            {
                Message.System("Приложение умеет производить следующие действия над 2-мя матрицами: ");
                Message.System("1. Складывать");
                Message.System("2. Вычитать");
                Message.System("3. Умножать");
                Message.System("Введите нужный пункт меню либо @ для выхода из программы");

                var menuItem = Message.UserInput();

                switch (menuItem)
                {
                    case "@":
                        return;
                    case "1":
                        AddMatrixes();
                        break;
                    case "2":
                        SubtructMatrix();
                        break;
                    case "3":
                        MultipleMatrixes();
                        break;
                    default:
                        Message.Error("Нет такого пункта меню! Повторите ввод.");
                        break;
                }
            }

        }

        /// <summary>
        /// объдиняет в одном методе создание сразу двух матриц
        /// </summary>
        public static void CreateMatrices()
        {
            matrixA = CreateMatrix();
            matrixB = CreateMatrix();
        }

        public static void AddMatrixes()
        {
           CreateMatrices();

        }


        public static void SubtructMatrix()
        {
            CreateMatrices();
        }



        /// <summary>
        /// перемножает две матрицы и выводит результат на экран
        /// </summary>
        public static void MultipleMatrixes()
        {
            CreateMatrices();
            var resMatrix =  Matrix.Multiple(matrixA, matrixB);
            
                for (int i = 0; i < resMatrix.Dimension; i++)
                {
                    for (int j = 0; j < resMatrix.Dimension; j++)
                    {
                        Console.Write(resMatrix[i, j].Value + "\t");
                    }
                    Console.WriteLine();
                }
            
        }



        /// <summary>
        /// Позволяет вводить размерность матрицы<br/>
        /// Возвращает размерность<br/>
        /// </summary>
        /// <returns></returns>
        public static int GetMatrixDemension()
        {
            while (true)
            {
                Message.System("Введите размерность  квадратной матрицы:");
                var dimensionAsString = Message.UserInput();

                var isSuccess = int.TryParse(dimensionAsString, out var quantity);

                if (!isSuccess || quantity < 1)
                {
                    Message.Error("Невозможно создать матрицу такой размерности!");
                    continue;
                }

                return quantity;
            }
        }



        /// <summary>
        /// Возвращает заполненную матрицу
        /// </summary>
        public static Matrix CreateMatrix()
        {
            while (true)
            {
                Message.System("Введите:");
                Message.System("0 - для создания нулевой матрицы");
                Message.System("1 - для ввода значений матрицы");
                var menuItem = Message.UserInput();

                switch (menuItem)
                {
                    case "0":
                        return Matrix.GetEmpty(GetMatrixDemension());
                    case "1":
                        return Matrix.FillMatrix(GetMatrixDemension());
                    default:
                        Message.Error("Нет такого пункта меню! Повторите ввод.");
                        break;
                }
            }
        }


    }
}
