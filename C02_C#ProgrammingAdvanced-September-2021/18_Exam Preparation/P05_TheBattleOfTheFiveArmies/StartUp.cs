namespace P05_TheBattleOfTheFiveArmies
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const string ARMY_WIN_A_WAR_MESSAGE = "The army managed to free the Middle World! Armor left: {0}";
        private const string ARMY_LOST_A_WAR_MESSAGE = "The army was defeated at {0};{1}.";
        private const char ARMY_CHARACTER = 'A';
        private const char ORCS_CHARACTER = 'O';
        private const char MORDOR_CHARACTER = 'M';
        private const char DEAD_CHARACTER = 'X';
        private const char EMPTY_CHARACTER = '-';

        public static void Main()
        {
            var armor = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());

            var matrix = new char[rows][];
            ReadMatrix(matrix);

            var armyRows = 0;
            var armyCols = 0;

            ArmyCords(matrix, ref armyRows, ref armyCols);

            while (true)
            {
                var arg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var commad = arg[0];
                var orcRows = int.Parse(arg[1]);
                var orcCols = int.Parse(arg[2]);

                matrix[orcRows][orcCols] = ORCS_CHARACTER;

                armor--;
                matrix[armyRows][armyCols] = EMPTY_CHARACTER;

                Move(matrix, ref armyRows, ref armyCols, commad, rows);

                if (matrix[armyRows][armyCols] == ORCS_CHARACTER)
                {
                    armor -= 2;
                }

                if (matrix[armyRows][armyCols] == MORDOR_CHARACTER)
                {
                    matrix[armyRows][armyCols] = EMPTY_CHARACTER;
                    Console.WriteLine(string.Format(ARMY_WIN_A_WAR_MESSAGE, armor));
                    break;
                }

                if (armor <= 0)
                {
                    matrix[armyRows][armyCols] = DEAD_CHARACTER;
                    Console.WriteLine(string.Format(ARMY_LOST_A_WAR_MESSAGE, armyRows, armyCols));
                    break;
                }

                matrix[armyRows][armyCols] = ARMY_CHARACTER;
            }

            PrintResult(matrix);
        }

        private static void ReadMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var rowDate = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = rowDate;
            }
        }

        private static void ArmyCords(char[][] matrix, ref int armyRow, ref int armyCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == ARMY_CHARACTER)
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
        }

        private static void Move(char[][] matrix, ref int armyRows, ref int armyCols, string commad, int rows)
        {
            if (commad == "up" && armyRows - 1 >= 0)
            {
                armyRows--;
            }
            else if (commad == "down" && armyRows + 1 < rows)
            {
                armyRows++;
            }
            else if (commad == "left" && armyCols - 1 >= 0)
            {
                armyCols--;
            }
            else if (commad == "right" && armyCols + 1 < matrix[armyRows].Length)
            {
                armyCols++;
            }
        }

        private static void PrintResult(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

    }
}
