using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string playerClass)
        {
            this.Name = name;
            this.Class = playerClass;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.Append($"Description: {this.Description}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
