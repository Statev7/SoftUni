namespace P01_SumAdjacentEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int index = 0; index < numbers.Count; index++)
            {
                if (index + 1 >= numbers.Count)
                {
                    break;
                }

                bool areTheNumbersEqual = numbers[index] == numbers[index + 1];

                if (areTheNumbersEqual)
                {
                    double sum = numbers[index] + numbers[index + 1];
                    numbers[index] = sum;
                    numbers.RemoveAt(index + 1);
                    index = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
