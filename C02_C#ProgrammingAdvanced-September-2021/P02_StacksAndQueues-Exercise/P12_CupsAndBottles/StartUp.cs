namespace P12_CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string WASTED_LITTERS_MESSAGE = "Wasted litters of water: {0}";
        public static void Main()
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> cups = new Stack<int>(cupsCapacity.Reverse());
            Stack<int> bottles = new Stack<int>(bottlesInput);
            int wasterWaterSum = 0;
            bool isBreak = false;

            while (cups.Count > 0)
            {
                if (bottles.Count == 0)
                {
                    isBreak = true;
                    break;
                }

                bool canItBeAssembled = cups.Peek() > bottles.Peek();
                if (canItBeAssembled)
                {
                    var fillUp = cups.Pop() - bottles.Pop();
                    cups.Push(fillUp);
                }
                else
                {
                    int wastetWater = bottles.Pop() - cups.Pop();
                    wasterWaterSum += wastetWater;
                }
            }

            if (isBreak)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups.ToArray())}");
                Console.WriteLine(WASTED_LITTERS_MESSAGE, wasterWaterSum);
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles.ToArray())}");
                Console.WriteLine(WASTED_LITTERS_MESSAGE, wasterWaterSum);
            }
        }
    }
}
