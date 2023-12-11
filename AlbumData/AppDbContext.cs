using Lab3___zadanieContextConnection.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lab3___zadanieContextConnection
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
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
            base.OnModelCreating(modelBuilder);
            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");

            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });

            string USER_ID = Guid.NewGuid().ToString();
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@example.com",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER"
            };

            PasswordHasher<IdentityUser> ph1 = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph1.HashPassword(user, "user123");

            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });







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
