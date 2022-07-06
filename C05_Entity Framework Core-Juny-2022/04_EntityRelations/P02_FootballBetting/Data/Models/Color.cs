namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }

        public int ColorId { get; set; }

        public string Name { get; set; }

        [InverseProperty("PrimaryKitColor")]
        public ICollection<Team> PrimaryKitTeams { get; set; }

        [InverseProperty("SecondaryKitColor")]
        public ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
