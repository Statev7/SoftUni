namespace P01_SortNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            
            int[] array = new int[3];

            for (int indedx = 0; indedx < 3; indedx++)
            {
                array[indedx] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);
            Array.Reverse(array);

            PrintResult(array);
        }

        private static void PrintResult(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                Console.WriteLine(array[index]);
            }
        }
    }
}
