namespace P09_SumOfOddNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            int result = 0;
            int initialValue = 1;

            for (int i = 0; i < input; i++)
            {
                int temp = initialValue;
                result += temp;

                initialValue += 2;
                Console.WriteLine(temp);
            }

            Console.WriteLine($"Sum: {result}");
        }
    }
}
