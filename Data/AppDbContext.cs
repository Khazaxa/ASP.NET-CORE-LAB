using Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
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
            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                new OrganizationEntity()
                {
                    Id = 1,
                    Name = "Apple",
                    Description = "Tech company",
                },
                new OrganizationEntity()
                {
                    Id = 2,
                    Name = "Samsung",
                    Description = "Tech company",
                });

            modelBuilder.Entity<ContactEntity>().HasData(
                new { ContactId = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10), Priority = 1, OrganizationId = 1 },
                new { ContactId = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10), Priority = 2, OrganizationId = 2 }
            );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                new
                {
                    OrganizationEntityId = 1,
                    City = "Kraków",
                    Street = "ul. Stanisława Lema",
                    PostalCode = "31-111"
                },
                new
                {
                    OrganizationEntityId = 2,
                    City = "Kraków",
                    Street = "ul. Bracka",
                    PostalCode = "31-222"
                }
                );


        }
    }
}