namespace P08_Fibonacci
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // 1 1 2 3 5 
            int n = int.Parse(Console.ReadLine());

            int result = GetFibonacci(n);
            Console.WriteLine(result);
        }

        private static int GetFibonacci(int n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }

            int sum = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            return sum;
        }
    }
}
