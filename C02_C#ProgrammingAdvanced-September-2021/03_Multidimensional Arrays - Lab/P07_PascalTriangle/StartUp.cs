namespace P07_PascalTriangle
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            long[][] matrix = new long[input][];
            int cols = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new long[cols];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < matrix[row].Length - 1; col++)
                    {
                        long[] prevRow = matrix[row - 1];
                        long firstNum = prevRow[col];
                        long secondNum = prevRow[col - 1];
                        matrix[row][col] = firstNum + secondNum;
                    }
                }

                cols++;
            }


            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
