namespace P07_ListManipulationAdvanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            bool isListNeedToBePrint = false;

            while (true)
            {
                string[] arguments = Console.ReadLine().Split(" ");
                string command = arguments[0];
                string secondCommand = string.Empty;

                bool isTheStopCommand = command == COMMAND_TO_STOP;
                if (isTheStopCommand)
                {
                    break;
                }

                bool isCalled = CheckIfWeCallSpecificalCommand(command);
                if (isCalled)
                {
                    isListNeedToBePrint = true;
                }

                bool isCommandFilter = command == "Filter";
                if (isCommandFilter)
                {
                    secondCommand = arguments[1];
                }

                ExecuteACommand(list, arguments, command, secondCommand);
            }

            if (isListNeedToBePrint)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static void ExecuteACommand(List<int> list, string[] arguments, string command, string secondCommand)
        {
            bool isValid = secondCommand.Length != 0;
            int digit = 0;
            if (isValid)
            {
                command = secondCommand;
                digit = int.Parse(arguments[2]);
            }

            bool isCommandHaveTwoArgs = CheckCommandsArgCount(command);
            if (isCommandHaveTwoArgs)
            {
                digit = int.Parse(arguments[1]);
            }

            switch (command)
            {
                case "Add": AddToList(list, digit); break;
                case "Remove": RemoveFromList(list, digit); break;
                case "RemoveAt": RemoveAt(list, digit); break;
                case "Insert":
                    int index = int.Parse(arguments[2]);
                    Insert(list, index, digit);
                    break;
                case "Contains":
                    digit = int.Parse(arguments[1]);
                    Contains(list, digit);
                    break;
                case "PrintEven": PrintEven(list); break;
                case "PrintOdd": PrintOdd(list); break;
                case "GetSum": GetSum(list); break;
                case ">": PrintUpperNumbers(list, digit); break;
                case ">=": PrintUpperOrEqualNumbers (list, digit); break;
                case "<": PrintLowerNumbers (list, digit); break;
                case "<=": PrintLowerOrEqualNumbers(list, digit); break;
            }
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

        private static void Contains(List<int> list, int digit)
        {
            string result = "No such number";
            bool isValid = list.Contains(digit);

            if (isValid)
            {
                result = "Yes";
            }

            Console.WriteLine(result);
        }

        private static void PrintEven(List<int> list)
        {
            List<int> evenNumbers = list
                .Where(x => x % 2 == 0)
                .ToList();

            Console.WriteLine(string.Join(" ", evenNumbers));
        }

        private static void PrintOdd(List<int> list)
        {
            List<int> oddNumbers = list
                .Where(x => x % 2 == 1)
                .ToList();

            Console.WriteLine(string.Join(" ", oddNumbers));
        }

        private static void GetSum(List<int> list)
        {
            int sum = list.Sum();

            Console.WriteLine(sum);
        }

        private static void PrintUpperNumbers(List<int> list, int digit)
        {
            List<int> upperNumbers = list
                .Where(x => x > digit)
                .ToList();

            Console.WriteLine(string.Join(" ", upperNumbers));

        }
        private static void PrintUpperOrEqualNumbers(List<int> list, int digit)
        {
            List<int> upperOrEqualNumbers = list
                .Where(x => x >= digit)
                .ToList();

            Console.WriteLine(string.Join(" ", upperOrEqualNumbers));
        }

        private static void PrintLowerNumbers(List<int> list, int digit)
        {
            List<int> lowerNumbers = list
                .Where(x => x < digit)
                .ToList();

            Console.WriteLine(string.Join(" ", lowerNumbers));
        }

        private static void PrintLowerOrEqualNumbers(List<int> list, int digit)
        {
            List<int> lowerOrEuqalNumbers = list
                .Where(x => x <= digit)
                .ToList();

            Console.WriteLine(string.Join(" ", lowerOrEuqalNumbers));
        }

        private static bool CheckIfWeCallSpecificalCommand(string command)
        {
            bool isCalled = command == "Add" ||
                            command == "Remove" ||
                            command == "RemoveAt" ||
                            command == "Insert";

            return isCalled;
        }

        private static bool CheckCommandsArgCount(string command)
        {
            bool isValid = command == "Add" ||
                           command == "Remove" ||
                           command == "RemoveAt" ||
                           command == "Insert";

            return isValid;
        }
    }
}
