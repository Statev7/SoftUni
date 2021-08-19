namespace P04_FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());
            int[] ordersInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(ordersInput);
            int biggestOrder = orders.Max();
            bool isBreak = false;

            while (orders.Count > 0)
            {
                int curruntOrder = orders.Peek();
                bool isValid = quantityOfTheFood - curruntOrder >= 0;
                if (isValid)
                {
                    quantityOfTheFood -= curruntOrder;
                    orders.Dequeue();
                }
                else
                {
                    isBreak = true;
                    break;
                }
            }

            PrintResult(orders, biggestOrder, isBreak);
        }

        private static void PrintResult(Queue<int> orders, int biggestOrder, bool isBreak)
        {
            Console.WriteLine(biggestOrder);
            if (isBreak)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders.ToArray())}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
