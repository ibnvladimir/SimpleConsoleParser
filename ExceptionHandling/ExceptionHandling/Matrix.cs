namespace ExceptionHandling
{

    /// <summary>
    /// Класс описывает ячейку матрицы, которая хранит в себе значение, но не расположение
    /// </summary>
    class Cell
    {
        public int Value { get; set; }
    }


    /// <summary>
    /// Класс описывает матрицу, которая имеет ширину и высоту, а так же массив ячеек (Cell)
    /// </summary>
    internal class Matrix
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
    }
}
