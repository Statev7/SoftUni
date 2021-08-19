namespace P07_HotPotato
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string[] kids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int n = int.Parse(Console.ReadLine());

            Queue<string> allKids = new Queue<string>(kids);
            int count = 0;

            while (allKids.Count > 1)
            {
                count++;
                if (count == n)
                {
                    count = 0;
                    Console.WriteLine($"Removed {allKids.Dequeue()}");
                }
                else
                {
                    string kid = allKids.Dequeue();
                    allKids.Enqueue(kid);
                }
            }

            Console.WriteLine($"Last is {allKids.Peek()}");

        }
    }
}
