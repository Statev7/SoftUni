namespace P05_TheBattleOfTheFiveArmies
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int armor = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());

            var army = new Army(armor);
            var matrix = new char[matrixSize, matrixSize];
            matrix = ReadMatrix(matrix);
            StartPosition(matrix, army);

            while (army.Armor > 0 && army.IsWarOver == false)
            {
                string[] arguments = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = arguments[0];
                int rowCord = int.Parse(arguments[1]);
                int colCord = int.Parse(arguments[2]);
                matrix[rowCord, colCord] = 'O';

                switch (command)
                {
                    case "up": Up(matrix, army); break;
                    case "down": Down(matrix, army); break;
                    case "right": Right(matrix, army); break;
                    case "left": Left(matrix, army); break;
                }
            }

            if (army.IsWarOver)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {army.Armor}");
                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine($"The army was defeated at {army.Y};{army.X}.");
                PrintMatrix(matrix);
            }
        }

        private static void Up(char[,] matrix, Army army)
        {
            bool canMove = army.Y - 1 >= 0;
            if (canMove)
            {
                army.Y -= 1;
                Move(matrix, army);
            }
            else
            {
                army.Armor -= 1;
            }
        }

        private static void Down(char[,] matrix, Army army)
        {
            bool canMove = army.Y + 1 < matrix.GetLength(0);
            if (canMove)
            {
                army.Y += 1;
                Move(matrix, army);
            }
            else
            {
                army.Armor -= 1;
            }
        }

        private static void Right(char[,] matrix, Army army)
        {
            bool canMove = army.X + 1 < matrix.GetLength(1);
            if (canMove)
            {
                army.X += 1;
                Move(matrix, army);
            }
            else
            {
                army.Armor -= 1;
            }
        }

        private static void Left(char[,] matrix, Army army)
        {
            bool canMove = army.X - 1 >= 0;
            if (canMove)
            {
                army.X -= 1;
                Move(matrix, army);
            }
            else
            {
                army.Armor -= 1;
            }
        }

        private static void Move(char[,] matrix, Army army)
        {
            army.Armor -= 1;

            if (matrix[army.Y, army.X] == 'O')
            {
                army.Armor -= 2;
                if (army.Armor <= 0)
                {
                    matrix[army.Y, army.X] = 'X';
                }
                else
                {
                    matrix[army.Y, army.X] = '-';
                }
            }
            else if (matrix[army.Y, army.X] == 'M')
            {
                matrix[army.Y, army.X] = '-';
                army.IsWarOver = true;
            }
        }

        private static void StartPosition(char[,] matrix, Army army)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'A')
                    {
                        army.Y = row;
                        army.X = col;
                        matrix[row, col] = '-';
                    }
                }
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

        private static void PrintMatrix(char[,] matrix)
        {
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

    public class Army
    {
        public Army(int armor)
        {
            this.Armor = armor;
        }
        
        public int Armor { get; set; }

        public bool IsWarOver { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
