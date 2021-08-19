namespace P04_MatrixShuffling
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_SWAP = "swap";
        const string INVALID_INPUT_ERROR_MESSAGE = "Invalid input!";
        const string COMMAND_TO_STOP = "END";

        public static void Main()
        {
            var matrixSize = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];
            ReadMatrix(matrix);

            while (true)
            {
                string[] arg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arg[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                bool isValid = arg.Contains(COMMAND_TO_SWAP) && arg.Length == 5;
                if (isValid)
                {
                    int row = int.Parse(arg[1]);
                    int col = int.Parse(arg[2]);
                    int rowToSwap = int.Parse(arg[3]);
                    int colToSwap = int.Parse(arg[4]);

                    bool isCordsValid = IsCordsValid(matrix, row, col, rowToSwap, colToSwap);
                    if (isCordsValid)
                    {
                        string temp = matrix[row, col];
                        matrix[row, col] = matrix[rowToSwap, colToSwap];
                        matrix[rowToSwap, colToSwap] = temp;
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine(INVALID_INPUT_ERROR_MESSAGE);
                    }
                }
                else
                {
                    Console.WriteLine(INVALID_INPUT_ERROR_MESSAGE);
                }
            }
        }

        private static bool IsCordsValid(string[,] matrix, int row, int col, int rowToSwap, int colToSwap)
        {
            bool isValid = matrix.GetLength(0) > row && row >= 0 &&
                           matrix.GetLength(1) > col && col >= 0 &&
                           matrix.GetLength(0) > rowToSwap && rowToSwap >= 0 &&
                           matrix.GetLength(1) > colToSwap && colToSwap >= 0;

            return isValid;

        }

        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowDate = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
