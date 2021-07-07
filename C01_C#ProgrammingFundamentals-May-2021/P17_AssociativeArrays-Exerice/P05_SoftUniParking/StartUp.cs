namespace P05_SoftUniParking
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string SUCCESSFULLY_REGISTERED_A_USER = "{0} registered {1} successfully";
        const string SUCCESSFULLY_UNREGISTERD_A_USER = "{0} unregistered successfully";
        const string USER_ALREADY_REGISTRED_ERROR_MESSAGE = "ERROR: already registered with plate number {0}";
        const string CANNOT_UNREGISTER_INVALID_USER_ERROR_MESSAGE = "ERROR: user {0} not found";

        public static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());
            var parkingCard = new Dictionary<string, string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = arguments[0];
                string username = arguments[1];

                switch (command)
                {
                    case "register":
                        string license = arguments[2];
                        Register(parkingCard, username, license); 
                        break;
                    case "unregister": Unregister(parkingCard, username); break;
                }
            }

            Print(parkingCard);
        }

        private static void Register(Dictionary<string, string> parkingCard, string username, string liicenseNumber)
        {
            bool isAlreadyRegistered = CheckIfUserExist(parkingCard, username);

            if (isAlreadyRegistered)
            {
                Console.WriteLine(string.Format(USER_ALREADY_REGISTRED_ERROR_MESSAGE, liicenseNumber));
            }
            else
            {
                parkingCard.Add(username, liicenseNumber);
                Console.WriteLine(string.Format(SUCCESSFULLY_REGISTERED_A_USER, username, liicenseNumber));
            }
        }

        private static void Unregister(Dictionary<string, string> parkingCard, string username)
        {
            bool isValid = CheckIfUserExist(parkingCard, username);

            if (isValid)
            {
                parkingCard.Remove(username);
                Console.WriteLine(string.Format(SUCCESSFULLY_UNREGISTERD_A_USER, username));
            }
            else
            {
                Console.WriteLine(string.Format(CANNOT_UNREGISTER_INVALID_USER_ERROR_MESSAGE, username));
            }
        }

        private static bool CheckIfUserExist(Dictionary<string, string> parkingCard, string username)
        {
            bool isExist = parkingCard.ContainsKey(username);
            return isExist;
        }

        private static void Print(Dictionary<string, string> allPeoples)
        {
            foreach (var person in allPeoples)
            {
                Console.WriteLine($"{person.Key} => {person.Value}");
            }
        }
    }
}
