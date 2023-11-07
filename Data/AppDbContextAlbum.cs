using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContextAlbum : DbContext
    {
        public DbSet<AlbumEntity> Album { get; set; }
        private string DbPath { get; set; }
        public AppDbContextAlbum()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "album.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumEntity>().HasData(
                new AlbumEntity() { Id = 1, Nazwa = "Adam", Zespol = "Enej", SpisPiosenek = "127813268163", Notowanie = 1, DataWydania = new DateTime(2000, 10, 10), CzasTrwania = 1  },
                new AlbumEntity() { Id = 2, Nazwa = "Ewa", Zespol = "ewa@wsei.edu.pl", SpisPiosenek = "293443823478", Notowanie = 2, DataWydania = new DateTime(1999, 8, 10), CzasTrwania = 2 }
            );
        }
    }
}
