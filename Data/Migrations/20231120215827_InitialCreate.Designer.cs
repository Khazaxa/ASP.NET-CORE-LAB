﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231120215827_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizationId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContactId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Birth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "adam@wsei.edu.pl",
                            Name = "Adam",
                            OrganizationId = 1,
                            Phone = "127813268163",
                            Priority = 1
                        },
                        new
                        {
                            ContactId = 2,
                            Birth = new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ewa@wsei.edu.pl",
                            Name = "Ewa",
                            OrganizationId = 2,
                            Phone = "293443823478",
                            Priority = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Tech company",
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Tech company",
                            Name = "Samsung"
                        });
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.HasOne("Data.Entities.OrganizationEntity", "Organization")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("Data.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 1,
                                    City = "Kraków",
                                    PostalCode = "31-111",
                                    Street = "ul. Stanisława Lema"
                                },
                                new
                                {
                                    OrganizationEntityId = 2,
                                    City = "Kraków",
                                    PostalCode = "31-222",
                                    Street = "ul. Bracka"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
