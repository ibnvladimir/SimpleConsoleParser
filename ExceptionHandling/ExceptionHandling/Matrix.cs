using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Cell
    {
        public int Value { get; set; }

        //public static Cell operator *(Cell a, Cell b)
        //{
        //    return new Cell {Value = a.Value * b.Value};
        //}

        //public static Cell operator +(Cell a, Cell b)
        //{
        //    return new Cell { Value = a.Value + b.Value };
        //}

        //public static Cell operator -(Cell a, Cell b)
        //{
        //    return new Cell { Value = a.Value - b.Value };
        //}
    }
    
    /// <summary>
    /// Квадратная матрица
    /// </summary>
    internal class Matrix
    {
        public int Dimension { get; set; }
        

        Cell[,] data;



        public Matrix(int dimension)
        {
            data = new Cell[dimension,dimension];
            Dimension = dimension;
        }
        public Cell this[int dimension1, int dimension2]
        {
            get
            {
                return data[dimension1, dimension2];
            }
            set
            {
                data[dimension1, dimension2] = value;
            }
        }

        public static Matrix GetEmpty(int dimension)
        {
            var matrix = new Matrix(dimension);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    matrix[i, j] = new Cell {Value = 0};
                }
            }

            return matrix;
        }


        public static Matrix  FillMatrix(int dimension)
        {
            var matrix = new Matrix(dimension);
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
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

        public static Matrix Multiple(Matrix a, Matrix b)
        {
            Matrix resMatrix = Matrix.GetEmpty(a.Dimension);
            for (int i = 0; i < a.Dimension; i++)
            {
                for (int j = 0; j < b.Dimension; j++)
                {
                    for (int k = 0; k < b.Dimension; k++)
                    {
                        resMatrix[i, j].Value += a[i, k].Value * b[k, j].Value;
                    }
                }
            }

            return resMatrix;
        }

        
    }
}
