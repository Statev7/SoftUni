namespace P04_PrintAndSum
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            int startDigit = int.Parse(Console.ReadLine());
            int endDigit = int.Parse(Console.ReadLine());

            double sum = 0;
            List<int> allDigits = new List<int>();

            for (int i = startDigit; i <= endDigit; i++)
            {
                allDigits.Add(i);
                sum += i;
            }

            PrintResult(allDigits, sum);
        }

        private static void PrintResult(List<int> allDigits, double sum)
        {
            var stringBuilder = new StringBuilder();

            string result = $"Sum: {sum}";

            stringBuilder.AppendLine(string.Join(" ", allDigits));
            stringBuilder.AppendLine(result);

            Console.WriteLine(stringBuilder.ToString());
        } 
    }
}
