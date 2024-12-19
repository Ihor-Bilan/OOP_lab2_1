using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2_zavd1
{
    public partial class MyMatrix
    {
        private double[,] matrix;
        public MyMatrix(double[,] array)
        {
            if (array == null)
                throw new ArgumentNullException("Масив не може бути пустим");
            matrix = (double[,])array.Clone();
        }

        public int Height
        {
            get { return matrix.GetLength(0); }
        }

        public int Weight
        {
            get { return matrix.GetLength(1); }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Weight; j++)
                {
                    result += $"{matrix[i, j]}\t";
                }
                result += Environment.NewLine;
            }
            return result;
        }


        public double this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Height || col < 0 || col >= Weight)
                    throw new ArgumentOutOfRangeException("Індекс поза межами матриці");
                return matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= Height || col < 0 || col >= Weight)
                    throw new ArgumentOutOfRangeException("Індекс поза межами матриці");
                matrix[row, col] = value;
            }
        }
       
        public double GetElement(int row, int col)
        {
            if (row < 0 || row >= Height || col < 0 || col >= Weight)
                throw new IndexOutOfRangeException("Індекс поза межами матриці.");
            return matrix[row, col];
        }

        
        public void SetElement(int row, int col, double value)
        {
            if (row < 0 || row >= Height || col < 0 || col >= Weight)
                throw new IndexOutOfRangeException("Індекс поза межами матриці.");
            matrix[row, col] = value;
        }

        public MyMatrix(double[][] jaggedArray)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
                throw new ArgumentNullException("Зубчастий масив не може бути порожнім.");

            int rowLength = jaggedArray[0].Length;
            if (jaggedArray.Any(row => row.Length != rowLength))
                throw new ArgumentException("Зубчастий масив не є прямокутним.");

            matrix = new double[jaggedArray.Length, rowLength];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    matrix[i, j] = jaggedArray[i][j];
                }
            }
        }

        public MyMatrix(string[] lines)
        {
            if (lines == null || lines.Length == 0)
                throw new ArgumentNullException("Масив рядків не може бути порожнім.");

            string[] firstLineElements = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int columnCount = firstLineElements.Length;

            if (lines.Any(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length != columnCount))
                throw new ArgumentException("Рядки не утворюють прямокутну матрицю.");

            matrix = new double[lines.Length, columnCount];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < columnCount; j++)
                {
                    if (!double.TryParse(elements[j], out matrix[i, j]))
                        throw new FormatException($"Неможливо перетворити '{elements[j]}' на число.");
                }
            }
        }

        public MyMatrix(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException("Рядок не може бути порожнім.");

            string[] lines = data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] firstLineElements = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int columnCount = firstLineElements.Length;

            if (lines.Any(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length != columnCount))
                throw new ArgumentException("Рядки не утворюють прямокутну матрицю.");

            matrix = new double[lines.Length, columnCount];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < columnCount; j++)
                {
                    if (!double.TryParse(elements[j], out matrix[i, j]))
                        throw new FormatException($"Неможливо перетворити '{elements[j]}' на число.");
                }
            }
        }

        public static MyMatrix ReadMatrix()
        {
            Console.Write("Введіть кількість рядків матриці: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість стовпчиків матриці: ");
            int cols = int.Parse(Console.ReadLine());

            double[,] array = new double[rows, cols];

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    array[i, j] = double.Parse(Console.ReadLine());
                }
            }

            return new MyMatrix(array);
        }

    }
}
