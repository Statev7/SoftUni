namespace P03_HouseParty
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string PERSON_NOT_IN_THE_LIST_MESSAGE = "{0} is not in the list!";
        const string PERSON_IS_ALREADY_IN_THE_LIST_MESSAGE = "{0} is already in the list!";

        public static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] arguments = Console.ReadLine().Split(" ");

                string personName = arguments[0];
                string command = arguments[1] + " " + arguments[2];
                ExecuteCommand(personName, command, list);
            }

            PrintResult(list);
        }

        private static void ExecuteCommand(string personName, string command, List<string> list)
        {
            switch (command)
            {
                case "is going!": AddPerson(personName, list); break;
                case "is not": RemovePerson(personName, list); break;
            }
        }

        private static void AddPerson(string personName, List<string> list)
        {
            bool isAlreadyInList = CheckIfThePersonIsAlreadyOnTheList(personName, list);

            if (!isAlreadyInList)
            {
                list.Add(personName);
            }
        }

        private static void RemovePerson(string personName, List<string> list)
        {
            bool isPersonInTheList = CheckToSeeIfThereIsSuchAPersonInTheList(personName, list);

            if (isPersonInTheList)
            {
                list.Remove(personName);
            }
        }

        private static bool CheckIfThePersonIsAlreadyOnTheList(string personName, List<string> list)
        {
            bool isAlreadyInList = list.Contains(personName);

            if (isAlreadyInList)
            {
                string message = string.Empty;
                message = string.Format(PERSON_IS_ALREADY_IN_THE_LIST_MESSAGE, personName);
                Console.WriteLine(message);
            }

            return isAlreadyInList;
        }

        private static bool CheckToSeeIfThereIsSuchAPersonInTheList(string personName, List<string> list)
        {
            bool isPersonInTheList = list.Contains(personName);

            if (!isPersonInTheList)
            {
                string message = string.Empty;
                message = string.Format(PERSON_NOT_IN_THE_LIST_MESSAGE, personName);
                Console.WriteLine(message);
            }

            return isPersonInTheList;
        }

        private static void PrintResult(List<string> list)
        {
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
