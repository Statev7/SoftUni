namespace MusicHub.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;

    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {

        }

        public MusicHubDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<SongPerformer> SongPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseSqlServer("Server=.;Database=MusicHub;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<SongPerformer>()
                .HasKey(sp => new { sp.SongId, sp.PerformerId });

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
