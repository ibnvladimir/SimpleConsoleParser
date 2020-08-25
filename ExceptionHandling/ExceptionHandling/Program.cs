using System;

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
                Message.System("Приложение умеет производить действия над 2-мя матрицами: ");
                matrixA = CreateMatrix(true);
                matrixB = CreateMatrix(false);
                Message.System("Какое действие над матрицами будем производить?");
                Message.System("1. Складывать");
                Message.System("2. Вычитать");
                Message.System("3. Умножать");
                Message.System("Введите нужный пункт меню либо @ для выхода из программы");

                var menuItem = Message.UserInput();
                Console.WriteLine();

                switch (menuItem)
                {
                    case "@":
                        return;
                    case "1":
                        AddMatrices();
                        break;
                    case "2":
                        SubtractMatrix();
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
        /// Складывает две матрицы и выводит результат на консоль
        /// </summary>
        public static void AddMatrices()
        {
            try
            {
                var resMatrix = MatrixMath.Add(matrixA, matrixB);
                PrintMatrix(resMatrix);
            }
            catch (InvalidDimensionException ex)
            {
                Message.Error(ex.Message);
                return;
            }

        }

        /// <summary>
        /// Вычитает из матрицы А матрицу В и выводит результат на консоль
        /// </summary>
        public static void SubtractMatrix()
        {
            try
            {
                var resMatrix = MatrixMath.Subtract(matrixA, matrixB);
                PrintMatrix(resMatrix);
            }
            catch (InvalidDimensionException ex)
            {
                Message.Error(ex.Message);
                return;
            }
        }



        /// <summary>
        /// перемножает две матрицы и выводит результат на консоль
        /// </summary>
        public static void MultipleMatrixes()
        {
            try
            {
                var resMatrix = MatrixMath.Multiple(matrixA, matrixB);
                PrintMatrix(resMatrix);
            }
            catch (InvalidDimensionException ex)
            {
                Message.Error(ex.Message);
                return;
            }
        }
        
        
        
        /// <summary>
        /// Выводит матрицу на консоль
        /// </summary>
        /// <param name="matrix"></param>
        public static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Width; i++)
            {
                for (int j = 0; j < matrix.Height; j++)
                {
                    Console.Write(matrix[i, j].Value + "\t");
                }
                Console.WriteLine();
            }
        }



        /// <summary>
        /// Позволяет вводить размерность матрицы<br/>
        /// Возвращает размерность<br/>
        /// </summary>
        /// <returns></returns>
        public static int GetMatrixDemension(bool demension)
        {
            string dem;
            dem = demension ? "столбцев" : "строк";
            
            while (true)
            {
                Message.System($"Введите количество {dem} матрицы:");
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
        public static Matrix CreateMatrix(bool whitch)
        {
            var w = whitch ? "A" : "B";
            while (true)
            {
                Message.System($"Выберите вариант создания матрицы {w}. ");
                Message.System("Введите:");
                Message.System("0 - для создания нулевой матрицы");
                Message.System("1 - для ввода значений матрицы");
                var menuItem = Message.UserInput();

                switch (menuItem)
                {
                    case "0":
                        return Matrix.GetEmpty(GetMatrixDemension(false), GetMatrixDemension(true));
                    case "1":
                        return Matrix.FillMatrix(GetMatrixDemension(false), GetMatrixDemension(true));
                    default:
                        Message.Error("Нет такого пункта меню! Повторите ввод.");
                        break;
                }
            }
        }


    }
}
