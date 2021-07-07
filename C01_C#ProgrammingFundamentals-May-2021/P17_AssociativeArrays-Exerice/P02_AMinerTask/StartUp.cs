namespace P02_AMinerTask
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "stop";

        public static void Main()
        {
            var dictionary = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();

                bool isStopCommand = resource == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    Print(dictionary);
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                AddToDictionary(dictionary, resource, quantity);
            }

        }

        private static void AddToDictionary(Dictionary<string, int> dictionary, string resource, int quantity)
        {
            if (dictionary.ContainsKey(resource))
            {
                dictionary[resource] += quantity;
            }
            else
            {
                dictionary.Add(resource, quantity);
            }
        }

        private static void Print(Dictionary<string, int> dictionary)
        {
            foreach (var resource in dictionary)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
