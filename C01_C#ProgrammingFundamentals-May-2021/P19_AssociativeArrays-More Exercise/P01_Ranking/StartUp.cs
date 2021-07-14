namespace P01_Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP_CONTEST_INPUT = "end of contests";
        const string COMMAND_TO_STOP_USERS_INPUT = "end of submissions";

        public static void Main()
        {
            var contestInformation = new Dictionary<string, string>();
            var contestWithUserInformation = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arguments[0] == COMMAND_TO_STOP_CONTEST_INPUT;
                if (isStopCommand)
                {
                    break;
                }

                string contestName = arguments[0];
                string contestPassword = arguments[1];

                if (contestInformation.ContainsKey(contestName) == false)
                {
                    contestInformation.Add(contestName, contestPassword);
                }
            }

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arguments[0] == COMMAND_TO_STOP_USERS_INPUT;
                if (isStopCommand)
                {
                    PrintResult(contestWithUserInformation);
                    break;
                }

                string contestName = arguments[0];
                string contestPassword = arguments[1];
                string username = arguments[2];
                int points = int.Parse(arguments[3]);

                bool isContestExist = contestInformation.ContainsKey(contestName);
                if (isContestExist)
                {
                    bool isPasswordCorrect = contestInformation[contestName].Contains(contestPassword);
                    if (isPasswordCorrect)
                    {
                        if (contestWithUserInformation.ContainsKey(username) == false)
                        {
                            contestWithUserInformation.Add(username, new Dictionary<string, int>());
                        }

                        bool isUserIn = contestWithUserInformation[username].ContainsKey(contestName);
                        if (isUserIn)
                        {
                            if (contestWithUserInformation[username][contestName] < points)
                            {
                                contestWithUserInformation[contestName][username] = points;
                            }
                        }
                        else
                        {
                            contestWithUserInformation[username].Add(contestName, points);
                        }
                    }
                }
            }
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> contestWithUserInformation)
        {
            int max;
            string name;
            PersonWithMostPoints(contestWithUserInformation, out max, out name);

            Console.WriteLine($"Best candidate is {name} with total {max} points.");

            Console.WriteLine("Ranking:");
            foreach (var user in contestWithUserInformation.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var userInformation in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {userInformation.Key} -> {userInformation.Value}");
                }
            }
        }

        private static void PersonWithMostPoints(Dictionary<string, Dictionary<string, int>> contestWithUserInformation, out int max, out string name)
        {
            max = int.MinValue;
            int sum = 0;
            name = string.Empty;
            foreach (var user in contestWithUserInformation)
            {
                foreach (var userInformation in user.Value)
                {
                    sum += userInformation.Value;
                }

                if (sum >= max)
                {
                    max = sum;
                    name = user.Key;
                }

                sum = 0;
            }
        }
    }
}
