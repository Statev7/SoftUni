namespace P03_MergingLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();
            MergeToLists(firstList, secondList, result);

            Console.WriteLine(string.Join(" ", result));
        }

        private static void MergeToLists(List<int> firstList, List<int> secondList, List<int> result)
        {
            for (int firstListIndex = 0; firstListIndex < firstList.Count; firstListIndex++)
            {
                result.Add(firstList[firstListIndex]);

                for (int secondListIndex = firstListIndex; secondListIndex < secondList.Count;)
                {
                    result.Add(secondList[secondListIndex]);
                    break;
                }
            }

            CheckIfTheSecondSheetIsLongerThanThePreviousOne(firstList, secondList, result);
        }

        private static void CheckIfTheSecondSheetIsLongerThanThePreviousOne(List<int> firstList, List<int> secondList, List<int> result)
        {
            if (secondList.Count > firstList.Count)
            {
                int count = secondList.Count - firstList.Count;
                int start = secondList.Count - count;

                for (int index = start; index < secondList.Count; index++)
                {
                    result.Add(secondList[index]);
                }
            }
        }
    }
}
