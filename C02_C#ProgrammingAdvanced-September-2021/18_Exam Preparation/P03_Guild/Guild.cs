namespace Guild
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Guild
    {
        private HashSet<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new HashSet<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => this.roster.Count; }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var person = this.roster
                .Where(x => x.Name == name)
                .SingleOrDefault();

            if (person != null)
            {
                this.roster.Remove(person);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var person = this.roster
                .Where(x => x.Name == name)
                .SingleOrDefault();

            person.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            var person = this.roster
                .Where(x => x.Name == name)
                .SingleOrDefault();

            person.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            var removedPlayers = this.roster
                .Where(x => x.Class == playerClass)
                .ToArray();

            this.roster.RemoveWhere(x => x.Class == playerClass);

            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine($"{player}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
