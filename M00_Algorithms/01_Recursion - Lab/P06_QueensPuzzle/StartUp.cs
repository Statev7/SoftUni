namespace P06_QueensPuzzle
{
    using System;

    public class StartUp
    {
        private const int CHESSBOARD_SIZE = 8;
        private const char QUEENS_SYMBOL = '*';
        private const char DEFUALT_SYMBOL = '-';

        public static void Main()
        {
            var matrix = new char[CHESSBOARD_SIZE, CHESSBOARD_SIZE];
            PutQueen(matrix, 0);
        }

        private static void PutQueen(char[,] matrix, int row)
        {
            if (row == CHESSBOARD_SIZE)
            {
                PrintMatrix(matrix);
                return;
            }

            for (int col = 0; col < CHESSBOARD_SIZE; col++)
            {
                if (CanPutQueen(matrix, row, col))
                {
                    matrix[row, col] = QUEENS_SYMBOL;
                    PutQueen(matrix, row + 1);
                    matrix[row, col] = DEFUALT_SYMBOL;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < CHESSBOARD_SIZE; row++)
            {
                for (int col = 0; col < CHESSBOARD_SIZE; col++)
                {
                    if (matrix[row, col] == '\0')
                    {
                        matrix[row, col] = DEFUALT_SYMBOL;
                    }

                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool CanPutQueen(char[,] matrix, int row, int col)
        {
            for (int i = 1; i < CHESSBOARD_SIZE; i++)
            {
                if (col + i < matrix.GetLength(1) && matrix[row, col + i] == QUEENS_SYMBOL)
                {
                    return false;
                }

                if (col - i >= 0 && matrix[row, col - i] == QUEENS_SYMBOL)
                {
                    return false;
                }

                if (row - i >= 0 && matrix[row - i, col] == QUEENS_SYMBOL)
                {
                    return false;
                }

                if (row + i < matrix.GetLength(0) && matrix[row + i, col] == QUEENS_SYMBOL)
                {
                    return false;
                }

                if (row + i < matrix.GetLength(0) && col + i < matrix.GetLength(0) && matrix[row + i, col + i] == QUEENS_SYMBOL)
                {
                    return false;
                }

                if (row - i >= 0 && col - i >= 0 && matrix[row - i, col - i] == QUEENS_SYMBOL)
                {
                    return false;
                }

                if (row + i < matrix.GetLength(0) && col - i >= 0 && matrix[row + i, col - i] == QUEENS_SYMBOL)
                {
                    return false;
                }

                if (row - i >= 0 && col + i < matrix.GetLength(1) && matrix[row - i, col + i] == QUEENS_SYMBOL)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
