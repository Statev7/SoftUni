namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;

    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
