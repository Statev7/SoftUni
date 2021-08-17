namespace P05_CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var dictionary = new Dictionary<char, int>();
            string input = Console.ReadLine();

            for (int index = 0; index < input.Length; index++)
            {
                bool isCharExist = dictionary.ContainsKey(input[index]);
                if (isCharExist == false)
                {
                    dictionary.Add(input[index], 0);
                }
                dictionary[input[index]]++;
            }

            foreach (var symbol in dictionary
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
