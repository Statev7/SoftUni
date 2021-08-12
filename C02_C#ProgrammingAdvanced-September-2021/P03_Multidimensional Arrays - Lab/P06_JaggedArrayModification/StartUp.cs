namespace P06_JaggedArrayModification
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "END";
        const string INVALID_CORDS_ERROR_MESSAGE = "Invalid coordinates";

        public static void Main()
        {
            int matrixLenght = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixLenght][];
            ReadMatrix(matrix);
            ExecuteCommands(matrix);
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void ExecuteCommands(int[][] matrix)
        {
            while (true)
            {
                string[] arg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommad = arg[0] == COMMAND_TO_STOP;
                if (isStopCommad)
                {
                    break;
                }

                string command = arg[0];
                int rowCord = int.Parse(arg[1]);
                int colCord = int.Parse(arg[2]);
                int value = int.Parse(arg[3]);

                if (command == "Add")
                {
                    bool isValid = isCordsValid(matrix, rowCord, colCord);
                    if (isValid)
                    {
                        matrix[rowCord][colCord] += value;
                    }
                }
                else if (command == "Subtract")
                {
                    bool isValid = isCordsValid(matrix, rowCord, colCord);
                    if (isValid)
                    {
                        matrix[rowCord][colCord] -= value;
                    }
                }
            }
        }

        private static void ReadMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var colDate = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = new int[colDate.Length];
                for (int col = 0; col < colDate.Length; col++)
                {
                    matrix[row][col] = colDate[col];
                }
            }
        }

        private static bool isCordsValid(int[][] matrix, int rowCord, int colCord)
        {
            bool isColCordsValid = false;

            bool isRowCordsValid = rowCord < matrix.Length && rowCord >= 0;
            if (isRowCordsValid == true)
            {
                isColCordsValid = colCord < matrix[rowCord].Length && colCord >= 0;
            }

            bool isValid = isColCordsValid && isRowCordsValid;
            if (isValid == false)
            {
                Console.WriteLine(INVALID_CORDS_ERROR_MESSAGE);
            }

            return isValid;
        }
    }
}
