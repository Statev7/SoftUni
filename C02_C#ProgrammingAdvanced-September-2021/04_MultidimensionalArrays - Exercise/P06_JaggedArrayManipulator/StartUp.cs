namespace P06_JaggedArrayManipulator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "End";

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            ReadMatrix(matrix);
            AnalyzingMatrix(matrix);

            while (true)
            {
                var arg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arg[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string command = arg[0];
                int row = int.Parse(arg[1]);
                int col = int.Parse(arg[2]);
                int value = int.Parse(arg[3]);

                switch (command)
                {
                    case "Add":
                        AddValueToMatrix(matrix, row, col, value);
                        break;
                    case "Subtract":
                        SubtractValueToMatrix(matrix, row, col, value);
                        break;
                }
            }

            Print(matrix);
        }

        private static double[][] ReadMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var rowLenght = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                
                matrix[row] = new double[rowLenght.Length];
                for (int col = 0; col < rowLenght.Length; col++)
                {
                    matrix[row][col] = rowLenght[col];
                }
            }

            return matrix;
        }

        private static double[][] AnalyzingMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length -1; row++)
            {
                bool isLenghtEquals = matrix[row].Length == matrix[row + 1].Length;
                if (isLenghtEquals)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            return matrix;
        }

        private static void AddValueToMatrix(double[][] matrix, int row, int col, int value)
        {
            bool isIndexValid = IsIndexValid(matrix, row, col);
            if (isIndexValid)
            {
                matrix[row][col] += value;
            }
        }

        private static void SubtractValueToMatrix(double[][] matrix, int row, int col, int value)
        {
            bool isIndexValid = IsIndexValid(matrix, row, col);
            if (isIndexValid)
            {
                matrix[row][col] -= value;
            }
        }

        private static bool IsIndexValid(double[][] matrix, int row, int col)
        {
            bool isValid = matrix.Length > row && row >= 0 && 
                           matrix[row].Length > col && col >= 0;

            return isValid;
        }

        private static void Print(double[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
