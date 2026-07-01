using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.MapId);
                });

            migrationBuilder.CreateTable(
                name: "Terrains",
                columns: table => new
                {
                    TerrainId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false),
                    Accessible = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terrains", x => x.TerrainId);
                });

            migrationBuilder.CreateTable(
                name: "MapTiles",
                columns: table => new
                {
                    MapTileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MapNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    XCoord = table.Column<int>(type: "INTEGER", nullable: false),
                    YCoord = table.Column<int>(type: "INTEGER", nullable: false),
                    TerrainId = table.Column<int>(type: "INTEGER", nullable: false),
                    MapId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapTiles", x => x.MapTileId);
                    table.ForeignKey(
                        name: "FK_MapTiles_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "MapId");
                    table.ForeignKey(
                        name: "FK_MapTiles_Terrains_TerrainId",
                        column: x => x.TerrainId,
                        principalTable: "Terrains",
                        principalColumn: "TerrainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapTiles_MapId",
                table: "MapTiles",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_MapTiles_TerrainId",
                table: "MapTiles",
                column: "TerrainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapTiles");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Terrains");
        }
    }
}
