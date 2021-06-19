namespace P01_SmallestOfThreeNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int[] digits = new int[3];

            for (int index = 0; index < 3; index++)
            {
                digits[index] = int.Parse(Console.ReadLine());
            }

            PrintTheLargestNumber(digits);
        }

        private static void PrintTheLargestNumber(int[] digits)
        {
            double theLargestDigit = Math.Min(digits[0], Math.Min(digits[1], digits[2]));

            Console.WriteLine(theLargestDigit);
        }
    }
}
