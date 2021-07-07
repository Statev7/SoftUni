namespace P04_Largest3Numbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length > 3)
            {
                numbers = numbers
                    .OrderByDescending(x => x)
                    .Take(3)
                    .ToArray();
            }
            else
            {
                numbers = numbers
                    .OrderByDescending(x => x)
                    .ToArray();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
