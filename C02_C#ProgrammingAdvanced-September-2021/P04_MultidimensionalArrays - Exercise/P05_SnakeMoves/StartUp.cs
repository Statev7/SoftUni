namespace P05_SnakeMoves
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[matrixSize[0], matrixSize[1]];

            matrix = ReadMatrix(matrix);
            Print(matrix);
        }

        private static char[,] ReadMatrix(char[,] matrix)
        {
            string snake = Console.ReadLine();

            string snakeDate = snake;
            string direction = "right";
            string forwardDirection = string.Empty;
            int snakeCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (direction == "right")
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[snakeCol];
                        snake = snake.Remove(0, 1);
                        snake = IsSnakeEmpty(snake, snakeDate);
                    }
                    direction = "down";
                    forwardDirection = "right";
                    continue;
                }
                else if (direction == "down" && forwardDirection == "right")
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeCol];
                        snake = snake.Remove(0, 1);
                        snake = IsSnakeEmpty(snake, snakeDate);
                    }
                    direction = "right";
                    continue;
                }

            }

            return matrix;
        }

        private static string IsSnakeEmpty(string snake, string snakeDate)
        {
            if (snake == string.Empty)
            {
                snake = snakeDate;
            }

            return snake;
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string result = string.Empty;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result += matrix[row, col];
                }
                Console.WriteLine(result);
            }
        }
    }
}
