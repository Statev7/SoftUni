namespace P10_TopNumber
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            List<int> allNumbers = TopNumbers(input);
            PrintResult(allNumbers);
        }

        private static List<int> TopNumbers(int count)
        {
            List<int> allNumbers = new List<int>();

            for (int digit = 17; digit < count; digit++)
            {
                bool isSumOfDigitsValid = IsTheSumOfDigitIsDivisibleByEight(digit);
                bool isThereAanOddNumber = IsThereAtLeastOneOddNumber(digit);

                if (isSumOfDigitsValid && isThereAanOddNumber)
                {
                    allNumbers.Add(digit);
                }
            }

            return allNumbers;
        }

        private static bool IsTheSumOfDigitIsDivisibleByEight(int digit)
        {
            bool isValid = false;
            int sum = 0;

            if (digit > 9)
            {
                var digitToArray = digit.ToString().ToCharArray();

                for (int index = 0; index < digitToArray.Length; index++)
                {
                    sum += int.Parse(digitToArray[index].ToString());
                }

                isValid = sum % 8 == 0;
            }
            else
            {
                isValid = digit % 8 == 0;
            }

            return isValid;
        }

        private static bool IsThereAtLeastOneOddNumber(int digit)
        {
            bool isValid = false;

            var digitToArray = digit.ToString().ToCharArray();
            for (int index = 0; index < digitToArray.Length; index++)
            {
                int parsetDigit = int.Parse(digitToArray[index].ToString());
                if (parsetDigit % 2 == 1)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        private static void PrintResult(List<int> allNumbers)
        {
            Console.WriteLine(string.Join(Environment.NewLine, allNumbers));
        }
    }
}
