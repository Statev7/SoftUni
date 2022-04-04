namespace P04_InsertionSort
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            InsertionSort(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            // 3 5 1 2
            for (int i = 1; i < numbers.Length; i++)
            {
                int element = numbers[i]; 
                int j = i - 1; 

                while (j >= 0 && numbers[j] > element) 
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }

                numbers[j + 1] = element; 
            }
        }
    }
}
