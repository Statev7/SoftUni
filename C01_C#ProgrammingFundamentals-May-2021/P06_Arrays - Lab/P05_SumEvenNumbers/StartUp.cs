namespace P05_SumEvenNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var sum = input
                .Where(n => n % 2 == 0)
                .Sum();

            Console.WriteLine(sum);
        }
    }
}
