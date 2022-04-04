namespace P02_NestedLoopsToRecursion
{
    using System;

    public class StartUp
    {
        private static int[] arr;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];

            Loop(0);
        }

        private static void Loop(int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                Loop(index + 1);
            }
        }
    }
}
