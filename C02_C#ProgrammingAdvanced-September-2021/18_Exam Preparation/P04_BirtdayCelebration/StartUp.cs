namespace P04_BirtdayCelebration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var eatingCapacityInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var platesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var eatingCapacity = new List<int>(eatingCapacityInput);
            var plates = new Stack<int>(platesInput);

            int wastedFood = 0;

            while (eatingCapacity.Count > 0 && plates.Count > 0)
            {
                var platesCurruntElement = plates.Peek();
                var eatingCurruntElement = eatingCapacity[0];

                bool canFeed = platesCurruntElement - eatingCurruntElement >= 0;
                if (canFeed)
                { 
                    wastedFood += plates.Pop() - eatingCurruntElement;
                    eatingCapacity.RemoveAt(0);
                }
                else
                {
                    var newValue = eatingCurruntElement - plates.Pop();
                    eatingCapacity[0] = newValue;
                }
            }

            if (eatingCapacity.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", eatingCapacity)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
        }
    }
}
