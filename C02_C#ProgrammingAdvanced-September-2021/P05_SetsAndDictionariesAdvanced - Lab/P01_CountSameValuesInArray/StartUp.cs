namespace P01_CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var allNumbers = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int index = 0; index < numbers.Length; index++)
            {
                bool isNumberIn = allNumbers.ContainsKey(numbers[index]);
                if (isNumberIn == false)
                {
                    allNumbers.Add(numbers[index], 0);
                }
                allNumbers[numbers[index]]++;
            }

            PrintResult(allNumbers);
        }

        private static void PrintResult(Dictionary<double, int> allNumbers)
        {
            foreach (var number in allNumbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
