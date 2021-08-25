namespace P04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            string condition = Console.ReadLine();
            Predicate<int> predicate;

            switch (condition)
            {
                case "odd":
                    predicate = n => n % 2 != 0;
                    break;
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                default:
                    predicate = null;
                    break;
            }

            var result = EvenOrOdd(start, end, predicate);
            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> EvenOrOdd(int start, int end, Predicate<int> predicate)
        {
            List<int> result = new List<int>();

            for (int i = start; i < end; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
