namespace P02_EnglishNameOfTheLastDigit
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            for (int index = input.Length - 1; index >= 0;)
            {
                int digit = int.Parse(input[index].ToString());
                string digitName = DigitName(digit);
                PrintResult(digitName);
                break;
            }
        }

        private static string DigitName(int digit)
        {
            string result = "zero";

            switch (digit)
            {
                case 1: result = "one"; break;
                case 2: result = "two"; break;
                case 3: result = "three"; break;
                case 4: result = "four"; break;
                case 5: result = "five"; break;
                case 6: result = "six"; break;
                case 7: result = "seven"; break;
                case 8: result = "eight"; break;
                case 9: result = "nine"; break;
            }
            return result;
        }

        private static void PrintResult(string digitName)
        {
            Console.WriteLine(digitName);
        }
    }
}
