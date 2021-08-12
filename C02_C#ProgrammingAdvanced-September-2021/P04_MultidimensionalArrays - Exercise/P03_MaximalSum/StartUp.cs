namespace P03_MaximalSum
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            ReadMatrix(matrix);

            int max, rowIndex, colIndex;
            MaxSum(matrix, out max, out rowIndex, out colIndex);

            PrintResult(matrix, max, rowIndex, colIndex);
        }

        private static void PrintResult(int[,] matrix, int max, int rowIndex, int colIndex)
        {
            Console.WriteLine($"Sum = {max}");
            for (int row = rowIndex; row < rowIndex + 3; row++)
            {
                for (int col = colIndex; col < colIndex + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void MaxSum(int[,] matrix, out int max, out int rowIndex, out int colIndex)
        {
            max = int.MinValue;
            rowIndex = 0;
            colIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = SumOfSquare(matrix, row, col);

                    if (sum > max)
                    {
                        rowIndex = row;
                        colIndex = col;
                        max = sum;
                    }
                }
            }
        }

        private static int SumOfSquare(int[,] matrix, int rowStartIndex, int col)
        {
            int sum = 0;

            for (int row = rowStartIndex; row < rowStartIndex + 3; row++)
            {
                sum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]; 
            }

            return sum;
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
    }
  
}
