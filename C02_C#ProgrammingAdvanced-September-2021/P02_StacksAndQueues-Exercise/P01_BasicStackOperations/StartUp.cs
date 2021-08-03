namespace P01_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numbersToPop = input[1];
            int digitToFind = input[2];

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> allNumbers = new Stack<int>(numbers);
            RemoveElements(numbersToPop, allNumbers);
            PrintResult(digitToFind, allNumbers);
        }

        private static void PrintResult(int digitToFind, Stack<int> allNumbers)
        {
            bool isDigitExist = allNumbers.Contains(digitToFind);
            if (isDigitExist)
            {
                Console.WriteLine("true");
            }
            else if (allNumbers.Count > 0)
            {
                Console.WriteLine(allNumbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static void RemoveElements(int numbersToPop, Stack<int> allNumbers)
        {
            for (int i = 0; i < numbersToPop; i++)
            {
                allNumbers.Pop();
            }
        }
    }
}
