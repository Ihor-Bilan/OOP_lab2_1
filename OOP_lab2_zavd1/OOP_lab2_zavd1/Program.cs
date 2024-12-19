using System;
using System.Text;

namespace OOP_lab2_zavd1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            MyMatrix matrix = null; 

            try
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

                matrix = new MyMatrix(array);

                Console.WriteLine("\nВведена матриця:");
                Console.WriteLine(matrix);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return; 
            }

            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати дві матриці");
            Console.WriteLine("2. Помножити дві матриці");
            Console.WriteLine("3. Транспонувати матрицю");
            Console.Write("Оберіть опцію: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введіть другу матрицю для додавання:");
                        MyMatrix otherMatrixForAdd = MyMatrix.ReadMatrix();
                        MyMatrix sumMatrix = matrix + otherMatrixForAdd;
                        Console.WriteLine("Результат додавання:");
                        Console.WriteLine(sumMatrix);
                        break;

                    case 2:
                        Console.WriteLine("Введіть другу матрицю для множення:");
                        MyMatrix otherMatrixForMultiply = MyMatrix.ReadMatrix();
                        MyMatrix productMatrix = matrix * otherMatrixForMultiply;
                        Console.WriteLine("Результат множення:");
                        Console.WriteLine(productMatrix);
                        break;

                    case 3:
                        MyMatrix transposedMatrix = matrix.GetTransponedCopy();
                        Console.WriteLine("Транспонована матриця:");
                        Console.WriteLine(transposedMatrix);
                        break;

                    default:
                        Console.WriteLine("Некоректний вибір.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        
        
    }
}

