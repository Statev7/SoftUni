namespace P06_StrongNumber
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;
            var array = input.ToString().ToCharArray();

            int sum = 0;
            string result = "no";

            for (int index = 0; index < array.Length; index++)
            {
                var digitForFactorial = int.Parse(array[index].ToString());
                sum += FactorialSum(digitForFactorial);
            }

            if (number == sum)
            {
                result = "yes";
            }

            Console.WriteLine(result);

        }

        private static int FactorialSum(int digit)
        {
            int sum = 1;

            for (int i = digit; i > 0; i--)
            {
                sum = sum * i;
            }

            return sum;
        }
    }
}
