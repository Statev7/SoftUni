namespace P06_ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int exclude = int.Parse(Console.ReadLine());
            Predicate<int> predicate = n => n % exclude != 0; 

            var newList = RemoveExcludeElements(input, predicate);
            Func<List<int>, List<int>> func = Reverse;

            Console.WriteLine(string.Join(" ", func(newList)));
            
        }

        private static List<int> RemoveExcludeElements(List<int> numbers, Predicate<int> filter)
        {
            var newNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (filter(numbers[i]))
                {
                    newNumbers.Add(numbers[i]);
                }
            }

            return newNumbers;
        }

        private static List<int> Reverse(List<int> numbers)
        {
            var reverstedElements = new List<int>();

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                reverstedElements.Add(numbers[i]);
            }

            return reverstedElements;
        }
    }
}
