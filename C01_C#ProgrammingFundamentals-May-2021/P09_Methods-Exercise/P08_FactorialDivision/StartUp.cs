namespace P08_FactorialDivision
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());

            double firstDigitFactorial = Factorial(firstDigit);
            double secondDigitFactorial = Factorial(secondDigit);

            double result = firstDigitFactorial / secondDigitFactorial;
            Console.WriteLine($"{result:F2}");
        }

        private static double Factorial(int digit)
        {
            double fact = 1;

            for (int i = 1; i <= digit; i++)
            {
                fact = fact * i;
            }

            return fact;
        }
    }
}
