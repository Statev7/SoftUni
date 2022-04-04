namespace P04_CombinationsWithoutRepetition
{
    using System;

    public class StartUp
    {
        private static int n;
        private static int[] combinations;
        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            combinations = new int[k];

            Comb(0, 1);
        }

        private static void Comb(int index, int i)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int j = i; j <= n; j++)
            {
                combinations[index] = j;
                Comb(index + 1, j + 1);
            }
        }
    }
}
