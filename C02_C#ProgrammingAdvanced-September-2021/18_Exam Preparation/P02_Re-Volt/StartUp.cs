namespace P02_Re_Volt
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            matrix = ReadMatrix(matrix);

            int[] startCords = StartCords(matrix);
            int startRow = startCords[0];
            int startCol = startCords[1];

            var playerInfo = new Matrix();
            playerInfo.CurruntRow = startRow;
            playerInfo.CurruntCol = startCol;


            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up": Up(matrix, playerInfo); break;
                    case "right": Right(matrix, playerInfo); break;
                    case "down": Down(matrix, playerInfo); break;
                    case "left": Left(matrix, playerInfo); break;
                }

                if (playerInfo.DoWeHaveAWinner)
                {
                    break;
                }
            }

            PrintResult(matrix, playerInfo);
        }

        private static void PrintResult(char[,] matrix, Matrix playerInfo)
        {
            if (playerInfo.DoWeHaveAWinner)
            {
                Console.WriteLine($"Player won!");
                matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] = 'f';
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"Player lost!");
                matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] = 'f';
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void Down(char[,] matrix, Matrix playerInfo)
        {
            bool canMove = playerInfo.CurruntRow + 1 < matrix.GetLength(0);
            playerInfo.CurruntRow = canMove == true ? playerInfo.CurruntRow + 1 : 0;

            if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'B')
            {
                Down(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'T')
            {
                Up(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'F')
            {
                playerInfo.DoWeHaveAWinner = true;
            }
        }

        private static void Up(char[,] matrix, Matrix playerInfo)
        {
            bool canMove = playerInfo.CurruntRow - 1 >= 0;
            playerInfo.CurruntRow = canMove == true ? playerInfo.CurruntRow - 1 : matrix.GetLength(0) - 1;

            if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'B')
            {
                Up(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'T')
            {
                Down(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'F')
            {
                playerInfo.DoWeHaveAWinner = true;
            }
        }

        private static void Right(char[,] matrix, Matrix playerInfo)
        {
            bool canMove = playerInfo.CurruntCol + 1 < matrix.GetLength(1);
            playerInfo.CurruntCol = canMove == true ? playerInfo.CurruntCol + 1 : 0;

            if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'B')
            {
                Right(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'T')
            {
                Left(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'F')
            {
                playerInfo.DoWeHaveAWinner = true;
            }
        }

        private static void Left(char[,] matrix, Matrix playerInfo)
        {
            bool canMove = playerInfo.CurruntCol - 1 >= 0;
            playerInfo.CurruntCol = canMove == true ? playerInfo.CurruntCol - 1 : matrix.GetLength(1) - 1;

            if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'B')
            {
                Left(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'T')
            {
                Right(matrix, playerInfo);
            }
            else if (matrix[playerInfo.CurruntRow, playerInfo.CurruntCol] == 'F')
            {
                playerInfo.DoWeHaveAWinner = true;
            }
        }

        private static int[] StartCords(char[,] matrix)
        {
            var cords = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        cords[0] = row;
                        cords[1] = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            return cords;
        }

        private static char[,] ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var matrixDate = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixDate[col];
                }
            }

            return matrix;
        }
    }

    public class Matrix
    {
        public int CurruntRow { get; set; }

        public int CurruntCol { get; set; }

        public bool DoWeHaveAWinner { get; set; }
    }
}
