namespace P07_NChooseKCount
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int result = Binom(n, k);
            Console.WriteLine(result);
        }

        private static int Binom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return Binom(row - 1, col - 1) + Binom(row - 1, col);
        }
    }
}
