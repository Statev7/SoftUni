namespace P02_RecursiveFactorial
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int result = FactorialSum(n);
            Console.WriteLine(result);
        }

        private static int FactorialSum(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * FactorialSum(n - 1);
        }
    }
}
