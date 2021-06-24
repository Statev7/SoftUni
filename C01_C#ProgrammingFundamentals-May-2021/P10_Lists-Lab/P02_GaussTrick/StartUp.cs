namespace P02_GaussTrick
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();
            SumOfIndexs(input, result);

            Console.WriteLine(string.Join(" ", result));
        }

        private static void SumOfIndexs(List<int> input, List<int> result)
        {
            int sum = 0;

            bool isEven = input.Count % 2 == 0;

            if (isEven)
            {
                for (int index = 0; index < input.Count; index++)
                {
                    sum = input[0] + input[input.Count - 1];
                    result.Add(sum);
                    input.RemoveAt(0);
                    input.RemoveAt(input.Count - 1);
                }
            }
            else
            {
                int averageIndex = input.Count / 2;
                int averageDigit = input[averageIndex];

                for (int index = 0; index < input.Count / 2; index++)
                {
                    sum = input[0] + input[input.Count - 1];
                    result.Add(sum);
                }

                result.Add(averageDigit);
            }
        }
    }
}
