namespace P01_BinarySearch
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

            int target = int.Parse(Console.ReadLine());

            int result = BinarySearch(numbers, target);
            Console.WriteLine(result);
        }

        private static int BinarySearch(int[] numbers, int target)
        {
            int index = -1;
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                int midIndex = (left + right) / 2;
                int element = numbers[midIndex];

                if (element == target)
                {
                    index = midIndex;
                    break;
                }
                else if (element > target)
                {
                    right = midIndex - 1;
                }
                else if(element < target)
                {
                    left = midIndex + 1; 
                }
            }

            return index;
        }
    }
}
