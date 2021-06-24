namespace P06_ListManipulationBasics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            List<int> input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isTheStopCommand = arguments == COMMAND_TO_STOP;
                if (isTheStopCommand)
                {
                    break;
                }

                string[] argumentsToArray = arguments.Split(" ");
                string command = argumentsToArray[0];
                int digit = int.Parse(argumentsToArray[1]);

                switch (command)
                {
                    case "Add": AddToList(input, digit); break;
                    case "Remove": RemoveFromList(input, digit); break;
                    case "RemoveAt": RemoveAt(input, digit); break;
                    case "Insert":
                        int index = int.Parse(argumentsToArray[2]);
                        Insert(input, index, digit);
                        break;
                }
            }

            PrintResult(input);
        }

        private static void AddToList(List<int> input, int digitToAdd)
        {
            input.Add(digitToAdd);
        }

        private static void RemoveFromList(List<int> input, int digitToRemove)
        {
            input.Remove(digitToRemove);
        }

        private static void RemoveAt(List<int> input, int index)
        {
            input.RemoveAt(index);
        }

        private static void Insert(List<int> input, int index, int digitToInser)
        {
            input.Insert(index, digitToInser);
        }

        private static void PrintResult(List<int> input)
        {
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
