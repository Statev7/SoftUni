namespace P07_RepeatString
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());

            string repeatedString = RepeatString(input, repeatCount);
            PrintTheString(repeatedString);
        }

        private static string RepeatString(string input, int repeatCount)
        {
            string result = string.Empty;

            for (int count = 0; count < repeatCount; count++)
            {
                result += input;
            }

            return result;
        }

        private static void PrintTheString(string repeatedString)
        {
            Console.WriteLine(repeatedString);
        }
    }
}
