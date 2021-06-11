namespace P03_RoundingNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                string result = $"{Convert.ToDecimal(input[i])} => {Math.Round(Convert.ToDecimal(input[i]), MidpointRounding.AwayFromZero)}";
                Console.WriteLine(result);
            }
        }
    }
}
