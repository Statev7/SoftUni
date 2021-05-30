namespace P03_ExactSumOfRealNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            float sum = 0;

            for (int i = 0; i < n; i++)
            {
                float number = float.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
