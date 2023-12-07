using AlbumData.Entities;
using Microsoft.EntityFrameworkCore;

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
                new AlbumEntity { AlbumId = 1, Title = "Thriller", Band = "Michael Jackson", Genre = "Pop", ChartPosition = "2", Duration = 122, ReleaseYear = 1982 },
                new AlbumEntity { AlbumId = 2, Title = "Back in Black", Band = "AC/DC", Genre = "Rock", ChartPosition = "3", Duration = 132, ReleaseYear = 1980 }
            );

            modelBuilder.Entity<SongEntity>().HasData(
                new SongEntity { Id = 1, Title = "Beat It", Duration = 258, AlbumId = 1, TrackNumber = 1 },
                new SongEntity { Id = 2, Title = "Billie Jean", Duration = 294, AlbumId = 1, TrackNumber = 2 },
                new SongEntity { Id = 3, Title = "Hells Bells", Duration = 312, AlbumId = 2, TrackNumber = 1 },
                new SongEntity { Id = 4, Title = "Back in Black", Duration = 255, AlbumId = 2, TrackNumber = 2 }
            );
        }
    }
}
