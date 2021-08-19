namespace P01_DiagonalDifference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            ReadMatrix(matrix);

            int primarySum = PrimaryDiagonalSum(matrix);
            int secondarySum = SecondaryDiagonalSum(matrix);

            int result = primarySum - secondarySum;
            Console.WriteLine(Math.Abs(result));
        }

        private static void ReadMatrix(int[,] matrix)
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
        }

        private static int PrimaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            int col = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, col];
                col++;
            }

            return sum;
        }

        private static int SecondaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            int col = matrix.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, col];
                col--;
            }

            return sum;
        }
    }
}
