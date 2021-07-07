namespace P01_CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var counts = new SortedDictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (counts.ContainsKey(input[i]))
                {
                    counts[input[i]]++;
                }
                else
                {
                    counts.Add(input[i], 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
