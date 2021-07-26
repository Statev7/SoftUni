namespace P04_WorldTour
{
    using System;

    public class StartUp
    {
        const string COMMAND_TO_STOP_TRAVEL = "Travel";
        const string RESULT_MESSAGE = "Ready for world tour! Planned stops: {0}";

        public static void Main()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arguments[0] == COMMAND_TO_STOP_TRAVEL;
                if (isStopCommand)
                {
                    PrintResult(input);
                    break;
                }

                string command = arguments[0];
                input = ExecuteCommands(input, arguments, command);
            }
        }

        private static string ExecuteCommands(string input, string[] arguments, string command)
        {
            switch (command)
            {
                case "Add Stop":
                    int index = int.Parse(arguments[1]);
                    string place = arguments[2];
                    input = Add(input, index, place);
                    break;
                case "Remove Stop":
                    int startIndex = int.Parse(arguments[1]);
                    int endIndex = int.Parse(arguments[2]);
                    input = Remove(input, startIndex, endIndex);
                    break;
                case "Switch":
                    string oldPlace = arguments[1];
                    string newPlace = arguments[2];
                    input = Switch(input, oldPlace, newPlace);
                    break;
            }

            return input;
        }

        private static string Add(string input, int index, string place)
        {
            bool isValid = IsIndexValid(input, index);
            if (isValid)
            {
                input = input.Insert(index, place);
            }
            PrintDistanationAfterOperation(input);

            return input;
        }

        private static string Remove(string input, int startIndex, int endIndex)
        {
            bool isStartIndexValid = IsIndexValid(input, startIndex);
            bool isEndIndexValid = IsIndexValid(input, endIndex);

            if (isStartIndexValid && isEndIndexValid)
            {
                int count = endIndex - startIndex;

                input = input.Remove(startIndex, count + 1);
            }
            PrintDistanationAfterOperation(input);

            return input;
        }

        private static string Switch(string input, string oldPlace, string newPlace)
        {
            input = input.Replace(oldPlace, newPlace);
            PrintDistanationAfterOperation(input);

            return input;
        }

        private static bool IsIndexValid(string input, int index)
        {
            bool isValid = input.Length > index && index >= 0;

            return isValid;
        }

        private static void PrintDistanationAfterOperation(string message)
        {
            Console.WriteLine(message);
        }

        private static void PrintResult(string result)
        {
            Console.WriteLine(string.Format(RESULT_MESSAGE, result));
        }
    }
}
