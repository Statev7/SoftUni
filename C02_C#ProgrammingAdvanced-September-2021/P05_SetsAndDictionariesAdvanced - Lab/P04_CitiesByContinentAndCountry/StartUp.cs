namespace P04_CitiesByContinentAndCountry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var continets = new Dictionary<string, Dictionary<string, List<string>>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string countryName = input[1];
                string city = input[2];

                if (!continets.ContainsKey(continent))
                {
                    continets.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continets[continent].ContainsKey(countryName))
                {
                    continets[continent].Add(countryName, new List<string>());
                }

                continets[continent][countryName].Add(city);
            }

            foreach (var continet in continets)
            {
                Console.WriteLine($"{continet.Key}:");
                foreach (var country in continet.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }

}
