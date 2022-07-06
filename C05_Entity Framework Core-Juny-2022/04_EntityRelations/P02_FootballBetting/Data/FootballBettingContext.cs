namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Bet> Bets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
