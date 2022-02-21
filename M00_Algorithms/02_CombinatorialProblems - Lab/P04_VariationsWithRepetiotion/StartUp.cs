namespace P04_VariationsWithRepetiotion
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static string[] arr;
        private static string[] variations;

        public static void Main()
        {
            arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int k = int.Parse(Console.ReadLine());
            variations = new string[k];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                variations[index] = arr[i];
                Variations(index + 1);
            }
        }
    }
}
