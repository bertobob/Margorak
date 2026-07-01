using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class UseMapIdForMapTiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapNumber",
                table: "MapTiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapNumber",
                table: "MapTiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
