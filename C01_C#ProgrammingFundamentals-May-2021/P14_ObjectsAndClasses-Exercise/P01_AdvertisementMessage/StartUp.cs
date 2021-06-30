namespace P01_AdvertisementMessage
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<string> phrases = new List<string>
            { 
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." 
            };

            List<string> events = new List<string>
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            List<string> authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            int n = int.Parse(Console.ReadLine());
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                string result = string.Empty;
                int index = 0;

                index = random.Next(phrases.Count - 1);
                result += phrases[index];
                index = random.Next(events.Count - 1);
                result += " " + events[index];
                index = random.Next(authors.Count - 1);
                result += " " + authors[index];
                index = random.Next(cities.Count - 1);
                result += " " + $"- {cities[index]}";

                Console.WriteLine(result);
            }
        }
    }
}
