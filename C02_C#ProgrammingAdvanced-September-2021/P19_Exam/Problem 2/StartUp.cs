namespace Problem_2
{
    using System;

    public class StartUp
    {
        private const char WHITE_POW_CHARACTER = 'w';
        private const char BLACK_POW_CHARACTER = 'b';
        private const char DEFUALT_CHARACTER = '-';

        public static void Main()
        {
            var matrix = new char[8, 8];
            ReadMatrix(matrix);

            var whitePowCords = PawsCords(matrix, WHITE_POW_CHARACTER);
            var whitePowRow = whitePowCords[0, 0];
            var whitePowCol = whitePowCords[0, 1];

            var blackPowCords = PawsCords(matrix, BLACK_POW_CHARACTER);
            var blackPowRow = blackPowCords[0, 0];
            var blackPowCol = blackPowCords[0, 1];

            while (true)
            {
                matrix[whitePowRow, whitePowCol] = DEFUALT_CHARACTER;

                if (whitePowRow - 1 >= 0 && whitePowCol - 1 >= 0)
                {
                    if (matrix[whitePowRow - 1, whitePowCol - 1] == BLACK_POW_CHARACTER)
                    {
                        matrix[whitePowRow - 1, whitePowCol - 1] = WHITE_POW_CHARACTER;
                        var colAsChar = ColAsChar(whitePowCol - 1);
                        whitePowRow = RowConvert(whitePowRow - 1);
                        Console.WriteLine($"Game over! White capture on {colAsChar}{whitePowRow}.");
                        break;
                    }
                }

                if (whitePowRow - 1 >= 0 && whitePowCol + 1 < matrix.GetLength(1))
                {
                    if (matrix[whitePowRow - 1, whitePowCol + 1] == BLACK_POW_CHARACTER)
                    {
                        matrix[whitePowRow - 1, whitePowCol + 1] = WHITE_POW_CHARACTER;
                        var colAsChar = ColAsChar(whitePowCol + 1);
                        whitePowRow = RowConvert(whitePowRow - 1);
                        Console.WriteLine($"Game over! White capture on {colAsChar}{whitePowRow}.");
                        break;
                    }
                }

                if (whitePowRow - 1 >= 0)
                {
                    whitePowRow--;
                }
                else
                {
                    var colAsChar = ColAsChar(whitePowCol);
                    whitePowRow = RowConvert(whitePowRow);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {colAsChar}{whitePowRow}.");
                    break;
                }

                matrix[whitePowRow, whitePowCol] = WHITE_POW_CHARACTER;

                matrix[blackPowRow, blackPowCol] = DEFUALT_CHARACTER;

                if (blackPowRow + 1 < matrix.GetLength(0) && blackPowCol + 1 < matrix.GetLength(1))
                {
                    if (matrix[blackPowRow + 1, blackPowCol + 1] == WHITE_POW_CHARACTER)
                    {
                        matrix[blackPowRow, blackPowCol + 1] = BLACK_POW_CHARACTER;
                        var colAsChar = ColAsChar(blackPowCol + 1);
                        blackPowRow = RowConvert(blackPowRow + 1);
                        Console.WriteLine($"Game over! Black capture on {colAsChar}{blackPowRow}.");
                        break;
                    }
                }

                if (blackPowRow + 1 < matrix.GetLength(0) && blackPowCol - 1 >= 0)
                {
                    if (matrix[blackPowRow + 1, blackPowCol - 1] == WHITE_POW_CHARACTER)
                    {
                        matrix[blackPowRow + 1, blackPowCol - 1] = BLACK_POW_CHARACTER;
                        var colAsChar = ColAsChar(blackPowCol - 1);
                        blackPowRow = RowConvert(blackPowRow + 1);
                        Console.WriteLine($"Game over! Black capture on {colAsChar}{blackPowRow}.");
                        break;
                    }
                }

                if (blackPowRow + 1 < matrix.GetLength(0))
                {
                    blackPowRow++;
                }
                else
                {
                    var colAsChar = ColAsChar(blackPowCol);
                    blackPowRow = RowConvert(blackPowRow);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colAsChar}{blackPowRow}.");
                    break;
                }

                matrix[blackPowRow, blackPowCol] = BLACK_POW_CHARACTER;
            }
        }

        private static char[,] ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowDate = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }

            return matrix;
        }

        private static int[,] PawsCords(char[,] matrix, char paw)
        {
            var cords = new int[1, 2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == paw)
                    {
                        cords[0, 0] = row;
                        cords[0, 1] = col;
                    }
                }
            }

            return cords;
        }

        private static char ColAsChar(int colCords)
        {
            var result = '\0';
            switch (colCords)
            {
                case 0: result = 'a'; break;
                case 1: result = 'b'; break;
                case 2: result = 'c'; break;
                case 3: result = 'd'; break;
                case 4: result = 'e'; break;
                case 5: result = 'f'; break;
                case 6: result = 'g'; break;
                case 7: result = 'h'; break;
            }

            return result;
        }

        private static int RowConvert(int rowCord)
        {
            var result = 0;
            switch (rowCord)
            {
                case 0: result = 8; break;
                case 1: result = 7; break;
                case 2: result = 6; break;
                case 3: result = 5; break;
                case 4: result = 4; break;
                case 5: result = 3; break;
                case 6: result = 2; break;
                case 7: result = 1; break;
            }

            return result;
        }
    }
}
