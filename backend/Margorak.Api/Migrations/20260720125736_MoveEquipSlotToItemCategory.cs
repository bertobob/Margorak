using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Margorak.Api.Migrations
{
    /// <inheritdoc />
    public partial class MoveEquipSlotToItemCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipSlotId",
                table: "ItemCategories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.Sql(
                """
                UPDATE ItemCategories
                SET EquipSlotId = (
                    SELECT MIN(ArmorStats.EquipSlotId)
                    FROM Items
                    INNER JOIN ArmorStats ON ArmorStats.ItemId = Items.Id
                    WHERE Items.ItemCategoryId = ItemCategories.Id
                )
                WHERE EXISTS (
                    SELECT 1
                    FROM Items
                    INNER JOIN ArmorStats ON ArmorStats.ItemId = Items.Id
                    WHERE Items.ItemCategoryId = ItemCategories.Id
                );

                UPDATE ItemCategories
                SET EquipSlotId = (
                    SELECT Id FROM EquipSlots WHERE Name = 'Weapon'
                )
                WHERE Name IN ('MeleeWeapon', 'RangedWeapon', 'MagicWeapon');

                UPDATE ItemCategories
                SET EquipSlotId = (
                    SELECT Id
                    FROM EquipSlots
                    WHERE EquipSlots.Name = ItemCategories.Name
                )
                WHERE EquipSlotId IS NULL
                  AND EXISTS (
                      SELECT 1
                      FROM EquipSlots
                      WHERE EquipSlots.Name = ItemCategories.Name
                  );
                """);

            migrationBuilder.DropForeignKey(
                name: "FK_ArmorStats_EquipSlots_EquipSlotId",
                table: "ArmorStats");

            migrationBuilder.DropIndex(
                name: "IX_ArmorStats_EquipSlotId",
                table: "ArmorStats");

            migrationBuilder.DropColumn(
                name: "EquipSlotId",
                table: "ArmorStats");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_EquipSlotId",
                table: "ItemCategories",
                column: "EquipSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategories_EquipSlots_EquipSlotId",
                table: "ItemCategories",
                column: "EquipSlotId",
                principalTable: "EquipSlots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategories_EquipSlots_EquipSlotId",
                table: "ItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategories_EquipSlotId",
                table: "ItemCategories");

            migrationBuilder.AddColumn<int>(
                name: "EquipSlotId",
                table: "ArmorStats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(
                """
                UPDATE ArmorStats
                SET EquipSlotId = (
                    SELECT ItemCategories.EquipSlotId
                    FROM Items
                    INNER JOIN ItemCategories ON ItemCategories.Id = Items.ItemCategoryId
                    WHERE Items.Id = ArmorStats.ItemId
                );
                """);

            migrationBuilder.CreateIndex(
                name: "IX_ArmorStats_EquipSlotId",
                table: "ArmorStats",
                column: "EquipSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArmorStats_EquipSlots_EquipSlotId",
                table: "ArmorStats",
                column: "EquipSlotId",
                principalTable: "EquipSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropColumn(
                name: "EquipSlotId",
                table: "ItemCategories");
        }
    }
}
