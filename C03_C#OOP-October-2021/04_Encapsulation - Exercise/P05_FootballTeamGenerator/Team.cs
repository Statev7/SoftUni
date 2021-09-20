namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private const string NAME_ERROR_MESSAGE = "A name should not be empty.";
        private const string PLAYER_ERROR_MESSAGE = "Player {0} is not in {1} team.";

        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                bool isInvalid = string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
                if (isInvalid)
                {
                    throw new ArgumentException(NAME_ERROR_MESSAGE);
                }
                this.name = value;
            }
        }

        public double Rating => CalculateRatiing();

        public int NumbersOfPlayers => this.players.Count;

        public void Add(Player player)
        {
            this.players.Add(player);
        }

        public void Remove(string playerName)
        {
            var playerToRemove = this.players
                .Where(x => x.Name == playerName)
                .SingleOrDefault();

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(PLAYER_ERROR_MESSAGE, playerName, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        private double CalculateRatiing()
        {
            if (this.players.Any())
            {
                return (int)Math.Round(this.players.Average(p => p.Rating));
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
