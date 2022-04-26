using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace golf_leagues_identity.Migrations
{
    public partial class AddStartAndEndDateToLeagues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "golf_league",
                table: "League",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "golf_league",
                table: "League",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "golf_league",
                table: "League");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "golf_league",
                table: "League");
        }
    }
}
