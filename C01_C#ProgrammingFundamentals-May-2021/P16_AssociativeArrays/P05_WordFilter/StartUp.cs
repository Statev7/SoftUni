namespace P05_WordFilter
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            input = input
                .Where(x => x.Length % 2 == 0)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
