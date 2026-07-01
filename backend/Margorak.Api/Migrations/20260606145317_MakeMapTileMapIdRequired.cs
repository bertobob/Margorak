using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeMapTileMapIdRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapTiles_Maps_MapId",
                table: "MapTiles");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "MapTiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MapTiles_Maps_MapId",
                table: "MapTiles",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "MapId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapTiles_Maps_MapId",
                table: "MapTiles");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "MapTiles",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_MapTiles_Maps_MapId",
                table: "MapTiles",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "MapId");
        }
    }
}
