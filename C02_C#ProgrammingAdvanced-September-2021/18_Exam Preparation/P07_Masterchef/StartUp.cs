namespace P07_Masterchef
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var ingredientsInput = Console.ReadLine().Split(" ").
                Select(int.Parse)
                .ToArray();

            var freshnessInput = Console.ReadLine().Split(" ")
                .Select(int.Parse)
                .ToArray();

            var ingredients = new Queue<int>(ingredientsInput);
            var freshness = new Stack<int>(freshnessInput);
            var cookResult = new Dictionary<string, int>();

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    var sum = ingredients.Peek() * freshness.Peek();
                    bool canCook = CanCook(sum);
                    if (canCook)
                    {
                        string dish = Dish(sum);
                        if (cookResult.ContainsKey(dish) == false)
                        {
                            cookResult.Add(dish, 0);
                        }
                        cookResult[dish]++;

                        ingredients.Dequeue();
                        freshness.Pop();
                    }
                    else
                    {
                        freshness.Pop();
                        var value = ingredients.Dequeue() + 5;
                        ingredients.Enqueue(value);
                    }
                }
            }

            PrintResult(ingredients, cookResult);
        }

        private static void PrintResult(Queue<int> ingredients, Dictionary<string, int> cookResult)
        {
            if (cookResult.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                if (ingredients.Count() != 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                foreach (var item in cookResult
                    .OrderBy(x => x.Key))
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Count() != 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                foreach (var item in cookResult
                    .OrderBy(x => x.Key))
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
        }

        private static bool CanCook(int sum)
        {
            bool canCook = sum == 150 || 
                           sum == 250 ||     
                           sum == 300 || 
                           sum == 400;
            if (canCook)
            {
                return true;
            }
            return false;
        }

        private static string Dish(int sum)
        {
            string dish = string.Empty;
            switch (sum)
            {
                case 150: dish = "Dipping sauce"; break;
                case 250: dish = "Green salad"; break;
                case 300: dish = "Chocolate cake"; break;
                case 400: dish = "Lobster"; break;
            }

            return dish;
        }
    }
}
