namespace P07_MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = 1;
            int max = int.MinValue;
            int longestSequenceDigit = 0;

            for (int firstIndex = 0; firstIndex < array.Length; firstIndex++)
            {
                count = 1;

                for (int secondIndex = firstIndex + 1; secondIndex < array.Length; secondIndex++)
                {
                    if (array[firstIndex] == array[secondIndex])
                    {
                        count++;

                        if (count > max)
                        {
                            max = count;
                            longestSequenceDigit = array[firstIndex];
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            count = max;
            List<int> result = MakeTheLongestRow(longestSequenceDigit, count);
            PrintResult(result);
        }

        private static List<int> MakeTheLongestRow(int longestSequenceDigit, int count)
        {
            List<int> result = new List<int>();

            for (int index = 0; index < count; index++)
            {
                result.Add(longestSequenceDigit);
            }

            return result;
        }

        private static void PrintResult(List<int> result)
        {
            Console.WriteLine(string.Join(' ', result));
        }

    }
}
