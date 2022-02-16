namespace P04_GeneratingVectors
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];
            Generate(array, 0);
        }

        private static void Generate(int[] array, int index)
        {
            if (index == array.Length)
            {
                Console.WriteLine(string.Join("", array));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                array[index] = i;
                Generate(array, index + 1);
            }
        }
    }
}
