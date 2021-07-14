namespace P03_MobaChaallenger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Season end";

        public static void Main()
        {
            var players = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommand = arguments == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintResult(players);
                    break;
                }

                string[] argumentsAfterSplit = arguments
                    .Split(new[] { " ", "->", "vs" }, StringSplitOptions.RemoveEmptyEntries);

                if (argumentsAfterSplit.Length % 2 == 1)
                {
                    string playerName = argumentsAfterSplit[0];
                    string position = argumentsAfterSplit[1];
                    int skill = int.Parse(argumentsAfterSplit[2]);

                    AddPlayer(players, playerName, position, skill);
                }
                else
                {
                    string firstPlayer = argumentsAfterSplit[0];
                    string secondPlayer = argumentsAfterSplit[1];

                    Fight(players, firstPlayer, secondPlayer);
                }
            }
        }

        private static void AddPlayer(Dictionary<string, Dictionary<string, int>> players, string playerName, string postion, int skill)
        {
            bool isPlayerExist = IsPlayerExist(players, playerName);

            if (isPlayerExist == false)
            {
                players.Add(playerName, new Dictionary<string, int>());
                players[playerName].Add(postion, skill);
            }
            else
            {
                bool isThePlayerAlreadyHaveThisPositon = players[playerName].ContainsKey(postion);
                if (isThePlayerAlreadyHaveThisPositon)
                {
                    if (players[playerName][postion] < skill)
                    {
                        players[playerName][postion] = skill;
                    }
                }
                else
                {
                    players[playerName].Add(postion, skill);
                }
            }
        }

        private static void Fight(Dictionary<string, Dictionary<string, int>> players, string firstPlayer, string secondPlayer)
        {
            bool isFirstPlayerExist = IsPlayerExist(players, firstPlayer);
            bool isSecondPlayerExist = IsPlayerExist(players, secondPlayer);
            bool isBreak = false;

            if (isFirstPlayerExist && isSecondPlayerExist)
            {
                foreach (var firstPlayerInformation in players[firstPlayer])
                {
                    foreach (var secondPlayerInformation in players[secondPlayer])
                    {
                        bool doTheyHaveTheSamePostion = firstPlayerInformation.Key == secondPlayerInformation.Key;
                        if (doTheyHaveTheSamePostion)
                        {
                            string position = firstPlayerInformation.Key;
                            FightWinner(players, firstPlayer, secondPlayer, position);
                            isBreak = true;
                            break;
                        }
                    }

                    if (isBreak)
                    {
                        break;
                    }
                }
            }
        }

        private static void FightWinner(Dictionary<string, Dictionary<string, int>> players, string firstPlayer, string secondPlayer, string posiont)
        {
            if (players[firstPlayer][posiont] > players[secondPlayer][posiont])
            {
                players.Remove(secondPlayer);
            }
            else if (players[firstPlayer][posiont] < players[secondPlayer][posiont])
            {
                players.Remove(firstPlayer);
            }
        }

        private static bool IsPlayerExist(Dictionary<string, Dictionary<string, int>> players, string playerName)
        {
            return players.ContainsKey(playerName);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> players)
        {
            var orderedPlayers = players
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key)
                .ToList();

            foreach (var player in orderedPlayers)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var playerValue in player.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {playerValue.Key} <::> {playerValue.Value}");
                }
            }
        }
    }
}
