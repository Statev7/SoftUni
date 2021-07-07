namespace P01_CountCharsInAString
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var dictionary = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char[] inputToCharArray = input[i].ToCharArray();

                for (int j = 0; j < inputToCharArray.Length; j++)
                {
                    if (dictionary.ContainsKey(inputToCharArray[j]))
                    {
                        dictionary[inputToCharArray[j]]++;
                    }
                    else
                    {
                        dictionary.Add(inputToCharArray[j], 1);
                    }
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
           
        }
    }
}
