using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlbumData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Band = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    ChartPosition = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Song List",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    TrackNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song List", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song List_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "Band", "ChartPosition", "Duration", "Genre", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Lunar Echoes", "Top 10", new TimeSpan(0, 0, 45, 0, 0), "Rock", 2023, "Eclipse" },
                    { 2, "Star Harmony", "Top 20", new TimeSpan(0, 0, 50, 0, 0), "Pop", 2022, "Night Sky" }
                });

            migrationBuilder.InsertData(
                table: "Song List",
                columns: new[] { "Id", "AlbumId", "Duration", "Title", "TrackNumber" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 0, 4, 0, 0), "Moonlight Sonata", 1 },
                    { 2, 2, new TimeSpan(0, 0, 3, 0, 0), "Starry Night", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song List_AlbumId",
                table: "Song List",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song List");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
