namespace P02_2X2SquaresInMatrix
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];
            ReadMatrix(matrix);
            PrintCountOfEqualsSquares(matrix);
        }

        private static void PrintCountOfEqualsSquares(string[,] matrix)
        {
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var isEquals = matrix[row, col] == matrix[row, col + 1] &&
                                   matrix[row, col] == matrix[row + 1, col] &&
                                   matrix[row + 1, col] == matrix[row + 1, col + 1];
                    if (isEquals)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowDate = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
        }
    }
}
