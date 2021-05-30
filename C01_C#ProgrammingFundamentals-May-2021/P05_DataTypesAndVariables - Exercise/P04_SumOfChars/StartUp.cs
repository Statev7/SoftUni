namespace P04_SumOfChars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());

                sum += input;
            }

            string result = $"The sum equals: {sum}";
            Console.WriteLine(result);
        }
    }
}
