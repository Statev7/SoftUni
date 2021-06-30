namespace P05_TeamworkProjects.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Team
    {
        public Team(string teamName, string teamLeaderName)
        {
            this.TeamName = teamName;
            this.TeamLeaderName = teamLeaderName;
            Members = new List<string>();
        }

        public string TeamName { get; private set; }

        public string TeamLeaderName { get; private set; }

        public List<string> Members { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.TeamName}");
            str.AppendLine($"- {this.TeamLeaderName}");
            foreach (var member in Members.OrderBy(x => x))
            {
                str.AppendLine($"-- {member}");
            }

            return str.ToString();
        }
    }
}
