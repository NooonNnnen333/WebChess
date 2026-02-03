using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shahmati.Infrastructure.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uuid", nullable: false),
                    hodie_bukva = table.Column<char>(type: "character(1)", nullable: false),
                    hodie_integer = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GamesId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
