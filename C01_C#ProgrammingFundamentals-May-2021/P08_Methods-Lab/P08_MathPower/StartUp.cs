namespace P08_MathPower
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double digit = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());

            double sum = RaiseToPower(digit, pow);
            PrintDigit(sum);
        }

        private static double RaiseToPower(double digit, int pow)
        {
            double result = Math.Pow(digit, pow);
            return result;
        }

        private static void PrintDigit(double sum)
        {
            Console.WriteLine(sum);
        }
    }
}
