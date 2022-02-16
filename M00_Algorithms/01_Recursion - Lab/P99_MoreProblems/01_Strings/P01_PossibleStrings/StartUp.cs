namespace P01_PossibleStrings
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            char[] set = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            int lenght = int.Parse(Console.ReadLine());
            char[] vector = new char[lenght];

            Generate(set, vector, 0);
        }

        private static void Generate(char[] set, char[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                vector[index] = set[i];
                Generate(set, vector, index + 1);
            }
        }
    }
}
