namespace P03_MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int operationCount = int.Parse(Console.ReadLine());
            Stack<int> allNumbers = new Stack<int>();

            for (int i = 0; i < operationCount; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int operation = input[0];

                switch (operation)
                {
                    case 1: Add(allNumbers, input[1]); break;
                    case 2: Remove(allNumbers); break;
                    case 3: MaxValue(allNumbers); break;
                    case 4: MinValue(allNumbers); break;
                }
            }

            Console.WriteLine(string.Join(", ", allNumbers.ToArray()));
        }

        private static void Add(Stack<int> allNumbers, int number)
        {
            allNumbers.Push(number);
        }

        private static void Remove(Stack<int> allNumbers)
        {
            bool isValid = IsValid(allNumbers);
            if (isValid)
            {
                allNumbers.Pop();
            }
        }

        private static void MaxValue(Stack<int> allNumbers)
        {
            bool isValid = IsValid(allNumbers);
            if (isValid)
            {
                Console.WriteLine(allNumbers.Max());
            }
        }

        private static void MinValue(Stack<int> allNumbers)
        {
            bool isValid = IsValid(allNumbers);
            if (isValid)
            {
                Console.WriteLine(allNumbers.Min());
            }
        }

        private static bool IsValid(Stack<int> allNumbers)
        {
            bool isValid = allNumbers.Count > 0;
            return isValid;
        }
    }
}

