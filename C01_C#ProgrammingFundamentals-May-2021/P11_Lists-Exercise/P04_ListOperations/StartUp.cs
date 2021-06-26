namespace P04_ListOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "End";
        const string INVALID_INDEX_ERROR_MESSAGE = "Invalid index";

        public static void Main()
        {
            List<int> inputList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            ReadCommands(inputList);
            PrintResult(inputList);
        }

        private static void ReadCommands(List<int> inputList)
        {
            while (true)
            {
                string[] arguments = Console.ReadLine().Split(" ");
                string command = arguments[0];

                bool isStopCommand = command == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                command = IsShiftCommand(arguments, command);
                ExecuteCommand(inputList, arguments, command);
            }
        }

        private static void ExecuteCommand(List<int> list, string[] arguments, string command)
        {
            int number = 0;
            int index = 0;
            int count = 0;

            switch (command)
            {
                case "Add":
                    number = int.Parse(arguments[1]);
                    AddNumberToList(list, number);
                    break;
                case "Insert":
                    number = int.Parse(arguments[1]);
                    index = int.Parse(arguments[2]);
                    InsertNumberToList(list, number, index);
                    break;
                case "Remove":
                    index = int.Parse(arguments[1]);
                    RemoveIndexFromList(list, index);
                    break;
                case "left":
                    count = int.Parse(arguments[2]);
                    ShiftLeft(list, count);
                    break;
                case "right":
                    count = int.Parse(arguments[2]);
                    ShiftRight(list, count);
                    break;
            }
        }

        private static void AddNumberToList(List<int> list, int numberToAdd)
        {
            list.Add(numberToAdd);
        }

        private static void InsertNumberToList(List<int> list, int number, int index)
        {
            bool isValid = CheckIfSuchAnIndexExists(list, index);
            if (isValid)
            {
                list.Insert(index, number);
            }
            else
            {
                Console.WriteLine(INVALID_INDEX_ERROR_MESSAGE);
            }
        }

        private static void RemoveIndexFromList(List<int> list, int indexToRemove)
        {
            bool isValid = CheckIfSuchAnIndexExists(list, indexToRemove);
            if (isValid)
            {
                list.RemoveAt(indexToRemove);
            }
            else
            {
                Console.WriteLine(INVALID_INDEX_ERROR_MESSAGE);
            }
        }

        private static void ShiftLeft(List<int> list, int count)
        {
            for (int index = 0; index < count; index++)
            {
                list.Add(list[0]);
                list.Remove(list[0]);
            }
        }

        private static void ShiftRight(List<int> list, int count)
        {
            for (int index = 0; index < count; index++)
            {
                int temp = list[list.Count - 1];
                list.Insert(0, temp);
                list.RemoveAt(list.Count - 1);
            }
        }

        private static string IsShiftCommand(string[] arguments, string command)
        {
            bool isShiftCommand = command == "Shift";
            if (isShiftCommand)
            {
                command = arguments[1];
            }

            return command;
        }

        private static bool CheckIfSuchAnIndexExists(List<int> list, int index)
        {
            bool isValid = list.Count - 1 >= index && index >= 0;

            return isValid;
        }

        private static void PrintResult(List<int> list)
        {
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
