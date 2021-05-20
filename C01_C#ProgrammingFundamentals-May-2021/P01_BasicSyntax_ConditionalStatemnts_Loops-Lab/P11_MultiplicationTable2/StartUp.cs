namespace P11_MultiplicationTable2
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            const int END_DIGIT = 10;

            int input = int.Parse(Console.ReadLine());
            int startDigit = int.Parse(Console.ReadLine());

            List<string> saveResult = new List<string>();
            string result = string.Empty;
            int sum = 0;

            if (END_DIGIT < startDigit)
            {
                sum = input * startDigit;

                result = $"{input} X {startDigit} = {sum}";
                saveResult.Add(result);
            }

            for (int i = startDigit; i <= END_DIGIT; i++)
            {
                sum = input * i;

                result = $"{input} X {i} = {sum}";
                saveResult.Add(result);
            }

            Console.WriteLine(string.Join(Environment.NewLine, saveResult));
        }
    }
}
