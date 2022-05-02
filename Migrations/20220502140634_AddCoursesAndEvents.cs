using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace golf_leagues_identity.Migrations
{
    public partial class AddCoursesAndEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                schema: "golf_league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "golf_league",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_League_LeagueId",
                        column: x => x.LeagueId,
                        principalSchema: "golf_league",
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Id",
                schema: "golf_league",
                table: "Course",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_Id",
                schema: "golf_league",
                table: "Event",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_LeagueId",
                schema: "golf_league",
                table: "Event",
                column: "LeagueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course",
                schema: "golf_league");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "golf_league");
        }
    }
}
