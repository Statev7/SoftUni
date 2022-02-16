namespace P01_ArraySum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const int INITIAL_INDEX = 0;

        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int result = ArraySum(input, INITIAL_INDEX);
            Console.WriteLine(result);
        }

        private static int ArraySum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return array[index];
            }

            return array[index] + ArraySum(array, index + 1);
        }
    }
}
