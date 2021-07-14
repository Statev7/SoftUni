namespace P02_Judge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "no more time";

        public static void Main()
        {
            var contestInformation = new Dictionary<string, Dictionary<string, int>>();
            var usersInformation = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommand = arguments == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    Print(contestInformation, usersInformation);
                    break;
                }

                string[] splitedArguments = arguments
                    .Split(new[] { " ", "->" }, StringSplitOptions.RemoveEmptyEntries);

                string username = splitedArguments[0];
                string contest = splitedArguments[1];
                int points = int.Parse(splitedArguments[2]);
                AddContest(contestInformation, username, contest, points);
                AddUsers(usersInformation, username, contest, points);
            }
        }

        private static void AddContest(Dictionary<string, Dictionary<string, int>> contestInformation, string username, string contest, int points)
        {
            if (contestInformation.ContainsKey(contest) == false)
            {
                contestInformation.Add(contest, new Dictionary<string, int>());
                contestInformation[contest].Add(username, points);
            }
            else
            {
                bool isUserIn = contestInformation[contest].ContainsKey(username);
                if (isUserIn)
                {
                    if (contestInformation[contest][username] < points)
                    {
                        contestInformation[contest][username] = points;
                    }
                }
                else
                {
                    contestInformation[contest].Add(username, points);
                }
            }
        }

        private static void AddUsers(Dictionary<string, Dictionary<string, int>> usersInformation, string username, string contest, int points)
        {
            if (usersInformation.ContainsKey(username) == false)
            {
                usersInformation.Add(username, new Dictionary<string, int>());
                usersInformation[username].Add(contest, points);
            }
            else
            {
                bool isAlreadyInContest = usersInformation[username].ContainsKey(contest);
                if (isAlreadyInContest)
                {
                    if (usersInformation[username][contest] < points)
                    {
                        usersInformation[username][contest] = points;
                    }
                }
                else
                {
                    usersInformation[username].Add(contest, points);
                }
            }
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> contestInformation, Dictionary<string, Dictionary<string, int>> usersInformation)
        {
            int i = 1;

            foreach (var contest in contestInformation)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{i++}. {user.Key} <::> {user.Value}");
                }

                i = 1;
            }

            Console.WriteLine("Individual standings:");

            var sortedUsers = usersInformation
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key);

            foreach (var users in sortedUsers)
            {
                Console.WriteLine($"{i++}. {users.Key} -> {users.Value.Values.Sum()}");
            }
        }
    }
}
