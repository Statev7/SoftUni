namespace MusicHub.Data.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MusicHub.Data.Models;

    public class SongTypeConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);

            builder
                .HasOne(s => s.Writer)
                .WithMany(w => w.Songs)
                .HasForeignKey(s => s.WriterId);
        }
    }
}
