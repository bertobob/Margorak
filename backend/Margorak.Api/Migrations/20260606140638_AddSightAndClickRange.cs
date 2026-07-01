using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSightAndClickRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Maps",
                newName: "SightRange");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Maps",
                newName: "ClickRange");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SightRange",
                table: "Maps",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "ClickRange",
                table: "Maps",
                newName: "Height");
        }
    }
}
