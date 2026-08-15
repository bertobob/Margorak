using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCombatTimelines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterTimeline",
                table: "ActiveCombats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CombatantTimeline",
                table: "ActiveCombatCombatants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterTimeline",
                table: "ActiveCombats");

            migrationBuilder.DropColumn(
                name: "CombatantTimeline",
                table: "ActiveCombatCombatants");
        }
    }
}
