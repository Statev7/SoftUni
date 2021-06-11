namespace P05_TopIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isBreak = false;
            List<int> result = new List<int>();

            for (int firstIndex = 0; firstIndex < array.Length; firstIndex++)
            {
                isBreak = false;

                for (int secondIndex = firstIndex + 1; secondIndex < array.Length; secondIndex++)
                {
                    if (array[firstIndex] <= array[secondIndex])
                    {
                        isBreak = true;
                        break;
                    }
                }

                if (isBreak == false)
                {
                    result.Add(array[firstIndex]);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
