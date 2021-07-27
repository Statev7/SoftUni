namespace P06_PlantDiscovery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TOP_STOP = "Exhibition";
        const string RESULT_MESSAGE = "- {0}; Rarity: {1}; Rating: {2:F2}";

        public static void Main()
        {
            var allPlants = new Dictionary<string, Plant>();
            AddPlants(allPlants);
            ExecuteCommands(allPlants);
        }

        private static void AddPlants(Dictionary<string, Plant> allPlants)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arg = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plantName = arg[0];
                int rariry = int.Parse(arg[1]);

                if (allPlants.ContainsKey(plantName) == false)
                {
                    Plant plant = new Plant(rariry);
                    allPlants.Add(plantName, plant);
                }
                else
                {
                    allPlants[plantName].Rarity = rariry;
                }
            }
        }

        private static void ExecuteCommands(Dictionary<string, Plant> allPlants)
        {
            while (true)
            {
                string[] arg = Console.ReadLine()
                    .Split(new[] { " ", "-" }, StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arg[0] == COMMAND_TOP_STOP;
                if (isStopCommand)
                {
                    PrintResult(allPlants);
                    break;
                }

                string command = arg[0];
                string plant = arg[1];
                bool isPlantExist = allPlants.ContainsKey(plant);
                if (isPlantExist)
                {
                    switch (command)
                    {
                        case "Rate:":
                            double rating = double.Parse(arg[2]);
                            allPlants[plant].Rating.Add(rating);
                            break;
                        case "Update:":
                            int newRariry = int.Parse(arg[2]);
                            allPlants[plant].Rarity = newRariry;
                            break;
                        case "Reset:":
                            allPlants[plant].Rating.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }

        private static void PrintResult(Dictionary<string, Plant> allPlants)
        {
            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in allPlants
                .OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.Rating.Count > 0 ? x.Value.Rating.Average() : 0))
            {
                string plantName = plant.Key;
                int ratity = plant.Value.Rarity;
                double rating = plant.Value.Rating.Count > 0 ? plant.Value.Rating.Average() : 0;

                Console.WriteLine(string.Format(RESULT_MESSAGE, plantName, ratity, rating));
            }
        }
    }

    public class Plant
    {
        public Plant(int rariry, double rating=0)
        {
            this.Rarity = rariry;
            this.Rating = new List<double>();
        }

        public int Rarity { get; set; }

        public List<double> Rating { get; set; }

    }
}
