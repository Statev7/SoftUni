namespace P07_Labyrinth
{
    using System;

    public class StartUp
    {
        private const char EMPTY_CELLS_SYMBOL = '-';
        private const char WALL_SYMBOL = '*';
        private const char MARK_SYMBOL = '#';
        private const char EXIT_SYMBOL = 'e';

        public static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            char[,] labyrinth = new char[row, col];
            string path = string.Empty;

            ReadLabyrinth(labyrinth);
            FindPaths(0, 0, labyrinth, path);
            
        }

        private static void FindPaths(int row, int col, char[,] labyrinth, string path)
        {
            if (labyrinth[row, col] == EXIT_SYMBOL)
            {
                Console.WriteLine(path);
                return;
            }

            labyrinth[row, col] = MARK_SYMBOL;

            if (IsFree(row, col + 1, labyrinth))
            {
                FindPaths(row, col + 1, labyrinth, path + 'R');
            }

            if (IsFree(row, col - 1, labyrinth))
            {
                FindPaths(row, col - 1, labyrinth, path + 'L');
            }

            if (IsFree(row + 1, col, labyrinth))
            {
                FindPaths(row + 1, col, labyrinth, path + 'D');
            }

            if (IsFree(row - 1, col, labyrinth))
            {
                FindPaths(row - 1, col, labyrinth, path + 'U');
            }

            labyrinth[row, col] = EMPTY_CELLS_SYMBOL;
        }

        private static bool IsFree(int row, int col, char[,] labyrinth)
        {
            if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return false;
            }

            if (labyrinth[row, col] == MARK_SYMBOL || labyrinth[row, col] == WALL_SYMBOL)
            {
                return false;
            }

            return true;
        }

        private static void ReadLabyrinth(char[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                string date = Console.ReadLine();

                for (int col = 0; col < date.Length; col++)
                {
                    labyrinth[row, col] = date[col];
                }
            }
        }
    }
}
