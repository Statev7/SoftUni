namespace P09_ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Lumpawaroo";
        const string JOIN_A_TEAM_MESSAGE = "{0} joins the {1} side!";

        public static void Main()
        {
            var book = new Dictionary<string, List<string>>();

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommand = arguments == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    Print(book);
                    break;
                }

                string[] argumentSplitByLine = arguments
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string[] argumentSplitByArrow = arguments
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                if (argumentSplitByLine.Length % 2 == 0)
                {
                    string forceSize = argumentSplitByLine[0].Trim();
                    string forceUser = argumentSplitByLine[1].Trim();
                    AddToSide(book, forceSize, forceUser);
                }
                else
                {
                    string forceUser = argumentSplitByArrow[0].Trim();
                    string forceSize = argumentSplitByArrow[1].Trim();
                    JoinASide(book, forceUser, forceSize);
                }
            }
        }

        private static void AddToSide(Dictionary<string, List<string>> book, string forceSize, string forceUser)
        {
            if (!book.ContainsKey(forceSize))
            {
                book.Add(forceSize, new List<string>() { forceUser });
            }
            else
            {
                bool isUserAlreadyIn = book[forceSize].Contains(forceUser);

                if (isUserAlreadyIn == false)
                {
                    book[forceSize].Add(forceUser);
                }
            }
        }

        private static void JoinASide(Dictionary<string, List<string>> book, string forceUser, string forceSide)
        {
            bool isSideExist = book.ContainsKey(forceSide);
            if (isSideExist)
            {
                bool isTheUserInAnotherTeam = CheckIfIserInAnotherTeam(book, forceUser);
                if (isTheUserInAnotherTeam)
                {
                    RemoveAUser(book, forceUser);
                }

                book[forceSide].Add(forceUser);
                Console.WriteLine(string.Format(JOIN_A_TEAM_MESSAGE, forceUser, forceSide));
            }
        }

        private static bool CheckIfIserInAnotherTeam(Dictionary<string, List<string>> books, string findUser)
        {
            bool isTheUserInAnotherTeam = false;
            bool isBreak = false;

            foreach (var users in books)
            {
                foreach (var user in users.Value)
                {
                    if (user == findUser)
                    {
                        isTheUserInAnotherTeam = true;
                        isBreak = true;
                        break;
                    }
                }

                if (isBreak)
                {
                    break;
                }
            }

            return isTheUserInAnotherTeam;
        }

        private static void RemoveAUser(Dictionary<string, List<string>> books, string userToRemove)
        {
            foreach (var users in books)
            {
                users.Value.Remove(userToRemove);
            }
        }

        private static void Print(Dictionary<string, List<string>> book)
        {
            var orderedBook = book
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in orderedBook)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
