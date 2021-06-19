namespace P07_NxNMatrix
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int[,] matrix = EnterTheDigitInMatrix(input);
            PrintMatrix(matrix, input);
        }

        private static int[,] EnterTheDigitInMatrix(int input)
        {
            int[,] matrix = new int[input, input];

            for (int row = 0; row < input; row++)
            {
                for (int col = 0; col < input; col++)
                {
                    matrix[row, col] = input;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix, int count)
        {
            for (int row = 0; row < count; row++)
            {
                for (int col = 0; col < count; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
