namespace P03_LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var legendaryItems = new Dictionary<string, int>
            { 
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0},
            };

            var junkItems = new Dictionary<string, int>();
            bool isBreak = false;

            while (true)
            {
                if (isBreak)
                {
                    PrintResult(legendaryItems, junkItems);
                    break;
                }

                string[] arguments = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int argumentsCount = arguments.Length / 2;
                int[] quantity = new int[argumentsCount];
                string[] material = new string[argumentsCount];

                AddArguments(quantity, material, arguments);
                isBreak = CheckIfWeHaveAWinner(legendaryItems, junkItems, quantity, material, argumentsCount, isBreak);
            }
        }

        private static void AddArguments(int[] quantity, string[] material, string[] arguments)
        {
            int quantityIndex = 0;
            int materialIndex = 0;

            for (int index = 0; index < arguments.Length; index++)
            {
                if (index % 2 == 0)
                {
                    quantity[quantityIndex++] = int.Parse(arguments[index]);
                }
                else
                {
                    material[materialIndex++] = arguments[index];
                }
            }
        }

        private static bool CheckIfWeHaveAWinner(Dictionary<string, int> legendaryItems, Dictionary<string, int> junkItems,
            int[] quantity, string[] material, int argumentsCount, bool isBreak)
        {
            for (int i = 0; i < argumentsCount; i++)
            {
                if (legendaryItems.ContainsKey(material[i]))
                {
                    legendaryItems[material[i]] += quantity[i];

                    if (legendaryItems[material[i]] >= 250)
                    {
                        PrintWinner(material[i]);
                        legendaryItems[material[i]] -= 250;
                        isBreak = true;
                        break;
                    }
                }
                else
                {
                    if (junkItems.ContainsKey(material[i]))
                    {
                        junkItems[material[i]] += quantity[i];
                    }
                    else
                    {
                        junkItems.Add(material[i], quantity[i]);
                    }
                } 
            }

            return isBreak;
        }

        private static void PrintWinner(string material)
        {
            string winner = string.Empty;

            switch (material)
            {
                case "shards": winner = "Shadowmourne"; break;
                case "fragments": winner = "Valanyr"; break;
                case "motes": winner = "Dragonwrath"; break;
            }

            Console.WriteLine($"{winner} obtained!");
        }

        private static void PrintResult(Dictionary<string, int> specialMaterials, Dictionary<string, int> junkMaterials)
        {
            specialMaterials
                 .OrderByDescending(x => x.Value)
                 .ThenBy(x => x.Key)
                 .ToList()
                 .ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));

            junkMaterials
                .OrderBy(x => x.Key)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));
        }
    }
}
