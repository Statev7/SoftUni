namespace P05_GeneratingCombinations
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const int INITIAL_INDEX_VALUE = 0;
        private const int INITIAL_BORDER_VALUE = 0;

        public static void Main()
        {
            int[] date = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = int.Parse(Console.ReadLine());
            int[] vector = new int[k];

            Generate(date, vector, INITIAL_INDEX_VALUE, INITIAL_BORDER_VALUE);
        }

        private static void Generate(int[] date, int[] vector, int index, int border)
        {
            if (vector.Length == index) 
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < date.Length; i++)
            {
                vector[index] = date[i];
                Generate(date, vector, index + 1, i + 1);
            }
        }
    }
}
