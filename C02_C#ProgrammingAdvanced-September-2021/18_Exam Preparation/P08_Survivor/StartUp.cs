namespace P08_Survivor
{
    using System;

    public class StartUp
    {
        private const string COMMAND_TO_STOP_READ_COMMANDS = "Gong";

        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            var matrix = new string[matrixSize][];
            ReadMatrix(matrix);

            int tokens = 0;
            int opponentTokens = 0;

            var input = Console.ReadLine();
            while (input != COMMAND_TO_STOP_READ_COMMANDS)
            {
                var splited = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splited[0];
                int row = int.Parse(splited[1]);
                int col = int.Parse(splited[2]);

                if (command == "Find")
                {
                    bool isValid = Find(matrix, row, col);
                    if (isValid)
                    {
                        tokens++;
                    }
                }
                else if (command == "Opponent")
                {
                    string direction = splited[3];
                    bool isCordsValid = IsIndexValid(matrix, row, col);

                    if (isCordsValid)
                    {
                        switch (direction)
                        {
                            case "up": opponentTokens += Up(matrix, row, col); break;
                            case "down": opponentTokens += Down(matrix, row, col); break;
                            case "right": opponentTokens += Right(matrix, row, col); break;
                            case "left": opponentTokens += Left(matrix, row, col); break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static int Up(string[][] matrix, int row, int col)
        {
            int count = 0;
            if (matrix[row][col] == "T")
            {
                count++;
                matrix[row][col] = "-";
            }

            for (int index = 0; index < 3; index++)
            {
                row -= 1;
                bool isCordsValid = IsIndexValid(matrix, row, col);
                if (isCordsValid && matrix[row][col] == "T")
                {
                    count++;
                    matrix[row][col] = "-";
                }
            }

            return count;
        }

        private static int Down(string[][] matrix, int row, int col)
        {
            int count = 0;
            if (matrix[row][col] == "T")
            {
                count++;
                matrix[row][col] = "-";
            }

            for (int index = 0; index < 3; index++)
            {
                row += 1;
                bool isCordsValid = IsIndexValid(matrix, row, col);
                if (isCordsValid && matrix[row][col] == "T")
                {
                    count++;
                    matrix[row][col] = "-";
                }
            }

            return count;
        }

        private static int Right(string[][] matrix, int row, int col)
        {
            int count = 0;
            if (matrix[row][col] == "T")
            {
                count++;
                matrix[row][col] = "-";
            }

            for (int index = 0; index < 3; index++)
            {
                col += 1;
                bool isCordsValid = IsIndexValid(matrix, row, col);
                if (isCordsValid && matrix[row][col] == "T")
                {
                    count++;
                    matrix[row][col] = "-";
                }
            }
            return count;
        }

        private static int Left(string[][] matrix, int row, int col)
        {
            int count = 0;
            if (matrix[row][col] == "T")
            {
                count++;
                matrix[row][col] = "-";
            }

            for (int index = 0; index < 3; index++)
            {
                col -= 1;
                bool isCordsValid = IsIndexValid(matrix, row, col);
                if (isCordsValid && matrix[row][col] == "T")
                {
                    count++;
                    matrix[row][col] = "-";
                }
            }
            return count;
        }

        private static bool Find(string[][] matrix, int row, int col)
        {
            bool isValid = IsIndexValid(matrix, row, col);
            if (isValid && matrix[row][col] == "T")
            {
                matrix[row][col] = "-";
                return true;
            }

            return false;
        }

        private static void ReadMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var rowDate = Console.ReadLine().Split(" ");
                matrix[row] = new string[rowDate.Length];

                for (int col = 0; col < rowDate.Length; col++)
                {
                    matrix[row][col] = rowDate[col];
                }
            }
        }

        private static bool IsIndexValid(string[][] matrix,int row, int col)
        {
            bool isValid = row >= 0 && row < matrix.Length && 
                            col >= 0 && matrix[row].Length > col;

            return isValid;
        }
    }
}
