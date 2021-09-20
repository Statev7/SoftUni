namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string TEAM_ERROR_MESSAGE = "Team {0} does not exist.";
        private const string COMMAND_TO_END_READ_ARGUMENTS = "END";

        private readonly List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            var arguments = Console.ReadLine();

            while (arguments != COMMAND_TO_END_READ_ARGUMENTS)
            {
                var splitedArg = arguments.Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    this.ExecuteCommands(splitedArg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                arguments = Console.ReadLine();
            }

        }

        private void ExecuteCommands(string[] splitedArg)
        {
            var command = splitedArg[0];

            if (command == "Team")
            {
                var team = new Team(splitedArg[1]);
                teams.Add(team);
            }
            else if (command == "Add")
            {
                this.AddPlayer(splitedArg);
            }
            else if (command == "Remove")
            {
                this.RemovePlayer(splitedArg);
            }
            else if (command == "Rating")
            {
                this.Rating(splitedArg);
            }
        }

        private void AddPlayer(string[] arguments)
        {
            var teamName = arguments[1];
            var team = this.teams.Where(x => x.Name == teamName).SingleOrDefault();
            if (team == null)
            {
                throw new ArgumentException(string.Format(TEAM_ERROR_MESSAGE, teamName));
            }

            var playerName = arguments[2];
            var endurance = double.Parse(arguments[3]);
            var sprint = double.Parse(arguments[4]);
            var dribble = double.Parse(arguments[5]);
            var passing = double.Parse(arguments[6]);
            var shooting = double.Parse(arguments[7]);

            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            team.Add(player);
        }

        private void RemovePlayer(string[] arguments)
        {
            var team = this.teams.Where(x => x.Name == arguments[1]).SingleOrDefault();
            var playerToRemove = arguments[2];

            team.Remove(playerToRemove);
        }

        private void Rating(string[] arguments)
        {
            var teamName = arguments[1];
            var team = this.teams.Where(x => x.Name == teamName).SingleOrDefault();
            if (team == null)
            {
                throw new ArgumentException(string.Format(TEAM_ERROR_MESSAGE, teamName));
            }

            Console.WriteLine(team);
        }
    }
}
