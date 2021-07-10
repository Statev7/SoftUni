namespace Problem_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Done";
        const string CRAFT_MESSAGE = "You crafted {0}!";

        public static void Main()
        {
            List<string> weapons = Console.ReadLine()
                .Split("|").ToList();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arguments[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintResult(weapons);
                    break;
                }

                string command = arguments[0];
                command = IsCheckCommand(arguments, command);
                int index = 0;

                switch (command)
                {
                    case "Add":
                        string particle = arguments[1];
                        index = int.Parse(arguments[2]);
                        Add(weapons, particle, index);
                        break;
                    case "Remove":
                        index = int.Parse(arguments[1]);
                        Remove(weapons, index);
                        break;
                    case "Even": PrintEven(weapons); break;
                    case "Odd": PrintOdd(weapons); break;
                }
            }
        }

        private static void Add(List<string> weapons, string particle, int index)
        {
            bool isIndexValid = IsIndexValid(weapons, index);

            if (isIndexValid)
            {
                weapons.Insert(index, particle);
            }
        }

        private static void Remove(List<string> weapons, int index)
        {
            bool isIndexValid = IsIndexValid(weapons, index);

            if (isIndexValid)
            {
                weapons.RemoveAt(index);
            }
        }

        private static void PrintEven(List<string> weapons)
        {
            for (int index = 0; index < weapons.Count; index++)
            {
                bool isValid = index % 2 == 0;
                if (isValid)
                {
                    Console.Write(weapons[index] + " ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintOdd(List<string> weapons)
        {
            for (int index = 0; index < weapons.Count; index++)
            {
                bool isValid = index % 2 == 1;
                if (isValid)
                {
                    Console.Write(weapons[index] + " ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintResult(List<string> weapons)
        {
            string result = string.Empty;

            for (int index = 0; index < weapons.Count; index++)
            {
                result += weapons[index];
            }

            string message = string.Format(CRAFT_MESSAGE, result);
            Console.WriteLine(message);
        }

        private static string IsCheckCommand(string[] arguments, string command)
        {
            if (command == "Check")
            {
                command = arguments[1];
            }

            return command;
        }

        private static bool IsIndexValid(List<string> weapons, int index)
        {
            bool isValid = weapons.Count > index && index >= 0;

            return isValid;
        }
    }
}
