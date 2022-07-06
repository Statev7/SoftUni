namespace P03_FootballBetting.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class TeamTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasOne(t => t.Town)
                .WithMany(to => to.Teams)
                .HasForeignKey(t => t.TownId);
        }
    }
}
