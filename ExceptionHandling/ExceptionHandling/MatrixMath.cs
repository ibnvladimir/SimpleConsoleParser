namespace ExceptionHandling
{
    class MatrixMath
    {
        /// <summary>
        /// Принимает две матрицы, складывает их и возвращает результат в виде матрицы.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix Add(Matrix a, Matrix b)
        {
            if (a.Width != b.Width)
            {
                throw new InvalidDimensionException($"Количество строк({a.Width}) в матрице А не равно количеству строк({b.Width}) в матрице В. Сумму таких матриц вычислить невозможно.");
            }
            if (a.Height != b.Height)
            {
                throw new InvalidDimensionException($"Количество столбцев({a.Height}) в матрице А не равно количеству столбцев({b.Height}) в матрице В. Сумму таких матриц вычислить невозможно.");
            }

            Matrix resMass = Matrix.GetEmpty(a.Width, a.Height);
            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    resMass[i, j].Value = a[i, j].Value + b[i, j].Value;
                }
            }
            return resMass;
        }





        /// <summary>
        /// Принимает две матрицы, перемножает их и возвращает результат в виде матрицы.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix Multiple(Matrix a, Matrix b)
        {
            if (a.Width != b.Height)
            {
                throw new InvalidDimensionException($"Количество строк({a.Width}) в матрице А не равно количеству столбцев({b.Height}) в матрице В. Такие матрицы перемножить невозможно.");
            }
            if (a.Height != b.Width)
            {
                throw new InvalidDimensionException($"Количество столбцев({a.Height}) в матрице А не равно количеству строк({b.Width}) в матрице В. Такие матрицы перемножить невозможно.");
            }
            Matrix resMatrix = Matrix.GetEmpty(a.Width, a.Height);
            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    for (int k = 0; k < b.Width; k++)
                    {
                        resMatrix[i, j].Value += a[i, k].Value * b[k, j].Value;
                    }
                }
            }

            return resMatrix;
        }


        /// <summary>
        /// Принимает две матрицы, вычитает из первой вторую и возвращает результат в виде матрицы.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix Subtract(Matrix a, Matrix b)
        {
            if (a.Width != b.Width)
            {
                throw new InvalidDimensionException($"Количество строк({a.Width}) в матрице А не равно количеству строк({b.Width}) в матрице В. Разность таких матриц вычислить невозможно.");
            }
            if (a.Height != b.Height)
            {
                throw new InvalidDimensionException($"Количество столбцев({a.Height}) в матрице А не равно количеству столбцев({b.Height}) в матрице В. Разность таких матриц вычислить невозможно.");
            }

            Matrix resMass = Matrix.GetEmpty(a.Width, a.Height);
            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    resMass[i, j].Value = a[i, j].Value - b[i, j].Value;
                }
            }
            return resMass;
        }


    }
}
