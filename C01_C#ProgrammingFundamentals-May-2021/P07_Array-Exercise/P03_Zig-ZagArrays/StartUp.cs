namespace P03_Zig_ZagArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            List<int> evenResult = new List<int>();
            List<int> oddResult = new List<int>();

            for (int index = 0; index < n; index++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int firstArg = input[0];
                int secondArg = input[1];

                firstArray[index] = firstArg;
                secondArray[index] = secondArg;
            }

            for (int index = 0; index < n; index++)
            {
                if (index % 2 == 0)
                {
                    evenResult.Add(firstArray[index]);
                    oddResult.Add(secondArray[index]);
                }
                else
                {
                    oddResult.Add(firstArray[index]);
                    evenResult.Add(secondArray[index]);
                }
            }

            Console.WriteLine(string.Join(' ', evenResult));
            Console.WriteLine(string.Join(' ', oddResult));
        }
    }
}
