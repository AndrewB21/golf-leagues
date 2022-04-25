using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace golf_leagues_identity.Migrations
{
    public partial class CreatePlayersAndLeagues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                schema: "golf_league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "golf_league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Handicap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaguePlayer",
                schema: "golf_league",
                columns: table => new
                {
                    LeaguesId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaguePlayer", x => new { x.LeaguesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_LeaguePlayer_League_LeaguesId",
                        column: x => x.LeaguesId,
                        principalSchema: "golf_league",
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaguePlayer_Player_PlayersId",
                        column: x => x.PlayersId,
                        principalSchema: "golf_league",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_League_Id",
                schema: "golf_league",
                table: "League",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaguePlayer_PlayersId",
                schema: "golf_league",
                table: "LeaguePlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Id",
                schema: "golf_league",
                table: "Player",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaguePlayer",
                schema: "golf_league");

            migrationBuilder.DropTable(
                name: "League",
                schema: "golf_league");

            migrationBuilder.DropTable(
                name: "Player",
                schema: "golf_league");
        }
    }
}
