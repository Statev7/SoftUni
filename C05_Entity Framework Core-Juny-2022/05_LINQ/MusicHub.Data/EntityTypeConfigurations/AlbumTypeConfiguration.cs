namespace MusicHub.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MusicHub.Data.Models;

    public class AlbumTypeConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .HasOne(a => a.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(a => a.ProducerId);
        }
    }
}
