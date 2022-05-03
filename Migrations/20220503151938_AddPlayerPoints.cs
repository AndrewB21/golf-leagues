using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace golf_leagues_identity.Migrations
{
    public partial class AddPlayerPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerPoints",
                schema: "golf_league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPoints_League_LeagueId",
                        column: x => x.LeagueId,
                        principalSchema: "golf_league",
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPoints_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "golf_league",
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_CourseId",
                schema: "golf_league",
                table: "Event",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPoints_LeagueId",
                schema: "golf_league",
                table: "PlayerPoints",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPoints_PlayerId",
                schema: "golf_league",
                table: "PlayerPoints",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Course_CourseId",
                schema: "golf_league",
                table: "Event",
                column: "CourseId",
                principalSchema: "golf_league",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Course_CourseId",
                schema: "golf_league",
                table: "Event");

            migrationBuilder.DropTable(
                name: "PlayerPoints",
                schema: "golf_league");

            migrationBuilder.DropIndex(
                name: "IX_Event_CourseId",
                schema: "golf_league",
                table: "Event");
        }
    }
}
