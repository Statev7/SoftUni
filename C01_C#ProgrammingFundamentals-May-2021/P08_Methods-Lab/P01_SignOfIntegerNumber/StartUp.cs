namespace P01_SignOfIntegerNumber
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            PrintSign(input);
        }

        private static void PrintSign(int digit)
        {
            string result = "The number 0 is zero.";

            if (digit > 0)
            {
                result = $"The number {digit} is positive.";
            }
            else if (digit < 0)
            {
                result = $"The number {digit} is negative.";
            }

            Console.WriteLine(result);
        }
    }
}
