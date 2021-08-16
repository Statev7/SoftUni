namespace P08_Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            matrix = ReadMatrix(matrix);
            var bombCoridation = Console.ReadLine()
                .Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            bool isBreak = false;

            while (bombCoridation.Count > 0)
            {
                for (int row = bombCoridation[0]; row < matrix.GetLength(0); row++)
                {
                    for (int col = bombCoridation[1]; col < matrix.GetLength(1); col++)
                    {
                        bool isBomb = row == bombCoridation[0] && col == bombCoridation[1];
                        if (isBomb)
                        {
                            bombCoridation.RemoveAt(0);
                            bombCoridation.RemoveAt(0);
                            Explosions(matrix, row, col);

                            matrix[row, col] = 0;
                            if (bombCoridation.Count == 0)
                            {
                                isBreak = true;
                                break;
                            }
                        }
                    }

                    if (isBreak)
                    {
                        break;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static int[,] ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowDate = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            return matrix;
        }

        private static void Explosions(int[,] matrix, int row, int col)
        {
            if (IsCordsValid(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
            {
                matrix[row - 1, col - 1] -= matrix[row, col];
            }

            if (IsCordsValid(matrix, row - 1, col) && matrix[row - 1, col] > 0)
            {
                matrix[row - 1, col] -= matrix[row, col];
            }

            if (IsCordsValid(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
            {
                matrix[row - 1, col + 1] -= matrix[row, col];
            }

            if (IsCordsValid(matrix, row, col + 1) && matrix[row, col + 1] > 0)
            {
                matrix[row, col + 1] -= matrix[row, col];
            }

            if (IsCordsValid(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
            {
                matrix[row + 1, col + 1] -= matrix[row, col];
            }

            if (IsCordsValid(matrix, row + 1, col) && matrix[row + 1, col] > 0)
            {
                matrix[row + 1, col] -= matrix[row, col];
            }

            if (IsCordsValid(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
            {
                matrix[row + 1, col - 1] -= matrix[row, col];
            }

            if (IsCordsValid(matrix, row, col - 1) && matrix[row, col - 1] > 0)
            {
                matrix[row, col - 1] -= matrix[row, col];
            }
        }


        private static bool IsCordsValid(int[,] matrix, int row, int col)
        {
            bool isValid = row >= 0 && row < matrix.GetLength(0) &&
                           col >= 0 && col < matrix.GetLength(1);

            return isValid;
        }


        private static void PrintMatrix(int[,] matrix)
        {
            PrintAliveCells(matrix);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintAliveCells(int[,] matrix)
        {
            int count = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    bool isAlive = matrix[row, col] > 0;
                    if (isAlive)
                    {
                        sum += matrix[row, col];
                        count++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
        }

    }
}
