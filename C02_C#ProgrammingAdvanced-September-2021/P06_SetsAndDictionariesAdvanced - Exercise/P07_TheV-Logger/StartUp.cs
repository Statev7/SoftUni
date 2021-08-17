namespace P07_TheV_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Statistics";
        const string FOLLOW_COMMAND = "followed";

        public static void Main()
        {
            var allVlogers = new Dictionary<string, Vloger>();

            string input = Console.ReadLine();
            while (input != COMMAND_TO_STOP)
            {
                var arg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isFollowedCommand = input.Contains(FOLLOW_COMMAND);

                if (isFollowedCommand)
                {
                    string firstVlogger = arg[0];
                    string secondVlogger = arg[2];

                    bool isVlogersExist = allVlogers.ContainsKey(firstVlogger) && allVlogers.ContainsKey(secondVlogger);
                    if (isVlogersExist)
                    {
                        bool isFirstVlogerAlredyFollowSecond = allVlogers[firstVlogger].Following.Contains(secondVlogger);
                        bool isFirstVlogerTryToFollowHimself = firstVlogger == secondVlogger;

                        if (isFirstVlogerAlredyFollowSecond == false && isFirstVlogerTryToFollowHimself == false)
                        {
                            allVlogers[firstVlogger].Following.Add(secondVlogger);
                            allVlogers[secondVlogger].Followers.Add(firstVlogger);
                        }
                    }
                }
                else
                {
                    string vlogerName = arg[0];
                    bool isVlogerAlreadyExist = allVlogers.ContainsKey(vlogerName);
                    if (isVlogerAlreadyExist == false)
                    {
                        Vloger vloger = new Vloger();
                        allVlogers.Add(vlogerName, vloger);
                    }
                }

                input = Console.ReadLine();
            }

            PrintResult(allVlogers);
        }

        private static void PrintResult(Dictionary<string, Vloger> allVlogers)
        {
            int index = 1;

            Console.WriteLine($"The V-Logger has a total of {allVlogers.Count} vloggers in its logs.");
            foreach (var bestVloger in allVlogers
                .OrderByDescending(x => x.Value.Followers.Count())
                .ThenBy(x => x.Value.Following.Count())
                .Take(1))
            {
                string vlogerName = bestVloger.Key;
                int followersCount = bestVloger.Value.Followers.Count();
                int followingCount = bestVloger.Value.Following.Count();

                Console.WriteLine($"{index++}. {vlogerName} : {followersCount} followers, {followingCount} following");
                foreach (var follower in bestVloger.Value.Followers
                    .OrderBy(x => x))
                {
                    Console.WriteLine($"*  {follower}");
                }

                allVlogers.Remove(bestVloger.Key);
            }

            foreach (var vloger in allVlogers
                .OrderByDescending(x => x.Value.Followers.Count())
                .ThenBy(x => x.Value.Following.Count()))
            {
                string vlogerName = vloger.Key;
                int followersCount = vloger.Value.Followers.Count();
                int followingCount = vloger.Value.Following.Count();

                Console.WriteLine($"{index++}. {vlogerName} : {followersCount} followers, {followingCount} following");
            }
        }
    }

    public class Vloger
    {
        public Vloger()
        {
            Followers = new List<string>();
            Following = new List<string>();
        }

        public List<string> Followers { get; set; }

        public List<string> Following { get; set; }
    }
}
