namespace P06_Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var arg = Console.ReadLine()
                    .Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = arg[0];
                bool isColorExist = wardrobe.ContainsKey(color);
                if (isColorExist == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int index = 1; index < arg.Length; index++)
                {
                    string clothe = arg[index];
                    bool isClotheExist = wardrobe[color].ContainsKey(clothe);
                    if (isClotheExist == false)
                    {
                        wardrobe[color].Add(clothe, 0);
                    }
                    wardrobe[color][clothe]++;
                }
            }

            string[] search = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string searchedColor = search[0];
            string searchedClothe = search[1];
            PrintResult(wardrobe, searchedColor, searchedClothe);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> wardrobe, string searchedColor, string searchedClothe)
        {
            foreach (var clothes in wardrobe)
            {
                Console.WriteLine($"{clothes.Key} clothes:");
                foreach (var clothe in clothes.Value)
                {
                    bool isSearchedClothe = clothes.Key == searchedColor && searchedClothe == clothe.Key;
                    if (isSearchedClothe)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }
            }
        }
    }
}
