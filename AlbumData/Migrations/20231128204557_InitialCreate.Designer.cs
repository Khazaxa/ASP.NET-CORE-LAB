﻿// <auto-generated />
using System;
using AlbumData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlbumData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231128204557_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("AlbumData.Entities.AlbumEntity", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Band")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChartPosition")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AlbumId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            Band = "Lunar Echoes",
                            ChartPosition = "Top 10",
                            Duration = new TimeSpan(0, 0, 45, 0, 0),
                            Genre = "Rock",
                            ReleaseYear = 2023,
                            Title = "Eclipse"
                        },
                        new
                        {
                            AlbumId = 2,
                            Band = "Star Harmony",
                            ChartPosition = "Top 20",
                            Duration = new TimeSpan(0, 0, 50, 0, 0),
                            Genre = "Pop",
                            ReleaseYear = 2022,
                            Title = "Night Sky"
                        });
                });

            modelBuilder.Entity("AlbumData.Entities.SongEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TrackNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Song List");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumId = 1,
                            Duration = new TimeSpan(0, 0, 4, 0, 0),
                            Title = "Moonlight Sonata",
                            TrackNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            AlbumId = 2,
                            Duration = new TimeSpan(0, 0, 3, 0, 0),
                            Title = "Starry Night",
                            TrackNumber = 1
                        });
                });

            modelBuilder.Entity("AlbumData.Entities.SongEntity", b =>
                {
                    b.HasOne("AlbumData.Entities.AlbumEntity", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("AlbumData.Entities.AlbumEntity", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}