namespace P02_SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            int firstSetSize = inputNumbers[0];
            int secondSetSize = inputNumbers[1];

            ReadNumbers(firstSetSize, firstSet);
            ReadNumbers(secondSetSize, secondSet);

            PrintUniqueNumbersInSets(firstSet, secondSet);
        }

        private static void ReadNumbers(int inputNumbers, HashSet<int> set)
        {
            for (int i = 0; i < inputNumbers; i++)
            {
                int num = int.Parse(Console.ReadLine());
                set.Add(num);
            }
        }

        private static void PrintUniqueNumbersInSets(HashSet<int> firstSet, HashSet<int> secondSet)
        {
            foreach (var num in firstSet)
            {
                bool isNumExistInSecondSet = secondSet.Contains(num);
                if (isNumExistInSecondSet)
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
