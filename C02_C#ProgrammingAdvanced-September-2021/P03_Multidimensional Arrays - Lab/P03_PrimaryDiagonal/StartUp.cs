namespace P03_PrimaryDiagonal
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];
            int sum = 0;
            int colDate = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowDate = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, colDate];
                colDate++;
            }

            Console.WriteLine(sum);
        }
    }
}
