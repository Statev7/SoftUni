namespace MusicHub.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MusicHub.Data.Models;

    public class SongPerformerTypeConfiguration : IEntityTypeConfiguration<SongPerformer>
    {
        public void Configure(EntityTypeBuilder<SongPerformer> builder)
        {
            builder
                .HasOne(sp => sp.Performer)
                .WithMany(p => p.PerformerSongs)
                .HasForeignKey(sp => sp.PerformerId);

            builder
                .HasOne(sp => sp.Song)
                .WithMany(s => s.SongPerformers)
                .HasForeignKey(sp => sp.SongId);
        }
    }
}
