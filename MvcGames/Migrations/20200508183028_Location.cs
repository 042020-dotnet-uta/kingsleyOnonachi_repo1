using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcGames.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Location_LocationId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Games",
                newName: "locationId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_LocationId",
                table: "Games",
                newName: "IX_Games_locationId");

            migrationBuilder.AlterColumn<int>(
                name: "locationId",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Location_locationId",
                table: "Games",
                column: "locationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Location_locationId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "locationId",
                table: "Games",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_locationId",
                table: "Games",
                newName: "IX_Games_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Location_LocationId",
                table: "Games",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
