namespace P02_PoundsToDollars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const decimal ONE_POUND_TO_DOLLARS = 1.31m;

            decimal pound = decimal.Parse(Console.ReadLine());
            decimal result = pound * ONE_POUND_TO_DOLLARS;

            Console.WriteLine($"{result:F3}");
        }
    }
}
