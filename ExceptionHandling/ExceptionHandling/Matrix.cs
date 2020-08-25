using System.Collections.Generic;
using System.Data.SqlTypes;

namespace ExceptionHandling
{

    /// <summary>
    /// Класс описывает ячейку матрицы, которая хранит в себе значение, но не расположение
    /// </summary>
    public class Cell
    {
        public int Value { get; set; }
    }


    /// <summary>
    /// Класс описывает матрицу, которая имеет ширину и высоту, а так же массив ячеек (Cell)
    /// </summary>
    public class Matrix:INullable
    {
        public int Width { get; set; }
        public int Height { get; set; }

        Cell[,] data;



        public Matrix(int width, int height)
        {
            data = new Cell[width,height];
            Width = width;
            Height = height;
        }



        public Cell this[int width, int height]
        {
            get
            {
                return data[width, height];
            }
            set
            {
                data[width, height] = value;
            }
        }

        public override bool Equals(object o)
        {
            Matrix matrix0 = (Matrix)o;
            if (matrix0 == null)
            {
                return false;
            }

            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    var b = this[i, j].Value == matrix0[i,j].Value;
                    if (!b)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Принимет высоту и ширину матрицы, возвращает матрицу заполненную нулями
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Matrix GetEmpty(int width, int height)
        {
            var matrix = new Matrix(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = new Cell {Value = 0};
                }
            }

            return matrix;
        }

        /// <summary>
        /// Принимает ширину  и высоту матрицы, пользователь заполняет ячейки матрицы самостоятельно, затем возвращает матрицу. 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Matrix  FillMatrix(int width, int height)
        {
            var matrix = new Matrix(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Message.System($"Введите {i + 1}:{j + 1} элемент матрицы ");

                    var isSuccess = int.TryParse(Message.UserInput(), out var result);
                    
                    if (!isSuccess)
                    {
                        Message.Error("Введите целое число!");
                        j--;
                        continue;
                    }

                    matrix[i,j] = new Cell {Value = result};
                }
            }
            return matrix;
        }

        /// <summary>
        /// Только для тестов!<br/>
        /// Заполняет матрицу переданными значениями, количество значений должно быть равно произведению ширины на высоту
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        public static Matrix FillForTests(int width, int height, List<int> mass)
        {
            var matrix = new Matrix(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = new Cell { Value = mass[0] };
                    mass.Remove(mass[0]);
                }
            }

            return matrix;
        }

        public bool IsNull { get; }
    }
}
