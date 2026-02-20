using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shahmati.Infrastructure.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class WithPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GamesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GamesId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayersId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Reyting = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayersId);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Bukva = table.Column<char>(type: "character(1)", nullable: false),
                    Integer = table.Column<short>(type: "smallint", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GamesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayrsThisGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ThisGameId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayrsThisGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayrsThisGame_Games_ThisGameId",
                        column: x => x.ThisGameId,
                        principalTable: "Games",
                        principalColumn: "GamesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayrsThisGame_Player_PlayerEntityId",
                        column: x => x.PlayerEntityId,
                        principalTable: "Player",
                        principalColumn: "PlayersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_GameId",
                table: "Coordinates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayrsThisGame_PlayerEntityId",
                table: "PlayrsThisGame",
                column: "PlayerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayrsThisGame_ThisGameId",
                table: "PlayrsThisGame",
                column: "ThisGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "PlayrsThisGame");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
