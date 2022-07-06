namespace P03_FootballBetting.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    internal class PlayerTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            builder
                .HasOne(p => p.Position)
                .WithMany(po => po.Players)
                .HasForeignKey(p => p.PositionId);
        }
    }
}
