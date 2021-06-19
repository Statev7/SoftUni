namespace P05_AddAndSubtract
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

            int sum = Sum(digits);
            Subtract(sum, digits[2]);
        }

        private static int Sum(int[] digits)
        {
            int sum = digits[0] + digits[1];

            return sum;
        }

        private static void Subtract(int firstDigit, int secondDigit)
        {
            int sum = firstDigit - secondDigit;
            Console.WriteLine(sum);
        }
    }
}
