namespace P02_PermWithRepetation
{
    using System;

    public class StartUp
    {
        private static string[] array;

        public static void Main()
        {
            array = Console.ReadLine().Split(" ");

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < array.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index, int i)
        {
            string temp = array[index];
            array[index] = array[i];
            array[i] = temp;
        }
    }
}
