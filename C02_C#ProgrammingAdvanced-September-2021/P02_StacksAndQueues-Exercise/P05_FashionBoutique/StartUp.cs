namespace P05_FashionBoutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int boxCapacity = int.Parse(Console.ReadLine());
            int boxCount = 1;
            int sum = 0;

            Stack<int> clothes = new Stack<int>(input.Reverse());

            while (clothes.Count > 0)
            {
                sum += clothes.Peek(); 

                if (sum <= boxCapacity)
                {
                    clothes.Pop();
                }
                else
                {
                    sum = 0;
                    boxCount++;
                }
            }

            Console.WriteLine(boxCount);
        }
    }
}
