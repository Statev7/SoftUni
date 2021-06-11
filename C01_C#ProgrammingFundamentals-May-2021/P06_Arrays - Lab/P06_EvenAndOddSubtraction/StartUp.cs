namespace P06_EvenAndOddSubtraction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int evenSum = EvenSum(input);
            int oddSum = OddSum(input);
            PrintResult(evenSum, oddSum);
        }

        private static int EvenSum(int[] input)
        {
            int sum = input
                .Where(n => n % 2 == 0)
                .Sum();

            return sum;
        }

        private static int OddSum(int[] input)
        {
            int sum = input
                .Where(n => n % 2 != 0)
                .Sum();

            return sum;
        }

        private static void PrintResult(int evenSum, int oddSum)
        {
            int sum = evenSum - oddSum;
            Console.WriteLine(sum);
        }
    }
}
