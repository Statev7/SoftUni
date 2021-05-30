namespace P02_SumDigits
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            int sum = 0;

            for (int index = 0; index < input.Length; index++)
            {
                sum += int.Parse(input[index].ToString());
            }

            Console.WriteLine(sum);
        }
    }
}
