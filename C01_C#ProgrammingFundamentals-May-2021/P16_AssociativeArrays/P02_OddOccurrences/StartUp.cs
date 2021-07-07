namespace P02_OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts.Add(word, 1);
                }
            }

            counts = counts
                .Where(x => x.Value % 2 == 1)
                .ToDictionary(x => x.Key, x => x.Value);


            Console.WriteLine(string.Join(" ", counts.Keys));

        }
    }
}
