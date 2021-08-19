namespace P05_SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            ReadMatrix(matrix);
            PrintSquareWithMaximumSum(matrix);
        }

        private static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowDate = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
        }

        private static void PrintSquareWithMaximumSum(int[,] matrix)
        {
            int rowCords = 0;
            int colCords = 0;
            int maxSum = int.MinValue;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + 
                        matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        rowCords = row;
                        colCords = col;
                        maxSum = sum;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowCords, colCords]} {matrix[rowCords,colCords+1]}");
            Console.WriteLine($"{matrix[rowCords + 1, colCords]} {matrix[rowCords + 1, colCords + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
