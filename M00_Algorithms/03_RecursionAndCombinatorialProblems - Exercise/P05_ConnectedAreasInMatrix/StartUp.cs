namespace P05_ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static char[,] matrix;

        public static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            matrix = new char[row, col];

            ReadMatrix();
            Generate(0, 0);
        }

        private static void Generate(int row, int col)
        {
            if (row >= matrix.GetLength(0))
            {
                return;
            }
        }

        private static void ReadMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colDate = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colDate[col];
                }
            }
        }
    }

}
