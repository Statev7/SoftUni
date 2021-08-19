namespace P05_PrintEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> number = new Queue<int>(inputNumbers);
            Queue<int> evenNumber = new Queue<int>();

            while (number.Count != 0)
            {
                int digit = number.Peek();
                if (digit % 2 == 0)
                {
                    evenNumber.Enqueue(digit);
                }
                number.Dequeue();
            }

            Console.WriteLine(string.Join(", ", evenNumber.ToArray()));
        }
    }
}
