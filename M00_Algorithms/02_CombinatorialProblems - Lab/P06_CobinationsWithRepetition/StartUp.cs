namespace P06_CobinationsWithRepetition
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static string[] arr;
        private static string[] combinations;

        public static void Main()
        {
            arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int k = int.Parse(Console.ReadLine());
            combinations = new string[k];

            Comb(0, 0);
        }

        private static void Comb(int index, int i)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int j = i; j < arr.Length; j++)
            {
                combinations[index] = arr[j];
                Comb(index + 1, j);
            }
        }
    }
}
