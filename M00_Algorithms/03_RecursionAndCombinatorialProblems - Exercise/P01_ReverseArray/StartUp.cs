namespace P01_ReverseArray
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] array;

        public static void Main()
        {
            array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ReverseArray(0);

            Console.WriteLine(string.Join(" ", array));
        }

        public static void ReverseArray(int index)
        {
            if (index >= array.Length / 2)
            {
                return;
            }

            int temp = array[index]; 
            array[index] = array[array.Length - (index + 1)]; 
            array[array.Length - (index + 1)] = temp;
            ReverseArray(index + 1);
        }
    }
}
