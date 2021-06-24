namespace P05_RemoveNegativesAndReverse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .Where(x => x >= 0)
                .Reverse()
                .ToList();

            bool isCountZero = input.Count == 0;
            if (isCountZero)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", input));
            }
        }
    }
}
