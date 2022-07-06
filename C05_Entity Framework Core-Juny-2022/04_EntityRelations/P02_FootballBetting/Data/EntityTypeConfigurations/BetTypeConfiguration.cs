namespace P03_FootballBetting.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class BetTypeConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder
                 .HasOne(b => b.User)
                 .WithMany(u => u.Bets)
                 .HasForeignKey(b => b.UserId);

            builder
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
        }
    }
}
