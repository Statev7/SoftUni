namespace P02_ChangeList
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

            while (true)
            {
                string[] arguments = Console.ReadLine().Split(" ");
                string command = arguments[0];

                bool isStopCommand = command == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                int number = int.Parse(arguments[1]);

                switch (command)
                {
                    case "Delete": RemoveDigitFromList(list, number); break;
                    case "Insert":
                        int index = int.Parse(arguments[2]);
                        InsertDigitByIndexToList(list, number, index);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static void RemoveDigitFromList(List<int> list, int number)
        {
            for (int index = 0; index < list.Count; index++)
            {
                if (list[index] == number)
                {
                    list.Remove(number);
                }
            }
        }

        private static void InsertDigitByIndexToList(List<int> list, int number, int index)
        {
            list.Insert(index, number);
        }
    }
}
