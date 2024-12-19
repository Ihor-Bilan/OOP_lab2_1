using System;

namespace OOP_lab2_zavd1
{
    public partial class MyMatrix
    {
       
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Weight != b.Weight)
                throw new ArgumentException("Розміри матриць мають співпадати для додавання.");

            double[,] resultArray = new double[a.Height, a.Weight];
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Weight; j++)
                {
                    resultArray[i, j] = a[i, j] + b[i, j];
                }
            }
            return new MyMatrix(resultArray);
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Weight != b.Height)
                throw new ArgumentException("Кількість стовпців першої матриці має дорівнювати кількості рядків другої.");

            double[,] resultArray = new double[a.Height, b.Weight];
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Weight; j++)
                {
                    for (int k = 0; k < a.Weight; k++)
                    {
                        resultArray[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return new MyMatrix(resultArray);
        }

        protected void TransponeMe()
        {
            double[,] transposed = new double[Weight, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Weight; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            matrix = transposed;
        }

        public MyMatrix GetTransponedCopy()
        {
            double[,] transposed = new double[Weight, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Weight; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return new MyMatrix(transposed);
        }
    }
}
