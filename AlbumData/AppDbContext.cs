using AlbumData.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AlbumData
{
    public class AppDbContext : DbContext
    {
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<SongEntity> Songs { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "albums.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumEntity>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId);

            modelBuilder.Entity<AlbumEntity>().HasData(
                new { AlbumId = 1, Title = "Eclipse", Band = "Lunar Echoes", ReleaseYear = 2023, Duration = TimeSpan.FromMinutes(45), ChartPosition = "Top 10", Genre = "Rock" },
                new { AlbumId = 2, Title = "Night Sky", Band = "Star Harmony", ReleaseYear = 2022, Duration = TimeSpan.FromMinutes(50), ChartPosition = "Top 20", Genre = "Pop" }
            );


            modelBuilder.Entity<SongEntity>().HasData(
                new { Id = 1, Title = "Moonlight Sonata", Duration = TimeSpan.FromMinutes(4), AlbumId = 1, TrackNumber = 1 },
                new { Id = 2, Title = "Starry Night", Duration = TimeSpan.FromMinutes(3), AlbumId = 2, TrackNumber = 1 }
            );


        }
    }
}
