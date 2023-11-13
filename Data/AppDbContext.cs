using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10), Priority = 1 },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10), Priority = 2}
            );

            modelBuilder.Entity<AlbumEntity>().HasData(
                new AlbumEntity() { Id = 1, Nazwa = "Album 1", Zespol = "Zespół 1", SpisPiosenek = "Piosenka 1, Piosenka 2", Notowanie = 1, DataWydania = new DateTime(2023, 1, 1), CzasTrwania = 3600 },
                new AlbumEntity() { Id = 2, Nazwa = "Album 2", Zespol = "Zespół 2", SpisPiosenek = "Piosenka 3, Piosenka 4", Notowanie = 2, DataWydania = new DateTime(2023, 2, 1), CzasTrwania = 3000 }
    );
        }
    }
}
