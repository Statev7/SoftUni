namespace P04_ReverseArrayOfStrings
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            Array.Reverse(input);

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
