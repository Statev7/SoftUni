namespace P10_MultiplyEventsByOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            char[] digitArray = ConverStringToCharArray(input);

            DetermineWhetherTheIndexOfTheNumbersIsEvenOrOdd(digitArray);
        }

        private static char[] ConverStringToCharArray(string input)
        {
            int digit = int.Parse(input);
            int digitAfterAbs = Math.Abs(digit);
            char[] digitArray = digitAfterAbs.ToString().ToCharArray();

            return digitArray;
        }

        private static void DetermineWhetherTheIndexOfTheNumbersIsEvenOrOdd(char[] digitArray)
        {
            List<int> evenDitigs = new List<int>();
            List<int> oddDitigs = new List<int>();

            for (int index = 0; index < digitArray.Length; index++)
            {
                if (digitArray[index] % 2 == 0)
                {
                    int evenDigit = Convert.ToInt32(digitArray[index].ToString());
                    evenDitigs.Add(evenDigit);
                }
                else
                {
                    int oddDigit = Convert.ToInt32(digitArray[index].ToString());
                    oddDitigs.Add(oddDigit);
                }
            }

            int evenDigitsSum = GetSumOfEvenDigits(evenDitigs);
            int oddDigitsSum = GetSumOfOddDigits(oddDitigs);
            int sumOfEvenAndOddDigits = GetMultipleOfEvenAndOdds(evenDigitsSum, oddDigitsSum);
            PrintResult(sumOfEvenAndOddDigits);
        }

        private static int GetSumOfEvenDigits(List<int> evenDigits)
        {
            int sumOfEvenDigits = evenDigits.Sum();
            return sumOfEvenDigits;
        }

        private static int GetSumOfOddDigits(List<int> oddDigits)
        {
            int sumOfOddDigits = oddDigits.Sum();
            return sumOfOddDigits;
        }

        private static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            int result = evenSum * oddSum;
            return result;
        }

        private static void PrintResult(int result)
        {
            Console.WriteLine(result);
        }
    }
}
